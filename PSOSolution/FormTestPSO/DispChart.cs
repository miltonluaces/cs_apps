using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;

namespace FormTestPSO {

    public class DispChart : UserControl {

        #region Fields

        private Bitmap drawArea;
        private Container components = null;

        private Random rnd;
        private Pen pen;
        private SolidBrush brush;

        #endregion

        #region Constructor

        public DispChart() {
            InitializeComponent();
            rnd = new Random((int)DateTime.Now.Ticks);
            pen = new Pen(Color.Red);
            brush = new SolidBrush(Color.Red);
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // DispChart
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "DispChart";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.DispChart_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DispChart_Paint);
            this.Click += new System.EventHandler(this.DispChart_Click);
            this.ResumeLayout(false);

        }

        // Clean up any resources being used
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) { components.Dispose(); }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Event Handlers

        // form load event
        private void DispChart_Load(object sender, System.EventArgs e) {
            drawArea = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format24bppRgb);
            InitializeDrawArea();
        }

        private void InitializeDrawArea() {
            Graphics graph;
            graph = Graphics.FromImage(drawArea);
            graph.Clear(Color.White);
        }

        // free up resources on program exit
        private void DispChart_Closed(object sender, System.EventArgs e) {
            drawArea.Dispose();
        }

        private void DispChart_Paint(object sender, PaintEventArgs e) {
            Graphics graph = e.Graphics;
            graph.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
            graph.Dispose();
        }

        private void DispChart_Click(object sender, EventArgs e) {
            //mostrar informacion de particula
        }
        
        #endregion

        #region Public Methods

        #region Function Methods

        public void DrawFunction(double[,] values, double[,] marks, int xBest, int yBest, bool normalize) {
            if(normalize) { values = NormalizeValues(values); }
            Graphics graph = Graphics.FromImage(drawArea);
            int xCount = values.GetLength(0);
            int yCount = values.GetLength(1);
            int xCntrl = this.Height;
            int yCntrl = this.Width;
            float xFact = (float)xCntrl / (float)xCount;
            float yFact = (float)yCntrl / (float)yCount;
            for(int i=0;i<xCount;i++) {
                for(int j=0;j<yCount;j++) {
                    if(values[i, j] == -1) {
                        //brush.Color = Color.FromArgb(255,255,255);
                        brush.Color = Color.FromArgb(70, 150, 255);
                    } else {
                        //brush.Color = Color.FromArgb((int)values[i, j], (int)values[i, j], (int)values[i, j]);
                        brush.Color = Color.FromArgb(70, 150, (int)values[i, j]);
                    }
                    graph.FillRectangle(brush, i * xFact, j * yFact, xFact, yFact);
                    if(marks[i, j] != 0) {
                        brush.Color = Color.FromArgb(0, 0, 0);
                        graph.FillEllipse(brush, i * xFact, j * yFact, xFact, yFact);
                    }
                    if(i == xBest && j == yBest) {
                        brush.Color = Color.FromArgb(200, 90, 40);
                        graph.FillEllipse(brush, i * xFact, j * yFact, xFact, yFact);
                    }

                }
            }
            graph.Dispose();
            this.Invalidate();
        }

        #endregion

        #region Test Draw Methods

        public void DrawLines() {
            Graphics graph;
            int k;

            graph = Graphics.FromImage(drawArea);

            for(k = 1;k < 40;k++) {
                pen.Color = Color.FromArgb((rnd.Next(0, 255)), (rnd.Next(0, 255)), (rnd.Next(0, 255)));
                graph.DrawLine(pen, (int)rnd.Next(0, this.Width), (int)rnd.Next(0, this.Height), (int)rnd.Next(0, this.Width), (int)rnd.Next(0, this.Height));
            }
            graph.Dispose();
            this.Invalidate();
        }

        public void DrawCircles() {
            Graphics graph;
            int k;
            int r;     // radius of circle
            int x, y;  // center coordinates of circle

            graph = Graphics.FromImage(drawArea);

            for(k = 1;k < 40;k++) {
                // radius for circle, max 1/2 the width of the form
                r = rnd.Next(0, (this.Width / 2));
                x = rnd.Next(0, this.Width);
                y = rnd.Next(0, this.Height);

                pen.Color = Color.FromArgb((rnd.Next(0, 255)), (rnd.Next(0, 255)), (rnd.Next(0, 255)));
                // convert centerX, centerY, radius to bounding rectangle
                graph.DrawEllipse(pen, x-r, y-r, r, r);
            }
            graph.Dispose();
            this.Invalidate();
        }

        public void Fill() {
            Graphics graph = Graphics.FromImage(drawArea);
            int k;
            int r;     // radius of circle
            int x, y;  // center coordinates of circle


            // Create solid brush.
            SolidBrush Brush = new SolidBrush(Color.Red);
            for(k = 1;k < 40;k++) {
                // radius for circle, max 1/2 the width of the form
                r = rnd.Next(0, (this.Width / 2));
                x = rnd.Next(0, this.Width);
                y = rnd.Next(0, this.Height);

                Brush.Color = Color.FromArgb(
                  (rnd.Next(0, 255)),
                  (rnd.Next(0, 255)),
                  (rnd.Next(0, 255)));
                // convert centerX, centerY, radius to bounding rectangle
                graph.FillEllipse(Brush, x-r, y-r, r, r);
            }
            graph.Dispose();
            this.Invalidate();
        }

        #endregion

        #region General Methods

        // save drawing in bitmap DrawArea as a jpeg file
        public void Save() {
            ImageFormat format = ImageFormat.Jpeg;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG Files(*.jpg)|*.jpg";
            drawArea.Save(sfd.FileName, format);
        }

        // clear the DrawArea
        public void Clear() {
            Graphics graph = Graphics.FromImage(drawArea);
            graph.Clear(Color.White);
            graph.Dispose();
            this.Invalidate();
        }

        #endregion


        #endregion

        #region Private Methods

        private double[,] NormalizeValues(double[,] values) {
            double[,] norm = new double[values.GetLength(0), values.GetLength(1)];
            double min = double.MaxValue;
            double max = double.MinValue;
            for(int i=0;i<values.GetLength(0);i++) {
                for(int j=0;j<values.GetLength(1);j++) {
                    if(values[i, j] < min) { min = values[i, j]; }
                    if(values[i, j] > max) { max = values[i, j]; }
                }
            }
            double range = max - min;
            for(int i=0;i<values.GetLength(0);i++) {
                for(int j=0;j<values.GetLength(1);j++) {
                    norm[i, j] = ((values[i, j] - min) / range) * 255;
                }
            }

            return norm;
        }

        #endregion

    }
}

