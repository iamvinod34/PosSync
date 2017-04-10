using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using DBConnection;
namespace PosSync.App_Code
{
    class SubCategory
    {
        #region Properties
        public string SubCategoryID { set; get; }
        public string SubCategoryDesc { set; get; }
        public string CategoryID { set; get; }
        public string Dcon { set; get; }
        
        #endregion
        DataCon objDB = new DataCon();

        public DataTable InsertSubCategory()
        {
            DataTable dt_subcat = null;
            try
            {
                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spSubCategoryDesc = new SqlCeParameter();
                spSubCategoryDesc.ParameterName = "@SubCategoryDesc";
                spSubCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryDesc.Value = this.SubCategoryDesc;

                string s = "insert into tbl_SubCategory_Temp values(@SubCategoryID,@SubCategoryDesc,@CategoryID)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spSubCategoryID, spSubCategoryDesc, spCategoryID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_subcat;
        }
        public DataTable InsertSubCategory_MasterData()
        {
            DataTable dt_subcat = null;
            try
            {
                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spSubCategoryDesc = new SqlCeParameter();
                spSubCategoryDesc.ParameterName = "@SubCategoryDesc";
                spSubCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryDesc.Value = this.SubCategoryDesc;

                string s = "insert into tbl_SubCategory values(@SubCategoryID,@SubCategoryDesc,@CategoryID)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spSubCategoryID, spSubCategoryDesc, spCategoryID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_subcat;
            
        }
        public DataTable UpdateSubCategory_MasterData()
        {
            DataTable dt_subcat = null;
            try
            {
                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spSubCategoryDesc = new SqlCeParameter();
                spSubCategoryDesc.ParameterName = "@SubCategoryDesc";
                spSubCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryDesc.Value = this.SubCategoryDesc;

                string s = "update tbl_SubCategory set SubCategoryDesc=@SubCategoryDesc,CategoryID=@CategoryID where SubCategoryID=@SubCategoryID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spSubCategoryID, spSubCategoryDesc, spCategoryID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_subcat;
        }
    }
}
