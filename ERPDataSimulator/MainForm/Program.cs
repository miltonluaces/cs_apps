#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace ErpSim {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (args.Length > 0) {
                DateTime startDate = DateTime.MinValue;
                if (args[0] == "now") { startDate = DateTime.Now; }
                else { startDate = Convert.ToDateTime(args[0]); }
                Simulator sim = new Simulator();
                sim.LoadFromDatabase();
                sim.GenerateSim(startDate);
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
