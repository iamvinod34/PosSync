using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using DBConnection;
namespace PosSync.App_Code
{
   
    class Category
    {
        #region Properties
        public string CategoryID { set; get; }
        public string CategoryDesc { set; get; }
        public string Dcon { set; get; }
        #endregion

        DataCon objDb = new DataCon();

        public DataTable InsertCategory()
        {
            DataTable dt_cat = null;
            try
            {
                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spCategoryDesc = new SqlCeParameter();
                spCategoryDesc.ParameterName = "@CategoryDesc";
                spCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryDesc.Value = this.CategoryDesc;

                string s = "insert into tbl_Category_Temp values(@CategoryID,@CategoryDesc)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCategoryID, spCategoryDesc);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cat;
        }
        public DataTable InsertCategory_MasterData()
        {
            DataTable dt_cat = null;
            try
            {
                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spCategoryDesc = new SqlCeParameter();
                spCategoryDesc.ParameterName = "@CategoryDesc";
                spCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryDesc.Value = this.CategoryDesc;

                string s = "insert into tbl_Category values(@CategoryID,@CategoryDesc)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCategoryID, spCategoryDesc);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cat;

            
        }
        public DataTable UpdateCategory_MasterData()
        {
            DataTable dt_cat = null;
            try
            {
                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;

                SqlCeParameter spCategoryDesc = new SqlCeParameter();
                spCategoryDesc.ParameterName = "@CategoryDesc";
                spCategoryDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryDesc.Value = this.CategoryDesc;

                string s = "update tbl_category set CategoryDesc=@CategoryDesc where CategoryID=@CategoryID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCategoryID, spCategoryDesc);
           

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cat;
        }
    }
}
