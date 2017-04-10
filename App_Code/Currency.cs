using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using DBConnection;
namespace PosSync.App_Code
{
    class Currency
    {
        #region Properties

        public string CurrencyID { set; get; }
        public string CurrencyName { set; get; }
        public double CurrRate { set; get; }
        public string Dcon { set; get; }

        #endregion

        DataCon objDb = new DataCon();
        public DataTable InsertCurrency()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCurrencyID = new SqlCeParameter();
                spCurrencyID.ParameterName = "@CurrencyID";
                spCurrencyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyID.Value = this.CurrencyID;

                SqlCeParameter spCurrencyName = new SqlCeParameter();
                spCurrencyName.ParameterName = "@CurrencyName";
                spCurrencyName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyName.Value = this.CurrencyName;

                SqlCeParameter spCurrRate = new SqlCeParameter();
                spCurrRate.ParameterName = "@CurrRate";
                spCurrRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spCurrRate.Value = this.CurrRate;

                string s = "Insert into tbl_Currency_Temp values(@CurrencyID,@CurrencyName,@CurrRate)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCurrencyID, spCurrencyName,spCurrRate);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_curr;

        }
        public DataTable InsertCurrency_MasterData()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCurrencyID = new SqlCeParameter();
                spCurrencyID.ParameterName = "@CurrencyID";
                spCurrencyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyID.Value = this.CurrencyID;

                SqlCeParameter spCurrencyName = new SqlCeParameter();
                spCurrencyName.ParameterName = "@CurrencyName";
                spCurrencyName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyName.Value = this.CurrencyName;

                SqlCeParameter spCurrRate = new SqlCeParameter();
                spCurrRate.ParameterName = "@CurrRate";
                spCurrRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spCurrRate.Value = this.CurrRate;

                string s = "Insert into tbl_Currency values(@CurrencyID,@CurrencyName,@CurrRate)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCurrencyID, spCurrencyName, spCurrRate);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_curr;
        }
        public DataTable UpdateCurrency_MasterData()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCurrencyID = new SqlCeParameter();
                spCurrencyID.ParameterName = "@CurrencyID";
                spCurrencyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyID.Value = this.CurrencyID;

                SqlCeParameter spCurrencyName = new SqlCeParameter();
                spCurrencyName.ParameterName = "@CurrencyName";
                spCurrencyName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyName.Value = this.CurrencyName;

                SqlCeParameter spCurrRate = new SqlCeParameter();
                spCurrRate.ParameterName = "@CurrRate";
                spCurrRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spCurrRate.Value = this.CurrRate;

                string s = "update tbl_Currency set CurrencyName=@CurrencyName,CurrRate=@CurrRate where CurrencyID=@CurrencyID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCurrencyID, spCurrencyName, spCurrRate);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_curr;
        }
       
    }
}
