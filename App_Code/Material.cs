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
    class Material
    {
        #region "Properties"

        public string Dcon { get; set; }

        public string InvoiceId { get; set; }
        public string MaterialID { get; set; }

        public string MaterialDesc1 { get; set; }

        public string MaterialDesc2 { get; set; }

        public string MaterialDesc3 { get; set; }

        public string ProductURL { get; set; }

        public string CategoryID { get; set; }
        public string UserID { get; set; }

        public string SubCategoryID { get; set; }
        public string BaseUOM { set; get; }

        public double Cost { get; set; }

        public string VendorID { get; set; }

        public int CustInt1 { get; set; }
        public int CustInt2 { get; set; }
        public int CustInt3 { get; set; }


        public DateTime CustDate1 { get; set; }
        public DateTime CustDate2 { get; set; }
        public DateTime CustDate3 { get; set; }

        public DateTime AddDate { get; set; }
        public DateTime UpdDate { get; set; }
        // public DateTime CustDate3 { get; set; }
        public int Dataid { get; set; }
        public string DataCon { get; set; }


        #endregion
        DataCon objDB = new DataCon();
        public DataTable InsertMaterial()
        {
            DataTable dt_material = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spMaterialDesc1 = new SqlCeParameter();
                spMaterialDesc1.ParameterName = "@MaterialDesc1";
                spMaterialDesc1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc1.Value = this.MaterialDesc1;

                SqlCeParameter spMaterialDesc2 = new SqlCeParameter();
                spMaterialDesc2.ParameterName = "@MaterialDesc2";
                spMaterialDesc2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc2.Value = this.MaterialDesc2;


                SqlCeParameter spMaterialDesc3 = new SqlCeParameter();
                spMaterialDesc3.ParameterName = "@MaterialDesc3";
                spMaterialDesc3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc3.Value = this.MaterialDesc3;

                SqlCeParameter spProductURL = new SqlCeParameter();
                spProductURL.ParameterName = "@ProductURL";
                spProductURL.SqlDbType = System.Data.SqlDbType.NVarChar;
                spProductURL.Value = this.ProductURL;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;


                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = this.UserID;

                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spBaseUOM = new SqlCeParameter();
                spBaseUOM.ParameterName = "@BaseUOM";
                spBaseUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUOM.Value = this.BaseUOM;

                SqlCeParameter spCost = new SqlCeParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = this.Cost;

                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;


                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt1.Value = this.CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt2.Value = this.CustInt2;


                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt3.Value = this.CustInt3;

                SqlCeParameter spCustDate1 = new SqlCeParameter();
                spCustDate1.ParameterName = "@CustDate1";
                spCustDate1.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate1.Value = this.CustDate1;

                SqlCeParameter spCustDate2 = new SqlCeParameter();
                spCustDate2.ParameterName = "@CustDate2";
                spCustDate2.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate2.Value = this.CustDate2;

                SqlCeParameter spCustDate3 = new SqlCeParameter();
                spCustDate3.ParameterName = "@CustDate3";
                spCustDate3.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate3.Value = this.CustDate3;

                SqlCeParameter spAddDate = new SqlCeParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = this.AddDate;

                SqlCeParameter spUpdDate = new SqlCeParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = this.UpdDate;

                SqlCeParameter spDataid = new SqlCeParameter();
                spDataid.ParameterName = "@Dataid";
                spDataid.SqlDbType = System.Data.SqlDbType.Int;
                spDataid.Value = this.Dataid;


                 string s = "insert into tbl_material_temp(MaterialID,MaterialDesc1,MaterialDesc2,MaterialDesc3,ProductURL,CategoryID,SubCategoryID,"
                        + "BaseUOM,Cost,VendorID,CustInt1,CustInt2,CustInt3,CustDate1,CustDate2,CustDate3,UserID,AddDate,UpdDate,Dataid)"
                     +"values(@MaterialID,@MaterialDesc1,@MaterialDesc2,@MaterialDesc3,@ProductURL,@CategoryID,@SubCategoryID,@BaseUOM,@Cost,@VendorID,"
                +" @CustInt1,@CustInt2,@CustInt3,@CustDate1,@CustDate2,@CustDate3,@UserID,@AddDate,@UpdDate,@Dataid)";
                 objDB.ConString = Dcon;
                 objDB.CmdType = CommandType.Text;
                 objDB.CmdString = s;
                 objDB.InsertRecord(spMaterialID,spMaterialDesc1,spMaterialDesc2,spMaterialDesc3,spProductURL,spCategoryID,spSubCategoryID,
                     spBaseUOM,spCost,spVendorID,spCustInt1,spCustInt2,spCustInt3,spCustDate1,spCustDate2,spCustDate3,spUserID,spAddDate,spUpdDate,spDataid);


                
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_material;
        }
        public DataTable InsertMaterial_MasterData()
        {
            DataTable dt_material = null;
            try
            {

                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spMaterialDesc1 = new SqlCeParameter();
                spMaterialDesc1.ParameterName = "@MaterialDesc1";
                spMaterialDesc1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc1.Value = this.MaterialDesc1;

                SqlCeParameter spMaterialDesc2 = new SqlCeParameter();
                spMaterialDesc2.ParameterName = "@MaterialDesc2";
                spMaterialDesc2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc2.Value = this.MaterialDesc2;


                SqlCeParameter spMaterialDesc3 = new SqlCeParameter();
                spMaterialDesc3.ParameterName = "@MaterialDesc3";
                spMaterialDesc3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc3.Value = this.MaterialDesc3;

                SqlCeParameter spProductURL = new SqlCeParameter();
                spProductURL.ParameterName = "@ProductURL";
                spProductURL.SqlDbType = System.Data.SqlDbType.NVarChar;
                spProductURL.Value = this.ProductURL;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;


                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = this.UserID;

                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spBaseUOM = new SqlCeParameter();
                spBaseUOM.ParameterName = "@BaseUOM";
                spBaseUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUOM.Value = this.BaseUOM;

                SqlCeParameter spCost = new SqlCeParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = this.Cost;

                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;


                SqlCeParameter spCustInt1 = new SqlCeParameter();
                spCustInt1.ParameterName = "@CustInt1";
                spCustInt1.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt1.Value = this.CustInt1;

                SqlCeParameter spCustInt2 = new SqlCeParameter();
                spCustInt2.ParameterName = "@CustInt2";
                spCustInt2.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt2.Value = this.CustInt2;


                SqlCeParameter spCustInt3 = new SqlCeParameter();
                spCustInt3.ParameterName = "@CustInt3";
                spCustInt3.SqlDbType = System.Data.SqlDbType.Int;
                spCustInt3.Value = this.CustInt3;

                SqlCeParameter spCustDate1 = new SqlCeParameter();
                spCustDate1.ParameterName = "@CustDate1";
                spCustDate1.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate1.Value = this.CustDate1;

                SqlCeParameter spCustDate2 = new SqlCeParameter();
                spCustDate2.ParameterName = "@CustDate2";
                spCustDate2.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate2.Value = this.CustDate2;

                SqlCeParameter spCustDate3 = new SqlCeParameter();
                spCustDate3.ParameterName = "@CustDate3";
                spCustDate3.SqlDbType = System.Data.SqlDbType.DateTime;
                spCustDate3.Value = this.CustDate3;

                SqlCeParameter spAddDate = new SqlCeParameter();
                spAddDate.ParameterName = "@AddDate";
                spAddDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spAddDate.Value = this.AddDate;

                SqlCeParameter spUpdDate = new SqlCeParameter();
                spUpdDate.ParameterName = "@UpdDate";
                spUpdDate.SqlDbType = System.Data.SqlDbType.DateTime;
                spUpdDate.Value = this.UpdDate;


                string s = "insert into tbl_material(MaterialID,MaterialDesc1,MaterialDesc2,MaterialDesc3,ProductURL,CategoryID,SubCategoryID,"
                       + "BaseUOM,Cost,VendorID,CustInt1,CustInt2,CustInt3,CustDate1,CustDate2,CustDate3,UserID,AddDate,UpdDate)"
                    + "values(@MaterialID,@MaterialDesc1,@MaterialDesc2,@MaterialDesc3,@ProductURL,@CategoryID,@SubCategoryID,@BaseUOM,@Cost,@VendorID,"
               + " @CustInt1,@CustInt2,@CustInt3,@CustDate1,@CustDate2,@CustDate3,@UserID,@AddDate,@UpdDate)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spMaterialID, spMaterialDesc1, spMaterialDesc2, spMaterialDesc3, spProductURL, spCategoryID, spSubCategoryID,
                    spBaseUOM, spCost, spVendorID, spCustInt1, spCustInt2, spCustInt3, spCustDate1, spCustDate2, spCustDate3, spUserID, spAddDate, spUpdDate);

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_material;
        }
        public DataTable UpdateMaterial_MasterData()
        {
            DataTable dt_material = null;
            try
            {
                SqlCeParameter spMaterialID = new SqlCeParameter();
                spMaterialID.ParameterName = "@MaterialID";
                spMaterialID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialID.Value = this.MaterialID;

                SqlCeParameter spMaterialDesc1 = new SqlCeParameter();
                spMaterialDesc1.ParameterName = "@MaterialDesc1";
                spMaterialDesc1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc1.Value = this.MaterialDesc1;

                SqlCeParameter spMaterialDesc2 = new SqlCeParameter();
                spMaterialDesc2.ParameterName = "@MaterialDesc2";
                spMaterialDesc2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc2.Value = this.MaterialDesc2;


                SqlCeParameter spMaterialDesc3 = new SqlCeParameter();
                spMaterialDesc3.ParameterName = "@MaterialDesc3";
                spMaterialDesc3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spMaterialDesc3.Value = this.MaterialDesc3;

                SqlCeParameter spProductURL = new SqlCeParameter();
                spProductURL.ParameterName = "@ProductURL";
                spProductURL.SqlDbType = System.Data.SqlDbType.NVarChar;
                spProductURL.Value = this.ProductURL;

                SqlCeParameter spCategoryID = new SqlCeParameter();
                spCategoryID.ParameterName = "@CategoryID";
                spCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCategoryID.Value = this.CategoryID;


                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserID.Value = this.UserID;

                SqlCeParameter spSubCategoryID = new SqlCeParameter();
                spSubCategoryID.ParameterName = "@SubCategoryID";
                spSubCategoryID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spSubCategoryID.Value = this.SubCategoryID;

                SqlCeParameter spBaseUOM = new SqlCeParameter();
                spBaseUOM.ParameterName = "@BaseUOM";
                spBaseUOM.SqlDbType = System.Data.SqlDbType.NVarChar;
                spBaseUOM.Value = this.BaseUOM;

                SqlCeParameter spCost = new SqlCeParameter();
                spCost.ParameterName = "@Cost";
                spCost.SqlDbType = System.Data.SqlDbType.Decimal;
                spCost.Value = this.Cost;

                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;

                string s = "update tbl_material set MaterialDesc1=@MaterialDesc1,MaterialDesc2=@MaterialDesc2,MaterialDesc3=@MaterialDesc1,ProductURL=@ProductURL,"
                    + " CategoryID=@CategoryID,SubCategoryID=@SubCategoryID,BaseUOM=@BaseUOM,Cost=@Cost,VendorID=@VendorID where MaterialID=@MaterialID";
                 objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spMaterialID, spMaterialDesc1, spMaterialDesc2, spMaterialDesc3, spProductURL,
                    spCategoryID, spSubCategoryID, spBaseUOM, spCost, spVendorID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_material;
        }
    }
}
