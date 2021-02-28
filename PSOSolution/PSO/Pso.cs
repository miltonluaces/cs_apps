#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumCalc;

#endregion

namespace PSO {
    
    public class Pso : IOptimizer {

        #region Fields

        private int nParts;
        private int nDims;

        private double inertia;
        private double maxVelocity;
        
        private int iterations;

        private double localRate;
        private double globalRate;

        private IFunction fitnessFunction;
        private IValid validFunction;

        private double[] mins;
        private double[] maxs;
        private double[][] initialPositions;
        private bool debug;

        private RandomGen rand;
        private bool useRandom;
        private Swarm swarm;

        
        #endregion

        #region Constructor

        public Pso(int nParts, int nDims, double[] mins, double[] maxs, double[][] initialPositions, IFunction fitnessFunction, IValid validFunction, int iterations, double epsilon) {
            this.nParts = nParts;
            this.nDims = nDims;
            this.mins = mins;
            this.maxs = maxs;
            this.initialPositions = initialPositions;
            this.fitnessFunction = fitnessFunction;
            this.validFunction = validFunction;
            this.iterations = iterations;
            this.debug = false;
            
            this.inertia = 1.0;
            this.maxVelocity = 3.0;
            this.localRate = 0.2;
            this.globalRate = 0.3;
            this.rand = new RandomGen();
            this.useRandom = true;
        }
        
        #endregion

        #region Properties

        public Swarm Swarm {
            get { return swarm; }
        }

        public int Iterations {
            get { return iterations; }
            set { iterations = value; }
        }

        public int NParts {
            get { return nParts; }
            set { nParts = value; }
        }

        public double LocalRate {
            get { return localRate; }
            set { localRate = value; }
        }
        
        public double GlobalLearningRate {
            get { return globalRate; }
            set { globalRate = value; }
        }

        public double Inertia {
            get { return inertia; }
            set { inertia = value; }
        }

        public double MaxVelocity {
            get { return maxVelocity; }
            set { maxVelocity = value; }
        }

        public IFunction FitnessFunction {
            get { return fitnessFunction; }
        }

        public bool Debug {
            get { return debug; }
            set { debug = value; }
        }

        #endregion
        
        #region Public Methods

        public void CreateSwarm() {
            swarm = new Swarm(nDims);
            Particle part;
            //initialPositions[0][0] =1.0;
            //initialPositions[0][1] =1.0;
            for(int i=0;i<nParts;i++) {
                part = new Particle(i.ToString(), initialPositions[i]);
                swarm.Add(part);
            }
        }
        
        public Particle Solve() {

            Init();
            double inertia = 1.0;  
            for(int i=0;i<iterations;i++) {
                #region debug

                if(debug && i % 100 == 0) {
                    Console.WriteLine("Iteration " + i);
                    Console.WriteLine(swarm);
                    Console.WriteLine(" ");
                    Console.In.ReadLine();
                }

                #endregion
                //if(inertia > 0.3) { inertia *= 0.99; }
                Update();
            }
            if(!validFunction.IsValid(swarm.Best)) { return null; }
            return swarm.Best;
        }

        public void Init() {
            foreach(Particle part in swarm.Particles) {
                part.Val = fitnessFunction.GetValue(part);
                if(part.Val > part.BestVal) {
                    part.BestVal = part.Val;
                    for(int i=0;i<part.Position.Length;i++) {
                        part.BestPosition[i] = part.Position[i];
                    }
                }
                if(part.Val > swarm.Best.Val) {
                    swarm.SaveBest(part);
                }
            }
        }
        
        public void Update() {
            foreach(Particle part in swarm.Particles) {
                Update(part);
            }
        }
       
        private void Update(Particle part) {
            UpdateVelocity(part, swarm.GetBest().Position);
            UpdatePosition(part);
            if(validFunction.IsValid(part)) {
                part.Val = fitnessFunction.GetValue(part);
                if(part.Val > part.BestVal) {
                    part.BestVal = part.Val;
                    for(int i=0;i<part.Position.Length;i++) {
                        part.BestPosition[i] = part.Position[i];
                    }
                }
                if(part.Val > swarm.Best.Val) { 
                    swarm.SaveBest(part); 
                }
            }
        }

        private void UpdateVelocity(Particle part, double[] bestPosition) {
            double[] newVelocity = new double[part.Dim];
            
            double randLocalFactor, randGlobalFactor;
            for(int d=0;d<part.Dim;d++) {
                randLocalFactor = 1.0;
                randGlobalFactor = 1.0;
                if(useRandom) {
                    randLocalFactor = rand.NextDouble(0.7, 1.3);
                    randGlobalFactor = rand.NextDouble(0.8, 1.2);
                }
                newVelocity[d] = inertia * part.Velocity[d] + 
                                 globalRate * (swarm.GetBest().Position[d] - part.Position[d]) * randLocalFactor + 
                                 localRate  * (bestPosition[d]  - part.Position[d]) * randGlobalFactor;

                if(Math.Abs(newVelocity[d]) > maxVelocity) {
                    newVelocity[d] = Math.Sign(newVelocity[d]) * maxVelocity;
                }
            }
            part.Velocity = newVelocity;
        }

        public void UpdatePosition(Particle part) {
            for(int d=0;d<part.Velocity.Length;d++) {
                part.Position[d] = part.Position[d] + part.Velocity[d];
                if(part.Position[d] < mins[d]) { part.Position[d] = mins[d]; } 
                else if(part.Position[d] > maxs[d]) { part.Position[d] = maxs[d]; }
            }
        }
        
        #endregion



        #region IOptimizer Members


        public Swarm GetSwarm() {
            return this.swarm;
        }

        #endregion
    }
}
