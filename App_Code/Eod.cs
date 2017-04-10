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
    public class Eod
    {
        DataCon dcon = new DataCon();
        MyDataConnection datacon1 = new MyDataConnection();

        #region "Properties"

        public string LocationID { get; set; }
        public string TerminalID { get; set; }
        public string EODID { set; get; }
        public string SalesId { get; set; }

        public DateTime DocDate { set; get; }


        public decimal Loan { set; get; }
        public decimal SystemCash { set; get; }
        public decimal ActualCash { set; get; }


        public int Cash1 { set; get; }
        public int Cash5 { set; get; }
        public int Cash10 { set; get; }
        public int Cash20 { set; get; }
        public int Cash50 { set; get; }
        public int Cash100 { set; get; }
        public int Cash200 { set; get; }
        public int Cash500 { set; get; }

        public decimal CashDiff { set; get; }
        public int CashCount { set; get; }

        public decimal CreditAmt { set; get; }
        public int CreditCnt { set; get; }

        public decimal DebitAmt { set; get; }
        public int DebitCnt { set; get; }

        public decimal ReturnAmt { set; get; }
        public int ReturnCnt { set; get; }

        public decimal DeleteAmt { set; get; }
        public int DeleteCnt { set; get; }

        public decimal OnAccAmt { set; get; }
        public int OnAccCnt { set; get; }

        public decimal Cust1Amt { set; get; }
        public int Cust1Cnt { set; get; }

        public decimal Cust2Amt { set; get; }
        public int Cust2Cnt { set; get; }

        public string DataCon { get; set; }

        public int LastEODId { set; get; }

        #endregion


        #region "Functions"

        public DataTable InsertEOD()
        {
            DataTable dtEOD = null;
            try
            {
                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spTermininalID = new SqlParameter();
                spTermininalID.ParameterName = "@TerminialID";
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

                SqlParameter spLoan = new SqlParameter();
                spLoan.ParameterName = "@Loan";
                spLoan.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLoan.Value = Loan;

                SqlParameter spSystemCash = new SqlParameter();
                spSystemCash.ParameterName = "@SystemCash";
                spSystemCash.SqlDbType = System.Data.SqlDbType.Decimal;
                spSystemCash.Value = SystemCash;

                SqlParameter spActualCash = new SqlParameter();
                spActualCash.ParameterName = "@ActualCash";
                spActualCash.SqlDbType = System.Data.SqlDbType.Decimal;
                spActualCash.Value = ActualCash;

                SqlParameter spCash1 = new SqlParameter();
                spCash1.ParameterName = "@1";
                spCash1.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash1.Value = Cash1;

                SqlParameter spCash5 = new SqlParameter();
                spCash5.ParameterName = "@5";
                spCash5.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash5.Value = Cash5;

                SqlParameter spCash10 = new SqlParameter();
                spCash10.ParameterName = "@10";
                spCash10.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash10.Value = Cash10;

                SqlParameter spCash20 = new SqlParameter();
                spCash20.ParameterName = "@20";
                spCash20.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash20.Value = Cash20;

                SqlParameter spCash50 = new SqlParameter();
                spCash50.ParameterName = "@50";
                spCash50.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash50.Value = Cash50;

                SqlParameter spCash100 = new SqlParameter();
                spCash100.ParameterName = "@100";
                spCash100.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash100.Value = Cash100;

                SqlParameter spCash200 = new SqlParameter();
                spCash200.ParameterName = "@200";
                spCash200.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash200.Value = Cash200;

                SqlParameter spCash500 = new SqlParameter();
                spCash500.ParameterName = "@500";
                spCash500.SqlDbType = System.Data.SqlDbType.Decimal;
                spCash500.Value = Cash500;

                SqlParameter spCashDiff = new SqlParameter();
                spCashDiff.ParameterName = "@CashDiff";
                spCashDiff.SqlDbType = System.Data.SqlDbType.Decimal;
                spCashDiff.Value = CashDiff;

                SqlParameter spCashCount = new SqlParameter();
                spCashCount.ParameterName = "@CashCount";
                spCashCount.SqlDbType = System.Data.SqlDbType.Int;
                spCashCount.Value = CashCount;

                SqlParameter spCreditAmt = new SqlParameter();
                spCreditAmt.ParameterName = "@CreditAmt";
                spCreditAmt.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditAmt.Value = CreditAmt;


                SqlParameter spDebitAmt = new SqlParameter();
                spDebitAmt.ParameterName = "@DebitAmt";
                spDebitAmt.SqlDbType = System.Data.SqlDbType.Decimal;
                spDebitAmt.Value = DebitAmt;

                SqlParameter spDebitCnt = new SqlParameter();
                spDebitCnt.ParameterName = "@DebitCnt";
                spDebitCnt.SqlDbType = System.Data.SqlDbType.Int;
                spDebitCnt.Value = DebitCnt;

                SqlParameter spReturnAmt = new SqlParameter();
                spReturnAmt.ParameterName = "@ReturnAmt";
                spReturnAmt.SqlDbType = System.Data.SqlDbType.Decimal;
                spReturnAmt.Value = ReturnAmt;

                SqlParameter spReturnCnt = new SqlParameter();
                spReturnCnt.ParameterName = "@ReturnCnt";
                spReturnCnt.SqlDbType = System.Data.SqlDbType.Int;
                spReturnCnt.Value = ReturnCnt;

                SqlParameter spDeleteAmt = new SqlParameter();
                spDeleteAmt.ParameterName = "@DeleteAmt";
                spDeleteAmt.SqlDbType = System.Data.SqlDbType.Decimal;
                spDeleteAmt.Value = DeleteAmt;

                SqlParameter spDeleteCnt = new SqlParameter();
                spDeleteCnt.ParameterName = "@DeleteCnt";
                spDeleteCnt.SqlDbType = System.Data.SqlDbType.Int;
                spDeleteCnt.Value = DeleteCnt;

                SqlParameter spOnAccAmt = new SqlParameter();
                spOnAccAmt.ParameterName = "@OnAccAmt";
                spOnAccAmt.SqlDbType = System.Data.SqlDbType.Decimal;
                spOnAccAmt.Value = OnAccAmt;

                SqlParameter spOnAccCnt = new SqlParameter();
                spOnAccCnt.ParameterName = "@OnAccCnt";
                spOnAccCnt.SqlDbType = System.Data.SqlDbType.Int;
                spOnAccCnt.Value = OnAccCnt;

                SqlParameter spCust1Amt = new SqlParameter();
                spCust1Amt.ParameterName = "@Cust1Amt";
                spCust1Amt.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCust1Amt.Value = Cust1Amt;

                SqlParameter spCust1Cnt = new SqlParameter();
                spCust1Cnt.ParameterName = "@";
                spCust1Cnt.SqlDbType = System.Data.SqlDbType.Int;
                spCust1Cnt.Value = Cust1Cnt;

                SqlParameter spCust2Amt = new SqlParameter();
                spCust2Amt.ParameterName = "@";
                spCust2Amt.SqlDbType = System.Data.SqlDbType.Decimal;
                spCust2Amt.Value = Cust2Amt;

                SqlParameter spCust2Cnt = new SqlParameter();
                spCust2Cnt.ParameterName = "@";
                spCust2Cnt.SqlDbType = System.Data.SqlDbType.Int;
                spCust2Cnt.Value = Cust2Cnt;

                SqlParameter spCreditCnt = new SqlParameter();
                spCreditCnt.ParameterName = "@CreditCnt";
                spCreditCnt.SqlDbType = System.Data.SqlDbType.Int;
                spCreditCnt.Value = CreditCnt;


                string EOD = "Proc_SyncInsertEod";


                datacon1.ConString = DataCon;
                datacon1.CmdType = CommandType.StoredProcedure;
                datacon1.CmdString = EOD;
               
                    datacon1.InsertRecord(spLocationID, spTermininalID, spEODID, spDocDate, spLoan, spSystemCash, spActualCash, spCash1, spCash5,
                                      spCash10, spCash20, spCash50, spCash100, spCash200, spCash500, spCashDiff, spCashCount, spCreditAmt, spDebitAmt,
                                      spDebitCnt, spReturnAmt, spReturnCnt, spDeleteAmt, spDeleteCnt, spOnAccAmt, spOnAccCnt, spCreditCnt,spCust1Amt);
                   
                UpdateReadEod();

            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_EOD'. Cannot insert duplicate key in object 'dbo.tbl_EOD'.\r\nThe statement has been terminated.";
                if (_Error.Equals(_Ex))
                {
                    UpdateReadEod();
                }
                else
                {
                    throw;
                }
            }
            return dtEOD;
        }

        public void UpdateReadEod()
        {
            try
            {
                using (TransactionScope objsco = new TransactionScope())
                {
                    SqlCeParameter spEod = new SqlCeParameter();
                    spEod.ParameterName = "@EodId";
                    spEod.SqlDbType = System.Data.SqlDbType.NVarChar;
                    spEod.Value = EODID;

                    string _read = "UPDATE TBL_EOD SET ConRead='True' WHERE EODID=@EODID";

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
