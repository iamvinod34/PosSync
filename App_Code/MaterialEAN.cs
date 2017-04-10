using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
using DBConnection;
namespace PosSync.App_Code
{
       
    class MaterialEAN
    {

        DataCon objDB = new DataCon();
        #region Properties
        public string EAN13 { set; get; }
        public string MaterialID { set; get; }
        public string Uom { set; get; }
        public double ConvertValue { set; get; }
        public string BaseUom { set; get; }
        public string MaterialMix { set; get; }
        public string Dcon { set; get; }
        #endregion

     
        public DataTable InsertMaterialEAN()
        {
            DataTable dt_material = null;
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

                SqlCeParameter spUom = new SqlCeParameter();
                spUom.ParameterName = "@Uom";
                spUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUom.Value = this.Uom;

                SqlCeParameter spConvertvalue = new SqlCeParameter();
                spConvertvalue.ParameterName = "@ConvertValue";
                spConvertvalue.SqlDbType = System.Data.SqlDbType.Decimal;
                spConvertvalue.Value = this.ConvertValue;

                SqlCeParameter spBaseUom = new SqlCeParameter();
                spBaseUom.ParameterName = "@BaseUom";
                spBaseUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUom.Value = this.BaseUom;

                SqlCeParameter spMaterialMix = new SqlCeParameter();
                spMaterialMix.ParameterName = "@MaterialMix";
                spMaterialMix.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialMix.Value = this.MaterialMix;


                string s = "INSERT INTO TBL_MATERIALEAN_TEMP VALUES(@EAN13,@MATERIALID,@UOM,@CONVERTVALUE,@BASEUOM,@MATERIALMIX)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUom, spConvertvalue, spBaseUom,spMaterialMix);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_material;


        }
        public DataTable UpdateMaterialEAN_MasterData()
        {
            DataTable dt_upmat = null;
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

                SqlCeParameter spUom = new SqlCeParameter();
                spUom.ParameterName = "@Uom";
                spUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUom.Value = this.Uom;

                SqlCeParameter spConvertvalue = new SqlCeParameter();
                spConvertvalue.ParameterName = "@ConvertValue";
                spConvertvalue.SqlDbType = System.Data.SqlDbType.Decimal;
                spConvertvalue.Value = this.ConvertValue;

                SqlCeParameter spBaseUom = new SqlCeParameter();
                spBaseUom.ParameterName = "@BaseUom";
                spBaseUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUom.Value = this.BaseUom;

                SqlCeParameter spMaterialMix = new SqlCeParameter();
                spMaterialMix.ParameterName = "@MaterialMix";
                spMaterialMix.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialMix.Value = this.MaterialMix;

                string s = "update tbl_MaterialEAN set MaterialID=@MaterialID,UOM=@Uom,ConvertValue=@ConvertValue,BaseUOM=@BaseUom,MaterialMix=@MaterialMix where EAN13=@EAN13";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUom, spConvertvalue, spBaseUom,spMaterialMix);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_upmat;
        }
        public DataTable InsertMaterialEAN_MasterData()
        {
            DataTable dt_mat = null;
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

                SqlCeParameter spUom = new SqlCeParameter();
                spUom.ParameterName = "@Uom";
                spUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUom.Value = this.Uom;

                SqlCeParameter spConvertvalue = new SqlCeParameter();
                spConvertvalue.ParameterName = "@ConvertValue";
                spConvertvalue.SqlDbType = System.Data.SqlDbType.Decimal;
                spConvertvalue.Value = this.ConvertValue;

                SqlCeParameter spBaseUom = new SqlCeParameter();
                spBaseUom.ParameterName = "@BaseUom";
                spBaseUom.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUom.Value = this.BaseUom;

                SqlCeParameter spMaterialMix = new SqlCeParameter();
                spMaterialMix.ParameterName = "@MaterialMix";
                spMaterialMix.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialMix.Value = this.MaterialMix;

                string s = "INSERT INTO TBL_MATERIALEAN VALUES(@EAN13,@MATERIALID,@UOM,@CONVERTVALUE,@BASEUOM,@MATERIALMIX)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spEAN13, spMaterialID, spUom, spConvertvalue, spBaseUom,spMaterialMix);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_mat;
        }

    }
}
