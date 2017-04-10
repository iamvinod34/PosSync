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

namespace PosSync.App_Code
{
  public  class PhysicalInventory
    {

      MyDataConnection datacon1 = new MyDataConnection();
        DataCon objDataCon = new DataCon();

        #region "Properties"

        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }

        public string PostingType { get; set; }
        public decimal ConvertFactor { set; get; }

        public string VendorId { set; get; }

        public string CategoryID { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public string UserID { get; set; }
        public string Filter { get; set; }

        public string FilterId { get; set; }

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

        public decimal DiscountRate { get; set; }
        public decimal Amount { get; set; }
        public decimal CreditAmount { get; set; }

        public string OrderQty { get; set; }
        public string RecQty { get; set; }

        public string Datacon { get; set; }

        public int RtnQty { set; get; }
        public bool PoStatus { set; get; }

        public int CategoryId { get; set; }

        public string PONumber { get; set; }

        #endregion

        public DataTable LoadNotInStockPhysical()
        {
            DataTable dtLoadstock=null;
            try
            {
                string s = "Proc_Sync_PhysicalInventoryNotIn";

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.StoredProcedure;
                datacon1.CmdString = s;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spDocid = new SqlParameter();
                spDocid.ParameterName = "@DocumentId";
                spDocid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocid.Value = DocumentID;

                SqlParameter spFilter = new SqlParameter();
                spFilter.ParameterName = "@Fillter";
                spFilter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFilter.Value = Filter;

                SqlParameter spStrageId = new SqlParameter();
                spStrageId.ParameterName = "@StorageId";
                spStrageId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStrageId.Value =StorageID;

                dtLoadstock = datacon1.LoadDataSet(spLocationID, spDocid, spFilter,spStrageId).Tables[0];

            }
            catch (Exception ex)
            {

            }
            return dtLoadstock;
        }

        public DataTable LoadPhysicalInventoryDocument()
        {
            DataTable dtPhyDocument = null;
            try
            {
                string s = "Select * from tbl_PhyInventory where LocationId=@LocationId and Status='False'";

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;

                dtPhyDocument = datacon1.LoadDataSet(spLocationID).Tables[0];

            }
            catch (Exception ex)
            {

            }

            return dtPhyDocument;
        }

        public void Detail()
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

                SqlParameter spVendorId = new SqlParameter();
                spVendorId.ParameterName = "@VendorId";
                spVendorId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorId.Value = VendorId;

                SqlParameter spCounter = new SqlParameter();
                spCounter.ParameterName = "@Counter";
                spCounter.SqlDbType = System.Data.SqlDbType.Int;
                spCounter.Value = Counter;

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
                spBaseQty.ParameterName = "@EntryBaseQty";
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
                spPostingDate.Value = PostingDate;

                SqlParameter spconvertFactor = new SqlParameter();
                spconvertFactor.ParameterName = "@ConvertFactor";
                spconvertFactor.SqlDbType = System.Data.SqlDbType.Decimal;
                spconvertFactor.Value = ConvertFactor;



                string TransferDtls = "Proc_PhyInventory_Detail";//Proc_TransferDisplay_Ent_In_Out

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.StoredProcedure;
                datacon1.CmdString = TransferDtls;

                datacon1.InsertRecord(spDoc, spCompanyID, spLocationID, spStorageID, spDoumentDate, spPostingDate,
                    spMaterialID, spBaseQty, spAddDate, spUpdDate, spCategoryID, spUserID, spconvertFactor);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateStatusPhy()
        {
            try
            {
                string s = "Update tbl_PhyInventory set Status='True'  where Locationid=@LocationId and DocumentId=@LocationId";

                SqlParameter spDoc = new SqlParameter();
                spDoc.ParameterName = "@DocumentID";
                spDoc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDoc.Value = DocumentID;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;

                datacon1.InsertRecord(spDoc, spLocationID);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
