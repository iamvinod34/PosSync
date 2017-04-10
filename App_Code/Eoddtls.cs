using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBConnection;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Transactions;


namespace PosSync.App_Code
{
    public class Eoddtls
    {
        DataCon dcon = new DataCon();
        MyDataConnection datacon1 = new MyDataConnection();

        #region "Properties"

        public string LocationID { get; set; }
        public string TerminalID { get; set; }
        public string EODID { set; get; }

        public DateTime DocDate { set; get; }

        public DateTime TransactionDate { set; get; }
        public string TransactionType { set; get; }
        public string TransactionID { set; get; }

        public int Count { set; get; }
        public string PayType { set; get; }

        public decimal Amount { set; get; }

        public string Datacon { get; set; }

        #endregion


        #region "Functions"

        public DataTable InsertEODdtls()
        {
            DataTable dtEODdtls = null;
            try
            {
                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spTermininalID = new SqlParameter();
                spTermininalID.ParameterName = "@TerminalID";
                spTermininalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTermininalID.Value = TerminalID;

                SqlParameter spEODID = new SqlParameter();
                spEODID.ParameterName = "@EODID";
                spEODID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEODID.Value = EODID;

                SqlParameter spDocDate = new SqlParameter();
                spDocDate.ParameterName = "@DocDate";
                spDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDocDate.Value = DocDate;

                SqlParameter spTransactionDate = new SqlParameter();
                spTransactionDate.ParameterName = "@TransactionDate";
                spTransactionDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spTransactionDate.Value = TransactionDate;

                SqlParameter spTransactionType = new SqlParameter();
                spTransactionType.ParameterName = "@TransactionType";
                spTransactionType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTransactionType.Value = TransactionType;

                SqlParameter spTransactionID = new SqlParameter();
                spTransactionID.ParameterName = "@TransactionID";
                spTransactionID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTransactionID.Value = TransactionID;

                SqlParameter spCount = new SqlParameter();
                spCount.ParameterName = "@Count";
                spCount.SqlDbType = System.Data.SqlDbType.BigInt;
                spCount.Value = Count;

                SqlParameter spPayType = new SqlParameter();
                spPayType.ParameterName = "@PayType";
                spPayType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPayType.Value = PayType;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spAmount.Value = Amount;


                string EODdtls = "Proc_SyncInsertEoddtls";

                datacon1.ConString = Datacon;
                datacon1.CmdType = CommandType.StoredProcedure;
                datacon1.CmdString = EODdtls;

                datacon1.InsertRecord(spLocationID, spTermininalID, spEODID, spDocDate, spTransactionDate,
                                  spTransactionType, spTransactionID, spCount, spPayType, spAmount);

                UpdateReadEoddtls();
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "Violation of PRIMARY KEY constraint 'tbl_eoddtls'. Cannot insert duplicate key in object 'dbo.tbl_eoddtls'.\r\nThe statement has been terminated.";
                if (_Error.Equals(_Ex))
                {
                    UpdateReadEoddtls();
                }
                else
                {
                    throw;
                }
            }
            return dtEODdtls;
        }

        public void UpdateReadEoddtls()
        {
            try
            {
                using (TransactionScope objsco = new TransactionScope())
                {
                    SqlCeParameter spEod = new SqlCeParameter();
                    spEod.ParameterName = "@EodId";
                    spEod.SqlDbType = System.Data.SqlDbType.NVarChar;
                    spEod.Value = EODID;

                    string _read = "UPDATE TBL_EOD_DETAIL SET ConRead='True' WHERE EODID=@EODID";

                    dcon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    dcon.CmdType = CommandType.Text;
                    dcon.CmdString = _read;

                    dcon.InsertRecord(spEod);

                    objsco.Complete();
                }

            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
