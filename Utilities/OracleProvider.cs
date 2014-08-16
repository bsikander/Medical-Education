using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace Utilities
{
    public class OracleProvider
    {
        /// <summary>
        /// This functions read data from database
        /// </summary>
        /// <param name="pQuery"></param>
        public DataTable FetchDataFromDB(string pQuery)
        {
            OracleConnection myConnection;
            OracleCommand myCommand;
            OracleDataReader dr;
            System.Data.DataTable dt = new System.Data.DataTable();

            myConnection = new OracleConnection(ReadConfigFile("ConnectionString"));

            try
            {
                myConnection.Open();
                myCommand = new OracleCommand(pQuery, myConnection);
                dr = myCommand.ExecuteReader();

                dt.Load(dr);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// This function reads the app.config. 
        /// </summary>
        /// <param name="pSettingName">Key name for the setting</param>
        /// <returns></returns>
        private string ReadConfigFile(string pSettingName)
        {
            return ConfigurationManager.AppSettings[pSettingName];
        }

        /// <summary>
        /// This function takes a list of queries and runs the queries. If the queries run without any issue then it commits the transaction otherwise it rollbacks.
        /// </summary>
        /// <param name="lQueris"></param>
        /// <returns></returns>
        public bool InsertIntoDBUsingTransaction(ArrayList lQueris)
        {
            OracleConnection myConnection;
            OracleCommand myCommand;
            OracleDataReader dr;
            OracleTransaction lor;
            System.Data.DataTable dt = new System.Data.DataTable();
                        
            using (myConnection = new OracleConnection(ReadConfigFile("ConnectionString")))
            {
                myConnection.Open();
                myCommand = myConnection.CreateCommand();

                lor = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                myCommand.Transaction = lor;

                try
                {
                    foreach(string lstr in lQueris)   
                    {
                        myCommand.CommandText = lstr;
                        myCommand.ExecuteNonQuery();
                    }
                    lor.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    lor.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// This function is used to execute select queires
        /// </summary>
        /// <param name="pQuery"></param>
        /// <returns></returns>
        public string FetchDataFromDBUsingExecuteScaler(string pQuery)
        {
            OracleConnection myConnection;
            OracleCommand myCommand = null;
            string lResult = string.Empty;

            myConnection = new OracleConnection(ReadConfigFile("ConnectionString"));

            try
            {
                myConnection.Open();
                myCommand = new OracleCommand(pQuery, myConnection);
                lResult = myCommand.ExecuteOracleScalar().ToString();

                return lResult;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            finally
            {
                if (myCommand != null)
                {
                    myCommand.Connection.Close();
                    myCommand.Dispose();
                }
            }
        }

        /// <summary>
        /// This function opens a connecion, assignes transaction to the command object and returns the command object
        /// </summary>
        /// <returns></returns>
        public OracleCommand OpenConnectionAndBeginTransaction()
        {
            OracleConnection myConnection;
            OracleCommand myCommand;            
            OracleTransaction lor;

            myConnection = new OracleConnection(ReadConfigFile("ConnectionString"));
            
            myConnection.Open();
            myCommand = myConnection.CreateCommand();

            lor = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            myCommand.Transaction = lor;

            return myCommand;
        }

        /// <summary>
        /// This fuction takes a command object and commits the transaction
        /// </summary>
        /// <param name="pCommand"></param>
        public void CommitTransaction(OracleCommand pCommand)
        {
            if (pCommand != null && pCommand.Transaction != null)
            {
                pCommand.Transaction.Commit();
            }
        }

        /// <summary>
        /// This function takes a transaction and roll backs it
        /// </summary>
        /// <param name="pCommand"></param>
        public void RollBackTransaction(OracleCommand pCommand)
        {
            if (pCommand != null && pCommand.Transaction != null)
            {
                pCommand.Transaction.Rollback();
            }
        }

        /// <summary>
        /// This fuction takes command, query and parameters and executes the query
        /// </summary>
        /// <param name="pCommand"></param>
        /// <param name="pQuery"></param>
        /// <param name="pParamCollection"></param>
        /// <returns></returns>
        public int FExecuteNonQuery(OracleCommand pCommand , string pQuery , OracleParameterCollection pParamCollection)
        {
            if (pCommand.Connection != null)
            {
                if (pParamCollection == null)
                {
                    pCommand.CommandText = pQuery;
                    return pCommand.ExecuteNonQuery();
                }
                else
                {
                    pCommand.Parameters.Clear();

                    foreach (OracleParameter lop in pParamCollection)
                    {
                        pCommand.Parameters.Add(lop.Clone());
                    }
                    pCommand.CommandText = pQuery;
                    return pCommand.ExecuteNonQuery();
                }
            }
            else
            {
                return -2;
            }
        }
    }
}
