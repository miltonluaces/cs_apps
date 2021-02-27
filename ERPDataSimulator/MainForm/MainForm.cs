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

namespace ErpSim {
    
    public partial class MainForm : Form {

        #region Fields

        private Simulator erpSim;
        private DateTime startDate;
        private int iteration;
        private int iniId;

        #endregion

        #region Constructor

        public MainForm() {
            InitializeComponent();
            erpSim = new Simulator();
            SetDefaultData();
            erpSim.LoadFromDatabase();
            startDate = new DateTime(2012, 1, 1);
            iteration = 0;
            iniId = 0;
        }

        #endregion

        #region Private Methods

        private void SetDefaultData() {

            mSelProductsTxt.Text = "280";
            sdSelProductsTxt.Text = "0";
            mSelNodesTxt.Text = "6";
            sdSelNodesTxt.Text = "0";
            mSimDmdsTxt.Text = "3000";
            sdSimDmdsTxt.Text = "0";
            mDmdQtyTxt.Text = "5";
            sdDmdQtyTxt.Text = "5";
            mSimOrdTxt.Text = "0";
            sdSimOrdTxt.Text = "0";
            mOrdQtyTxt.Text = "0";
            sdOrdQtyTxt.Text = "0";
            iterationsTxt.Text = "170";
            simFreqMinTxt.Text = "1";
            iniDateTxt.Text = "2012-12-31";
        }

        private void ReadFields() {
            erpSim.MSelProducts = Convert.ToDouble(mSelProductsTxt.Text);
            erpSim.SdSelProducts = Convert.ToDouble(sdSelProductsTxt.Text);
            erpSim.MSelNodes = Convert.ToDouble(mSelNodesTxt.Text);
            erpSim.SdSelNodes = Convert.ToDouble(sdSelNodesTxt.Text);
            erpSim.MSimDmds = Convert.ToDouble(mSimDmdsTxt.Text);
            erpSim.SdSimDmds = Convert.ToDouble(sdSimDmdsTxt.Text);
            erpSim.MDmdQty = Convert.ToDouble(mDmdQtyTxt.Text);
            erpSim.SdDmdQty = Convert.ToDouble(sdDmdQtyTxt.Text);
            erpSim.MSimOrds = Convert.ToDouble(mSimOrdTxt.Text);
            erpSim.SdSimOrds = Convert.ToDouble(sdSimOrdTxt.Text);
            erpSim.MOrdQty = Convert.ToDouble(mOrdQtyTxt.Text);
            erpSim.SdOrdQty = Convert.ToDouble(sdOrdQtyTxt.Text);
            erpSim.Iterations = Convert.ToInt32(iterationsTxt.Text);
            erpSim.SimFreqMinutes = Convert.ToInt32(simFreqMinTxt.Text);
            startDate = Convert.ToDateTime(iniDateTxt.Text);
         }

        #endregion

        #region Events

        private void runOneSim_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            DateTime date = startDate.AddDays(iteration);
            int countIt = erpSim.GenerateSim(date);
            iteration++;
            iniId += countIt;
            iterationsTxt.Text = (iteration+1).ToString();
            iniDateTxt.Text = date.ToShortDateString();
            Cursor.Current = Cursors.Default;
        }

        private void runButton_Click(object sender, EventArgs e) {
            erpSim.Run(startDate);
        }
        
        private void readFieldsButton_Click(object sender, EventArgs e) {
            ReadFields();
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            erpSim.DeleteDemands();
            Cursor.Current = Cursors.Default;
        }

        #endregion

    }
}
