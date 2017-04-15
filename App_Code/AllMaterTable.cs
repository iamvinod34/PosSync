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
    public class AllMaterTable
    {
        DataCon LocalDataCon = new DataCon();
        MyDataConnection ServerMyDataConnection = new MyDataConnection();
        

        #region "Properties"



        public string VendorID { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string POBox { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CustInt1 { get; set; }
        public string CustInt2 { get; set; }
        public string CustInt3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }
        public string UOM { get; set; }
        public string UOMDesc { get; set; }
        public string TerminalID { get; set; }
        public string LocationID { get; set; }
        public string TenderID { get; set; }
        public string TenderName { get; set; }
        public string GL_Debit { get; set; }
        public string GL_Credit { get; set; }
        public string SubCategoryID { get; set; }
        public string SubCategoryDesc { get; set; }
        public string CategoryID { get; set; }
        public string StorageID { get; set; }
        public string StorageName { get; set; }
        public string StorageType { get; set; }
        public string EAN13 { get; set; }
        public string MaterialID { get; set; }
        public string Price { get; set; }
        public string KitID { get; set; }
        public string KitDescription { get; set; }
        public string MaterialLess { get; set; }
        public string UOMLess { get; set; }
        public string QuantityLess { get; set; }
        public string MaterialAdd { get; set; }
        public string UOMAdd { get; set; }
        public string QuantityAdd { get; set; }
        public string ConvertValue { get; set; }
        public string BaseUOM { get; set; }
        public string MaterialMix { get; set; }
        public string MaterialDesc1 { get; set; }
        public string MaterialDesc2 { get; set; }
        public string MaterialDesc3 { get; set; }
        public string ProductURL { get; set; }
        public string Cost { get; set; }
        public string CustDate1 { get; set; }
        public string CustDate2 { get; set; }
        public string CustDate3 { get; set; }
        public string UserID { get; set; }
        public string AddDate { get; set; }
        public string UpdDate { get; set; }
        public string Dataid { get; set; }
        public string LocationDesc { get; set; }
        public string CostCenter { get; set; }
        public string BusinessArea { get; set; }
        public string FieldArea { get; set; }
        public string CashLoan { get; set; }
        public string CustomerID { get; set; }
        public decimal CreditLimit { get; set; }
        public string CustType { get; set; }
        public string TotalDue { get; set; }
        public string CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string CurrRate { get; set; }
        public string CompanyID { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string DefaultCurrency { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string CategoryDesc { get; set; }

        public string BOMID { get; set; }
        public string BOMQty { get; set; }

        public int Id { get; set; }
        public string ConnectionStringName { get; set; }
        public string ServerIP { get; set; }
        public string ServerUserName { get; set; }
        public string ServerPassword { get; set; }
        public string ServerDataBaseName { get; set; }
        public string Security { get; set; }
        public string DominName { get; set; }
        public string Sales_Comm { get;  set; }
        public string Produc_Comm { get;  set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string ID { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Address { get;  set; }
        public bool Status { get; private set; }
        public object TotalAmount { get; private set; }
        public object LastUpdateTime { get; private set; }
        public string Password { get;  set; }

        public string PI_KeyWord { get; set; }
        public string PI_Description { get; set; }
        public string Days { get; set; }
        public string PI_DateTime { get; set; }
        public string PhoneDigit { get; internal set; }
        public string PhoneCode { get; internal set; }
        public string PhoneDescription { get; internal set; }




        #endregion

        public void Declaretions()
        {
           
            SqlCeParameter spTerminalID = new SqlCeParameter();
            spTerminalID.ParameterName = "@TerminalID ";
            spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spTerminalID.Value = TerminalID;

            SqlCeParameter spLocationID = new SqlCeParameter();
            spLocationID.ParameterName = "@LocationID";
            spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spLocationID.Value = LocationID;

            SqlCeParameter spTenderID = new SqlCeParameter();
            spTenderID.ParameterName = "@TenderID";
            spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spTenderID.Value = TenderID;

            SqlCeParameter spTenderName = new SqlCeParameter();
            spTenderName.ParameterName = "@TenderName";
            spTenderName.SqlDbType = System.Data.SqlDbType.NVarChar;
            spTenderName.Value = TenderName;

            SqlCeParameter spGL_Debit = new SqlCeParameter();
            spGL_Debit.ParameterName = "@GL_Debit";
            spGL_Debit.SqlDbType = System.Data.SqlDbType.NVarChar;
            spGL_Debit.Value = GL_Debit;

            SqlCeParameter spGL_Credit = new SqlCeParameter();
            spGL_Credit.ParameterName = "@GL_Credit";
            spGL_Credit.SqlDbType = System.Data.SqlDbType.NVarChar;
            spGL_Credit.Value = GL_Credit;

            SqlCeParameter spSubCategoryID = new SqlCeParameter();
            spSubCategoryID.ParameterName = "@SubCategoryID";
            spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spSubCategoryID.Value = SubCategoryID;

            SqlCeParameter spSubCategoryDesc = new SqlCeParameter();
            spSubCategoryDesc.ParameterName = "@SubCategoryDesc";
            spSubCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
            spSubCategoryDesc.Value = SubCategoryDesc;

            SqlCeParameter spCategoryID = new SqlCeParameter();
            spCategoryID.ParameterName = "@CategoryID";
            spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spCategoryID.Value = CategoryID;

            SqlCeParameter spStorageID = new SqlCeParameter();
            spStorageID.ParameterName = "@StorageID";
            spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spStorageID.Value = StorageID;

            SqlCeParameter spStorageName = new SqlCeParameter();
            spStorageName.ParameterName = "@StorageName";
            spStorageName.SqlDbType = System.Data.SqlDbType.NVarChar;
            spStorageName.Value = StorageName;

            SqlCeParameter spStorageType = new SqlCeParameter();
            spStorageType.ParameterName = "@StorageType";
            spStorageType.SqlDbType = System.Data.SqlDbType.NVarChar;
            spStorageType.Value = StorageType;

            SqlCeParameter spEAN13 = new SqlCeParameter();
            spEAN13.ParameterName = "@EAN13";
            spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
            spEAN13.Value = EAN13;

            SqlCeParameter spMaterialID = new SqlCeParameter();
            spMaterialID.ParameterName = "@MaterialID";
            spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
            spMaterialID.Value = MaterialID;

            SqlCeParameter spPrice = new SqlCeParameter();
            spPrice.ParameterName = "@Price";
            spPrice.SqlDbType = System.Data.SqlDbType.NVarChar;
            spPrice.Value = Price;


          

           
            SqlCeParameter spCost = new SqlCeParameter();
            spCost.ParameterName = "@Cost";
            spCost.SqlDbType = System.Data.SqlDbType.NVarChar;
            spCost.Value = Cost;

        

         

         



            SqlCeParameter spCreditLimit = new SqlCeParameter();
            spCreditLimit.ParameterName = "@CreditLimit";
            spCreditLimit.SqlDbType = System.Data.SqlDbType.NVarChar;
            spCreditLimit.Value = CreditLimit;















        }

        #region "all Mater Tables"

        public string LocalConn()
        {
            string LocalConn = string.Empty;
            return LocalConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public string ServerConn()
        {
            string ServerConn = string.Empty;
            return ServerConn = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
        }


        public DataTable LocalCateogry()
        {
            DataTable local = null;
            try
            {



                string S = "SELECT * FROM TBL_CATEGORY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];

            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCategory()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_CATEGORY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCity()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_CITY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable LocalPhoneCode()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM tbl_PhoneCode";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCity()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_CITY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable ServerPhoneCode()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM tbl_PhoneCode";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCompany()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_COMPANY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCompany()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_COMPANY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCountry()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_COUNTRY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCountry()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_COUNTRY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCurrency()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_CURRENCY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCurrency()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_CURRENCY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCustomter()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_CUSTOMER";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCusomter()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_CUSTOMER";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalLocation()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_LOCATION";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerLocation()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_LOCATION";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalLocationPrice()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_LOCATIONPRICE";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerLocationPrice()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_LOCATIONPRICE";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalMaterial()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIAL";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerMaterial()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIAL";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalMaterialEAN()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIALEAN";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerMaterialEAN()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIALEAN";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalMaterialKit()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIALKIT";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerMatterialKit()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_MATERIALKIT";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalPreferUOM()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_PREFERUOM";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerPreferUOM()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_PREFERUOM";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalPriceFile()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_PRICEFILE";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerPriceFile()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_PRICEFILE";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalRegion()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_REGION";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerRegion()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_REGION";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalStorage()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_STORAGE";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerStorage()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_STORAGE";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalSubCategory()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_SUBCATEGORY";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerSubCategory()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_SUBCATEGORY";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalTender()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_TENDER";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerTender()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_TENDER";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalTerminal()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_TERMINAL";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerTerminal()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_TERMINAL";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalUOM()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_UOM";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerUOM()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_UOM";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalVendor()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_VENDOR";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerVendor()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_VENDOR";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalBOM()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_BOM";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerBOM()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_BOM";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalConnectionString()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM TBL_ConnectionString";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;  
        }
        
        public DataTable ServerConnectionString()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM TBL_ConnectionString where Status='False'";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }

        public DataTable LocalCustType()
        {
            DataTable local = null;
            try
            {
                string S = "SELECT * FROM tbl_CustType";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                local = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public DataTable ServerCustType()
        {
            DataTable server = null;
            try
            {
                string S = "SELECT * FROM tbl_CustType";

                ServerMyDataConnection.CmdString = S;
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.ConString = ServerConn();

                server = ServerMyDataConnection.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return server;
        }


        #endregion

        #region "All Mater Table Insert"

        public string InsertLocalCateogry()
        {
            string local = null;
            try
            {
                SqlCeParameter spcategoryid = new SqlCeParameter();
                spcategoryid.ParameterName = "@CATEGORYID";
                spcategoryid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spcategoryid.Value = CategoryID;

                SqlCeParameter spCategoryDesc = new SqlCeParameter();
                spCategoryDesc.ParameterName = "@CategoryDesc";
                spCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryDesc.Value = CategoryDesc;


                string S = "INSERT INTO TBL_CATEGORY (CATEGORYID,CATEGORYDESC) VALUES(@CATEGORYID,@CATEGORYDESC)";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spcategoryid, spCategoryDesc);

            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalCity()
        {
            string local = null;
            try
            {
                SqlCeParameter spCityID = new SqlCeParameter();
                spCityID.ParameterName = "@CityID";
                spCityID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityID.Value = CityID;

                SqlCeParameter spCityName = new SqlCeParameter();
                spCityName.ParameterName = "@CityName";
                spCityName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityName.Value = CityName;


                string S = "INSERT INTO TBL_CITY (CITYID,CITYNAME) VALUES(@CITYID,@CITYNAME) ";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spCityID, spCityName);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalPhoneCode()
        {
            string local = null;
            try
            {
                SqlCeParameter spPhoneCode = new SqlCeParameter();
                spPhoneCode.ParameterName = "@PhoneCode";
                spPhoneCode.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhoneCode.Value = PhoneCode;

                SqlCeParameter spPhoneDigits = new SqlCeParameter();
                spPhoneDigits.ParameterName = "@PhoneDigits";
                spPhoneDigits.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhoneDigits.Value = PhoneDigit;

                SqlCeParameter spPhoneDescription = new SqlCeParameter();
                spPhoneDescription.ParameterName = "@PhoneDescription";
                spPhoneDescription.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhoneDescription.Value = PhoneDescription;


                string S = "INSERT INTO tbl_PhoneCode (PhoneCode,PhoneDigits,PhoneDescription) VALUES(@PhoneCode,@PhoneDigits,@PhoneDescription) ";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spPhoneCode,spPhoneDigits,spPhoneDescription);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalCompany()
        {
            string local = null;
            try
            {
                SqlCeParameter spCompanyID = new SqlCeParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = CompanyID;

                SqlCeParameter spLongName = new SqlCeParameter();
                spLongName.ParameterName = "@LongName";
                spLongName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLongName.Value = LongName;

                SqlCeParameter spShortName = new SqlCeParameter();
                spShortName.ParameterName = "@ShortName";
                spShortName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spShortName.Value = ShortName;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = Address3;


                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;



                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlCeParameter spDefaultCurrency = new SqlCeParameter();
                spDefaultCurrency.ParameterName = "@DefaultCurrency";
                spDefaultCurrency.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDefaultCurrency.Value = DefaultCurrency;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;



                string S = "INSERT INTO TBL_COMPANY(COMPANYID,LONGNAME,SHORTNAME,ADDRESS1,ADDRESS2,ADDRESS3,POBOX,CONTACT,PHONE,FAX,EMAIL,CITY,REGION,COUNTRY,DEFAULTCURRENCY) " +
                    " VALUES(@COMPANYID,@LONGNAME,@SHORTNAME,@ADDRESS1,@ADDRESS2,@ADDRESS3,@POBOX,@CONTACT,@PHONE,@FAX,@EMAIL,@CITY,@REGION,@COUNTRY,@DEFAULTCURRENCY);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spCompanyID, spLongName, spShortName, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spDefaultCurrency);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        //public string InsertLocalCountry()
        //{
        //    string local = null;
        //    try
        //    {
        //        string S = "";

        //        LocalDataCon.CmdString = S;
        //        LocalDataCon.CmdType = CommandType.Text;
        //        LocalDataCon.ConString = LocalConn();

        //        LocalDataCon.InsertRecord();
        //    }
        //    catch (Exception ex)
        //    {
       // throw;
        //    }
        //    return local;
        //}

        public string InsertLocalCurrency()
        {
            string local = null;
            try
            {
                SqlCeParameter spCurrencyID = new SqlCeParameter();
                spCurrencyID.ParameterName = "@CurrencyID";
                spCurrencyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyID.Value = CurrencyID;

                SqlCeParameter spCurrencyName = new SqlCeParameter();
                spCurrencyName.ParameterName = "@CurrencyName";
                spCurrencyName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrencyName.Value = CurrencyName;

                SqlCeParameter spCurrRate = new SqlCeParameter();
                spCurrRate.ParameterName = "@CurrRate";
                spCurrRate.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCurrRate.Value = CurrRate;

                string S = "INSERT INTO tbl_Currency(CurrencyID,CurrencyName,CurrRate)VALUES(@CurrencyID,@CurrencyName,@CurrRate);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spCurrencyID, spCurrencyName, spCurrRate);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalCustomter()
        {
            string local = null;
            try
            {

                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                SqlCeParameter spName1 = new SqlCeParameter();
                spName1.ParameterName = "@Name1";
                spName1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName1.Value = Name1;

                SqlCeParameter spName2 = new SqlCeParameter();
                spName2.ParameterName = "@Name2";
                spName2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName2.Value = Name2;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = Address3;


                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;



                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCreditLimit.Value = CreditLimit;

                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt1.Value = CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt2.Value = CustInt2;

                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt3.Value = CustInt3;

                SqlCeParameter spCustText1 = new SqlCeParameter();
                spCustText1.ParameterName = "@CustText1";
                spCustText1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText1.Value = CustText1;

                SqlCeParameter spCustText2 = new SqlCeParameter();
                spCustText2.ParameterName = "@CustText2";
                spCustText2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText2.Value = CustText2;

                SqlCeParameter spCustText3 = new SqlCeParameter();
                spCustText3.ParameterName = "@CustText3";
                spCustText3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText3.Value = CustText3;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                SqlCeParameter spTotalDue = new SqlCeParameter();
                spTotalDue.ParameterName = "@TotalDue";
                spTotalDue.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTotalDue.Value = TotalDue;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;

                SqlCeParameter spPassword = new SqlCeParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = Password;


                string S = "INSERT INTO tbl_Customer(CustomerID,Name1,Name2,Address1,Address2,Address3,POBox,Phone,Fax,Email,City,Region,Country,CreditLimit,CustInt1,CustInt2,CustInt3,CustText1,CustText2,CustText3,CustType,TotalDue,Password) " +
                    " VALUES(@CustomerID,@Name1,@Name2,@Address1,@Address2,@Address3,@POBox,@Phone,@Fax,@Email,@City,@Region,@Country,@CreditLimit,@CustInt1,@CustInt2,@CustInt3,@CustText1,@CustText2,@CustText3,@CustType,@TotalDue,@Password);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spCustomerID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCreditLimit, spCustInt1,
                spCustInt2, spCustInt3, spCustText1, spCustText2, spCustText3, spCustType, spTotalDue,spPassword);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalLocation()
        {
            string local = null;
            try
            {

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlCeParameter spLocationDesc = new SqlCeParameter();
                spLocationDesc.ParameterName = "@LocationDesc";
                spLocationDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationDesc.Value = LocationDesc;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = Address3;


                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;



                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;


                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt1.Value = CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt2.Value = CustInt2;

                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt3.Value = CustInt3;

                SqlCeParameter spCustText1 = new SqlCeParameter();
                spCustText1.ParameterName = "@CustText1";
                spCustText1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText1.Value = CustText1;

                SqlCeParameter spCustText2 = new SqlCeParameter();
                spCustText2.ParameterName = "@CustText2";
                spCustText2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText2.Value = CustText2;

                SqlCeParameter spCustText3 = new SqlCeParameter();
                spCustText3.ParameterName = "@CustText3";
                spCustText3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText3.Value = CustText3;

                SqlCeParameter spCostCenter = new SqlCeParameter();
                spCostCenter.ParameterName = "@CostCenter";
                spCostCenter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCostCenter.Value = CostCenter;

                SqlCeParameter spBusinessArea = new SqlCeParameter();
                spBusinessArea.ParameterName = "@BusinessArea";
                spBusinessArea.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBusinessArea.Value = BusinessArea;

                SqlCeParameter spFieldArea = new SqlCeParameter();
                spFieldArea.ParameterName = "@FieldArea";
                spFieldArea.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFieldArea.Value = FieldArea;

                SqlCeParameter spCashLoan = new SqlCeParameter();
                spCashLoan.ParameterName = "@CashLoan";
                spCashLoan.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCashLoan.Value = CashLoan;



                string S = "INSERT INTO tbl_Location(LocationID,LocationDesc,Address1,Address2,Address3,POBox,Contact,Phone,Email,City,Region,Country,CostCenter,BusinessArea,FieldArea,CashLoan,CustInt1,CustInt2,CustInt3,CustText1,CustText2,CustText3) " +
                    " VALUES(@LocationID,@LocationDesc,@Address1,@Address2,@Address3,@POBox,@Contact,@Phone,@Email,@City,@Region,@Country,@CostCenter,@BusinessArea,@FieldArea,@CashLoan,@CustInt1,@CustInt2,@CustInt3,@CustText1,@CustText2,@CustText3);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spLocationID, spLocationDesc, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spEmail, spCity, spRegion, spCountry, spCostCenter,
                    spBusinessArea, spFieldArea, spCashLoan, spCustInt1, spCustInt2, spCustInt3, spCustText1, spCustText2, spCustText3);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string LocalLInsertocationPrice()
        {
            string local = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                SqlCeParameter spPrice = new SqlCeParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPrice.Value = Price;


                string S = "INSERT INTO tbl_LocationPrice(LocationID,EAN13,MaterialID,UOM,Price,CustType)VALUES(@LocationID,@EAN13,@MaterialID,@UOM,@Price,@CustType);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spLocationID, spEAN13, spMaterialID, spUOM, spPrice,spCustType);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalMaterial()
        {
            string local = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spMaterialDesc1 = new SqlCeParameter();
                spMaterialDesc1.ParameterName = "@MaterialDesc1";
                spMaterialDesc1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc1.Value = MaterialDesc1;

                SqlCeParameter spMaterialDesc2 = new SqlCeParameter();
                spMaterialDesc2.ParameterName = "@MaterialDesc2";
                spMaterialDesc2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc2.Value = MaterialDesc2;

                SqlCeParameter spMaterialDesc3 = new SqlCeParameter();
                spMaterialDesc3.ParameterName = "@MaterialDesc3";
                spMaterialDesc3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc3.Value = MaterialDesc3;

                SqlCeParameter spProductURL = new SqlCeParameter();
                spProductURL.ParameterName = "@ProductURL";
                spProductURL.SqlDbType = System.Data.SqlDbType.NVarChar;
                spProductURL.Value = ProductURL;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryID;

                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = SubCategoryID;

                SqlCeParameter spBaseUOM = new SqlCeParameter();
                spBaseUOM.ParameterName = "@BaseUOM";
                spBaseUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUOM.Value = BaseUOM;

                SqlCeParameter spCost = new SqlCeParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCost.Value = Cost;

                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = VendorID;

                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt1.Value = CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt2.Value = CustInt2;

                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt3.Value = CustInt3;

                SqlCeParameter spCustDate1 = new SqlCeParameter();
                spCustDate1.ParameterName = "@CustDate1";
                spCustDate1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustDate1.Value = CustDate1;

                SqlCeParameter spCustDate2 = new SqlCeParameter();
                spCustDate2.ParameterName = "@CustDate2";
                spCustDate2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustDate2.Value = CustDate2;

                SqlCeParameter spCustDate3 = new SqlCeParameter();
                spCustDate3.ParameterName = "@CustDate3";
                spCustDate3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustDate3.Value = CustDate3;

                SqlCeParameter spCustText1 = new SqlCeParameter();
                spCustText1.ParameterName = "@CustText1";
                spCustText1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText1.Value = CustText1;

                SqlCeParameter spCustText2 = new SqlCeParameter();
                spCustText2.ParameterName = "@CustText2";
                spCustText2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText2.Value = CustText2;

                SqlCeParameter spCustText3 = new SqlCeParameter();
                spCustText3.ParameterName = "@CustText3";
                spCustText3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText3.Value = CustText3;

                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = UserID;

                SqlCeParameter spAddDate = new SqlCeParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = AddDate;

                SqlCeParameter spUpdDate = new SqlCeParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = UpdDate;

                SqlCeParameter spDataid = new SqlCeParameter();
                spDataid.ParameterName = "@Dataid";
                spDataid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDataid.Value = Dataid;

                SqlCeParameter spSalesComm = new SqlCeParameter();
                spSalesComm.ParameterName = "@SalesComm";
                spSalesComm.SqlDbType = System.Data.SqlDbType.Decimal;
                spSalesComm.Value = Sales_Comm;

                SqlCeParameter spProducComm = new SqlCeParameter();
                spProducComm.ParameterName = "@ProducComm";
                spProducComm.SqlDbType = System.Data.SqlDbType.Decimal;
                spProducComm.Value = Produc_Comm;

                string S = "INSERT INTO tbl_Material(MaterialID,MaterialDesc1,MaterialDesc2,MaterialDesc3,ProductURL,CategoryID,SubCategoryID,BaseUOM,Cost,VendorID,CustInt1,CustInt2,CustInt3,CustDate1,CustDate2,CustDate3,CustText1,CustText2,CustText3,UserID,AddDate,UpdDate,Dataid,Sales_Comm,Produc_Comm) " +
                    " VALUES(@MaterialID,@MaterialDesc1,@MaterialDesc2,@MaterialDesc3,@ProductURL,@CategoryID,@SubCategoryID,@BaseUOM,@Cost,@VendorID,@CustInt1,@CustInt2,@CustInt3,@CustDate1,@CustDate2,@CustDate3,@CustText1,@CustText2,@CustText3,@UserID,@AddDate,@UpdDate,@Dataid,@SalesComm,@ProducComm);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spMaterialID, spMaterialDesc1, spMaterialDesc2, spMaterialDesc3, spProductURL, spCategoryID, spSubCategoryID, spBaseUOM, spCost, spVendorID, spCustInt1,
                    spCustInt2, spCustInt3, spCustDate1, spCustDate2, spCustDate3, spCustText1, spCustText2, spCustText3, spUserID, spAddDate, spUpdDate, spDataid,spSalesComm,spProducComm);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalMaterialEAN()
        {
            string local = null;
            try
            {
                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spConvertValue = new SqlCeParameter();
                spConvertValue.ParameterName = "@ConvertValue";
                spConvertValue.SqlDbType = System.Data.SqlDbType.NVarChar;
                spConvertValue.Value = ConvertValue;

                SqlCeParameter spBaseUOM = new SqlCeParameter();
                spBaseUOM.ParameterName = "@BaseUOM";
                spBaseUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUOM.Value = BaseUOM;

                SqlCeParameter spMaterialMix = new SqlCeParameter();
                spMaterialMix.ParameterName = "@MaterialMix";
                spMaterialMix.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialMix.Value = MaterialMix;

                string S = "INSERT INTO tbl_MaterialEAN(EAN13,MaterialID,UOM,ConvertValue,BaseUOM,MaterialMix)VALUES(@EAN13,@MaterialID,@UOM,@ConvertValue,@BaseUOM,@MaterialMix);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spEAN13, spMaterialID, spUOM, spConvertValue, spBaseUOM, spMaterialMix);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalMaterialKit()
        {
            string local = null;
            try
            {


                SqlCeParameter spKitID = new SqlCeParameter();
                spKitID.ParameterName = "@KitID";
                spKitID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spKitID.Value = KitID;

                SqlCeParameter spKitDescription = new SqlCeParameter();
                spKitDescription.ParameterName = "@KitDescription";
                spKitDescription.SqlDbType = System.Data.SqlDbType.NVarChar;
                spKitDescription.Value = KitDescription;

                SqlCeParameter spMaterialLess = new SqlCeParameter();
                spMaterialLess.ParameterName = "@MaterialLess";
                spMaterialLess.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialLess.Value = MaterialLess;

                SqlCeParameter spUOMLess = new SqlCeParameter();
                spUOMLess.ParameterName = "@UOMLess";
                spUOMLess.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOMLess.Value = UOMLess;

                SqlCeParameter spQuantityLess = new SqlCeParameter();
                spQuantityLess.ParameterName = "@QuantityLess";
                spQuantityLess.SqlDbType = System.Data.SqlDbType.NVarChar;
                spQuantityLess.Value = QuantityLess;

                SqlCeParameter spMaterialAdd = new SqlCeParameter();
                spMaterialAdd.ParameterName = "@MaterialAdd";
                spMaterialAdd.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialAdd.Value = MaterialAdd;

                SqlCeParameter spUOMAdd = new SqlCeParameter();
                spUOMAdd.ParameterName = "@UOMAdd";
                spUOMAdd.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOMAdd.Value = UOMAdd;

                SqlCeParameter spQuantityAdd = new SqlCeParameter();
                spQuantityAdd.ParameterName = "@QuantityAdd";
                spQuantityAdd.SqlDbType = System.Data.SqlDbType.NVarChar;
                spQuantityAdd.Value = QuantityAdd;



                string S = "INSERT INTO tbl_MaterialKit(KitID,KitDescription,MaterialLess,UOMLess,QuantityLess,MaterialAdd,UOMAdd,QuantityAdd)VALUES(@KitID,@KitDescription,@MaterialLess,@UOMLess,@QuantityLess,@MaterialAdd,@UOMAdd,@QuantityAdd);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spKitID, spKitDescription, spMaterialLess, spUOMLess, spQuantityLess, spMaterialAdd, spUOMAdd, spQuantityAdd);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalPreferUOM()
        {
            string local = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = EAN13;


                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                string S = "INSERT INTO tbl_PreferUOM(MaterialID,EAN13,UOM,TerminalID)VALUES(@MaterialID,@EAN13,@UOM,@TerminalID);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spMaterialID, spEAN13, spUOM, spTerminalID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalPriceFile()
        {
            string local = null;
            try
            {

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spPrice = new SqlCeParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPrice.Value = Price;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;


                string S = "INSERT INTO tbl_PriceFile(EAN13,MaterialID,UOM,Price,CustType)VALUES(@EAN13,@MaterialID,@UOM,@Price,@CustType);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spEAN13, spMaterialID, spUOM, spPrice,spCustType);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        //public string InsertLocalRegion()
        //{
        //    string local = null;
        //    try
        //    {
        //        string S = "";

        //        LocalDataCon.CmdString = S;
        //        LocalDataCon.CmdType = CommandType.Text;
        //        LocalDataCon.ConString = LocalConn();

        //        LocalDataCon.InsertRecord();
        //    }
        //    catch (Exception ex)
        //    {
     //   throw;
        //    }
        //    return local;
        //}

        public string InsertLocalStorage()
        {
            string local = null;
            try
            {
                SqlCeParameter spStorageID = new SqlCeParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlCeParameter spStorageName = new SqlCeParameter();
                spStorageName.ParameterName = "@StorageName";
                spStorageName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageName.Value = StorageName;

                SqlCeParameter spStorageType = new SqlCeParameter();
                spStorageType.ParameterName = "@StorageType";
                spStorageType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageType.Value = StorageType;


                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                string S = "INSERT INTO tbl_Storage(StorageID,StorageName,StorageType,LocationID)VALUES(@StorageID,@StorageName,@StorageType,@LocationID);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spStorageID, spStorageName, spStorageType, spLocationID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalSubCategory()
        {
            string local = null;
            try
            {

                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = SubCategoryID;

                SqlCeParameter spSubCategoryDesc = new SqlCeParameter();
                spSubCategoryDesc.ParameterName = "@SubCategoryDesc";
                spSubCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryDesc.Value = SubCategoryDesc;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = CategoryID;

                string S = "INSERT INTO tbl_SubCategory(SubCategoryID,SubCategoryDesc,CategoryID)VALUES(@SubCategoryID,@SubCategoryDesc,@CategoryID);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spSubCategoryID, spSubCategoryDesc, spCategoryID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalTender()
        {
            string local = null;
            try
            {

                SqlCeParameter spTenderID = new SqlCeParameter();
                spTenderID.ParameterName = "@TenderID";
                spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTenderID.Value = TenderID;

                SqlCeParameter spTenderName = new SqlCeParameter();
                spTenderName.ParameterName = "@TenderName";
                spTenderName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTenderName.Value = TenderName;

                SqlCeParameter spGL_Debit = new SqlCeParameter();
                spGL_Debit.ParameterName = "@GL_Debit";
                spGL_Debit.SqlDbType = System.Data.SqlDbType.NVarChar;
                spGL_Debit.Value = GL_Debit;

                SqlCeParameter spGL_Credit = new SqlCeParameter();
                spGL_Credit.ParameterName = "@GL_Credit";
                spGL_Credit.SqlDbType = System.Data.SqlDbType.NVarChar;
                spGL_Credit.Value = GL_Credit;

                string S = "INSERT INTO tbl_Tender(TenderID,TenderName,GL_Debit,GL_Credit)VALUES(@TenderID,@TenderName,@GL_Debit,@GL_Credit);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spTenderID, spTenderName, spGL_Debit, spGL_Credit);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalTerminal()
        {
            string local = null;
            try
            {
                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID ";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                string S = "INSERT INTO tbl_Terminal(TerminalID,LocationID)VALUES(@TerminalID,@LocationID);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spTerminalID, spLocationID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalUOM()
        {
            string local = null;
            try
            {
                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spUOMDesc = new SqlCeParameter();
                spUOMDesc.ParameterName = "@UOMDesc";
                spUOMDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOMDesc.Value = UOMDesc;


                string S = "INSERT INTO tbl_UOM(UOM,UOMDesc)VALUES(@UOM,@UOMDesc);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spUOM, spUOMDesc);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalVendor()
        {
            string local = null;
            try
            {
                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = VendorID;

                SqlCeParameter spName1 = new SqlCeParameter();
                spName1.ParameterName = "@Name1";
                spName1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName1.Value = Name1;

                SqlCeParameter spName2 = new SqlCeParameter();
                spName2.ParameterName = "@Name2";
                spName2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName2.Value = Name2;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = Address3;


                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;



                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCreditLimit.Value = CreditLimit;

                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt1.Value = CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt2.Value = CustInt2;

                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustInt3.Value = CustInt3;

                SqlCeParameter spCustText1 = new SqlCeParameter();
                spCustText1.ParameterName = "@CustText1";
                spCustText1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText1.Value = CustText1;

                SqlCeParameter spCustText2 = new SqlCeParameter();
                spCustText2.ParameterName = "@CustText2";
                spCustText2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText2.Value = CustText2;

                SqlCeParameter spCustText3 = new SqlCeParameter();
                spCustText3.ParameterName = "@CustText3";
                spCustText3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText3.Value = CustText3;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                SqlCeParameter spTotalDue = new SqlCeParameter();
                spTotalDue.ParameterName = "@TotalDue";
                spTotalDue.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTotalDue.Value = TotalDue;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;

                string S = "INSERT INTO tbl_Vendor(VendorID,Name1,Name2,Address1,Address2,Address3,POBox,Contact,Phone,Fax,Email,City,Region,Country,CustInt1,CustInt2,CustInt3,CustText1,CustText2,CustText3)VALUES(@VendorID,@Name1,@Name2,@Address1,@Address2,@Address3,@POBox,@Contact,@Phone,@Fax,@Email,@City,@Region,@Country,@CustInt1,@CustInt2,@CustInt3,@CustText1,@CustText2,@CustText3);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spVendorID, spName1, spName2, spAddress1, spAddress2, spAddress3, 
                    spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCustInt1,
                    spCustInt2, spCustInt3, spCustText1, spCustText2, spCustText3);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public string InsertLocalBOM()
        {
            string local = null;
            try
            {
                SqlCeParameter spBOMID = new SqlCeParameter();
                spBOMID.ParameterName = "@BOMID";
                spBOMID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBOMID.Value = BOMID;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = UOM;

                SqlCeParameter spBOMQty = new SqlCeParameter();
                spBOMQty.ParameterName = "@BOMQty";
                spBOMQty.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBOMQty.Value = BOMQty;


                string S = "INSERT INTO tbl_BOM(BOMID,MaterialID,UOM,BOMQty)VALUES(@BOMID,@MaterialID,@UOM,@BOMQty);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spBOMID, spMaterialID, spUOM, spBOMQty);
            }
            catch (Exception ex)
            {
                throw;
            }
            return local;
        }

        public void InsertLocalConnectionString()
        {
            try
            {
                SqlCeParameter spID = new SqlCeParameter();
                spID.ParameterName = "@ID";
                spID.SqlDbType = System.Data.SqlDbType.Int;
                spID.Value = Id;

                SqlCeParameter spConnectionStringName = new SqlCeParameter();
                spConnectionStringName.ParameterName = "@ConnectionStringName";
                spConnectionStringName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spConnectionStringName.Value = ConnectionStringName;

                SqlCeParameter spServerIP = new SqlCeParameter();
                spServerIP.ParameterName = "@ServerIP";
                spServerIP.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerIP.Value = ServerIP;

                SqlCeParameter spServerUserName = new SqlCeParameter();
                spServerUserName.ParameterName = "@ServerUserName";
                spServerUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerUserName.Value = ServerUserName;

                SqlCeParameter spServerPassword = new SqlCeParameter();
                spServerPassword.ParameterName = "@ServerPassword";
                spServerPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerPassword.Value = ServerPassword;

                SqlCeParameter spServerDataBaseName = new SqlCeParameter();
                spServerDataBaseName.ParameterName = "@ServerPassword";
                spServerDataBaseName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerDataBaseName.Value = ServerPassword;

                SqlCeParameter spServerSecurity = new SqlCeParameter();
                spServerSecurity.ParameterName = "@Security";
                spServerSecurity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerSecurity.Value = Security;

                SqlCeParameter spServerDominName = new SqlCeParameter();
                spServerDominName.ParameterName = "@DominName";
                spServerDominName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spServerDominName.Value = DominName;

                DataTable dtConnectionString= this.LocalConnectionString();

                DataRow[] dr = dtConnectionString.Select("ID = '" + Id + "'");
                string S;
                if (dr.Length > 0)
                {
                    S = "Update tbl_ConnectionString set ConnectionStringName=@ConnectionStringName,ServerIP=@ServerIP,ServerUserName=@ServerUserName,ServerPassword=@ServerPassword,Security=@Security,DominName=@DominName where Id=@ID";
                }
                else
                {
                     S = "INSERT INTO tbl_ConnectionString(ConnectionStringName,ServerIP,ServerUserName,ServerPassword,Security,DominName)VALUES(@ConnectionStringName,@ServerIP,@ServerUserName,@ServerPassword,@Security,@DominName);";
                }
                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord(spID,spConnectionStringName,spServerIP,spServerUserName,spServerPassword,spServerSecurity,spServerDominName);
            }
            catch(Exception ex)
            {

            }
        }

        public void InsertLocationCountry()
        {
            try
            {
                SqlCeParameter spCountryID = new SqlCeParameter();
                spCountryID.ParameterName = "@CountryID";
                spCountryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountryID.Value = CountryID;

                SqlCeParameter spCountryName = new SqlCeParameter();
                spCountryName.ParameterName = "@CountryName";
                spCountryName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountryName.Value = CountryName;

                string S = "INSERT INTO tbl_Country(CountryName)VALUES(@CountryName);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord( spCountryName);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertLocationRegion()
        {
            try
            {
                SqlCeParameter spRegionID = new SqlCeParameter();
                spRegionID.ParameterName = "@RegionID";
                spRegionID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegionID.Value = RegionID;

                SqlCeParameter spRegionName = new SqlCeParameter();
                spRegionName.ParameterName = "@RegionName";
                spRegionName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegionName.Value = RegionName;

                string S = "INSERT INTO tbl_Region(RegionName)VALUES(@RegionName);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord( spRegionName);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertLocationCustType()
        {
            try
            {
                SqlCeParameter spId = new SqlCeParameter();
                spId.ParameterName = "@ID";
                spId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spId.Value = ID;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                string S = "INSERT INTO tbl_CustType(CustType)VALUES(@CustType);";

                LocalDataCon.CmdString = S;
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.ConString = LocalConn();

                LocalDataCon.InsertRecord( spCustType);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool GetByIdLocalCustomer()
        {
            bool result = false;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                string s = "select * from tbl_Customer where CustomerID=@CustomerID";

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

               DataTable dt= LocalDataCon.LoadDataSet(spCustomerID).Tables[0];
                if(dt.Rows.Count>0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public bool GetByIdServerCustomer()
        {
            bool result = false;
            try
            {
                SqlParameter spCustomerID = new SqlParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                string s = "select * from tbl_Customer where CustomerID=@CustomerID";

                ServerMyDataConnection.ConString = ServerConn();
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.CmdString = s;

                DataTable dt = ServerMyDataConnection.LoadDataSet(spCustomerID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public bool InsertServer()
        {
            bool result = false;
            try
            {

                SqlParameter spCustomerID = new SqlParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                SqlParameter spFirstName = new SqlParameter();
                spFirstName.ParameterName = "@FirstName";
                spFirstName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFirstName.Value = FirstName;

                SqlParameter spLastName = new SqlParameter();
                spLastName.ParameterName = "@LastName";
                spLastName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLastName.Value = LastName;

                SqlParameter spAddress = new SqlParameter();
                spAddress.ParameterName = "@Address";
                spAddress.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress.Value = Address;

                SqlParameter spPOBox = new SqlParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlParameter spPhone = new SqlParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlParameter spFax = new SqlParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlParameter spEmail = new SqlParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;

                SqlParameter spCity = new SqlParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;

                SqlParameter spRegion = new SqlParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlParameter spCountry = new SqlParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlParameter spCreditLimit = new SqlParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditLimit.Value = CreditLimit;

                SqlParameter spCustType = new SqlParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                SqlParameter spStatus = new SqlParameter();
                spStatus.ParameterName = "@Status";
                spStatus.SqlDbType = System.Data.SqlDbType.Bit;
                spStatus.Value = Status = true;

                SqlParameter spTotalAmount = new SqlParameter();
                spTotalAmount.ParameterName = "@TotalAmount";
                spTotalAmount.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTotalAmount.Value = TotalAmount;

                SqlParameter spLastUpdateTime = new SqlParameter();
                spLastUpdateTime.ParameterName = "@LastUpdateTime";
                spLastUpdateTime.SqlDbType = System.Data.SqlDbType.DateTime;
                spLastUpdateTime.Value = LastUpdateTime;

                SqlParameter spPassword = new SqlParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = Password;

                bool Uresult = this.GetByIdServerCustomer();
                string s;

                if (Uresult)
                {
                    //update
                    s = "Proc_UpdateCustomerRegistration";

                    ServerMyDataConnection.ConString = ServerConn();
                    ServerMyDataConnection.CmdType = CommandType.StoredProcedure;
                    ServerMyDataConnection.CmdString = s;

                    ServerMyDataConnection.InsertRecord(spCustomerID, spFirstName, spLastName, spAddress, spPOBox, spPhone, spFax, spEmail,
                    spCity, spRegion, spCountry, spCreditLimit, spCustType, spStatus,spPassword);
                }
                else
                {
                    s = "Proc_InsertCustomerRegistration";

                    ServerMyDataConnection.ConString = ServerConn();
                    ServerMyDataConnection.CmdType = CommandType.StoredProcedure;
                    ServerMyDataConnection.CmdString = s;

                    ServerMyDataConnection.InsertRecord(spCustomerID, spFirstName, spLastName, spAddress, spPOBox, spPhone, spFax, spEmail,
                    spCity, spRegion, spCountry, spCreditLimit, spCustType, spStatus,spPassword);
                }

                

                
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public bool InsertLocal()
        {
            bool result = false;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                SqlCeParameter spFirstName = new SqlCeParameter();
                spFirstName.ParameterName = "@FirstName";
                spFirstName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFirstName.Value = FirstName;

                SqlCeParameter spLastName = new SqlCeParameter();
                spLastName.ParameterName = "@LastName";
                spLastName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLastName.Value = LastName;

                SqlCeParameter spAddress = new SqlCeParameter();
                spAddress.ParameterName = "@Address";
                spAddress.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress.Value = Address;

                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = POBox;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = Email;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = City;

                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = Region;

                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = Country;

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditLimit.Value = CreditLimit;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = CustType;

                SqlCeParameter spStatus = new SqlCeParameter();
                spStatus.ParameterName = "@Status";
                spStatus.SqlDbType = System.Data.SqlDbType.Bit;
                spStatus.Value = Status = true;

                SqlCeParameter spTotalAmount = new SqlCeParameter();
                spTotalAmount.ParameterName = "@TotalAmount";
                spTotalAmount.SqlDbType = System.Data.SqlDbType.Decimal;
                spTotalAmount.Value = TotalAmount;

                SqlCeParameter spLastUpdateTime = new SqlCeParameter();
                spLastUpdateTime.ParameterName = "@LastUpdateTime";
                spLastUpdateTime.SqlDbType = System.Data.SqlDbType.DateTime;
                spLastUpdateTime.Value = LastUpdateTime;

                SqlCeParameter spPassword = new SqlCeParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = Password;

                bool UResult = this.GetByIdLocalCustomer();
                string s;
                if(UResult)
                {
                    //update
                    s = "update tbl_Customer set  Name1 = @FirstName, Name2 = @LastName, Address1 = @Address, POBox = @POBox," +
                " Phone = @Phone, Fax = @Fax, Email = @Email, City = @City, Region = @Region, Country = @Country, CreditLimit = @CreditLimit, CustType = @CustType,ConRead='True',Password=@Password where CustomerID = @CustomerID";

                    LocalDataCon.ConString = LocalConn();
                    LocalDataCon.CmdType = CommandType.Text;
                    LocalDataCon.CmdString = s;

                    LocalDataCon.InsertRecord(spCustomerID, spFirstName, spLastName, spAddress, spPOBox, spPhone, spFax, spEmail,
                        spCity, spRegion, spCountry, spCreditLimit, spCustType,spPassword);
                }
                else
                {
                    s = "insert into tbl_Customer (CustomerID, Name1, Name2, Address1,  POBox, Phone, Fax, Email , " +
           " City, Region, Country, CreditLimit,  CustType, Status,ConRead,Password)values(@CustomerID,@FirstName," +
            " @LastName,@Address,@POBox,@Phone,@Fax,@Email,@City,@Region,@Country," +
            " @CreditLimit,@CustType,@Status,'True',@Password)";

                    LocalDataCon.ConString = LocalConn();
                    LocalDataCon.CmdType = CommandType.Text;
                    LocalDataCon.CmdString = s;

                    LocalDataCon.InsertRecord(spCustomerID, spFirstName, spLastName, spAddress, spPOBox, spPhone, spFax, spEmail,
                        spCity, spRegion, spCountry, spCreditLimit, spCustType, spStatus,spPassword);
                }
                
                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public DataTable SelectLocal()
        {
            DataTable result = null;
            try
            {
                string s = "select * from tbl_Customer where ConRead='False'";

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                result = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public DataTable AllSelectLocal()
        {
            DataTable result = null;
            try
            {
                string s = "select * from tbl_Customer ";

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                result = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public void UpdateCustomerConRead()
        {
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = CustomerID;

                string s = "Update tbl_Customer set ConRead='True' where CustomerID=@CustomerID";


                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                LocalDataCon.InsertRecord(spCustomerID);
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable SelectServer()
        {
            DataTable result = null;
            try
            {
                string s = "select * from tbl_Customer";

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                result = LocalDataCon.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public DataTable MainCustomerTable()
        {
            DataTable dtMain = null;
            try
            {
                DataTable dtServer = this.SelectServer();
                DataTable dtLocal = this.SelectLocal();
                DataTable dtAllLocal = this.AllSelectLocal();

                //insert table local to server
                for (int i = 0; i < dtLocal.Rows.Count; i++)
                {
                    this.CustomerID = dtLocal.Rows[i]["CustomerID"].ToString();
                    this.FirstName = dtLocal.Rows[i]["Name1"].ToString();
                    this.LastName = dtLocal.Rows[i]["Name2"].ToString();
                    this.Address = dtLocal.Rows[i]["Address1"].ToString();
                    this.POBox = dtLocal.Rows[i]["POBox"].ToString();
                    this.Phone = dtLocal.Rows[i]["Phone"].ToString();
                    this.Fax = dtLocal.Rows[i]["Fax"].ToString();
                    this.Email = dtLocal.Rows[i]["Email"].ToString();
                    this.City = dtLocal.Rows[i]["City"].ToString();
                    this.Region = dtLocal.Rows[i]["Region"].ToString();
                    this.Country = dtLocal.Rows[i]["Country"].ToString();
                    this.CreditLimit =Convert.ToDecimal(dtLocal.Rows[i]["CreditLimit"].ToString());
                    this.CustType = dtLocal.Rows[i]["CustType"].ToString();
                    this.Password = dtLocal.Rows[i]["Password"].ToString();
                    this.InsertServer();
                    UpdateCustomerConRead();
                }

                //insert table server to local cutomerID
                DataTable dtNotin = dtServer.AsEnumerable()
                    .Where(e => !dtAllLocal.AsEnumerable().Any(n => n.Field<string>("CustomerID") == e.Field<string>("CustomerId")))
                    .CopyToDataTable();

                //local insert
                for (int j = 0; j < dtNotin.Rows.Count; j++)
                {
                    this.CustomerID = dtNotin.Rows[j]["CustomerID"].ToString();
                    this.FirstName = dtNotin.Rows[j]["Name1"].ToString();
                    this.LastName = dtNotin.Rows[j]["Name2"].ToString();
                    this.Address = dtNotin.Rows[j]["Address1"].ToString();
                    this.POBox = dtNotin.Rows[j]["POBox"].ToString();
                    this.Phone = dtNotin.Rows[j]["Phone"].ToString();
                    this.Fax = dtNotin.Rows[j]["Fax"].ToString();
                    this.Email = dtNotin.Rows[j]["Email"].ToString();
                    this.City = dtNotin.Rows[j]["City"].ToString();
                    this.Region = dtNotin.Rows[j]["Region"].ToString();
                    this.Country = dtNotin.Rows[j]["Country"].ToString();
                    this.CreditLimit = Convert.ToDecimal(dtNotin.Rows[j]["CreditLimit"].ToString());
                    this.CustType = dtNotin.Rows[j]["CustType"].ToString();
                    this.Password = dtLocal.Rows[j]["Password"].ToString();
                    this.InsertLocal();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return dtMain;
        }

        public DataTable Get_Select_Local_PI_TimeTable()
        {
            DataTable result = null;
            try
            {
                string s = "select * from tbl_PI_TimeTable where ConRead='False' and LocationID=@LocationID";

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                result = LocalDataCon.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public DataTable Get_Select_Server_PI_TimeTable()
        {
            DataTable result = null;
            try
            {
                string s = "select * from tbl_PI_TimeTable where ConRead='False' and LocationID=@LocationID";

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                ServerMyDataConnection.ConString = ServerConn();
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.CmdString = s;

                result = ServerMyDataConnection.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public void Insert_Local_PI_TimeTable()
        {
            try
            {
                DataTable Get_Select_Local_PI_TimeTable = this.Get_Select_Local_PI_TimeTable();
                DataTable Get_Select_Server_PI_TimeTable = this.Get_Select_Server_PI_TimeTable();
                if(Get_Select_Local_PI_TimeTable!=null)
                {
                    if (Get_Select_Local_PI_TimeTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < Get_Select_Local_PI_TimeTable.Rows.Count; i++)
                        {
                            this.PI_KeyWord = Get_Select_Local_PI_TimeTable.Rows[i]["PI_KeyWord"].ToString();
                            this.PI_Description = Get_Select_Local_PI_TimeTable.Rows[i]["PI_Description"].ToString();
                            this.Days = Get_Select_Local_PI_TimeTable.Rows[i]["Days"].ToString();
                            this.PI_DateTime = Get_Select_Local_PI_TimeTable.Rows[i]["PI_DateTime"].ToString();
                            this.LocationID = Get_Select_Local_PI_TimeTable.Rows[i]["LocationID"].ToString();
                            this.StorageID = Get_Select_Local_PI_TimeTable.Rows[i]["StorageID"].ToString();
                            this.TerminalID = Get_Select_Local_PI_TimeTable.Rows[i]["TerminalID"].ToString();
                            this.Insert_Update_Server_PI_Time_DataTable();

                        }
                    }
                }
                if(Get_Select_Server_PI_TimeTable!=null)
                {
                    if(Get_Select_Server_PI_TimeTable.Rows.Count>0)
                    {
                        //insert or update local table
                        for (int i = 0; i < Get_Select_Local_PI_TimeTable.Rows.Count; i++)
                        {
                            this.PI_KeyWord = Get_Select_Server_PI_TimeTable.Rows[i]["PI_KeyWord"].ToString();
                            this.PI_Description = Get_Select_Server_PI_TimeTable.Rows[i]["PI_Description"].ToString();
                            this.Days = Get_Select_Server_PI_TimeTable.Rows[i]["Days"].ToString();
                            this.PI_DateTime = Get_Select_Server_PI_TimeTable.Rows[i]["PI_DateTime"].ToString();
                            this.LocationID = Get_Select_Server_PI_TimeTable.Rows[i]["LocationID"].ToString();
                            this.StorageID = Get_Select_Server_PI_TimeTable.Rows[i]["StorageID"].ToString();
                            this.TerminalID = Get_Select_Server_PI_TimeTable.Rows[i]["TerminalID"].ToString();
                            this.Insert_Update_Local_PI_Time_DataTable();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Insert_Update_Local_PI_Time_DataTable()
        {
            try
            {
                SqlCeParameter spPIKeyWord = new SqlCeParameter();
                spPIKeyWord.ParameterName = "@PIKeyWord";
                spPIKeyWord.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIKeyWord.Value = this.PI_KeyWord;

                SqlCeParameter spPIDescription = new SqlCeParameter();
                spPIDescription.ParameterName = "@PIDescription";
                spPIDescription.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIDescription.Value = this.PI_Description;

                SqlCeParameter spDays = new SqlCeParameter();
                spDays.ParameterName = "@Days";
                spDays.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDays.Value = this.Days;

                SqlCeParameter spPIDateTime = new SqlCeParameter();
                spPIDateTime.ParameterName = "@PIDateTime";
                spPIDateTime.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIDateTime.Value = this.PI_DateTime;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlCeParameter spStorageID = new SqlCeParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID ";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                DataTable Get_By_Local_PI_TimeTable = this.Get_By_Local_PI_TimeTable();
                string s=string.Empty;

                if(Get_By_Local_PI_TimeTable!=null)
                {
                    if (Get_By_Local_PI_TimeTable.Rows.Count > 0)
                    {
                        s = "INSERT INTO tbl_PI_TimeTable (PI_KeyWord,PI_Description,Days,PI_DateTime,LocationID,StorageID,TerminalID,ConRead) VALUES"+
                            "(@PIKeyWord,@PIDescription,@Days,@PIDateTime,@LocationID,@StorageID,@TerminalID,'True')";
                    }
                    else
                    {
                        s = "UPDATE TBL_PI_TIMETABLE SET PI_Description=@PIDescription,Days=@Days,PI_DateTime=@PIDateTime,StorageID=@StorageID,TerminalID=@TerminalID,ConRead='True' where PI_KeyWord=@PIKeyWord,LocationID=@LocationID";
                            
                    }
                }
                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                LocalDataCon.InsertRecord(spPIKeyWord, spPIDescription, spDays, spPIDateTime, spLocationID, spStorageID, spTerminalID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Insert_Update_Server_PI_Time_DataTable()
        {
            try
            {
                SqlParameter spPIKeyWord = new SqlParameter();
                spPIKeyWord.ParameterName = "@PIKeyWord";
                spPIKeyWord.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIKeyWord.Value = this.PI_KeyWord;

                SqlParameter spPIDescription = new SqlParameter();
                spPIDescription.ParameterName = "@PIDescription";
                spPIDescription.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIDescription.Value = this.PI_Description;

                SqlParameter spDays = new SqlParameter();
                spDays.ParameterName = "@Days";
                spDays.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDays.Value = this.Days;

                SqlParameter spPIDateTime = new SqlParameter();
                spPIDateTime.ParameterName = "@PIDateTime";
                spPIDateTime.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIDateTime.Value = this.PI_DateTime;

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spStorageID = new SqlParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = StorageID;

                SqlParameter spTerminalID = new SqlParameter();
                spTerminalID.ParameterName = "@TerminalID ";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = TerminalID;

                DataTable Get_By_Local_PI_TimeTable = this.Get_By_Server_PI_TimeTable();
                string s = string.Empty;

                if (Get_By_Local_PI_TimeTable != null)
                {
                    if (Get_By_Local_PI_TimeTable.Rows.Count > 0)
                    {
                        s = "INSERT INTO tbl_PI_TimeTable (PI_KeyWord,PI_Description,Days,PI_DateTime,LocationID,StorageID,TerminalID,ConRead) VALUES" +
                            "(@PIKeyWord,@PIDescription,@Days,@PIDateTime,@LocationID,@StorageID,@TerminalID,'True')";
                    }
                    else
                    {
                        s = "UPDATE TBL_PI_TIMETABLE SET PI_Description=@PIDescription,Days=@Days,PI_DateTime=@PIDateTime,StorageID=@StorageID,TerminalID=@TerminalID,ConRead='True' where PI_KeyWord=@PIKeyWord,LocationID=@LocationID";

                    }
                }
                ServerMyDataConnection.ConString = ServerConn();
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.CmdString = s;

                ServerMyDataConnection.InsertRecord(spPIKeyWord, spPIDescription, spDays, spPIDateTime, spLocationID, spStorageID, spTerminalID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable Get_By_Local_PI_TimeTable()
        {
            DataTable dt = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlCeParameter spPIKeyWord = new SqlCeParameter();
                spPIKeyWord.ParameterName = "@PIKeyWord";
                spPIKeyWord.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIKeyWord.Value = this.PI_KeyWord;

                string s = "select * from tbl_PI_TimeTable where LocationID=@LocationId and PI_KeyWord=@PIKeyWord";

                LocalDataCon.ConString = LocalConn();
                LocalDataCon.CmdType = CommandType.Text;
                LocalDataCon.CmdString = s;

                dt = LocalDataCon.LoadDataSet(spLocationID,spPIKeyWord).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        public DataTable Get_By_Server_PI_TimeTable()
        {
            DataTable dt = null;
            try
            {
                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                SqlParameter spPIKeyWord = new SqlParameter();
                spPIKeyWord.ParameterName = "@PIKeyWord";
                spPIKeyWord.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPIKeyWord.Value = this.PI_KeyWord;

                string s = "select * from tbl_PI_TimeTable where LocationID=@LocationId and PI_KeyWord=@PIKeyWord";

                ServerMyDataConnection.ConString = ServerConn();
                ServerMyDataConnection.CmdType = CommandType.Text;
                ServerMyDataConnection.CmdString = s;

                dt = ServerMyDataConnection.LoadDataSet(spLocationID, spPIKeyWord).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return dt;
        }

        #endregion

    }
}
