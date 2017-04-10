using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PosSync.App_Code;
using System.Configuration;
namespace PosSync.App_Code
{
    class MasterData
    {
        MyDataConnection datacon1 = new MyDataConnection();

        public string LocationId { get; set; }
        public string SysTerminalID { get; set; }

        public DataTable GetmaterialEAN_MasterData()
        {
            DataTable dt_materialEAN = null;
            try
            {
                string s = "SELECT * FROM TBL_MATERIALEAN_TEMP WHERE LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spMLocId = new SqlParameter();
                spMLocId.ParameterName = "@LOCATIONID";
                spMLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_materialEAN = datacon1.LoadDataSet(spMLocId, spMTerminal).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_materialEAN;
        }

        public DataTable GetLocationPrice_MasterData()
        {
            DataTable dt_locationPrice = null;
            try
            {
                string s = "SELECT * FROM TBL_LOCATIONPRICE_TEMP WHERE LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spLPLocId = new SqlParameter();
                spLPLocId.ParameterName = "@LOCATIONID";
                spLPLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLPLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_locationPrice = datacon1.LoadDataSet(spLPLocId, spMTerminal).Tables[0];

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_locationPrice;
        }

        public DataTable GetPriceFile_masterData()
        {
            DataTable dt_priceFile = null;
            try
            {
                string s = "SELECT * FROM TBL_PRICEFILE_TEMP WHERE LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spPFLocId = new SqlParameter();
                spPFLocId.ParameterName = "@LOCATIONID";
                spPFLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPFLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_priceFile = datacon1.LoadDataSet(spPFLocId, spMTerminal).Tables[0];


            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_priceFile;

        }

        public DataTable GetMaterial_MasterData()
        {
            DataTable dt_material = null;
            try
            {
                string s = "SELECT * FROM TBL_MATERIAL_TEMP WHERE LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spMRLocId = new SqlParameter();
                spMRLocId.ParameterName = "@LOCATIONID";
                spMRLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMRLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_material = datacon1.LoadDataSet(spMRLocId, spMTerminal).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_material;

        }

        public DataTable GetUsers_MasterData()
        {
            DataTable dt_users = null;
            try
            {
                string s = "select * from tbl_Users Where LocationId=@LocationId";

                SqlParameter spULocId = new SqlParameter();
                spULocId.ParameterName = "@LocationId";
                spULocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spULocId.Value = LocationId;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_users = datacon1.LoadDataSet(spULocId).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_users;


        }

        public DataTable GetLocation_MasterData()
        {
            DataTable dt_location = null;
            try
            {
                string s = "SELECT * FROM TBL_LOCATION Where LOCATIONID=@LOCATIONID";

                SqlParameter spLLocId = new SqlParameter();
                spLLocId.ParameterName = "@LocationId";
                spLLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLLocId.Value = LocationId;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dt_location = datacon1.LoadDataSet(spLLocId).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_location;
        }

        public DataTable GetCategory_MasterData()
        {
            DataTable dr_cat = null;
            try
            {
                string s = "SELECT * FROM TBL_CATEGORY";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_cat = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_cat;
        }

        public DataTable GetSubCategory_MasterData()
        {
            DataTable dr_subcat = null;
            try
            {
                string s = "select * from tbl_SubCategory";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_subcat = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_subcat;
        }

        public DataTable GetPreferUOM_MasterData()
        {
            DataTable dr_prefer = null;
            try
            {
                string s = "SELECT * FROM TBL_PREFERUOM_TEMP WHERE LOCATIONID=@LOCATIONID";

                SqlParameter spPULocId = new SqlParameter();
                spPULocId.ParameterName = "@LOCATIONID";
                spPULocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPULocId.Value = LocationId;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_prefer = datacon1.LoadDataSet(spPULocId).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_prefer;
        }

        public DataTable GetCurrency_MasterData()
        {
            DataTable dr_curr = null;
            try
            {
                string s = "SELECT * FROM TBL_CURRENCY";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_curr = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_curr;
        }

        public DataTable GetCustomer_MasterData()
        {
            DataTable dr_curr = null;
            try
            {
                string s = "SELECT * FROM TBL_CUSTOMER";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_curr = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_curr;
        }

        public DataTable GetCity_MasterData()
        {
            DataTable dr_city = null;
            try
            {
                string s = "SELECT * FROM TBL_CITY";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_city = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_city;
        }

        public DataTable GetCompany_MasterData()
        {
            DataTable dr_company = null;
            try
            {
                string s = "SELECT * FROM TBL_COMPANY";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_company = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_company;
        }

        public DataTable GetStorage_MasterData()
        {
            DataTable dr_st = null;
            try
            {
                string s = "SELECT * FROM TBL_STORAGE WHERE LOCATIONID=@LOCATIONID";

                SqlParameter spSLocId = new SqlParameter();
                spSLocId.ParameterName = "@LOCATIONID";
                spSLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSLocId.Value = LocationId;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_st = datacon1.LoadDataSet(spSLocId).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_st;
        }

        public DataTable GetTender_MasterData()
        {
            DataTable dr_ten = null;
            try
            {
                string s = "SELECT * FROM TBL_TENDER";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_ten = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_ten;
        }

        public DataTable GetTerminal_MasterData()
        {
            DataTable dr_ten = null;
            try
            {
                string s = "SELECT * FROM TBL_TERMINAL WHERE LOCATIONID=@LOCATIONID";

                SqlParameter spTLocId = new SqlParameter();
                spTLocId.ParameterName = "@LOCATIONID";
                spTLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTLocId.Value = LocationId;

                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_ten = datacon1.LoadDataSet(spTLocId).Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_ten;
        }

        public DataTable GetUOM_MasterData()
        {
            DataTable dr_uom = null;
            try
            {
                string s = "SELECT * FROM TBL_UOM";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_uom = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_uom;
        }

        public DataTable GetVendor_MasterData()
        {
            DataTable dr_ven = null;
            try
            {
                string s = "SELECT * FROM TBL_VENDOR";
                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                dr_ven = datacon1.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            return dr_ven;
        }

        public void DeleteLocationPriceTemp()
        {
            try
            {
                string s = "delete from tbl_LocationPrice_Temp Where LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spDPLocId = new SqlParameter();
                spDPLocId.ParameterName = "@LOCATIONID";
                spDPLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDPLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                datacon1.DeleteRecord(spDPLocId, spMTerminal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteMaterialEanTemp()
        {
            try
            {
                string s = "DELETE FROM TBL_MATERIALEAN_TEMP Where LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spDMELocId = new SqlParameter();
                spDMELocId.ParameterName = "@LOCATIONID";
                spDMELocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDMELocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                datacon1.DeleteRecord(spDMELocId, spMTerminal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteMaterialTemp()
        {
            try
            {
                string s = "delete from tbl_Material_Temp  Where LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spDMLocId = new SqlParameter();
                spDMLocId.ParameterName = "@LOCATIONID";
                spDMLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDMLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                datacon1.DeleteRecord(spDMLocId, spMTerminal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePriceFileTemp()
        {
            try
            {
                string s = "delete from tbl_PriceFile_Temp  Where LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spDPFLocId = new SqlParameter();
                spDPFLocId.ParameterName = "@LOCATIONID";
                spDPFLocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDPFLocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                datacon1.DeleteRecord(spDPFLocId, spMTerminal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePreferUOMTemp()
        {

            try
            {
                string s = "DELETE FROM TBL_PREFERUOM_TEMP WHERE LOCATIONID=@LOCATIONID AND TERMINALID=@TERMINALID";

                SqlParameter spDPULocId = new SqlParameter();
                spDPULocId.ParameterName = "@LOCATIONID";
                spDPULocId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDPULocId.Value = LocationId;

                SqlParameter spMTerminal = new SqlParameter();
                spMTerminal.ParameterName = "@TERMINALID";
                spMTerminal.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMTerminal.Value = SysTerminalID;


                datacon1.ConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
                datacon1.CmdType = CommandType.Text;
                datacon1.CmdString = s;
                datacon1.DeleteRecord(spDPULocId, spMTerminal);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
