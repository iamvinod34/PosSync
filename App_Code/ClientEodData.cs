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
   public class ClientEodData
    {
        DataCon objDB = new DataCon();

        #region "Properties"

        public string Dcon { get; set; }

        public string EodId { get; set; }

        #endregion

        #region "Functions"

        public DataTable LoadEOD()
        {

            DataTable dt_Eod = null;

            try
            {
                string s = "SELECT * FROM TBL_EOD";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_Eod = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt_Eod;

        }

        public DataTable LoadEODdtls()
        {

            DataTable dt_Eoddlts = null;

            try
            {
                string s = "SELECT * FROM TBL_EOD_DETAIL";

                SqlCeParameter spEodId = new SqlCeParameter();
                spEodId.ParameterName = "@EODID";
                spEodId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEodId.Value = this.EodId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dt_Eoddlts = objDB.LoadDataSet().Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt_Eoddlts;

        }

        public void DeleteEOD()
        {
            try
            {
                string s = "DELETE FROM TBL_EOD WHERE EODID=@EODID";

                SqlCeParameter spEodid = new SqlCeParameter();
                spEodid.ParameterName = "@EODID";
                spEodid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEodid.Value = EodId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord(spEodid);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteEODdtls()
        {
            try
            {
                string s = "DELETE FROM TBL_EOD_DETAIL WHERE EODID=@EODID";

                SqlCeParameter spEodid = new SqlCeParameter();
                spEodid.ParameterName = "@EODID";
                spEodid.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEodid.Value = EodId;

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.DeleteRecord(spEodid);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}
