#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSO;
using NumCalc;

#endregion

namespace ConsoleTestPSO {

    public class Program {
    
        static void Main(string[] args) {

            int nParts = 50;
            int nDims = 2;
            
            int nIterations = 1000000;
            double epsilon = 0.1;

            double[] mins = new double[2];
            double[] maxs = new double[2];
            //mins[0] = 0;
            //mins[1] = 0;
            //maxs[0] = 100;
            //maxs[1] = 100;

            mins[0] = -10;
            mins[1] = -10;
            maxs[0] = 10;
            maxs[1] = 10;
            
            double[][] iniPos = new double[nParts][];
            for(int p=0;p<nParts;p++) {
                iniPos[p] = new double[nDims];
            }
            RandomGen rand = new RandomGen();
            for(int p=0;p<nParts;p++) {
                for(int d=0;d<nDims;d++) {
                    iniPos[p][d] = rand.NextDouble(mins[d], maxs[d]);
                }
            }

            Function.Mode mode;
            //mode = Function.Mode.oneMin;
            //mode = Function.Mode.rosenbrock;
            mode = Function.Mode.levi5;


            Function fitnessFunction = new Function(mode, 15, 48);
            Valid validFunction = new Valid();

            Pso pso = new Pso(nParts, nDims, mins, maxs, iniPos, fitnessFunction, validFunction, nIterations, epsilon);
            
            pso.Debug = true;
            pso.CreateSwarm();
            pso.Solve();

            //Console.WriteLine("Final positions");
            //Console.WriteLine(pso.Swarm);

            Console.WriteLine("Best");
            Console.WriteLine(pso.Swarm.GetBest());

            
            Console.In.Read();
            
        }
    }
}
