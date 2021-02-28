using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO {
    
    public class Function : IFunction {

        #region Fields

        private Mode mode;
        private double coordX;
        private double coordY;

        private double coordX1;
        private double coordY1;
        private double coordX2;
        private double coordY2;

        private double xBest;
        private double yBest;
        private double fBest;

        #endregion

        #region Constructores

        public Function(Mode mode, double X, double Y) {
            this.mode = mode;
            coordX = X;
            coordY = Y;
        }

        public Function(double X1, double Y1, double X2, double Y2) {
            mode = Mode.twoMin;
            coordX1 = X1;
            coordY1 = Y1;
            coordX2 = X2;
            coordY2 = Y2;
        }

        public Function(Mode mode) {
            this.mode = mode;
            switch(mode) {
                case Mode.oneMin:
                    break;
                case Mode.twoMin:
                    break;
                case Mode.rosenbrock:
                    xBest = 1.0;
                    yBest = 1.0;
                    fBest = double.MaxValue; // 1/0
                    break;
                case Mode.levi5:
                    xBest = -1.3068;
                    yBest = -1.4248;
                    fBest = 1.0/-176.1375;
                    break;
                case Mode.sinXsinY:
                    xBest = 1.5709;
                    yBest = 1.5709;
                    fBest = 4.00;
                    break;
            
            }
        }

        #endregion

        #region Properties

        public double XBest { get { return xBest; } }
        public double YBest { get { return yBest; } }
        public double FBest { get { return fBest; } }

        #endregion
        
        #region IFunction Members

        public double GetValue(Particle particle) {
            switch(mode) { 
                case Mode.oneMin:
                    return GetValueOneMin(particle);
                case Mode.twoMin:
                    return GetValueTwoMin(particle);
                case Mode.rosenbrock:
                    return GetValueRosenbrock(particle);
                case Mode.levi5:
                    return GetValueLevi5(particle);
                case Mode.sinXsinY:
                    return GetValueSenXSenY(particle);
                    
            }
            return -1;
        }

        #endregion

        #region Private Methods

        private double GetValueOneMin(Particle particle) {
            double diffX = Math.Pow((double)(particle.Position[0] - coordX), 2.0);
            double diffY = Math.Pow((double)(particle.Position[1] - coordY), 2.0);
            double euclid = Math.Sqrt(diffX + diffY);
            if(euclid == 0) { return double.MaxValue; }
            return -euclid;
        }

        private double GetValueTwoMin(Particle particle) {
            return -1.0;
        }

        private double GetValueRosenbrock(Particle particle) {
            double x = particle.Position[0];
            double y = particle.Position[1];
            double ros = Math.Pow(1-x, 2) + 100 * Math.Pow(y - Math.Pow(x, 2), 2);
            return -ros;
        }

        //Funcion Levi 5

        //dominio: -10 <= x,y <= 10
        //minimo: x= -1.3068, y = -1.4248, f(x,y) = -176.1375...
        private double GetValueLevi5(Particle particle) {
            double x = particle.Position[0];
            double y = particle.Position[1];
            //x = -1.3068;
            //y = -1.4248;
            double fact1 = 0, fact2 = 0;
            for (int i = 1; i <= 5; i++) {
                fact1 += i * Math.Cos((i - 1) * x + i);
                fact2 += i * Math.Cos((i + 1) * y + i);
            }
            double levi = fact1 * fact2 + Math.Pow(x + 1.42513, 2) + Math.Pow(y + 0.80032 ,2);
            return -levi;
        }

        //dominio: -0.55 <= x,y <= 3.85
        //minimo: x, y = 1.65 f(x,y) = 0,993739885
        //discretización: 23 (con valores mayores el maximo sera 1.0 en el punto (1.5709,1.5709)
        private double GetValueSenXSenY(Particle particle) {
            //double k = 1.0; 
            double k = 0.0001; 
            double x = particle.Position[0];
            double y = particle.Position[1];
            double val = (Math.Sin(x) + k) * (Math.Sin(y) + k);
            return val;
        }
        
        #endregion

        #region Enum Mode

        public enum Mode { oneMin, twoMin, rosenbrock, levi5, sinXsinY };

        #endregion
    }
}
