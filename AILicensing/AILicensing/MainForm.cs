#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace AILicensing {

    public partial class MainForm : Form {

        #region Fields

        private RSAGen rsaGen;

        #endregion

        #region Constructor

        public MainForm() {
            InitializeComponent();
            rsaGen = new RSAGen();
            txtVersion.Text = "1.0";
        }

        #endregion

        #region Events

        private void buttPKFile_Click(object sender, EventArgs e) {
            rsaGen.GeneratePrivKeyFile(txtVersion.Text);
            Console.WriteLine("PK File Generated Ok.");
        }

        private void buttGenerateLicFile_Click(object sender, EventArgs e) {
            rsaGen.GenerateLicFile(txtFileName.Text, datePicker.Value);
        }

        #endregion

        private void buttTest_Click(object sender, EventArgs e) {
            string pkFileName = @"..\..\..\Files\PK" + txtVersion.Text + ".txt";
            string code = "AILogSys";
            string fileName = @"..\..\..\Files\AILicKey" + txtFileName.Text + ".txt";
            HcReader hcr = new HcReader(code, txtVersion.Text, fileName, pkFileName);
            bool ok = hcr.Process(fileName, rsaGen);
            if (ok) { MessageBox.Show("Ok"); }
            else { MessageBox.Show("Error"); }
        }

     }
}
