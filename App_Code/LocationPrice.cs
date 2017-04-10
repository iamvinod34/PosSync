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
    class LocationPrice
    {
        #region Properties
        public string LocationID { set; get; }
        public string EAN13 { set; get; }
        public string MaterialID { set; get; }
        public string UOM { set; get; }
        public double Price { set; get; }
        public string Dcon { set; get; }
        #endregion

        DataCon objDB = new DataCon();
        public DataTable InsertLocationPrice()
        {
            DataTable dt_locationPrice = null;
            try
            {
                SqlCeParameter spLocationID= new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spPrice = new SqlCeParameter();
                spPrice.ParameterName="@Price";
                spPrice.SqlDbType=System.Data.SqlDbType.Decimal;
                spPrice.Value=this.Price;


                string s = "INSERT INTO TBL_LOCATIONPRICE_TEMP VALUES(@LOCATIONID,@EAN13,@MATERIALID,@UOM,@PRICE)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spEAN13, spMaterialID, spUOM, spPrice);


            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_locationPrice;
        }
        public DataTable UpdateLocationPrice_MasterData()
        {
            DataTable dt_user = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spPrice = new SqlCeParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.Decimal;
                spPrice.Value = this.Price;


                string s = "UPDATE TBL_LOCATIONPRICE SET EAN13=@EAN13,MATERIALID=@MATERIALID,UOM=@UOM,PRICE=@PRICE WHERE LOCATIONID=@LOCATIONID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spEAN13, spMaterialID, spUOM, spPrice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_user;
        }
        public DataTable InsertLocationPrice_MasterData()
        {
            DataTable dt_locaion = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spEAN13 = new SqlCeParameter();
                spEAN13.ParameterName = "@EAN13";
                spEAN13.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEAN13.Value = this.EAN13;

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spUOM = new SqlCeParameter();
                spUOM.ParameterName = "@UOM";
                spUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUOM.Value = this.UOM;

                SqlCeParameter spPrice = new SqlCeParameter();
                spPrice.ParameterName = "@Price";
                spPrice.SqlDbType = System.Data.SqlDbType.Decimal;
                spPrice.Value = this.Price;


                string s = "INSERT INTO TBL_LOCATIONPRICE VALUES(@LOCATIONID,@EAN13,@MATERIALID,@UOM,@PRICE)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spEAN13, spMaterialID, spUOM, spPrice);

            }
            catch(Exception ex)
            {
                throw;
            }
            return dt_locaion;
        }
    }
}
