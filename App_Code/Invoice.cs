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

namespace PosSync
{
    public class Invoice
    {
        DataCon dcon = new DataCon();
        MyDataConnection datacon1 = new MyDataConnection();

        #region "Properties"

        public string DocumentID { get; set; }

        public string SalesOrder { get; set; }

        public string CompanyID { get; set; }

        public string LocationID { get; set; }

        public string StorageID { get; set; }

        public string TerminalID { get; set; }

        public string CustomerID { get; set; }

        public string DocDetail { get; set; }

        public DateTime DocumentDate { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime AddDate { get; set; }

        public string UserID { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public decimal NetValue { get; set; }

        public string DataCon { get; set; }

        #endregion

        #region "Functions"

        public DataTable InsertInvoice()
        {
            DataTable dtInvoice = null;
            try
            {
                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlParameter spSalesOrder = new SqlParameter();
                spSalesOrder.ParameterName = "@SalesOrder";
                spSalesOrder.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSalesOrder.Value = SalesOrder;

                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyID;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationID;

                SqlParameter spStorageId = new SqlParameter();
                spStorageId.ParameterName = "@StorageId";
                spStorageId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageId.Value = StorageID;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalID;

                SqlParameter spCustomerId = new SqlParameter();
                spCustomerId.ParameterName = "@CustomerId";
                spCustomerId.SqlDbType = System.Data.SqlDbType.NVarChar;
                if (!CustomerID.Equals(string.Empty))
                    spCustomerId.Value = CustomerID;
                else
                    spCustomerId.Value = DBNull.Value;

                SqlParameter spDocDetail = new SqlParameter();
                spDocDetail.ParameterName = "@DocDetail";
                spDocDetail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocDetail.Value = DocDetail;

                SqlParameter SpDocDate = new SqlParameter();
                SpDocDate.ParameterName = "@DocDate";
                SpDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SpDocDate.Value = DocumentDate;

                SqlParameter SpPostDate = new SqlParameter();
                SpPostDate.ParameterName = "@PostDate";
                SpPostDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SpPostDate.Value = PostingDate;

                SqlParameter SpAddDate = new SqlParameter();
                SpAddDate.ParameterName = "@AddDate";
                SpAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SpAddDate.Value = AddDate;

                SqlParameter SpUser = new SqlParameter();
                SpUser.ParameterName = "@UserId";
                SpUser.SqlDbType = System.Data.SqlDbType.NVarChar;
                SpUser.Value = UserID;

                SqlParameter SpAmount = new SqlParameter();
                SpAmount.ParameterName = "@Amount";
                SpAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                SpAmount.Value = Amount;

                SqlParameter SpDiscount = new SqlParameter();
                SpDiscount.ParameterName = "@Discount";
                SpDiscount.SqlDbType = System.Data.SqlDbType.Decimal;
                SpDiscount.Value = Discount;

                SqlParameter SpNetValue = new SqlParameter();
                SpNetValue.ParameterName = "@NetValue";
                SpNetValue.SqlDbType = System.Data.SqlDbType.Decimal;
                SpNetValue.Value = NetValue;



                string invoice = "INSERT INTO TBL_SALES (DOCUMENTID,SALESORDER,COMPANYID,LOCATIONID,STORAGEID,TERMINALID,"+
                                                        " DOCUMENTDATE,POSTINGDATE,CUSTOMERID,DOCDETAIL,AMOUNT,DISCOUNT,NETVALUE,USERID,ADDDATE) VALUES "+
                                                        " (@DOCUMENTID,@SALESORDER,@COMPANYID,@LOCATIONID,@STORAGEID,@TERMINALID,"+
                                                        "@DOCDATE,@POSTDATE,@CUSTOMERID,@DOCDETAIL,@AMOUNT,@DISCOUNT,@NETVALUE,@USERID,@ADDDATE)";               
               

              

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                    datacon1.CmdType = CommandType.Text;
                    datacon1.CmdString = invoice;

                    datacon1.InsertRecord(spDoc, spSalesOrder, spCompanyId, spLocationId, spStorageId, spTerminalId, SpDocDate,
                                SpPostDate, spCustomerId, spDocDetail, SpAmount, SpDiscount, SpNetValue, SpUser, SpAddDate);
                    UpdateReadSales();
                    //  string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_Sales'. Cannot insert duplicate key in object 'dbo.tbl_Sales'.The statement has been terminated.";
                                    
                  
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                 string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_Sales'. Cannot insert duplicate key in object 'dbo.tbl_Sales'.\r\nThe statement has been terminated.";
                 if (_Error.Equals(_Ex))
                 {
                     UpdateReadSales();
                 }
                 else
                 {
                     throw;
                 }
               
            }



            return dtInvoice;
        }

        public void UpdateReadSales()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                    spDoc.ParameterName = "@DocumentId";
                    spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                    spDoc.Value = DocumentID;

                    string _read = "UPDATE TBL_SALES SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID";

                    dcon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    dcon.CmdType = CommandType.Text;
                    dcon.CmdString = _read;

                    dcon.InsertRecord(spDoc);

                 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }


}
