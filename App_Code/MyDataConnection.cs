using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PosSync
{
   public class MyDataConnection
    {
        #region "Declaretion"

        System.Data.SqlClient.SqlConnection SqlConn;
        System.Data.SqlClient.SqlCommand SqlCmd;
        System.Data.SqlClient.SqlDataAdapter SqlDa;

        DataSet ds;

        private string conString;
        private string cmdString;
        private CommandType cmdType;
        private string tableName;

        #endregion

        #region "Properties"

        public string ConString
        {
            get
            {
                return conString;
            }
            set
            {
                conString = value;
            }
        }
        public string CmdString
        {
            get
            {
                return cmdString;
            }
            set
            {
                cmdString = value;
            }
        }
        public CommandType CmdType
        {
            get
            {
                return cmdType;
            }
            set
            {
                cmdType = value;
            }
        }
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        #endregion

        #region"Functions"

        public void OpenConnection()
        {
            try
            {
                this.SqlConn = new System.Data.SqlClient.SqlConnection();
                this.SqlConn.ConnectionString = this.conString;
                this.SqlConn.Open();
            }
            catch
            {
                throw;
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (SqlConn.State.Equals(ConnectionState.Open))
                    this.SqlConn.Close();
            }
            catch
            {
                throw;
            }
        }

        public void InsertRecord(params object[] paramList)
        {
            try
            {

                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;
                this.SqlCmd.CommandText = cmdString;

                foreach (SqlParameter i in paramList)
                {
                    this.SqlCmd.Parameters.Add(i);
                }

                if (cmdType == CommandType.StoredProcedure || cmdType == CommandType.Text )
                {

                    this.SqlCmd.ExecuteNonQuery();
                }

                SqlCmd.Parameters.Clear();
                this.SqlCmd.Dispose();
               
            }

            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void InsertRecord(string cmdString, CommandType cmdType)
        {
            try
            {
                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;
                this.SqlCmd.CommandText = cmdString;
                if (cmdType == CommandType.Text)
                {

                    this.SqlCmd.ExecuteNonQuery();
                }
                
                this.SqlCmd.Dispose();
            }

            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void InsertRecord(string cmdString, CommandType cmdType, params object[] paramList)
        {
            try
            {
                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;

                this.SqlCmd.CommandText = cmdString;

                foreach (SqlParameter i in paramList)
                {
                    this.SqlCmd.Parameters.Add(i);
                }

                if (cmdType == CommandType.StoredProcedure || cmdType == CommandType.Text)
                {

                    this.SqlCmd.ExecuteNonQuery();
                }

                SqlCmd.Parameters.Clear();
                this.SqlCmd.Dispose();
                
            }

            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void DeleteRecord(params object[] paramList)
        {
            try
            {
                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;
                this.SqlCmd.CommandText = cmdString;

                foreach (SqlParameter i in paramList)
                {
                    this.SqlCmd.Parameters.Add(i);
                }

                if (cmdType == CommandType.StoredProcedure || cmdType == CommandType.Text)
                {
                    this.SqlCmd.ExecuteNonQuery();
                }

                SqlCmd.Parameters.Clear();
                this.SqlCmd.Dispose();
            }

            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void DeleteRecord(string cmdString, CommandType cmdType)
        {
            try
            {
                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;
                this.SqlCmd.CommandText = cmdString;
                if (cmdType == CommandType.Text)
                {

                    this.SqlCmd.ExecuteNonQuery();
                }
                this.CloseConnection();
                this.SqlCmd.Dispose();
            }

            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void DeleteRecord(string cmdString, CommandType cmdType, params object[] paramList)
        {
            try
            {

                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;
                this.SqlCmd.CommandType = cmdType;

                this.SqlCmd.CommandText = cmdString;

                foreach (SqlParameter i in paramList)
                {
                    this.SqlCmd.Parameters.Add(i);
                }

                if (cmdType == CommandType.StoredProcedure || cmdType == CommandType.Text)
                {

                    this.SqlCmd.ExecuteNonQuery();
                }
                SqlCmd.Parameters.Clear();
                this.SqlCmd.Dispose();
                this.CloseConnection();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataSet LoadDataSet()
        {
            try
            {

                if (this.TableName == null)
                    this.TableName = "table1";
                this.OpenConnection();
                ds = new DataSet();
                ds.Clear();

                SqlDa = new System.Data.SqlClient.SqlDataAdapter(cmdString, SqlConn);
                SqlDa.Fill(ds, TableName);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;

        }
        public DataSet LoadDataSet(params object[] paramList)
        {
            try
            {

                if (this.TableName == null)
                    this.TableName = "table1";

                ds = new DataSet();
                ds.Clear();


                this.SqlCmd = new System.Data.SqlClient.SqlCommand();
                this.SqlCmd.CommandType = cmdType;
                SqlCmd.CommandText = cmdString;
                this.OpenConnection();
                this.SqlCmd.Connection = this.SqlConn;

                if (paramList.Length > 0)
                {
                    foreach (SqlParameter i in paramList)
                    {
                        this.SqlCmd.Parameters.Add(i);
                    }
                }

                SqlDa = new System.Data.SqlClient.SqlDataAdapter(SqlCmd);
                SqlDa.Fill(ds, TableName);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
            return ds;
        }

        #endregion
    }
}
