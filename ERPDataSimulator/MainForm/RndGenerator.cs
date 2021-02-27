#region Imports

using System;
using System.Collections.Generic;

#endregion

namespace ErpSim {

    public class RndGenerator {

        #region Fields

        private Random rand;
        private double storedUniformDeviate;
        private bool storedUniformDeviateIsGood = false;
    
        #endregion

        #region Constructor

        public RndGenerator() {
            Reset();
        }

        public void Reset() {
            rand = new Random(Environment.TickCount);
        }

        #endregion

        #region Distributions

        #region Uniform

        public int NextInt(int min, int max) {
            if (max == min) { return min; } else if (max < min) { throw new ArgumentException("Max must be greater than min"); }
            double nextDouble = 0.0;
            lock (rand) { nextDouble = rand.NextDouble(); }
            int randInt = Convert.ToInt32(min + nextDouble * (max - min));
            return randInt;
        }

        public double NextDouble(double min, double max) {
            if (max <= min) { throw new ArgumentException("Max must be greater than min"); }
            double nextDouble = 0.0;
            lock (rand) { nextDouble = rand.NextDouble(); }
            double randDbl = min + nextDouble * (max - min);
            return randDbl;
        }

        #endregion

        #region Normal

        public double NextNormal() {
            // basado en algoritmo de Numerical Recipes
            if (storedUniformDeviateIsGood) {
                storedUniformDeviateIsGood = false;
                return storedUniformDeviate;
            }
            else {
                double rsq = 0.0;
                double v1 = 0.0, v2 = 0.0, fac = 0.0;
                while (rsq == 0.0 || rsq >= 1.0) {
                    v1 = NextDouble(0,1) * 2.0 - 1.0;
                    v2 = NextDouble(0,1) * 2.0 - 1.0;
                    rsq = Math.Pow(v1, 2) + Math.Pow(v2, 2);
                }
                fac = Math.Sqrt(Math.Log(rsq, Math.E) / rsq * -2.0);
                storedUniformDeviate = v1 * fac;
                storedUniformDeviateIsGood = true;
                return v2 * fac;
            }
        }

        /** Method:  Devuelve variables N(m,s) (sesgos) 
        m – mean.
        s - standard deviation. */
        public double NextNormal(double m, double s) {
            double z = NextNormal();
            double x = s * z + m;
            return x;
        }


        #endregion

        #region Exponential

        /** Method:  Devuelve sesgos randómicos positivos con media = 1, con distribucion Exponencial */
        public double NextExponential() {
            double dum = 0.0;
            while (dum == 0.0) { dum = NextDouble(0,1); }
            return -Math.Log(dum);
        }

        /** Method:  Devuelve sesgos randómicos positivos con media = m, con distribucion Exponencial */
        public double NextExponential(double m) {
            return NextExponential() + m;
        }

        #endregion

        #endregion

    }
}
