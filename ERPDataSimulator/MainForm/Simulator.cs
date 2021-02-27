#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ErpSim {
    
    public class Simulator {

        #region Fields

        private double mSelProducts;
        private double sdSelProducts;
        private double mSelNodes;
        private double sdSelNodes;

        private double mSimDmds;
        private double sdSimDmds;
        private double mSimOrds;
        private double sdSimOrds;
   
        private double mDmdQty;
        private double sdDmdQty;
        private double mOrdQty;
        private double sdOrdQty;

        private int simFreqMinutes;
        private int iterations;
        
        private char separator;

        private int[,] skus;

        private RndGenerator rand;
        private DBMgr dbMgr;

        private DateTime start;
        private DateTime finish;


        #endregion

        #region Constructor

        public Simulator() {
            rand = new RndGenerator();
            dbMgr = new DBMgr();

            mSelProducts = 280;
            sdSelProducts = 0;
            mSelNodes = 6;
            sdSelNodes = 0;
            mSimDmds = 3000;
            sdSimDmds = 0;
            mDmdQty = 5;
            sdDmdQty = 5;
            mSimOrds = 0;
            sdSimOrds = 0;
            mOrdQty = 0;
            sdOrdQty = 0;
            iterations = 1;
            simFreqMinutes = 1;
        }

        #endregion

        #region Properties

        public double MSelProducts {
            get { return mSelProducts; }
            set { mSelProducts = value; }
        }

        public double SdSelProducts {
            get { return sdSelProducts; }
            set { sdSelProducts = value; }
        }
        
        public double MSelNodes {
            get { return  mSelNodes;}
            set { mSelNodes = value; }
        }

        public double SdSelNodes {
            get { return sdSelNodes; }
            set { sdSelNodes = value; }
        }
        
        public double MDmdQty {
            get { return mDmdQty;}
            set { mDmdQty = value; }
        }

        public double SdDmdQty {
            get { return sdDmdQty;}
            set { sdDmdQty = value; }
        }

        public double MOrdQty {
            get { return mOrdQty; }
            set { mOrdQty = value; }
        }

        public double SdOrdQty {
            get { return sdOrdQty; }
            set { sdOrdQty = value; }
        }
        
        public double MSimDmds {
            get { return mSimDmds; }
            set { mSimDmds = value; }
        }

        public double SdSimDmds {
            get { return sdSimDmds; }
            set { sdSimDmds = value; }
        }

        public double MSimOrds {
            get { return mSimOrds; }
            set { mSimOrds = value; }
        }

        public double SdSimOrds {
            get { return sdSimOrds; }
            set { sdSimOrds = value; }
        }

        public int Iterations {
            get { return iterations; }
            set { iterations = value; }
        }
        
        public int SimFreqMinutes {
            get { return simFreqMinutes;}
            set { simFreqMinutes = value; }
        }

        public int[,] Skus {
            get { return skus; }
        }

        public char Separator {
            get { return separator; }
            set { separator = value; }
        }

        public DateTime Start {
            get { return start; }
        }

        public DateTime Finish {
            get { return finish; }
        }
        
        #endregion
        
        #region Public Methods

        #region Load Methods

        public void LoadFromFile(string fileName) {
            //TODO: cargar productIds y nodeIds desde archivos csv: columnas: skuId, productId, nodeId
        }

        public void LoadFromDatabase() {
            skus = dbMgr.LoadSkus();
        }

        #endregion

        #region Generate Methods

        public int GenerateSim(DateTime date) {
            start = DateTime.Now;
            int[,] demands, orders;
            Parameters par = SetParameters();

            demands = GenerateDBObjs(par.nSimDmds, par.nSelProducts, par.nSelNodes, true);
            dbMgr.SaveDemands(demands, date);

            //orders = GenerateDBObjs(iniId, par.nSimOrds, par.nSelProducts, par.nSelNodes, false);
            //dbMgr.SaveOrders(orders, date);
            finish = DateTime.Now;
            dbMgr.RegisterProcess(start, finish);
            return demands.GetLength(0);
        }

        public void Run(DateTime startDate) {
            DateTime date = startDate;
            for(int i=0;i<this.Iterations;i++) {
                date = date.AddDays(1);
                GenerateSim(date);
            }
        }

        public void DeleteDemands() {
            dbMgr.DeleteDemands();
        }
        
        #endregion

        #endregion

        #region Private Methods

        private int[,] GenerateDBObjs(int nSimDBObjs, int nSelProducts, int nSelNodes, bool isDemand) {

            int[,] data = new int[nSimDBObjs, 4];

            Dictionary<int, int> selProds = new Dictionary<int, int>();
            Dictionary<int, int> selNodes = new Dictionary<int, int>();
          

            for (int i = 0; i < data.GetLength(0); i++) {
                int index = (int)GetRnd(0, skus.GetLength(0));
                int skuId = skus[index, 0];
                //Console.WriteLine(index + " " + skus[index, 0]);
                int productId = skus[index, 1];
                int nodeId = skus[index, 2];
                int qty = 0;
                if (isDemand) { qty = GetNorm(mDmdQty, sdDmdQty); }
                else { qty = GetNorm(mDmdQty, sdDmdQty); }

                if (selProds.Count < nSelProducts && !selProds.ContainsKey(productId)) { selProds.Add(productId, productId); }
                if (selNodes.Count < nSelNodes && !selNodes.ContainsKey(nodeId)) { selNodes.Add(nodeId, nodeId); }

                while (!selProds.ContainsKey(productId) || !selNodes.ContainsKey(nodeId)) {
                    index = (int)GetRnd(0, skus.GetLength(0));
                    skuId = skus[index, 0];
                    productId = skus[index, 1];
                    nodeId = skus[index, 2];
                }

                data[i, 0] = skuId;
                data[i, 1] = productId;
                data[i, 2] = nodeId;
                data[i, 3] = qty;
            }

            return data;
        }
        
        private Parameters SetParameters() {
            Parameters par = new Parameters();
            par.nSimDmds = GetNorm(mSimDmds, sdSimDmds);
            par.nSimOrds = GetNorm(mSimOrds, sdSimOrds);
            par.nSelProducts = GetNorm(mSelProducts, sdSelProducts);
            par.nSelNodes = GetNorm(mSelNodes, sdSelNodes);
            return par;
        }

        private double GetRnd(int min, int max) {
            return rand.NextDouble(min, max);
        }

        private int GetNorm(double m, double sd) {
            double q = rand.NextNormal(m, sd);
            if (q < 0) { return 0; }
            else { return (int)q; }
        }

        #endregion

        #region Public Classes

        public class Parameters {
            public int nSimDmds;
            public int nSimOrds;
            public int nSelProducts;
            public int nSelNodes;
         }
        
        #endregion

    }
}
