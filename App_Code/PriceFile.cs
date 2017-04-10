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
    class PriceFile
    {
        DataCon objDB = new DataCon();
        #region Properties
        public string EAN13 { set; get; }
        public string MaterialID { set; get; }
        public string UOM { set; get; }
        public double Price { set; get; }
        public string Dcon { set; get; }
        #endregion
        public DataTable InsertPriceFile()
        {
            DataTable dt_pricefile = null;
            try
            {
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


                string s = "INSERT INTO TBL_PRICEFILE_TEMP VALUES(@EAN13,@MATERIALID,@UOM,@PRICE)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUOM, spPrice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_pricefile;
        }
        public DataTable InsertpriceFile_MasterData()
        {
            DataTable dt_price = null;
            try
            {
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


                string s = "INSERT INTO TBL_PRICEFILE VALUES(@EAN13,@MATERIALID,@UOM,@PRICE)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUOM, spPrice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_price;
        }
        public DataTable UpdatePriceFile_MasterData()
        {
            DataTable dt_locprice = null;
            try
            {
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


                string s = "UPDATE TBL_PRICEFILE SET MATERIALID=@MATERIALID,UOM=@UOM,PRICE=@PRICE WHERE EAN13=@EAN13";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUOM, spPrice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_locprice;
        }
    }
}
