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
    class Company
    {
        #region Properties
        public string CompanyID { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
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
        public string DefaultCurrency { get; set; }
        public string Dcon { get; set; }
        #endregion
        DataCon objDb = new DataCon();
        public DataTable InsertCompany_MaserData()
        {
            DataTable dt_company = null;
            try
            {
                SqlCeParameter spCompanyID = new SqlCeParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = this.CompanyID;

                SqlCeParameter spLongName = new SqlCeParameter();
                spLongName.ParameterName = "@LongName";
                spLongName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLongName.Value = this.LongName;

                SqlCeParameter spShortName = new SqlCeParameter();
                spShortName.ParameterName = "@ShortName";
                spShortName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spShortName.Value = this.ShortName;

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

                SqlCeParameter spDefaultCurrency = new SqlCeParameter();
                spDefaultCurrency.ParameterName = "@DefaultCurrency";
                spDefaultCurrency.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDefaultCurrency.Value = this.DefaultCurrency;

                string s = "Insert into tbl_Company values(@CompanyID,@LongName,@ShortName,@Address1,@Address2,@Address3,@POBox,@Contact,@Phone,@Fax,@Email,@City,@Region,@Country,@DefaultCurrency)";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCompanyID,spLongName,spShortName,spAddress1,spAddress2,spAddress3,spPOBox,spContact,spPhone,spFax,spEmail,spCity,spRegion,spCountry,spDefaultCurrency);
            }
            catch (Exception ex)
            {

            }
            return dt_company;
        }
        public DataTable UpdateCompany_MasterData()
        {
            DataTable dt_company = null;
            try
            {

                SqlCeParameter spCompanyID = new SqlCeParameter();
                spCompanyID.ParameterName = "@CompanyID";
                spCompanyID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCompanyID.Value = this.CompanyID;

                SqlCeParameter spLongName = new SqlCeParameter();
                spLongName.ParameterName = "@LongName";
                spLongName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLongName.Value = this.LongName;

                SqlCeParameter spShortName = new SqlCeParameter();
                spShortName.ParameterName = "@ShortName";
                spShortName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spShortName.Value = this.ShortName;

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

                SqlCeParameter spDefaultCurrency = new SqlCeParameter();
                spDefaultCurrency.ParameterName = "@DefaultCurrency";
                spDefaultCurrency.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDefaultCurrency.Value = this.DefaultCurrency;

                string s = "update tbl_company set LongName=@LongName,ShortName=@ShortName,Address1=@Address1,Address2=@Address2,Address3=@Address3,POBox=@POBox,Contact=@Contact,Phone=@Phone,"
                    + "Fax=@Fax,Email=@Email,City=@City,Region=@Region,Country=@Country,DefaultCurrency=@DefaultCurrency  where CompanyID=@CompanyID";
                objDb.ConString = Dcon;
                objDb.CmdType = CommandType.Text;
                objDb.CmdString = s;
                objDb.InsertRecord(spCompanyID, spLongName, spShortName, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spDefaultCurrency);
           
            }
            catch (Exception ex)
            {

            }
            return dt_company;
        }
    }
}
