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
    class PreferUOM
    {
        #region Properties

        public string MaterialID { set; get; }
        public string EAN13 { set; get; }
        public string UOM { set; get; }
        public string Dcon { set; get; }
        public string TerminalID{ get; set; }

        #endregion

        DataCon objDB = new DataCon();
        public DataTable InsertPreferUOM()
        {
            DataTable dt_prefer = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                string s = "insert into tbl_PreferUOM_Temp values(@MaterialID,@EAN13,@UOM)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spMaterialID, spEAN13, spUOM);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_prefer;
        }
        public DataTable InsertPreferUOM_MasterData()
        {
            DataTable dt_prefer = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = this.TerminalID;

                string s = "insert into tbl_PreferUOM values(@MaterialID,@EAN13,@UOM,@TerminalID)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spMaterialID, spEAN13, spUOM,spTerminalID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_prefer;
        }
        public DataTable UpdatePreferUOM_MasterData()
        {
            DataTable dt_prefer = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = this.TerminalID;


                string s = "Update tbl_PreferUOM set EAN13=@EAN13,UOM=@UOM,TerminalID=@TerminalID where MaterialID=@MaterialID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spMaterialID, spEAN13, spUOM,spTerminalID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_prefer;

        }
    }
}
