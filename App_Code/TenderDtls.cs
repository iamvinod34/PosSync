using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using DBConnection;
using System.Configuration;
using System.Transactions;

namespace PosSync.App_Code
{
    class TenderDtls
    {
        DataCon dcon = new DataCon();
        MyDataConnection datacon = new MyDataConnection();

        #region "Properties"

        public string DocumentID { get; set; }
        public string LocationID { get; set; }
        public string TerminalID { get; set; }
        public string CompanyID { get; set; }
        public string StorageID { get; set; }
        public string CustomerID { get; set; }
        public string TenderID { get; set; }

        public string PostingType { get; set; }

        public int Counter { get; set; }

        public DateTime DocumentDate { get; set; }
        public DateTime PostingDate { get; set; }

        public decimal Amount { set; get; }
        public decimal ChangeAmount { set; get; }
        public decimal PaidAmount { set; get; }
        public string DataCon { get; set; }

        public string TransCode { get; set; }

        #endregion

        #region "Functions"

        public void InsertTenderDtls()
        {
            try
            {
                SqlParameter spDocumentID = new SqlParameter();
                spDocumentID.ParameterName = "@DocumentID";
                spDocumentID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentID.Value = DocumentID;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                SqlParameter spCompanyID = new SqlParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = CompanyID;

                SqlParameter spStorageID = new SqlParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlParameter spCustomerID = new SqlParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                if (!CustomerID.Equals(string.Empty))
                    spCustomerID.Value = CustomerID;
                else
                    spCustomerID.Value = DBNull.Value;

                SqlParameter spTenderID = new SqlParameter();
                spTenderID.ParameterName = "@TenderID";
                spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTenderID.Value = TenderID;

                SqlParameter spPostingType = new SqlParameter();
                spPostingType.ParameterName = "@PostingType";
                spPostingType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPostingType.Value = PostingType;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.Int;
                spCounter.Value = Counter;

                SqlParameter spDocumentDate = new SqlParameter();
                spDocumentDate.ParameterName = "@DocumentDate";
                spDocumentDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDocumentDate.Value = DocumentDate;

                SqlParameter spPostingDate = new SqlParameter();
                spPostingDate.ParameterName = "@PostingDate";
                spPostingDate.SqlDbType = System.Data.SqlDbType.Date;
                spPostingDate.Value = PostingDate;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spAmount.Value = Amount;

                SqlParameter spChangeAmount = new SqlParameter();
                spChangeAmount.ParameterName = "@ChangeAmount";
                spChangeAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spChangeAmount.Value = ChangeAmount;

                SqlParameter spPaidAmount = new SqlParameter();
                spPaidAmount.ParameterName = "@PaidAmount";
                spPaidAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spPaidAmount.Value = PaidAmount;

                SqlParameter spTransCode = new SqlParameter();
                spTransCode.ParameterName = "@TransCode";
                spTransCode.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTransCode.Value = TransCode;

                string TenderDtls = "INSERT INTO TBL_TENDER_DETAIL(DOCUMENTID,LOCATIONID,TERMINALID,COUNTER,COMPANYID,STORAGEID,DOCUMENTDATE,POSTINGTYPE,POSTINGDATE,CUSTOMERID,TENDERID,AMOUNT,PAIDAMOUNT,CHANGEAMOUNT,TRANSCODE) VALUES(@DOCUMENTID,@LOCATIONID,@TERMINALID,@COUNTER,@COMPANYID," +
                                    " @STORAGEID,@DOCUMENTDATE,@POSTINGTYPE,@POSTINGDATE,@CUSTOMERID,@TENDERID,@AMOUNT,@PAIDAMOUNT,@CHANGEAMOUNT,@TRANSCODE)";

                datacon.ConString = DataCon;
                datacon.CmdType = CommandType.Text;
                datacon.CmdString = TenderDtls;
               
                datacon.InsertRecord(spDocumentID, spLocationID, spTerminalID, spCompanyID, spStorageID, spCustomerID, spTenderID,
                                      spPostingType, spCounter, spDocumentDate, spPostingDate, spAmount, spChangeAmount, spPaidAmount, spTransCode);
                    UpdateReadTenderdtls();
                  

            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_Tender_Detail'. Cannot insert duplicate key in object 'dbo.tbl_Tender_Detail'.\r\nThe statement has been terminated.";
                if (_Error.Equals(_Ex))
                {
                    UpdateReadTenderdtls();
                }
                else
                {
                    throw;
                }


            }
        }

        public void UpdateReadTenderdtls()
        {
            try
            {
               SqlCeParameter spDoc = new SqlCeParameter();
                    spDoc.ParameterName = "@DocumentId";
                    spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                    spDoc.Value = DocumentID;

                    string _read = "UPDATE TBL_TENDER_DETAIL SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID";

                    dcon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    dcon.CmdType = CommandType.Text;
                    dcon.CmdString = _read;

                    dcon.InsertRecord(spDoc);
                  

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }

}

