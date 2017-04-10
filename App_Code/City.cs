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
    class City
    {
        #region Properties
        public string CityID { get; set;}
        public string CityName { get; set; }
        public string Dcon { get; set; }
        #endregion
        DataCon objDB = new DataCon();
        public DataTable InsertCity_MasterData()
        {
            DataTable dt_city = null;
            try
            {
                SqlCeParameter spCityID = new SqlCeParameter();
                spCityID.ParameterName = "@CityID";
                spCityID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityID.Value = this.CityID;

                SqlCeParameter spCityName = new SqlCeParameter();
                spCityName.ParameterName = "@CityName";
                spCityName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityName.Value = this.CityName;

                string s = "insert into tbl_city values(@CityID,@CityName)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spCityID, spCityName);

            }
            catch (Exception ex)
            {

            }
            return dt_city;
        }
        public DataTable UpdateCity_MasterData()
        {
            DataTable dt_city = null;
            try
            {
                SqlCeParameter spCityID = new SqlCeParameter();
                spCityID.ParameterName = "@CityID";
                spCityID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityID.Value = this.CityID;

                SqlCeParameter spCityName = new SqlCeParameter();
                spCityName.ParameterName = "@CityName";
                spCityName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCityName.Value = this.CityName;

                string s = "update tbl_city set CityName=@CityName where CityID=@CityID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spCityID, spCityName);

            }
            catch (Exception ex)
            {

            }
            return dt_city;
        }
    }
}
