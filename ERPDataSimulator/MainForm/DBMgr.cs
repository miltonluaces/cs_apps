#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Resources;
using System.Reflection;
using System.Text;

#endregion

namespace ErpSim {

    public class DBMgr {

        #region Fields

        private string dbAilConnStr;
        private string dbErpConnStr;
        private string dbProvider;
        private string dbName;
        private DbConnection connAil;
        private DbConnection connErp;
        private DbCommand cmd;
        private DbDataAdapter adapter;
        private DataSet set;
        private DbCommandBuilder builder;

        #endregion

        #region Constructor

        public DBMgr() {
            dbProvider = "System.Data.SqlClient";
            dbAilConnStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Milton\\NewDeal\\Databases\\AILogSys.mdf;Integrated Security=True;Connect Timeout=30";
            dbErpConnStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Milton\\NewDeal\\Databases\\ErpData.mdf;Integrated Security=True;Connect Timeout=30";
            dbName = "ErpData";
            set = new DataSet();
            Initialize();
        }

        #endregion

        #region Public Methods


        public void Initialize() {
            try { 
                connAil = new SqlConnection(dbAilConnStr);
                connErp = new SqlConnection(dbErpConnStr);
            }
            catch {  Console.WriteLine("Error."); }
        }

        public void SaveDemands(int[,] demands, DateTime creation)  {
            try  {
                connErp.Open();
            }
            catch { Console.WriteLine("Could not create connection"); return; }
            try {
                for (int i = 0; i < demands.GetLength(0); i++) {
                    string dmdDateStr = GetDateStr(creation);
                    string query = "INSERT INTO ErpDemand (skuId, productId, nodeId, dmdDate, qty, creation) VALUES (" + demands[i, 0] + ", " + demands[i, 1] + ", " + demands[i, 2] + ", "  + dmdDateStr + ", " + demands[i, 1] + ", " + dmdDateStr + ")";
                    cmd = new SqlCommand(query, (SqlConnection)connErp); 
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex) { Console.Write("Error." + ex.StackTrace);  }
            finally  { if (connErp.State == ConnectionState.Open) { connErp.Close(); } }
        }

        
        public void SaveOrders( int[,] orders, DateTime creation)  {
            try  {
                connErp.Open();
            }
            catch { Console.WriteLine("Could not create connection"); return; }
            try {
                for (int i = 0; i < orders.Length; i++) {
                    string dmdDateStr = GetDateStr(creation);
                    string query = "INSERT INTO ErpOrder (erpOrderId, skuId, productId, nodeId, dmdDate, qty, creation) VALUES (" + i + ", " + orders[i, 0] + ", " + orders[i, 1] + ", " + orders[i, 2] + ", " + dmdDateStr + ", " + orders[i, 1] + ", " + dmdDateStr + ")";
                    cmd = new SqlCommand(query, (SqlConnection)connErp); 
                    cmd.ExecuteNonQuery();
                }
            }
            catch { Console.Write("Error.");  }
            finally  { if (connErp.State == ConnectionState.Open) { connErp.Close(); } }
        }


        public void CreateDatabase() { 
 
            string query = "CREATE DATABASE ERPData";

            string query1 = "CREATE TABLE ErpDemand ( " +
            "erpDemandId int NOT NULL, " +
            "skuId int NOT NULL, " +
            "productId int NOT NULL, " +
            "nodeId int NOT NULL, " +
            "dmdDate datetime, " + 
            "qty float, " +
            "creation datetime NOT NULL, " +
            "CONSTRAINT PkErpDemand PRIMARY KEY (erpDemandId))";

            string query2 = "CREATE TABLE ErpSupply ( " +
            "erpSupplyId int NOT NULL, " +
            "skuId int NOT NULL, " +
            "productId int NOT NULL, " +
            "nodeId int NOT NULL, " +
            "supDate datetime, " +
            "qty float, " +
            "creation datetime NOT NULL, " +
            "CONSTRAINT PkErpSupply PRIMARY KEY (erpSupplyId))";
 
            string query3 = "CREATE TABLE ErpSupplyItem ( " +
            "erpSupplyItemId int NOT NULL, " +
            "qty float,  " +
            "erpSupplyId int NOT NULL REFERENCES ErpSupply(erpSupplyId),  " +
            "erpDemandId int REFERENCES ErpDemand(erpDemandId),  " +
            "creation datetime NOT NULL, " +
            "CONSTRAINT PkErpSupplyLine PRIMARY KEY (erpSupplyItemId))";
  
        }

        public void DeleteDemands(DateTime iniDate, DateTime endDate) {
            try {
                connErp.Open();
            }
            catch { Console.WriteLine("Could not create connection"); return; }
            try {
                  string query = "DELETE FROM ErpDemand WHERE date >= " + GetDateStr(iniDate) + " AND date <= " + GetDateStr(endDate) +")";
                  cmd = new SqlCommand(query, (SqlConnection)connErp);
                  cmd.ExecuteNonQuery();
            } 
            catch (Exception ex) { Console.Write("Error." + ex.StackTrace); }
            finally { if (connErp.State == ConnectionState.Open) { connErp.Close(); } }
        }

        public void DeleteDemands() {
            try {
                connErp.Open();
            }
            catch { Console.WriteLine("Could not create connection"); return; }
            try {
                string query = "DELETE FROM ErpDemand";
                cmd = new SqlCommand(query, (SqlConnection)connErp);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.Write("Error." + ex.StackTrace); }
            finally { if (connErp.State == ConnectionState.Open) { connErp.Close(); } }
        }

   
     
        #endregion


        internal int[,] LoadSkus() {
            DataRow row;
            try  {
                connAil.Open();
            }
            catch(Exception ex) { Console.WriteLine("Could not create connection" + ex.StackTrace); return null; }
            try {
                set = new DataSet();
                adapter = new SqlDataAdapter("SELECT skuId, productId, nodeId FROM AilSku WHERE nodeId IN (SELECT nodeId FROM AilNode WHERE schLevel = 0) ORDER BY nodeId", (SqlConnection)connAil); 
                adapter.Fill(set);
                int[,] skus = new int[set.Tables[0].Rows.Count, 3];
                for (int i = 0; i < set.Tables[0].Rows.Count;i++) {
                    row = set.Tables[0].Rows[i];
                    skus[i,0] = (int)row["skuId"];
                    skus[i,1] = (int)row["productId"];
                    skus[i,2] = (int)row["nodeId"];
                }
                return skus;
            }
            catch { Console.Write("Error."); return null; }
            finally { if (connAil.State == ConnectionState.Open) { connAil.Close(); } }
            return null;
        }

        
        internal void RegisterProcess(DateTime start, DateTime finish) {
            try {
                connAil.Open();
                string query = "UPDATE AilProcess SET lastDate = " + GetDateStr(start) + ", start = " + GetTimeStr(start) + ", finish = " + GetTimeStr(finish) + ", state = 1, notes = 'Ok' WHERE processId = 0";
                cmd = new SqlCommand(query, (SqlConnection)connAil);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.Write("Error." + ex.StackTrace); return; }
            finally { if (connAil.State == ConnectionState.Open) { connAil.Close(); } }
        }


        internal string GetDateStr(DateTime date) {
            return "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
        }

        internal string GetTimeStr(DateTime date) {
            return "'" + date.Hour + ":" + date.Minute + "'";
        }
    }
}
