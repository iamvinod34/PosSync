using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
using PosSync.App_Code;
using DBConnection;
using System.Transactions;


namespace PosSync.App_Code
{
    public class InvoiceDtls
    {
        MyDataConnection dcon = new MyDataConnection();
        DataCon objDcon = new DataCon();


        #region "Properties"

        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }
        public string TerminalID { get; set; }
        public string PostingType { get; set; }


        public string SalesOrder { set; get; }
        public string CustomerID { get; set; }
        public string CategoryID { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public string UserID { get; set; }
        public string MyProperty { get; set; }

        public DateTime DocumentDate { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdDate { get; set; }

        public int Counter { get; set; }
        public int PostKey { get; set; }

        public decimal TranQty { get; set; }
        public decimal BaseQty { get; set; }
        public decimal CreditQty { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Amount { get; set; }
        public decimal CreditAmount { get; set; }

        public string Datacon { get; set; }

        public string OrderNo{ get; set; }
        public string Sales_Comm { get;  set; }
        public string Produc_Comm { get;  set; }
        public decimal TaxAmount { get;  set; }
        public decimal CostAmount { get;  set; }
        public string OrderUsername { get; internal set; }
        public string OrderTransQty { get; internal set; }
        public string OrderBaseQty { get; internal set; }

        #endregion

        #region "Functions"

        public void InsertInvoiceDtls()
        {
            try
            {
                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentID";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spStorageID = new SqlParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.Int;
                spCounter.Value = Counter;

                SqlParameter spSalesOrder = new SqlParameter();
                spSalesOrder.ParameterName = "@SalesOrder";
                spSalesOrder.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSalesOrder.Value = SalesOrder;

                SqlParameter spCompanyID = new SqlParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = CompanyID;

                SqlParameter spDoumentDate = new SqlParameter();
                spDoumentDate.ParameterName = "@DocumentDate";
                spDoumentDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDoumentDate.Value = DocumentDate;

                SqlParameter spPostingType = new SqlParameter();
                spPostingType.ParameterName = "@PostingType";
                spPostingType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPostingType.Value = PostingType;

                SqlParameter spCustomerID = new SqlParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                if (!CustomerID.Equals(string.Empty))
                    spCustomerID.Value = CustomerID;
                else
                    spCustomerID.Value = DBNull.Value;

                SqlParameter spCategoryID = new SqlParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryID;


                SqlParameter spMaterialID = new SqlParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlParameter spUOM = new SqlParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlParameter spTranQty = new SqlParameter();
                spTranQty.ParameterName = "@TranQty";
                spTranQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spTranQty.Value = TranQty;

                SqlParameter spBaseQty = new SqlParameter();
                spBaseQty.ParameterName = "@BaseQty";
                spBaseQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spBaseQty.Value = BaseQty;

                SqlParameter spCreditQty = new SqlParameter();
                spCreditQty.ParameterName = "@CreditQty";
                spCreditQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditQty.Value = CreditQty;

                SqlParameter spCost = new SqlParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = Cost;

                SqlParameter spPrice = new SqlParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.Decimal;
                spPrice.Value = Price;

                SqlParameter spDiscountRate = new SqlParameter();
                spDiscountRate.ParameterName = "@DiscountRate";
                spDiscountRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spDiscountRate.Value = DiscountRate;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spAmount.Value = Amount;

                SqlParameter spCreditAmount = new SqlParameter();
                spCreditAmount.ParameterName = "@CreditAmount";
                spCreditAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditAmount.Value = CreditAmount;

                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserID;

                SqlParameter spPostKey = new SqlParameter();
                spPostKey.ParameterName = "@PostKey";
                spPostKey.SqlDbType = System.Data.SqlDbType.Int;
                spPostKey.Value = PostKey;

                SqlParameter spAddDate = new SqlParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = AddDate;

                SqlParameter spUpdDate = new SqlParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = UpdDate;

                SqlParameter spPostingDate = new SqlParameter();
                spPostingDate.ParameterName = "@PostingDate";
                spPostingDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spPostingDate.Value = DocumentDate;

                SqlParameter spOrderNo = new SqlParameter();
                spOrderNo.ParameterName = "@OrderNo";
                spOrderNo.SqlDbType = System.Data.SqlDbType.NVarChar;
                spOrderNo.Value = OrderNo;

                SqlParameter spSalesComm = new SqlParameter();
                spSalesComm.ParameterName = "@SalesComm";
                spSalesComm.SqlDbType = System.Data.SqlDbType.Decimal;
                spSalesComm.Value = Sales_Comm;

                SqlParameter spProducComm = new SqlParameter();
                spProducComm.ParameterName = "@ProducComm";
                spProducComm.SqlDbType = System.Data.SqlDbType.Decimal;
                spProducComm.Value = Produc_Comm;

                SqlParameter spTax = new SqlParameter();
                spTax.ParameterName = "@Tax";
                spTax.SqlDbType = System.Data.SqlDbType.Decimal;
                spTax.Value = TaxAmount;

                SqlParameter spCostAmount = new SqlParameter();
                spCostAmount.ParameterName = "@CostAmount";
                spCostAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spCostAmount.Value = CostAmount;

                SqlParameter spOrderUserName = new SqlParameter();
                spOrderUserName.ParameterName = "@OrderUserName";
                spOrderUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spOrderUserName.Value = OrderUsername;

                SqlParameter spOrderTransQty = new SqlParameter();
                spOrderTransQty.ParameterName = "@OrderTransQty";
                spOrderTransQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spOrderTransQty.Value = OrderTransQty;

                SqlParameter spOrderBaseQty = new SqlParameter();
                spOrderBaseQty.ParameterName = "@OrderBaseQty";
                spOrderBaseQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spOrderBaseQty.Value = OrderBaseQty;

                string InvoiceDtls = "INSERT INTO TBL_SALES_DETAIL(DOCUMENTID,COMPANYID,LOCATIONID,STORAGEID,TERMINALID,DOCUMENTDATE,POSTINGTYPE,CUSTOMERID,COUNTER,CATEGORYID,MATERIALID,POSTINGDATE,UOM," +
                " TRANQTY,BASEQTY,CREDITQTY,COST,PRICE,DISCOUNTRATE,AMOUNT,CREDITAMOUNT,USERID,POSTKEY,ADDDATE,UPDDATE,RtnQty,OrderNo,Sales_CommAmount,Produc_CommAmount,TaxAmount,CostAmount,OrderUserName,OrderTransQty,OrderBaseQty)"+
                " VALUES(@DOCUMENTID,@COMPANYID,@LOCATIONID,@STORAGEID,@TERMINALID,@DOCUMENTDATE," +
                                    " @POSTINGTYPE,@CUSTOMERID,@COUNTER,@CATEGORYID,@MATERIALID,@POSTINGDATE,@UOM," +
                                    " @TRANQTY,@BASEQTY,@CREDITQTY,@COST,@PRICE,@DISCOUNTRATE,@AMOUNT,@CREDITAMOUNT,@USERID,@POSTKEY,@ADDDATE," +
                                    " @UPDDATE,0,@OrderNo,@SalesComm,@ProducComm,@Tax,@CostAmount,@OrderUserName,@OrderTransQty,@OrderBaseQty)";

                dcon.ConString = Datacon;
                dcon.CmdType = CommandType.Text;
                dcon.CmdString = InvoiceDtls;

                    dcon.InsertRecord(spDoc, spCompanyID, spLocationID, spStorageID, spTerminalID, spDoumentDate, spPostingType, spCustomerID, spCounter, spCategoryID, spMaterialID, spPostingDate,
                        spUOM, spTranQty, spBaseQty, spCreditQty, spCost, spPrice, spDiscountRate, spAmount, spCreditAmount, spUserID, spPostKey, spAddDate, spUpdDate,spOrderNo,spSalesComm,spProducComm,spTax,spCostAmount,
                        spOrderUserName, spOrderTransQty, spOrderBaseQty);
                    UpdateReadSalesdtls();
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_Sales_Detail'. Cannot insert duplicate key in object 'dbo.tbl_Sales_Detail'.\r\nThe statement has been terminated.";
                if (_Error.Equals(_Ex))
                {
                    UpdateReadSalesdtls();
                }
                else
                {
                    throw;
                }

            }
        }

        public void UpdateReadSalesdtls()
        {
            try
            {
               SqlCeParameter spDoc = new SqlCeParameter();
                    spDoc.ParameterName = "@DocumentId";
                    spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                    spDoc.Value = DocumentID;

                    string _read = "UPDATE TBL_SALES_DETAIL SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID";

                    objDcon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    objDcon.CmdType = CommandType.Text;
                    objDcon.CmdString = _read;

                    objDcon.InsertRecord(spDoc);
                   
            }
            catch (Exception ex)
            {

            }
        }

        public void InsertInvoiceDtls_Copy()
        {
            try
            {
                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentID";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spStorageID = new SqlParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                SqlParameter spSalesOrder = new SqlParameter();
                spSalesOrder.ParameterName = "@SalesOrder";
                spSalesOrder.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSalesOrder.Value = SalesOrder;

                SqlParameter spCompanyID = new SqlParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = CompanyID;

                SqlParameter spDoumentDate = new SqlParameter();
                spDoumentDate.ParameterName = "@DocumentDate";
                spDoumentDate.SqlDbType = System.Data.SqlDbType.Date;
                spDoumentDate.Value = DocumentDate;

                SqlParameter spPostingType = new SqlParameter();
                spPostingType.ParameterName = "@PostingType";
                spPostingType.SqlDbType = System.Data.SqlDbType.Date;
                spPostingType.Value = PostingType;

                SqlParameter spCoustomerID = new SqlParameter();
                spCoustomerID.ParameterName = "@CustomerID";
                spCoustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCoustomerID.Value = CustomerID;

                SqlParameter spCategoryID = new SqlParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryID;


                SqlParameter spMaterialID = new SqlParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.Decimal;
                spMaterialID.Value = CustomerID;

                SqlParameter spUOM = new SqlParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlParameter spTranQty = new SqlParameter();
                spTranQty.ParameterName = "@TranQty";
                spTranQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spTranQty.Value = TranQty;

                SqlParameter spBaseQty = new SqlParameter();
                spBaseQty.ParameterName = "@BaseQty";
                spBaseQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spBaseQty.Value = BaseQty;

                SqlParameter spCreditQty = new SqlParameter();
                spCreditQty.ParameterName = "@CreditQty";
                spCreditQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditQty.Value = CreditQty;

                SqlParameter spCost = new SqlParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = Cost;

                SqlParameter spPrice = new SqlParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.Decimal;
                spPrice.Value = Price;

                SqlParameter spDiscountRate = new SqlParameter();
                spDiscountRate.ParameterName = "@DiscountRate";
                spDiscountRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spDiscountRate.Value = DiscountRate;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spAmount.Value = Amount;

                SqlParameter spCreditAmount = new SqlParameter();
                spCreditAmount.ParameterName = "@CreditAmount";
                spCreditAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditAmount.Value = CreditAmount;

                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserID;

                SqlParameter spPostKey = new SqlParameter();
                spPostKey.ParameterName = "@PostKey";
                spPostKey.SqlDbType = System.Data.SqlDbType.Int;
                spPostKey.Value = PostKey;

                SqlParameter spAddDate = new SqlParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = AddDate;

                SqlParameter spUpdDate = new SqlParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = UpdDate;


                string InvoiceDtls = "INSERT INTO TBL_SALES_DETAIL_COPY VALUES(@DOCUMENTID,@LOCATIONID,@STORAGEID,@TERMINALID," +
                                    " @COUNTER,@SALESORDER,@COMPANYID,@DOCUMENTDATE,@POSTINGTYPE,@CUSTOMERID,@CATEGORYID,@MATERIALID,@UOM," +
                                    " @TRANQTY,@BASEQTY,@CREDITQTY,@COST,@PRICE,@DISCOUNTRATE,@AMOUNT,@CREDITAMOUNT,@USERID,@POSTKEY,@ADDDATE," +
                                    " @UPDDATE)";

                dcon.ConString = Datacon;
                dcon.CmdType = CommandType.Text;
                dcon.CmdString = InvoiceDtls;

                dcon.InsertRecord(DocumentID, LocationID, StorageID, TerminalID, Counter, SalesOrder, CompanyID, DocumentDate,
                                  PostingType, CustomerID, CategoryID, MaterialID, UOM, TranQty, BaseQty, CreditQty, Cost, Price,
                                  DiscountRate, Amount, CreditAmount, UserID, PostKey, AddDate, UpdDate);



            }
            catch (Exception ex)
            {
            }
        }

        public DataTable SearchInvoiceDtls()
        {
            DataTable dtInvoice = null;

            try
            {
            }
            catch (Exception ex)
            {
            }

            return dtInvoice;
        }

        public void UpdateInvoiceDtls()
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteInvoiceDtls()
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertOrderDetils()
        {
            try
            {
                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentID";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spStorageID = new SqlParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.Int;
                spCounter.Value = Counter;

                SqlParameter spSalesOrder = new SqlParameter();
                spSalesOrder.ParameterName = "@SalesOrder";
                spSalesOrder.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSalesOrder.Value = SalesOrder;

                SqlParameter spCompanyID = new SqlParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = CompanyID;

                SqlParameter spDoumentDate = new SqlParameter();
                spDoumentDate.ParameterName = "@DocumentDate";
                spDoumentDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDoumentDate.Value = DocumentDate;

                SqlParameter spPostingType = new SqlParameter();
                spPostingType.ParameterName = "@PostingType";
                spPostingType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPostingType.Value = PostingType;

                SqlParameter spCustomerID = new SqlParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                if (!CustomerID.Equals(string.Empty))
                    spCustomerID.Value = CustomerID;
                else
                    spCustomerID.Value = DBNull.Value;

                SqlParameter spCategoryID = new SqlParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryID;


                SqlParameter spMaterialID = new SqlParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlParameter spUOM = new SqlParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlParameter spTranQty = new SqlParameter();
                spTranQty.ParameterName = "@TranQty";
                spTranQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spTranQty.Value = TranQty;

                SqlParameter spBaseQty = new SqlParameter();
                spBaseQty.ParameterName = "@BaseQty";
                spBaseQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spBaseQty.Value = BaseQty;

                SqlParameter spCreditQty = new SqlParameter();
                spCreditQty.ParameterName = "@CreditQty";
                spCreditQty.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditQty.Value = CreditQty;

                SqlParameter spCost = new SqlParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = Cost;

                SqlParameter spPrice = new SqlParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.Decimal;
                spPrice.Value = Price;

                SqlParameter spDiscountRate = new SqlParameter();
                spDiscountRate.ParameterName = "@DiscountRate";
                spDiscountRate.SqlDbType = System.Data.SqlDbType.Decimal;
                spDiscountRate.Value = DiscountRate;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spAmount.Value = Amount;

                SqlParameter spCreditAmount = new SqlParameter();
                spCreditAmount.ParameterName = "@CreditAmount";
                spCreditAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditAmount.Value = CreditAmount;

                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserID;

                SqlParameter spPostKey = new SqlParameter();
                spPostKey.ParameterName = "@PostKey";
                spPostKey.SqlDbType = System.Data.SqlDbType.Int;
                spPostKey.Value = PostKey;

                SqlParameter spAddDate = new SqlParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = AddDate;

                SqlParameter spUpdDate = new SqlParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = UpdDate;

                SqlParameter spPostingDate = new SqlParameter();
                spPostingDate.ParameterName = "@PostingDate";
                spPostingDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spPostingDate.Value = DocumentDate;


                string InvoiceDtls = "Proc_InsertOrderDetails";

                dcon.ConString = Datacon;
                dcon.CmdType = CommandType.StoredProcedure;
                dcon.CmdString = InvoiceDtls;

                dcon.InsertRecord(spDoc, spCompanyID, spLocationID, spStorageID, spTerminalID, spDoumentDate, spPostingType, spCustomerID, spCounter, spCategoryID, spMaterialID, spPostingDate,
                    spUOM, spTranQty, spBaseQty, spCreditQty, spCost, spPrice, spDiscountRate, spAmount, spCreditAmount, spUserID, spPostKey, spAddDate, spUpdDate);
                UpdateReadOrderdtls();
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "Violation of PRIMARY KEY constraint 'PK_tbl_Sales_Detail'. Cannot insert duplicate key in object 'dbo.tbl_Sales_Detail'.\r\nThe statement has been terminated.";
                if (_Error.Equals(_Ex))
                {
                    UpdateReadOrderdtls();
                }
                else
                {
                    throw;
                }
            }
        }
        public void UpdateReadOrderdtls()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlCeParameter spCounter = new SqlCeParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                string _read = "UPDATE TBL_ORDER_DETAILS SET CONREAD='TRUE' WHERE DOCUMENTID=@DOCUMENTID AND COUNTER=@COUNTER";

                objDcon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                objDcon.CmdType = CommandType.Text;
                objDcon.CmdString = _read;

                objDcon.InsertRecord(spDoc,spCounter);

            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
