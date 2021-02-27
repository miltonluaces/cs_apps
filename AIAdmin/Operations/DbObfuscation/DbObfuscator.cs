#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Resources;
using System.Reflection;

#endregion

namespace Operations {

    public class DbObfuscator {

        #region Fields

        protected string connStr;
        protected string dbName;
        protected string dbConnStr;
        protected DbConnection conn;
        protected DbCommand cmd;
        protected DbDataAdapter adapter;
        protected DataSet set;
        protected DbCommandBuilder builder;
   
        #endregion

        #region Constructor

        public DbObfuscator() { 
        }

        #endregion

        #region Public Methods

        public void Obfuscate() {
            Obfuscate("AilProduct", "descr", "DemoProducts.txt");
            //Obfuscate("AilNode", "descr", "DemoNodes.txt");
        }

        public void Obfuscate(string tableName, string fieldName, string fileName) {
            List<string> productNames = GetListNames(fileName);

            try {
                dbConnStr = @"Data Source=MILTON-PC\SQLEXPRESS;AttachDbFilename=C:\Users\Milton\NewDeal\Databases\AILogSys.mdf;user Id=sa; password=newdeal12;Integrated Security=True;Connect Timeout=30";

                conn = new SqlConnection(dbConnStr);
                set = new DataSet();
                string query = "SELECT * FROM " + tableName;
                adapter = new SqlDataAdapter(query, (SqlConnection)conn);
                builder = new SqlCommandBuilder((SqlDataAdapter)adapter);
                conn.Open();
                adapter.Fill(set);
                int nNames = productNames.Count;
                if (set.Tables[0].Rows.Count == 0) { return; }
                for (int i = 0; i < set.Tables[0].Rows.Count; i++) {
                    if (i >= productNames.Count) { break; }
                    set.Tables[0].Rows[i][fieldName] = productNames[i % nNames];
                }
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(set, set.Tables[0].TableName);
            }
            catch (Exception ex) { /*throw new Exception("Error", ex);*/ }
            finally {
                try { conn.Close(); }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
        }
        
        #endregion

        #region Private Methods

        private void Initialize() {
            dbConnStr = "";
            conn = new SqlConnection(dbConnStr); 
        }

        private List<string> GetListNames(string fileName) {
            List<string> listNames = new List<string>();
            StreamReader sr = new StreamReader(fileName);
            string line;
            while ((line = sr.ReadLine()) != null) { listNames.Add(line.Trim()); }
            return listNames;
        }

        #endregion
    }
}
