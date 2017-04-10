using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using DBConnection;
namespace PosSync
{
    class Uom
    {
        #region Properties
        public string UOM { get; set; }
        public string UOMDesc { get; set; }
        public string Dcon { get; set; }
        #endregion
        DataCon objDb = new DataCon();
        public DataTable InsertUom_MasterData()
        {
            DataTable dt = null;
            try
            {
                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spUOMDesc = new SqlCeParameter();
                spUOMDesc.ParameterName = "@UOMDesc";
                spUOMDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOMDesc.Value = this.UOMDesc;

                string s = "insert tbl_uom values(@UOM,@UOMDesc)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spUOM, spUOMDesc);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable UpdateUom_MasterData()
        {
            DataTable dt = null;
            try
            {
                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spUOMDesc = new SqlCeParameter();
                spUOMDesc.ParameterName = "@UOMDesc";
                spUOMDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOMDesc.Value = this.UOMDesc;

                string s = "update tbl_uom set UOMDesc=@UOMDesc where UOM=@UOM";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spUOM, spUOMDesc);
            }
            catch (Exception ex)
            {

            }
            return dt;


        }
    }
}
