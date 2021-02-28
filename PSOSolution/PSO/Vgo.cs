using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO {

    //Variable gradient optimization
    public class Vgo : IOptimizer {
        
        #region Fields

        private int nParts;
        private int nDims;

        private double maxVelocity;
        private int iterations;

        private IFunction fitnessFunction;
        private IValid validFunction;

        private double[] mins;
        private double[] maxs;
        private double[][] initialPositions;
        private bool debug;

        private double angleVar;
        private List<int[]> combinations;

        private Swarm swarm;
        
        #endregion

        #region Constructor

        public Vgo(int nParts, int nDims, double[] mins, double[] maxs, double[][] initialPositions, IFunction fitnessFunction, IValid validFunction, int iterations, double epsilon) {
            this.nParts = nParts;
            this.nDims = nDims;
            this.mins = mins;
            this.maxs = maxs;
            this.initialPositions = initialPositions;
            this.fitnessFunction = fitnessFunction;
            this.validFunction = validFunction;
            this.iterations = iterations;
            this.debug = false;
            this.maxVelocity = 3.0;

            //angulo de variacion en la busqueda
            this.angleVar = 0.1;
            this.combinations = GetCombinations(nDims);

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
            for(int i=0;i<nParts;i++) {
                part = new Particle(i.ToString(), initialPositions[i]);
                swarm.Add(part);
            }
        }
        
        public Particle Solve() {

            Init();
            for(int i=0;i<iterations;i++) {
                #region debug

                if(debug && i % 100 == 0) {
                    Console.WriteLine("Iteration " + i);
                    Console.WriteLine(swarm);
                    Console.WriteLine(" ");
                    Console.In.ReadLine();
                }

                #endregion
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
            double[] bestPosition = new double[part.Dim];
            double[] bestVelocity = new double[part.Dim];
            double bestVal = double.MinValue;
            double[] algPosition = new double[part.Dim];
            for(int i=0;i<part.Dim;i++) { algPosition[i] = part.Position[i]; }
            double[] algVelocity = new double[part.Dim];
            for(int i=0;i<part.Dim;i++) { algVelocity[i] = part.Velocity[i]; }
            foreach(int[] comb in combinations) {
                for(int i=0;i<part.Dim;i++) { part.Position[i] = algPosition[i]; }
                for(int i=0;i<part.Dim;i++) { part.Velocity[i] = algVelocity[i]; }
                UpdateVelocity(part, comb, swarm.GetBest().Position);
                UpdatePosition(part);
                if(validFunction.IsValid(part)) {
                    part.Val = fitnessFunction.GetValue(part);
                    if(part.Val > bestVal) {
                        bestVal = part.Val;
                        for(int i=0;i<part.Position.Length;i++) { 
                            bestPosition[i] = part.Position[i];
                            bestVelocity[i] = part.Velocity[i];
                        }
                    }
                    if(part.Val > part.BestVal) {
                        part.BestVal = part.Val;
                        for(int i=0;i<part.Position.Length;i++) { part.BestPosition[i] = part.Position[i]; }
                    }
                    if(part.Val > swarm.Best.Val) {  swarm.SaveBest(part); }
                }
            }
            for(int i=0;i<part.Position.Length;i++) { 
                part.Position[i] = bestPosition[i];
                part.Velocity[i] = bestVelocity[i];
            }
            part.Val = bestVal;
        }

        private void UpdateVelocity(Particle part, int[] comb, double[] bestPosition) {
            double[] newVelocity = new double[part.Dim];
            for(int d=0;d<part.Dim;d++) {
                newVelocity[d] = part.Velocity[d] + angleVar * comb[d];
                if(Math.Abs(newVelocity[d]) > maxVelocity) {
                    newVelocity[d] = Math.Sign(newVelocity[d]) * maxVelocity;
                }
            }
            part.Velocity = newVelocity;
        }

        public void UpdatePosition(Particle part) {
            for(int d=0;d<part.Velocity.Length;d++) {
                part.Position[d] = part.Position[d] + part.Velocity[d];
                if(part.Position[d] < mins[d]) { part.Position[d] = mins[d]; } else if(part.Position[d] > maxs[d]) { part.Position[d] = maxs[d]; }
            }
        }
      
        #endregion

        #region Combinatorial

        private List<int[]> GetCombinations(int dim) {
            List<int[]> combs = new List<int[]>();

            int[] comb1  = { -1, -1, -1 }; combs.Add(comb1);
            int[] comb2  = { -1, -1,  0 }; combs.Add(comb2);
            int[] comb3  = { -1, -1,  1 }; combs.Add(comb3);
            int[] comb4  = { -1,  0, -1 }; combs.Add(comb4);
            int[] comb5  = { -1,  0,  0 }; combs.Add(comb5);
            int[] comb6  = { -1,  0,  1 }; combs.Add(comb6);
            int[] comb7  = { -1,  1, -1 }; combs.Add(comb7);
            int[] comb8  = { -1,  1,  0 }; combs.Add(comb8);
            int[] comb9  = { -1,  1,  1 }; combs.Add(comb9);
            int[] comb10 = {  0, -1, -1 }; combs.Add(comb10);
            int[] comb11 = {  0, -1,  0 }; combs.Add(comb11);
            int[] comb12 = {  0, -1,  1 }; combs.Add(comb12);
            int[] comb13 = {  0,  0, -1 }; combs.Add(comb13);
            int[] comb14 = {  0,  0,  0 }; combs.Add(comb14);
            int[] comb15 = {  0,  0,  1 }; combs.Add(comb15);
            int[] comb16 = {  0,  1, -1 }; combs.Add(comb16);
            int[] comb17 = {  0,  1,  0 }; combs.Add(comb17);
            int[] comb18 = {  0,  1,  1 }; combs.Add(comb18);
            int[] comb19 = {  1, -1, -1 }; combs.Add(comb19);
            int[] comb20 = {  1, -1,  0 }; combs.Add(comb20);
            int[] comb21 = {  1, -1,  1 }; combs.Add(comb21);
            int[] comb22 = {  1,  0, -1 }; combs.Add(comb22);
            int[] comb23 = {  1,  0,  0 }; combs.Add(comb23);
            int[] comb24 = {  1,  0,  1 }; combs.Add(comb24);
            int[] comb25 = {  1,  1, -1 }; combs.Add(comb25);
            int[] comb26 = {  1,  1,  0 }; combs.Add(comb26);
            int[] comb27 = {  1,  1,  1 }; combs.Add(comb27);
            
            //int[] comb = new int[dim];
            //int[] copy;
            //for(int i=0;i<dim;i++) { comb[i] = -1; }
            //copy = new int[dim];
            //Array.Copy(comb, copy, dim);
            //combs.Add(copy);
            //int pos = 0;
            //while(pos < dim) {
            //    while(comb[pos] < 1) {
            //        comb[pos]++;
            //        copy = new int[dim];
            //        Array.Copy(comb, copy, dim);
            //        combs.Add(copy);
            //    }
            //    pos++;
            //}
            return combs;
        }

        #endregion


        #region IOptimizer Members


        public Swarm GetSwarm() {
            return swarm;
        }

        #endregion
    }
}
