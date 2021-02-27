#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Operations;

#endregion

namespace GUI {

    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm {

        #region Constructor

        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void barMailing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AILClientMailer cm = new AILClientMailer();
        }

        private void barObfuscate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            DbObfuscator dbo = new DbObfuscator();
            dbo.Obfuscate();
        }

        #endregion
    }
}
