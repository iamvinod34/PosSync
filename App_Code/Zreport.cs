using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using DBConnection;
using System.Configuration;
using System.Diagnostics;
namespace PosSync.App_Code
{
    public class Zreport
    {

        MyDataConnection DbSvr = new MyDataConnection();
        DataCon CeDataCon = new DataCon();

        public string DocumentId { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string CategoryId { get; set; }
        public string UOM { get; set; }
        public string MaterialId { get; set; }
        public string SalesOrder { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string StorageId { get; set; }
        public string TerminalId { get; set; }
        public string PostingType { get; set; }
        public string CusmoterId { get; set; }
        public string Counter { get; set; }
        public string TranQty { get; set; }
        public string BaseQty { get; set; }
        public string CreditQty { get; set; }
        public string Cost { get; set; }
        public string Price { get; set; }
        public string DiscountRate { get; set; }
        public string PostKey { get; set; }
        public string AddDate { get; set; }
        public string UppDate { get; set; }
        public string ChangeAmount { get; set; }
        public string PaidAmount { get; set; }
        public string CreditAmount { get; set; }
        public string DataCon { set; get; }

        public byte[] FileByte { get; set; }
        public string EodId { get; set; }


        public void InsertSalesCategory()
        {
            try
            {

                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyId;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationId;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalId;


                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlParameter spCategoryName = new SqlParameter();
                spCategoryName.ParameterName = "@CategoryName";
                spCategoryName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryName.Value = CategoryName;

                SqlParameter spUserName = new SqlParameter();
                spUserName.ParameterName = "@UserName";
                spUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserName.Value = UserName;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAmount.Value = Amount;

                SqlParameter spDocDate = new SqlParameter();
                spDocDate.ParameterName = "@Date";
                spDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDocDate.Value = Date;

                string s = "Proc_InsertSalesCategory";

                DbSvr.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                DbSvr.CmdType = CommandType.StoredProcedure;
                DbSvr.CmdString = s;

                DbSvr.InsertRecord(spDoc, spCategoryName, spUserName, spAmount, spDocDate, spCompanyId, spLocationId, spTerminalId);
                UpdateSalesCategory();


            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "";
                if (_Error.Equals(_Ex))
                {
                    UpdateSalesCategory();
                }
                else
                {
                    throw;
                }
            }
        }

        public void UpdateSalesCategory()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlCeParameter spCategoryname = new SqlCeParameter();
                spCategoryname.ParameterName = "@CATEGORYNAME";
                spCategoryname.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryname.Value = CategoryName;

                string _read = "UPDATE TBL_SALESCATEGORY SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID and CATEGORYNAME=@CATEGORYNAME";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.InsertRecord(spDoc, spCategoryname);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertSalesDeleteLineItem()
        {
            try
            {


                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyId;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationId;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalId;

                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlParameter spCategoryId = new SqlParameter();
                spCategoryId.ParameterName = "@CategotyId";
                spCategoryId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryId.Value = CategoryId;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAmount.Value = Amount;

                SqlParameter spUom = new SqlParameter();
                spUom.ParameterName = "@UOM";
                spUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUom.Value = UOM;

                SqlParameter spMaterialId = new SqlParameter();
                spMaterialId.ParameterName = "@MaterialId";
                spMaterialId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialId.Value = MaterialId;

                SqlParameter spDocDate = new SqlParameter();
                spDocDate.ParameterName = "@Date";
                spDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spDocDate.Value = Date;

                SqlParameter spUserName = new SqlParameter();
                spUserName.ParameterName = "@UserId";
                spUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserName.Value = UserName;

                SqlParameter spAddDate = new SqlParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = Date;

                string s = "Proc_InsertSalesDeleteLineItem";

                DbSvr.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                DbSvr.CmdType = CommandType.StoredProcedure;
                DbSvr.CmdString = s;

                DbSvr.InsertRecord(spDoc, spCategoryId, spAmount, spUom, spMaterialId, spUserName, spAddDate, spDocDate, spCompanyId, spTerminalId, spLocationId);
                UpdateSalesDeleteLineItem();
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "";
                if (_Error.Equals(_Ex))
                {
                    UpdateSalesDeleteLineItem();
                }
                else
                {
                    throw;
                }
            }
        }

        public void UpdateSalesDeleteLineItem()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlCeParameter spMaterid = new SqlCeParameter();
                spMaterid.ParameterName = "@MaterialId";
                spMaterid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterid.Value = MaterialId;

                string _read = "UPDATE TBL_SALESDELETELINEITEM SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID AND MATERIALID=@MATERIALID";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.InsertRecord(spDoc, spMaterid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertsalesUnHold()
        {
            try
            {
                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlParameter spSalesOrder = new SqlParameter();
                spSalesOrder.ParameterName = "@SalesOrder";
                spSalesOrder.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSalesOrder.Value = SalesOrder;

                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyId;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationId;

                SqlParameter spStorageId = new SqlParameter();
                spStorageId.ParameterName = "@StorageId";
                spStorageId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageId.Value = StorageId;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalId;



                SqlParameter SpDocDate = new SqlParameter();
                SpDocDate.ParameterName = "@DocDate";
                SpDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SpDocDate.Value = Date;

                SqlParameter SpPostingType = new SqlParameter();
                SpPostingType.ParameterName = "@PostingType";
                SpPostingType.SqlDbType = System.Data.SqlDbType.NVarChar;
                SpPostingType.Value = PostingType;

                SqlParameter spCustomerId = new SqlParameter();
                spCustomerId.ParameterName = "@CustomerId";
                spCustomerId.SqlDbType = System.Data.SqlDbType.NVarChar;
                if (!CusmoterId.Equals(string.Empty))
                    spCustomerId.Value = CusmoterId;
                else
                    spCustomerId.Value = DBNull.Value;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                SqlParameter spCategoryID = new SqlParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryId;


                SqlParameter spMaterialID = new SqlParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialId;

                SqlParameter spUOM = new SqlParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlParameter spTranQty = new SqlParameter();
                spTranQty.ParameterName = "@TranQty";
                spTranQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTranQty.Value = TranQty;

                SqlParameter spBaseQty = new SqlParameter();
                spBaseQty.ParameterName = "@BaseQty";
                spBaseQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseQty.Value = BaseQty;

                SqlParameter spCreditQty = new SqlParameter();
                spCreditQty.ParameterName = "@CreditQty";
                spCreditQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCreditQty.Value = CreditQty;

                SqlParameter spCost = new SqlParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCost.Value = Cost;

                SqlParameter spPrice = new SqlParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPrice.Value = Price;

                SqlParameter spDiscountRate = new SqlParameter();
                spDiscountRate.ParameterName = "@DiscountRate";
                spDiscountRate.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDiscountRate.Value = DiscountRate;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAmount.Value = Amount;

                SqlParameter spCreditAmount = new SqlParameter();
                spCreditAmount.ParameterName = "@CreditAmount";
                spCreditAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCreditAmount.Value = CreditAmount;

                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserName;

                SqlParameter spPostKey = new SqlParameter();
                spPostKey.ParameterName = "@PostKey";
                spPostKey.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPostKey.Value = PostKey;

                SqlParameter spAddDate = new SqlParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = AddDate;

                SqlParameter spUpdDate = new SqlParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = UppDate;

                string s = "Proc_InsertsalesUnHold";

                DbSvr.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                DbSvr.CmdType = CommandType.StoredProcedure;
                DbSvr.CmdString = s;

                DbSvr.InsertRecord(spDoc, spSalesOrder, spCompanyId, spLocationId, spStorageId, spTerminalId, SpDocDate,
                    SpPostingType, spCustomerId, spCounter, spCategoryID, spMaterialID, spUOM, spTranQty, spBaseQty, spCreditQty, spCost,
                    spPrice, spDiscountRate, spAmount, spCreditAmount, spUserID, spPostKey, spAddDate, spUpdDate);
                UpdateSalesUnHold();

            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "";
                if (_Error.Equals(_Ex))
                {
                    UpdateSalesUnHold();
                }
                else
                {
                    throw;
                }
            }
        }

        public void UpdateSalesUnHold()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlCeParameter spMaterid = new SqlCeParameter();
                spMaterid.ParameterName = "@MaterialId";
                spMaterid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterid.Value = MaterialId;

                SqlCeParameter spCounter = new SqlCeParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                string _read = "UPDATE TBL_SALESUNHOLD SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID AND MATERIALID=@MATERIALID AND COUNTER=@COUNTER";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.InsertRecord(spDoc, spMaterid, spCounter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertSalesUserTender_Detail()
        {
            try
            {

                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyId;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationId;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalId;

                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserName;

                SqlParameter spAmount = new SqlParameter();
                spAmount.ParameterName = "@Amount";
                spAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAmount.Value = Amount;

                SqlParameter SpDocDate = new SqlParameter();
                SpDocDate.ParameterName = "@DocDate";
                SpDocDate.SqlDbType = System.Data.SqlDbType.DateTime;
                SpDocDate.Value = Date;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalId";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalId;

                SqlParameter spChangeAmount = new SqlParameter();
                spChangeAmount.ParameterName = "@ChangeAmount";
                spChangeAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spChangeAmount.Value = ChangeAmount;

                SqlParameter spPaidAmount = new SqlParameter();
                spPaidAmount.ParameterName = "@PaidAmount";
                spPaidAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPaidAmount.Value = PaidAmount;




                string s = "Proc_InsertSalesUserTender_Detail";

                DbSvr.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                DbSvr.CmdType = CommandType.StoredProcedure;
                DbSvr.CmdString = s;

                DbSvr.InsertRecord(spDoc, spUserID, spTerminalID, spAmount, SpDocDate, spCounter, spChangeAmount, spPaidAmount, spCompanyId, spLocationId);
                UpdateSalesTender_Detail();
            }
            catch (Exception ex)
            {
                string _Ex = ex.Message;
                string _Error = "";
                if (_Error.Equals(_Ex))
                {
                    UpdateSalesTender_Detail();
                }
                else
                {
                    throw;
                }
            }
        }

        public void UpdateSalesTender_Detail()
        {
            try
            {
                SqlCeParameter spDoc = new SqlCeParameter();
                spDoc.ParameterName = "@DocumentId";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentId;

                SqlCeParameter spCounter = new SqlCeParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCounter.Value = Counter;

                string _read = "UPDATE TBL_SALESUSERTENDER_DETAIL SET ConRead='True' WHERE DOCUMENTID=@DOCUMENTID AND COUNTER=@COUNTER";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.InsertRecord(spDoc, spCounter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public DataTable GetSalesCategory()
        {
            DataTable dtSalesCategory = null;
            try
            {
                string _read = "SELECT * FROM TBL_SALESCATEGORY WHERE CONREAD='FALSE'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                dtSalesCategory = CeDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dtSalesCategory;
        }

        public DataTable GetDeleteLineItem()
        {
            DataTable dtDeleteLineItem = null;
            try
            {
                string _read = "SELECT * FROM TBL_SALESDELETELINEITEM WHERE CONREAD='FALSE'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                dtDeleteLineItem = CeDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dtDeleteLineItem;
        }

        public DataTable GetUnHold()
        {
            DataTable dtUnHold = null;
            try
            {
                string _read = "SELECT * FROM TBL_SALESUNHOLD WHERE CONREAD='FALSE'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                dtUnHold = CeDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dtUnHold;
        }

        public DataTable GetUserTender_Detail()
        {
            DataTable dtTenderdtls = null;
            try
            {
                string _read = "SELECT * FROM TBL_SALESUSERTENDER_DETAIL WHERE CONREAD='FALSE'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                dtTenderdtls = CeDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dtTenderdtls;
        }




        public void DeleteSalesCategory()
        {
            try
            {
                string _read = "DELETE FROM TBL_SALESCATEGORY WHERE ZREPORT='True'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.DeleteRecord();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteSalesCategory : " + ex.StackTrace);
            }
        }

        public void DeleteSalesDeleteLineItem()
        {
            try
            {
                string _read = "DELETE FROM TBL_SALESDELETELINEITEM WHERE ZREPORT='True'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.DeleteRecord();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteSalesDeleteLineItem : " + ex.StackTrace);
            }
        }

        public void DeleteUnhold()
        {
            try
            {
                string _read = "DELETE FROM TBL_SALESUNHOLD WHERE ZREPORT='True'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.DeleteRecord();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteUnhold : " + ex.StackTrace);
            }
        }

        public void DeleteTender_Detail()
        {
            try
            {
                string _read = "DELETE FROM TBL_SALESUSERTENDER_DETAIL WHERE ZREPORT='True'";

                CeDataCon.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                CeDataCon.CmdType = CommandType.Text;
                CeDataCon.CmdString = _read;

                CeDataCon.DeleteRecord();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteTender_Detail zreport : " + ex.StackTrace);
            }
        }

        public void InsertEODFile()
        {
            try
            {

                SqlParameter spCompanyId = new SqlParameter();
                spCompanyId.ParameterName = "@CompanyId";
                spCompanyId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyId.Value = CompanyId;

                SqlParameter spLocationId = new SqlParameter();
                spLocationId.ParameterName = "@LocationId";
                spLocationId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationId.Value = LocationId;

                SqlParameter spTerminalId = new SqlParameter();
                spTerminalId.ParameterName = "@TerminalId";
                spTerminalId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalId.Value = TerminalId;

                SqlParameter spEodId = new SqlParameter();
                spEodId.ParameterName = "@EodId";
                spEodId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEodId.Value = EodId;

                SqlParameter spFileByte = new SqlParameter();
                spFileByte.ParameterName = "@FileByte";
                spFileByte.SqlDbType = System.Data.SqlDbType.Binary;
                spFileByte.Value = FileByte;

                string _read = "Proc_InsertEODFile";

                DbSvr.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ToString();
                DbSvr.CmdType = CommandType.StoredProcedure;
                DbSvr.CmdString = _read;

                DbSvr.InsertRecord(spLocationId, spTerminalId, spFileByte, spCompanyId, spEodId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
