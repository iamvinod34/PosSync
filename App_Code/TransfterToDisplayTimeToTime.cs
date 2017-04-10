using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace PosSync.App_Code
{
    public class TransfterToDisplayTimeToTime
    {
        MyDataConnection WebConnecString = new MyDataConnection();
        DBConnection.DataCon LocConnecString = new DataCon();

        public string WebConString { get; set; }
        public string LocalConString{ get; set; }
        public string LocationID{ get; set; }

        public string ID { get; set; }
        public string CrateDate { get; set; }
        public string Warning1 { get; set; }
        public string Warning2 { get; set; }
        public string Warning3 { get; set; }
        public string Warning1Status { get; set; }
        public string Warning2Status { get; set; }
        public string Warning3Status { get; set; }
        public string TDDocumentID { get; set; }
        public string UserID { get; set; }
        public string CreatedDate { get; set; }
        public string WLDbStatus { get; set; }
        public string LDbStatus { get; set; }
        public string SysDateTime { get; set; }
        public string TDDocumentIDStatus{ get; set; }




        public string WebConnString()
        {
            WebConString = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
            return WebConString;
        }
        public string LocalConnString()
        {
            LocalConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return LocalConString;
        }

        public DataTable GetWeb()
        {
            DataTable dtGetWebInsert = null;
            try
            {
                //web to local insert methoed
                string S = "SELECT * FROM TBL_TRANSFTERDISPLAYDATETIME WHERE LOCATIONID=@LOCATIONID AND WLDBSTATUS='0'";

                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                WebConnecString.ConString= WebConnString();
                WebConnecString.CmdType = CommandType.Text;
                WebConnecString.CmdString = S;
               dtGetWebInsert = WebConnecString.LoadDataSet(spLocationID).Tables[0];

            }
            catch (Exception ex)
            {

            }
            return dtGetWebInsert;
        }

        public DataTable GetLocal()
        {
            DataTable dtGetLocal = null;
            try
            {
                //web to local insert methoed
                string S = "SELECT * FROM TBL_TRANSFTERDISPLAYDATETIME WHERE LOCATIONID=@LOCATIONID AND Warning3Status='0'  ORDER BY ID ASC";

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = S;
                dtGetLocal = LocConnecString.LoadDataSet(spLocationID).Tables[0];

            }
            catch (Exception ex)
            {

            }
            return dtGetLocal;
        }
     

        public DataTable GetLocalUpdate(string StatusName)
        {
            DataTable dtGetLocalUpdate = null;
            try
            {
                //local update methoed

                string S = "UPDATE TBL_TRANSFTERDISPLAYDATETIME SET "+StatusName+ "='True' , SysDateTime=@SysDateTime  WHERE ID=@ID";

                SqlCeParameter spID = new SqlCeParameter();
                spID.ParameterName = "@ID";
                spID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spID.Value = this.ID;

                SqlCeParameter spSysDateTime = new SqlCeParameter();
                spSysDateTime.ParameterName = "@SysDateTime";
                spSysDateTime.SqlDbType = System.Data.SqlDbType.DateTime;
                spSysDateTime.Value = DateTime.Now.ToString();

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = S;
                LocConnecString.InsertRecord(spID,spSysDateTime);

            }
            catch (Exception ex)
            {

            }
            return dtGetLocalUpdate;
        }

        public string LocalInsert()
        {
            string dtLocalInsert = null;
            try
            {
                SqlCeParameter spID = new SqlCeParameter();
                spID.ParameterName = "@ID";
                spID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spID.Value = this.ID;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spCrateDate = new SqlCeParameter();
                spCrateDate.ParameterName = "@CrateDate";
                spCrateDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spCrateDate.Value = this.CrateDate;

                SqlCeParameter spWarning1 = new SqlCeParameter();
                spWarning1.ParameterName = "@Warning1";
                spWarning1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning1.Value = this.Warning1;

                SqlCeParameter spWarning2 = new SqlCeParameter();
                spWarning2.ParameterName = "@Warning2";
                spWarning2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning2.Value = this.Warning2;

                SqlCeParameter spWarning3 = new SqlCeParameter();
                spWarning3.ParameterName = "@Warning3";
                spWarning3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning3.Value = this.Warning3;

                SqlCeParameter spWarning1Status = new SqlCeParameter();
                spWarning1Status.ParameterName = "@Warning1Status";
                spWarning1Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning1Status.Value = this.Warning1Status;

                SqlCeParameter spWarning2Status = new SqlCeParameter();
                spWarning2Status.ParameterName = "@Warning2Status";
                spWarning2Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning2Status.Value = this.Warning2Status;

                SqlCeParameter spWarning3Status = new SqlCeParameter();
                spWarning3Status.ParameterName = "@Warning3Status";
                spWarning3Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning3Status.Value = this.Warning3Status;

                SqlCeParameter spTDDocumentID = new SqlCeParameter();
                spTDDocumentID.ParameterName = "@TDDocumentID";
                spTDDocumentID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTDDocumentID.Value = this.TDDocumentID;

                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = this.UserID;

                SqlCeParameter spCreatedDate = new SqlCeParameter();
                spCreatedDate.ParameterName = "@CreatedDate";
                spCreatedDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spCreatedDate.Value = this.CreatedDate;

                SqlCeParameter spWLDbStatus = new SqlCeParameter();
                spWLDbStatus.ParameterName = "@WLDbStatus";
                spWLDbStatus.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWLDbStatus.Value = this.WLDbStatus;

                SqlCeParameter spLDbStatus = new SqlCeParameter();
                spLDbStatus.ParameterName = "@LDbStatus";
                spLDbStatus.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLDbStatus.Value = this.LDbStatus;

                SqlCeParameter spSysDateTime = new SqlCeParameter();
                spSysDateTime.ParameterName = "@SysDateTime";
                spSysDateTime.SqlDbType = System.Data.SqlDbType.DateTime;
                spSysDateTime.Value =DateTime.Now.ToString();

                SqlCeParameter spTDDocumentIDStatus = new SqlCeParameter();
                spTDDocumentIDStatus.ParameterName = "@TDDocumentIDStatus";
                spTDDocumentIDStatus.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTDDocumentIDStatus.Value = TDDocumentIDStatus;


                string S = "INSERT INTO TBL_TRANSFTERDISPLAYDATETIME VALUES(@ID,@LocationID,@CrateDate,@Warning1,@Warning2,@Warning3, "+
                                " @Warning1Status,@Warning2Status,@Warning3Status,@TDDocumentID,@UserID,@CreatedDate,@WLDbStatus,@LDbStatus,@SysDateTime,@TDDocumentIDStatus)";

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = S;
                LocConnecString.InsertRecord(spID, spLocationID, spCrateDate, spWarning1, spWarning2, spWarning3, spWarning1Status,
                                            spWarning2Status, spWarning3Status, spTDDocumentID, spUserID, spCreatedDate, spWLDbStatus, spLDbStatus,spSysDateTime,spTDDocumentIDStatus);

                //update web column is ture

                bool result = GetWebUpdate();


            }
            catch (Exception ex)
            {

            }
            return dtLocalInsert;
        }

        public bool GetWebUpdate()
        {
            bool result = false;
            try
            {
                string s = "UPDATE TBL_TRANSFTERDISPLAYDATETIME SET WLDbStatus='1' WHERE ID=@ID";

                SqlParameter spID = new SqlParameter();
                spID.ParameterName = "@ID";
                spID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spID.Value = this.ID;

                WebConnecString.ConString = WebConnString();
                WebConnecString.CmdType = CommandType.Text;
                WebConnecString.CmdString = s;
                WebConnecString.InsertRecord(spID);

                //local update 

                SqlCeParameter spID1 = new SqlCeParameter();
                spID1.ParameterName = "@ID";
                spID1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spID1.Value = this.ID;

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = s;
                LocConnecString.InsertRecord(spID1);

                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public DataTable UpdateWeb()
        {
            DataTable dtGetLocalCheck = null;
            try
            {
                SqlParameter spID = new SqlParameter();
                spID.ParameterName = "@ID";
                spID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spID.Value = this.ID;

                SqlParameter spWarning1Status = new SqlParameter();
                spWarning1Status.ParameterName = "@Warning1Status";
                spWarning1Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning1Status.Value = this.Warning1Status;

                SqlParameter spWarning2Status = new SqlParameter();
                spWarning2Status.ParameterName = "@Warning2Status";
                spWarning2Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning2Status.Value = this.Warning2Status;

                SqlParameter spWarning3Status = new SqlParameter();
                spWarning3Status.ParameterName = "@Warning3Status";
                spWarning3Status.SqlDbType = System.Data.SqlDbType.NVarChar;
                spWarning3Status.Value = this.Warning3Status;

                SqlParameter spSysDateTime = new SqlParameter();
                spSysDateTime.ParameterName = "@SysDateTime";
                spSysDateTime.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSysDateTime.Value = DateTime.Now.ToString();

                SqlParameter spTDDocumentIDStatus = new SqlParameter();
                spTDDocumentIDStatus.ParameterName = "@TDDocumentIDStatus";
                spTDDocumentIDStatus.SqlDbType = System.Data.SqlDbType.NVarChar;
                spTDDocumentIDStatus.Value = TDDocumentIDStatus;

                string S = "UPDATE TBL_TRANSFTERDISPLAYDATETIME SET  Warning1Status=@Warning1Status,Warning2Status=@Warning2Status,Warning3Status=@Warning3Status,SysDateTime=@SysDateTime , TDDocumentIDStatus=@TDDocumentIDStatus WHERE ID=@ID";

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = S;
                LocConnecString.InsertRecord(spID, spWarning1Status,spWarning2Status, spWarning3Status, LDbStatus, spSysDateTime);
            }
            catch (Exception ex)
            {

            }
            return dtGetLocalCheck;
        }


        public DataTable GetLocalforWeb()
        {
            DataTable dtGetLocal = null;
            try
            {
                //web to local insert methoed
                string S = "SELECT * FROM TBL_TRANSFTERDISPLAYDATETIME WHERE Warning2Status='True' and Warning2Status='True' and Warning3Status='True'";

                LocConnecString.ConString = LocalConnString();
                LocConnecString.CmdType = CommandType.Text;
                LocConnecString.CmdString = S;
                dtGetLocal = LocConnecString.LoadDataSet().Tables[0];

            }
            catch (Exception ex)
            {

            }
            return dtGetLocal;
        }

    }
}
