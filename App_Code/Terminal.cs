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
    class Terminal
    {
        #region Properties
        public string TerminalID { get; set; }
        public string LocationID { get; set; }
        public string Dcon { set; get; }
        #endregion
        DataCon objDb = new DataCon();
        public DataTable InsertTerminal_MasterData()
        {
            DataTable dt_tt = null;
            try
            {
                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = this.TerminalID;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "Insert into tbl_terminal values(@TerminalID,@LocationID)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spTerminalID, spLocationID);

            }
            catch (Exception ex)
            {

            }
            return dt_tt;
        }
        public DataTable UpdateTerminal_MasterData()
        {
            DataTable dt_tt = null;
            try
            {
                SqlCeParameter spTerminalID = new SqlCeParameter();
                spTerminalID.ParameterName = "@TerminalID";
                spTerminalID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTerminalID.Value = this.TerminalID;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "update tbl_terminal set TerminalID=@TerminalID where LocationID=@LocationID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spTerminalID, spLocationID);

            }
            catch (Exception ex)
            {

            }
            return dt_tt;
        }
    }
}
