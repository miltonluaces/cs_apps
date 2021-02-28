using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PSO;
using NumCalc;
using System.Threading;


namespace FormTestPSO {
    public partial class FormDist : Form {

        private IOptimizer opt;
        private Function func;
        private double xMin = 100;
        private double xMax = 100;
        private double yMin = 100;
        private double yMax = 100; 

        public FormDist() {
            InitializeComponent();
        }

        //This is the main entry point for the application.
        //public static void Main() {
        //Application.Run(new FormDist());
        //}

        private void buttRandom_Click(object sender, EventArgs e) {
            
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int dim = Convert.ToInt32(txtDim.Text);
            int xDim = dim;
            int yDim = dim;
            double[,] matrix = new double[xDim, yDim];
            double val;
            for(int i=0;i<xDim;i++) {
                for(int j=0;j<yDim;j++) {
                    val = rnd.Next(-1000, 1000);
                    //if(val < 0) { val = 0; }
                    //if(val > 255) { val = 255; }
                    matrix[i, j] = val;
                }
            }
            double[,] marks = new double[dim, dim];
            int xMark, yMark;
            for(int i=0;i<xDim;i++) {
                xMark = rnd.Next(0, dim-1);
                yMark = rnd.Next(0, dim-1);
                marks[xMark, yMark] = 1.00;
            }
            int xBest = 0;
            int yBest = 0;
            chart.DrawFunction(matrix, marks, xBest, yBest, true);
        }

        private void buttRosenbrock_Click(object sender, EventArgs e) {
            
            int dim = Convert.ToInt32(txtDim.Text);
            func = new Function(Function.Mode.rosenbrock);
            txtExpXBest.Text = func.XBest.ToString();
            txtExpYBest.Text = func.YBest.ToString();
            txtExpFBest.Text = func.FBest.ToString("0.#####");
            FuncToMatrix fm = new FuncToMatrix();
            xMin = -100;
            xMax = 100;
            yMin = -100;
            yMax = 100;
            InitOpt();
            fm.CalcMatrix(func, xMin, xMax, yMin, yMax, dim, dim, opt.GetSwarm());
            double[,] matrix = fm.Matrix;
            double[,] marks = fm.Marks;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            marks = new double[dim, dim];
            int xMark, yMark;
            for(int i=0;i<dim;i++) {
                xMark = rnd.Next(0, dim-1);
                yMark = rnd.Next(0, dim-1);
                marks[xMark, yMark] = 1.00;
            }
            int xBest = 0;
            int yBest = 0;
            chart.DrawFunction(matrix, marks, xBest, yBest, true);
        }

        private void buttLevi5_Click(object sender, EventArgs e) {
            DrawLevi5Function();
        }

        private void buttSinXSinY_Click(object sender, EventArgs e) {
            DrawSinXSinYFunction();
        }

        private void DrawSinXSinYFunction() {
            int dim = Convert.ToInt32(txtDim.Text);
            func = new Function(Function.Mode.sinXsinY);
            txtExpXBest.Text = func.XBest.ToString();
            txtExpYBest.Text = func.YBest.ToString();
            txtExpFBest.Text = func.FBest.ToString("0.#####");
            FuncToMatrix fm = new FuncToMatrix();
            xMin = -0.55;
            xMax = 3.85;
            yMin = -0.55;
            yMax = 3.85;
            InitOpt();
            fm.CalcMatrix(func, xMin, xMax, yMin, yMax, dim, dim, opt.GetSwarm());
            double[,] matrix = fm.Matrix;
            double[,] marks = fm.Marks;
            int xBest = fm.XBest;
            int yBest = fm.YBest;
            chart.DrawFunction(matrix, marks, xBest, yBest, true);
        }

        private void DrawLevi5Function() {
            int dim = Convert.ToInt32(txtDim.Text);
            func = new Function(Function.Mode.levi5);
            txtExpXBest.Text = func.XBest.ToString();
            txtExpYBest.Text = func.YBest.ToString();
            txtExpFBest.Text = func.FBest.ToString("0.#####");
            FuncToMatrix fm = new FuncToMatrix();
            xMin = -10;
            xMax = 10;
            yMin = -10;
            yMax = 10;
            InitOpt();
            fm.CalcMatrix(func, xMin, xMax, yMin, yMax, dim, dim, opt.GetSwarm());
            double[,] matrix = fm.Matrix;
            double[,] marks = fm.Marks;
            int xBest = fm.XBest;
            int yBest = fm.YBest;

            //Random rnd = new Random((int)DateTime.Now.Ticks);
            //marks = new double[dim, dim];
            //int xMark, yMark;
            //for(int i=0;i<dim;i++) {
            //    xMark = rnd.Next(0, dim-1);
            //    yMark = rnd.Next(0, dim-1);
            //    marks[xMark, yMark] = 1.00;
            //}
            chart.DrawFunction(matrix, marks, xBest, yBest, true);
        }

        private void InitOpt() {
            int nIterations = 1000000;
            double epsilon = 0.1;

            int nParts = 50;
            int nDims = 2;

            double[] mins = new double[2];
            double[] maxs = new double[2];
            
            mins[0] = xMin;
            mins[1] = yMin;
            maxs[0] = xMax;
            maxs[1] = yMax;

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

            Function fitnessFunction = func;
            Valid validFunction = new Valid();

            if(radPSO.Checked) {
                opt = new Pso(nParts, nDims, mins, maxs, iniPos, fitnessFunction, validFunction, nIterations, epsilon);
            } 
            else if(radVGO.Checked) {
                opt = new Vgo(nParts, nDims, mins, maxs, iniPos, fitnessFunction, validFunction, nIterations, epsilon);
            }
            opt.CreateSwarm();
            opt.Init();

        }

        private void buttClear_Click(object sender, EventArgs e) {
            chart.Clear();
        }

        private void buttIterate_Click(object sender, EventArgs e) {
            int dim = Convert.ToInt32(txtDim.Text);
            int its = Convert.ToInt32(txtIter.Text);
            for(int i = 0;i < its;i++) { opt.Update(); }
            FuncToMatrix fm = new FuncToMatrix();
            fm.CalcMatrix(func, xMin, xMax, yMin, yMax, dim, dim, opt.GetSwarm());
            double[,] matrix = fm.Matrix;
            double[,] marks = fm.Marks;
            int xBest = fm.XBest;
            int yBest = fm.YBest;
            chart.DrawFunction(matrix, marks, xBest, yBest, true);
            txtXBest.Text = opt.GetSwarm().GetBest().Position[0].ToString();
            txtYBest.Text = opt.GetSwarm().GetBest().Position[1].ToString();
            txtXNorm.Text = xBest.ToString();
            txtYNorm.Text = yBest.ToString();
            double bestVal = opt.GetSwarm().GetBest().Val;
            double invBVal = 0;
            if(bestVal != 0) { invBVal = 1.0/bestVal; }
            txtBestVal.Text = bestVal.ToString("0.#####");
            txtInvBVal.Text = invBVal.ToString("0.#####");
            txtError.Text = Math.Abs(invBVal - func.FBest).ToString();
        }
    }
}
