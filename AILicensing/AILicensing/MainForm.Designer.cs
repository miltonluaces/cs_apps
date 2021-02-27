namespace AILicensing {

    partial class MainForm {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.buttPKFile = new System.Windows.Forms.Button();
            this.buttGenerateLicFile = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttPKFile
            // 
            this.buttPKFile.Location = new System.Drawing.Point(88, 57);
            this.buttPKFile.Name = "buttPKFile";
            this.buttPKFile.Size = new System.Drawing.Size(121, 23);
            this.buttPKFile.TabIndex = 0;
            this.buttPKFile.Text = "Generate PK File";
            this.buttPKFile.UseVisualStyleBackColor = true;
            this.buttPKFile.Click += new System.EventHandler(this.buttPKFile_Click);
            // 
            // buttGenerateLicFile
            // 
            this.buttGenerateLicFile.Location = new System.Drawing.Point(87, 87);
            this.buttGenerateLicFile.Name = "buttGenerateLicFile";
            this.buttGenerateLicFile.Size = new System.Drawing.Size(121, 23);
            this.buttGenerateLicFile.TabIndex = 1;
            this.buttGenerateLicFile.Text = "Generate Lic File";
            this.buttGenerateLicFile.UseVisualStyleBackColor = true;
            this.buttGenerateLicFile.Click += new System.EventHandler(this.buttGenerateLicFile_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(101, 51);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(202, 20);
            this.datePicker.TabIndex = 2;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(101, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(121, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lic. Expiration:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.buttPKFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialization";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttGenerateLicFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.datePicker);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Location = new System.Drawing.Point(13, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 135);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Licence File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(149, 24);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(41, 20);
            this.txtVersion.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttTest);
            this.groupBox3.Location = new System.Drawing.Point(13, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 97);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test";
            // 
            // buttTest
            // 
            this.buttTest.Location = new System.Drawing.Point(87, 36);
            this.buttTest.Name = "buttTest";
            this.buttTest.Size = new System.Drawing.Size(121, 23);
            this.buttTest.TabIndex = 0;
            this.buttTest.Text = "Test HcReader";
            this.buttTest.UseVisualStyleBackColor = true;
            this.buttTest.Click += new System.EventHandler(this.buttTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 363);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "AI Financial & Logistics Systems";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttPKFile;
        private System.Windows.Forms.Button buttGenerateLicFile;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttTest;
    }
}

