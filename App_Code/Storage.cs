using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using DBConnection;
namespace PosSync.App_Code
{
    class Storage
    {
        #region Properties
        public string StorageID { get; set; }
        public string StorageName { get; set; }
        public string StorageType { get; set; }
        public string LocationID { get; set; }
        public string Dcon { get; set; }
        #endregion
        DataCon objDb = new DataCon();
        public DataTable InsertStorage_MasterData()
        {
            DataTable dt_storage = null;
            try
            {
                SqlCeParameter spStorageID = new SqlCeParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = this.StorageID;

                SqlCeParameter spStorageName = new SqlCeParameter();
                spStorageName.ParameterName = "@StorageName";
                spStorageName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageName.Value = this.StorageName;

                SqlCeParameter spStorageType = new SqlCeParameter();
                spStorageType.ParameterName = "@StorageType";
                spStorageType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageType.Value = this.StorageType;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;
                string s = "insert into tbl_storage values(@StorageID,@StorageName,@StorageType,@LocationID)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spStorageID, spStorageName, spStorageType, spLocationID);
            }
            catch (Exception ex)
            {

            }
            return dt_storage;
        }
        public DataTable UpdateStrorage_MasteData()
        {
            DataTable dt_st = null;
            try
            {
                SqlCeParameter spStorageID = new SqlCeParameter();
                spStorageID.ParameterName = "@StorageID";
                spStorageID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageID.Value = this.StorageID;

                SqlCeParameter spStorageName = new SqlCeParameter();
                spStorageName.ParameterName = "@StorageName";
                spStorageName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageName.Value = this.StorageName;

                SqlCeParameter spStorageType = new SqlCeParameter();
                spStorageType.ParameterName = "@StorageType";
                spStorageType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spStorageType.Value = this.StorageType;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "update tbl_storage set StorageName=@StorageName,StorageType=@StorageType,StorageID=@StorageID where LocationID=@LocationID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spStorageID, spStorageName, spStorageType, spLocationID);
            }
            catch (Exception ex)
            {

            }
            return dt_st;
        }
    }
}
