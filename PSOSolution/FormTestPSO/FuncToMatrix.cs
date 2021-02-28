using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSO;

namespace FormTestPSO {
    public class FuncToMatrix {

        private double[,] matrix;
        private double[,] marks;
        private int xBest;
        private int yBest;

        public FuncToMatrix() {
        }

        public double[,] Matrix { get { return matrix; } }
        public double[,] Marks { get { return marks; } }
        public int XBest { get { return xBest; } }
        public int YBest { get { return yBest; } }

        public void CalcMatrix(IFunction function, double xMin, double xMax, double yMin, double yMax, int xCount, int yCount, Swarm swarm) {
            matrix = new double[xCount, yCount];
            double xStep = (xMax - xMin) / (double)xCount;
            double yStep = (yMax - yMin) / (double)yCount;
            double xVal = xMin;
            double yVal = yMin;
            Particle part;

            for(int x=0;x<xCount;x++) {
                for(int y=0;y<yCount;y++) {
                    part = new Particle("", 2);
                    part.Position[0] = xVal;
                    part.Position[1] = yVal;
                    matrix[x, y] = function.GetValue(part);
                    yVal += yStep;
                }
                xVal += xStep;
            }
            int indX, indY;
            marks = new double[xCount, yCount];
            foreach(Particle partic in swarm.Particles) {
                indX = (int)((partic.Position[0] - xMin) / xStep);
                if(indX < 0) { indX = 0; }
                if(indX >= xCount) { indX = xCount - 1; }
                indY = (int)((partic.Position[1] - yMin) / yStep);
                if(indY < 0) { indY = 0; }
                if(indY >= yCount) { indY = yCount - 1; }
                marks[indX, indY] = 1.0;
            }

            xBest = (int)((swarm.Best.Position[0] - xMin) / xStep);
            yBest = (int)((swarm.Best.Position[1] - yMin) / yStep);

        }
    }
}
