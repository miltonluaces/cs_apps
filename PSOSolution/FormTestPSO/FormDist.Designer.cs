namespace FormTestPSO {
    partial class FormDist {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttRandom = new System.Windows.Forms.Button();
            this.buttRosenbrock = new System.Windows.Forms.Button();
            this.buttClear = new System.Windows.Forms.Button();
            this.buttLevi = new System.Windows.Forms.Button();
            this.txtDim = new System.Windows.Forms.TextBox();
            this.buttIterate = new System.Windows.Forms.Button();
            this.txtIter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttSinXSinY = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radVGO = new System.Windows.Forms.RadioButton();
            this.radPSO = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtYNorm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtXNorm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvBVal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBestVal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYBest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXBest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chart = new FormTestPSO.DispChart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExpInvBVal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtExpFBest = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtExpYBest = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtExpXBest = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttRandom
            // 
            this.buttRandom.Location = new System.Drawing.Point(19, 27);
            this.buttRandom.Name = "buttRandom";
            this.buttRandom.Size = new System.Drawing.Size(78, 25);
            this.buttRandom.TabIndex = 1;
            this.buttRandom.Text = "Random";
            this.buttRandom.UseVisualStyleBackColor = true;
            this.buttRandom.Click += new System.EventHandler(this.buttRandom_Click);
            // 
            // buttRosenbrock
            // 
            this.buttRosenbrock.Location = new System.Drawing.Point(19, 89);
            this.buttRosenbrock.Name = "buttRosenbrock";
            this.buttRosenbrock.Size = new System.Drawing.Size(78, 25);
            this.buttRosenbrock.TabIndex = 5;
            this.buttRosenbrock.Text = "Rosenbrock";
            this.buttRosenbrock.UseVisualStyleBackColor = true;
            this.buttRosenbrock.Click += new System.EventHandler(this.buttRosenbrock_Click);
            // 
            // buttClear
            // 
            this.buttClear.Location = new System.Drawing.Point(95, 862);
            this.buttClear.Name = "buttClear";
            this.buttClear.Size = new System.Drawing.Size(64, 25);
            this.buttClear.TabIndex = 6;
            this.buttClear.Text = "Clear";
            this.buttClear.UseVisualStyleBackColor = true;
            this.buttClear.Click += new System.EventHandler(this.buttClear_Click);
            // 
            // buttLevi
            // 
            this.buttLevi.Location = new System.Drawing.Point(19, 58);
            this.buttLevi.Name = "buttLevi";
            this.buttLevi.Size = new System.Drawing.Size(78, 25);
            this.buttLevi.TabIndex = 7;
            this.buttLevi.Text = "Levi5";
            this.buttLevi.UseVisualStyleBackColor = true;
            this.buttLevi.Click += new System.EventHandler(this.buttLevi5_Click);
            // 
            // txtDim
            // 
            this.txtDim.Location = new System.Drawing.Point(132, 767);
            this.txtDim.Name = "txtDim";
            this.txtDim.Size = new System.Drawing.Size(46, 20);
            this.txtDim.TabIndex = 8;
            this.txtDim.Text = "100";
            // 
            // buttIterate
            // 
            this.buttIterate.Location = new System.Drawing.Point(64, 811);
            this.buttIterate.Name = "buttIterate";
            this.buttIterate.Size = new System.Drawing.Size(53, 25);
            this.buttIterate.TabIndex = 9;
            this.buttIterate.Text = "Iterate";
            this.buttIterate.UseVisualStyleBackColor = true;
            this.buttIterate.Click += new System.EventHandler(this.buttIterate_Click);
            // 
            // txtIter
            // 
            this.txtIter.Location = new System.Drawing.Point(132, 811);
            this.txtIter.Name = "txtIter";
            this.txtIter.Size = new System.Drawing.Size(46, 20);
            this.txtIter.TabIndex = 10;
            this.txtIter.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 771);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Discretization";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttSinXSinY);
            this.groupBox1.Controls.Add(this.buttRandom);
            this.groupBox1.Controls.Add(this.buttLevi);
            this.groupBox1.Controls.Add(this.buttRosenbrock);
            this.groupBox1.Location = new System.Drawing.Point(31, 553);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 188);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fitness Function";
            // 
            // buttSinXSinY
            // 
            this.buttSinXSinY.Location = new System.Drawing.Point(19, 120);
            this.buttSinXSinY.Name = "buttSinXSinY";
            this.buttSinXSinY.Size = new System.Drawing.Size(78, 25);
            this.buttSinXSinY.TabIndex = 8;
            this.buttSinXSinY.Text = "Sin(x) * Sin(y)";
            this.buttSinXSinY.UseVisualStyleBackColor = true;
            this.buttSinXSinY.Click += new System.EventHandler(this.buttSinXSinY_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radVGO);
            this.groupBox2.Controls.Add(this.radPSO);
            this.groupBox2.Location = new System.Drawing.Point(152, 553);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(85, 154);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optimization Method";
            // 
            // radVGO
            // 
            this.radVGO.AutoSize = true;
            this.radVGO.Location = new System.Drawing.Point(15, 63);
            this.radVGO.Name = "radVGO";
            this.radVGO.Size = new System.Drawing.Size(48, 17);
            this.radVGO.TabIndex = 1;
            this.radVGO.Text = "VGO";
            this.radVGO.UseVisualStyleBackColor = true;
            // 
            // radPSO
            // 
            this.radPSO.AutoSize = true;
            this.radPSO.Checked = true;
            this.radPSO.Location = new System.Drawing.Point(15, 40);
            this.radPSO.Name = "radPSO";
            this.radPSO.Size = new System.Drawing.Size(47, 17);
            this.radPSO.TabIndex = 0;
            this.radPSO.TabStop = true;
            this.radPSO.Text = "PSO";
            this.radPSO.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtYNorm);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtXNorm);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtInvBVal);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtBestVal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtYBest);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtXBest);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(243, 553);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 158);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results:";
            // 
            // txtYNorm
            // 
            this.txtYNorm.Location = new System.Drawing.Point(163, 55);
            this.txtYNorm.Name = "txtYNorm";
            this.txtYNorm.Size = new System.Drawing.Size(47, 20);
            this.txtYNorm.TabIndex = 21;
            this.txtYNorm.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "yNorm";
            // 
            // txtXNorm
            // 
            this.txtXNorm.Location = new System.Drawing.Point(163, 28);
            this.txtXNorm.Name = "txtXNorm";
            this.txtXNorm.Size = new System.Drawing.Size(47, 20);
            this.txtXNorm.TabIndex = 19;
            this.txtXNorm.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "xNorm";
            // 
            // txtInvBVal
            // 
            this.txtInvBVal.Location = new System.Drawing.Point(61, 113);
            this.txtInvBVal.Name = "txtInvBVal";
            this.txtInvBVal.Size = new System.Drawing.Size(91, 20);
            this.txtInvBVal.TabIndex = 17;
            this.txtInvBVal.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "invBVal";
            // 
            // txtBestVal
            // 
            this.txtBestVal.Location = new System.Drawing.Point(61, 86);
            this.txtBestVal.Name = "txtBestVal";
            this.txtBestVal.Size = new System.Drawing.Size(91, 20);
            this.txtBestVal.TabIndex = 15;
            this.txtBestVal.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "bestVal";
            // 
            // txtYBest
            // 
            this.txtYBest.Location = new System.Drawing.Point(60, 55);
            this.txtYBest.Name = "txtYBest";
            this.txtYBest.Size = new System.Drawing.Size(47, 20);
            this.txtYBest.TabIndex = 13;
            this.txtYBest.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "yBest";
            // 
            // txtXBest
            // 
            this.txtXBest.Location = new System.Drawing.Point(60, 27);
            this.txtXBest.Name = "txtXBest";
            this.txtXBest.Size = new System.Drawing.Size(47, 20);
            this.txtXBest.TabIndex = 11;
            this.txtXBest.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "xBest";
            // 
            // chart
            // 
            this.chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chart.Location = new System.Drawing.Point(31, 30);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(501, 500);
            this.chart.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtError);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtExpInvBVal);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtExpFBest);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtExpYBest);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtExpXBest);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(243, 717);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 158);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Expected:";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(217, 30);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(47, 20);
            this.txtError.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Error";
            // 
            // txtExpInvBVal
            // 
            this.txtExpInvBVal.Location = new System.Drawing.Point(61, 113);
            this.txtExpInvBVal.Name = "txtExpInvBVal";
            this.txtExpInvBVal.ReadOnly = true;
            this.txtExpInvBVal.Size = new System.Drawing.Size(91, 20);
            this.txtExpInvBVal.TabIndex = 17;
            this.txtExpInvBVal.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "invBVal";
            // 
            // txtExpFBest
            // 
            this.txtExpFBest.Location = new System.Drawing.Point(61, 86);
            this.txtExpFBest.Name = "txtExpFBest";
            this.txtExpFBest.ReadOnly = true;
            this.txtExpFBest.Size = new System.Drawing.Size(91, 20);
            this.txtExpFBest.TabIndex = 15;
            this.txtExpFBest.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "bestVal";
            // 
            // txtExpYBest
            // 
            this.txtExpYBest.Location = new System.Drawing.Point(60, 55);
            this.txtExpYBest.Name = "txtExpYBest";
            this.txtExpYBest.ReadOnly = true;
            this.txtExpYBest.Size = new System.Drawing.Size(47, 20);
            this.txtExpYBest.TabIndex = 13;
            this.txtExpYBest.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "yBest";
            // 
            // txtExpXBest
            // 
            this.txtExpXBest.Location = new System.Drawing.Point(60, 27);
            this.txtExpXBest.Name = "txtExpXBest";
            this.txtExpXBest.ReadOnly = true;
            this.txtExpXBest.Size = new System.Drawing.Size(47, 20);
            this.txtExpXBest.TabIndex = 11;
            this.txtExpXBest.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "xBest";
            // 
            // FormDist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 899);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIter);
            this.Controls.Add(this.buttIterate);
            this.Controls.Add(this.txtDim);
            this.Controls.Add(this.buttClear);
            this.Controls.Add(this.chart);
            this.Name = "FormDist";
            this.Text = "FormDist";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttRandom;
        private DispChart chart;
        private System.Windows.Forms.Button buttRosenbrock;
        private System.Windows.Forms.Button buttClear;
        private System.Windows.Forms.Button buttLevi;
        private System.Windows.Forms.TextBox txtDim;
        private System.Windows.Forms.Button buttIterate;
        private System.Windows.Forms.TextBox txtIter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radVGO;
        private System.Windows.Forms.RadioButton radPSO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBestVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYBest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXBest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvBVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtXNorm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYNorm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttSinXSinY;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExpInvBVal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtExpFBest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtExpYBest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtExpXBest;
        private System.Windows.Forms.Label label13;
    }
}