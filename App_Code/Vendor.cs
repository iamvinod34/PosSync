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

    class Vendor
    {
        #region Properties
        public string VendorID { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string POBox { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public int CustInt1 { get; set; }
        public int CustInt2 { get; set; }
        public int CustInt3 { get; set; }
        public string CustText1 { get; set; }
        public string CustText2 { get; set; }
        public string CustText3 { get; set; }
        public string Dcon { get; set; }
        #endregion

        DataCon objDb = new DataCon();
        
        public DataTable InsertVendor_MasterData()
        {
            DataTable dt = null;
            try
            {
                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;

                SqlCeParameter spName1 = new SqlCeParameter();
                spName1.ParameterName = "@Name1";
                spName1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName1.Value = this.Name1;

                SqlCeParameter spName2 = new SqlCeParameter();
                spName2.ParameterName = "@Name2";
                spName2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName2.Value = this.Name2;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = this.Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = this.Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = this.Address3;

                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = this.POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = this.Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = this.Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = this.Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = this.Email;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = this.City;

                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = this.Region;


                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = this.Country;

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

                SqlCeParameter spCustText1 = new SqlCeParameter();
                spCustText1.ParameterName = "@CustText1";
                spCustText1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText1.Value = this.CustText1;

                SqlCeParameter spCustText2 = new SqlCeParameter();
                spCustText2.ParameterName = "@CustText2";
                spCustText2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText2.Value = this.CustText2;

                SqlCeParameter spCustText3 = new SqlCeParameter();
                spCustText3.ParameterName = "@CustText3";
                spCustText3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustText3.Value = this.CustText3;

                string s = "insert into tbl_Vendor values(@VendorID,@Name1,@Name2,@Address1,@Address2,@Address3,@POBox,@Contact,@Phone,@Fax,@Email,@City,@Region,@Country,@CustInt1,"
                   + " @CustInt2,@CustInt3,@CustText1,@CustText2,@CustText3)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spVendorID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCustInt1,
                    spCustInt2, spCustInt3, spCustText1, spCustText2, spCustText3);


            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable UpdateVendor_MasterData()
        {
            DataTable dt = null;
            try
            {
                SqlCeParameter spVendorID = new SqlCeParameter();
                spVendorID.ParameterName = "@VendorID";
                spVendorID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spVendorID.Value = this.VendorID;

                SqlCeParameter spName1 = new SqlCeParameter();
                spName1.ParameterName = "@Name1";
                spName1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName1.Value = this.Name1;

                SqlCeParameter spName2 = new SqlCeParameter();
                spName2.ParameterName = "@Name2";
                spName2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spName2.Value = this.Name2;

                SqlCeParameter spAddress1 = new SqlCeParameter();
                spAddress1.ParameterName = "@Address1";
                spAddress1.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress1.Value = this.Address1;

                SqlCeParameter spAddress2 = new SqlCeParameter();
                spAddress2.ParameterName = "@Address2";
                spAddress2.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress2.Value = this.Address2;

                SqlCeParameter spAddress3 = new SqlCeParameter();
                spAddress3.ParameterName = "@Address3";
                spAddress3.SqlDbType = System.Data.SqlDbType.NVarChar;
                spAddress3.Value = this.Address3;

                SqlCeParameter spPOBox = new SqlCeParameter();
                spPOBox.ParameterName = "@POBox";
                spPOBox.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPOBox.Value = this.POBox;

                SqlCeParameter spContact = new SqlCeParameter();
                spContact.ParameterName = "@Contact";
                spContact.SqlDbType = System.Data.SqlDbType.NVarChar;
                spContact.Value = this.Contact;

                SqlCeParameter spPhone = new SqlCeParameter();
                spPhone.ParameterName = "@Phone";
                spPhone.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPhone.Value = this.Phone;

                SqlCeParameter spFax = new SqlCeParameter();
                spFax.ParameterName = "@Fax";
                spFax.SqlDbType = System.Data.SqlDbType.NVarChar;
                spFax.Value = this.Fax;

                SqlCeParameter spEmail = new SqlCeParameter();
                spEmail.ParameterName = "@Email";
                spEmail.SqlDbType = System.Data.SqlDbType.NVarChar;
                spEmail.Value = this.Email;

                SqlCeParameter spCity = new SqlCeParameter();
                spCity.ParameterName = "@City";
                spCity.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCity.Value = this.City;

                SqlCeParameter spRegion = new SqlCeParameter();
                spRegion.ParameterName = "@Region";
                spRegion.SqlDbType = System.Data.SqlDbType.NVarChar;
                spRegion.Value = this.Region;


                SqlCeParameter spCountry = new SqlCeParameter();
                spCountry.ParameterName = "@Country";
                spCountry.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCountry.Value = this.Country;



                string s = "update tbl_vendor set Name1=@Name1,Name2=@Name2,Address1=@Address1,Address2=@Address2,Address3=@Address3,POBox=@POBox,"
                    + " Contact=@Contact,Phone=@Phone,Fax=@Fax,Email=@Email,City=@City,Region=@Region,Country=@Country where VendorID=@VendorID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spVendorID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry);

            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}
