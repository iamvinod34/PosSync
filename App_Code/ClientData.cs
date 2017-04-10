using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using DBConnection;
using System.Configuration;
namespace PosSync.App_Code
{
    public class ClientData
    {
        DataCon objDB = new DataCon();

        #region "Properties"

        public string Dcon { get; set; }

        public string InvoiceId { get; set; }

        public string EAN13 { get; set; }

        public string LocationID { get; set; }
        public string MaterialID { set; get; }
        public string MasterSyncDate { get; set; }
        public string NewMasterSyncDate { get; set; }
        public string UserID { set; get; }
        public string CategoryID { set; get; }
        public string SubCategoryID { set; get; }
        public string CurrencyID { set; get; }
        public string CustomerID { set; get; }
        public string CityID { set; get; }
        public string CompanyID { set; get; }
        public string StorageID { set; get; }
        public string TenderID { set; get; }
        public string UOM { set; get; }
        public string VendorID { set; get; }

        #endregion

        #region "Functions"

        public DataTable LoadInvoices()
        {
            DataTable dt_invc = null;

            try
            {
                string s = "SELECT * FROM TBL_SALES";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_invc = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt_invc;
        }
        public DataTable GetMasterDate()
        {
            DataTable dt_date = null;
            try
            {
                string s = "select * from tbl_Default";
                objDB.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString ;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_date = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_date;
        }
        public void UpdateMasterSyncDate()
        {
            try
            {
                string s = "update tbl_Default set MasterSyncDate=@NewMasterSyncDate";

                SqlCeParameter spNewMasteSyncDate = new SqlCeParameter();
                spNewMasteSyncDate.ParameterName = "@NewMasterSyncDate";
                spNewMasteSyncDate.SqlDbType = System.Data.SqlDbType.NVarChar;
                spNewMasteSyncDate.Value = this.NewMasterSyncDate;
               
                objDB.ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spNewMasteSyncDate);
            
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable LoadInvoiceDtls()
        {
            DataTable dt_invcdtls = null;

            try
            {
                string s = "SELECT * FROM TBL_SALES_DETAIL";

                SqlCeParameter spDocumentid = new SqlCeParameter();
                spDocumentid.ParameterName = "@DocumentID";
                spDocumentid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentid.Value = this.InvoiceId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_invcdtls = objDB.LoadDataSet().Tables[0];


            }
            catch (Exception ex)
            {
            }

            return dt_invcdtls;
        }

        public DataTable LoadOrderDtls()
        {
            DataTable dt_invcdtls = null;

            try
            {
                string s = "SELECT * FROM tbl_Order_Details where ConRead='Flase'";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_invcdtls = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt_invcdtls;
        }

        public DataTable LoadTenderDtls()
        {
            DataTable dt_tenderdtls = null;

            try
            {
                string s = "SELECT * FROM TBL_TENDER_DETAIL ";

                SqlCeParameter spDocumentid = new SqlCeParameter();
                spDocumentid.ParameterName = "@DocumentID";
                spDocumentid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentid.Value = this.InvoiceId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_tenderdtls = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt_tenderdtls;
        }

        public void DeleteTenderDtls()
        {
            try
            {
                string s = "DELETE FROM TBL_TENDER_DETAIL WHERE DOCUMENTID=@DOCUMENTID";

                SqlCeParameter spDocumentid = new SqlCeParameter();
                spDocumentid.ParameterName = "@DocumentID";
                spDocumentid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentid.Value = this.InvoiceId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord(spDocumentid);



            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteInvoiceDtls()
        {          
            try
            {
                string s = "DELETE FROM TBL_SALES_DETAIL WHERE DOCUMENTID=@DOCUMENTID";

                SqlCeParameter spDocumentid = new SqlCeParameter();
                spDocumentid.ParameterName = "@DocumentID";
                spDocumentid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentid.Value = this.InvoiceId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord(spDocumentid);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteInvoice()
        {
            try
            {
                string s = "DELETE FROM TBL_SALES WHERE DOCUMENTID=@DocumentID";

                SqlCeParameter spDocumentid = new SqlCeParameter();
                spDocumentid.ParameterName = "@DocumentID";
                spDocumentid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDocumentid.Value = this.InvoiceId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord(spDocumentid);

            }
            catch (Exception ex)
            {

            } 
        }
        public DataTable LoadMaterialEAN()
        {
            DataTable dt_mat = null;
            try
            {
                string s = "SELECT * FROM TBL_MATERIALEAN WHERE EAN13=@EAN13";
                
                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_mat = objDB.LoadDataSet(spEAN13).Tables[0];

            }
            catch (Exception ex)
            {

            }
            return dt_mat;
        }
        
        public void DeleteMaterialEAN()
        {
            try
            {
                string s = "DELETE FROM TBL_MATERIALEAN_TEMP";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable LoadLocationprice()
        {
            DataTable dt_loc = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "select * from tbl_LocationPrice where LocationID=@LocationID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_loc = objDB.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_loc;
        }
        public DataTable LoadPriceFile()
        {
            DataTable dt_loadprice = null;
            try
            {
                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                string s = "SELECT * FROM TBL_PRICEFILE WHERE EAN13=@EAN13";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_loadprice = objDB.LoadDataSet(spEAN13).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_loadprice;
        }
        public DataTable LoadMaterial()
        {
            DataTable dt_material = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                string s = "select * from tbl_material where MaterialID=@MaterialID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_material=objDB.LoadDataSet(spMaterialID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_material;
        }
        public DataTable LoadUsers()
        {
            DataTable dt_users = null;
            try
            {
                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = this.UserID;

                string s = "select * from tbl_users where UserID=@UserID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_users = objDB.LoadDataSet(spUserID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_users;
        }
        public DataTable LoadLocation()
        {
            DataTable dt_location = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "select * from tbl_location where LocationID=@LocationID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_location = objDB.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_location;
        }
        public DataTable LoadCategory()
        {
            DataTable dt_cat = null;
            try
            {
                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                string s = "select * from tbl_category where CategoryID=@CategoryID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_cat=objDB.LoadDataSet(spCategoryID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_cat;
        }
        public DataTable LoadSubCategory()
        {
            DataTable dt_Subcat = null;
            try
            {
                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                string s = "select * from tbl_Subcategory where SubCategoryID=@SubCategoryID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_Subcat = objDB.LoadDataSet(spSubCategoryID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_Subcat;
        }
        public DataTable LoadPreferUOM()
        {
            DataTable dt_prefer = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                string s = "select * from tbl_PreferUOM where MaterialID=@MaterialID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_prefer = objDB.LoadDataSet(spMaterialID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_prefer;
        }
        public DataTable LoadCurency()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCurrencyID = new SqlCeParameter();
                spCurrencyID.ParameterName = "@CurrencyID";
                spCurrencyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyID.Value = this.CurrencyID;

                string s = "select * from tbl_Currency where CurrencyID=@CurrencyID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_curr = objDB.LoadDataSet(spCurrencyID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_curr;
        }
        public DataTable LoadCustomer()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = this.CustomerID;

                string s = "select * from tbl_Customer where CustomerID=@CustomerID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_curr = objDB.LoadDataSet(spCustomerID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_curr;
        }
        public DataTable LoadCompany()
        {
            DataTable dt_curr = null;
            try
            {
                SqlCeParameter spCompanyID = new SqlCeParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = this.CompanyID;

                string s = "select * from tbl_Company where CompanyID=@CompanyID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_curr = objDB.LoadDataSet(spCompanyID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_curr;
        }
        public DataTable LoadCity()
        {
            DataTable dt_city = null;
            try
            {
                SqlCeParameter spCityID = new SqlCeParameter();
                spCityID.ParameterName = "@CityID";
                spCityID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityID.Value = this.CityID;

                string s = "select * from tbl_City where CityID=@CityID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_city = objDB.LoadDataSet(spCityID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_city;
        }
        public DataTable LoadStorage()
        {
            DataTable dt_st = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "select * from tbl_Storage where LocationID=@LocationID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_st = objDB.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_st;
        }
        public DataTable LoadTender()
        {
            DataTable dt_ten = null;
            try
            {
                SqlCeParameter spTenderID = new SqlCeParameter();
                spTenderID.ParameterName = "@TenderID";
                spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTenderID.Value = this.TenderID;

                string s = "select * from tbl_tender where TenderID=@TenderID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_ten = objDB.LoadDataSet(spTenderID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_ten;
        }
        public DataTable LoadTerminal()
        {
            DataTable dt_ten = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "select * from tbl_terminal where LocationID=@LocationID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_ten = objDB.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_ten;
        }
        public DataTable LoadUOM()
        {
            DataTable dt_ten = null;
            try
            {
                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                string s = "select * from tbl_UOM where UOM=@UOM";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_ten = objDB.LoadDataSet(spUOM).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_ten;
        }
        public DataTable LoadVendor()
        {
            DataTable dt_ten = null;
            try
            {
                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;

                string s = "select * from tbl_Vendor where VendorID=@VendorID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_ten = objDB.LoadDataSet(spVendorID).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt_ten;
        }

        public void DeleteLocationPrice()
        {
            try
            {
                string s = "DELETE FROM TBL_LOCATIONPRICE_TEMP";
                //SqlCeParameter spLocationID = new SqlCeParameter();
                //spLocationID.ParameterName = "@LocationID";
                //spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                //spLocationID.Value = this.LocationID;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeletePriceFile()
        {
            try
            {
                string s = "DELETE FROM TBL_PRICEFILE_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }

        }
        public void DeleteMaterial()
        {
            try
            {
                string s = "DELETE FROM TBL_MATERIAL_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }

        }
        public void DeleteUsers()
        {
            try
            {
                string s = "DELETE FROM TBL_USERS_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {
               
            }
        }
        public void DeleteLocation()
        {
            try
            {
                string s = "DELETE FROM TBL_LOCATION_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteCategory()
        {
            try
            {
                string s = "DELETE FROM TBL_CATEGORY_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteSubCategory()
        {
            try
            {
                string s = "DELETE FROM TBL_SUBCATEGORY_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeletePreferUOM()
        {
            try
            {
                string s = "DELETE FROM TBL_PREFERUOM_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteCurrency()
        {
            try
            {
                string s = "DELETE FROM TBL_CURRENCY_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteCustomer()
        {
            try
            {
                string s = "DELETE FROM TBL_CUSTOMER_TEMP";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteSalesArchive()
        {
            try
            {
                string s = "DELETE FROM TBL_SALES_ARCHIVE WHERE DOCUMENTDATE < GETDATE()-10";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteSalesDetailArchive()
        {
            try
            {
                string s = "DELETE FROM TBL_SALES_DETAIL_ARCHIVE WHERE DOCUMENTDATE < GETDATE()-10";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteTenderDetailArchive()
        {
            try
            {
                string s = "DELETE FROM TBL_TENDER_DETAIL_ARCHIVE WHERE DOCUMENTDATE < GETDATE()-10";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteSalesRawData()
        {
            try
            {
                string s = "DELETE FROM TBL_SALES_RAWDATA WHERE REC_CREATED < GETDATE()-10";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
