using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using DBConnection;
namespace PosSync.App_Code
{
    class Location
    {
        #region Properties
        public string LocationID { set; get; }
        public string LocationDesc { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string Address3 { set; get; }
        public string POBox { set; get; }
        public string Contact { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string City { set; get; }
        public string Region { set; get; }
        public string Country { set; get; }
        public string CostCenter { get; set; }
        public string BusinessArea { get; set; }
        public string FieldArea { set; get; }
        public double CashLoan { set; get; }
        public int CustInt1 { set; get; }
        public int CustInt2 { set; get; }
        public int CustInt3 { set; get; }
        public string Dcon { set; get; }
        #endregion

        DataCon objDB = new DataCon();

        public DataTable InsertLocation()
        {
            DataTable dt_location=null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spLocationDesc = new SqlCeParameter();
                spLocationDesc.ParameterName = "@LocationDesc";
                spLocationDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationDesc.Value = this.LocationDesc;

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

                SqlCeParameter spCostCenter = new SqlCeParameter();
                spCostCenter.ParameterName = "@CostCenter";
                spCostCenter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCostCenter.Value = this.CostCenter;

                SqlCeParameter spCashLoan = new SqlCeParameter();
                spCashLoan.ParameterName = "@CashLoan";
                spCashLoan.SqlDbType = System.Data.SqlDbType.Decimal;
                spCashLoan.Value = this.CashLoan;

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

                string s = "insert into tbl_location_temp(LocationID,LocationDesc,Address1,Address2,Address3,POBox,Contact,Phone,Fax,Email,City,Region,Country,"
                    + " CostCenter,CashLoan,CustInt1,CustInt2,CustInt3)values(@LocationID,@LocationDesc,@Address1,@Address2,@Address3,@POBox,@Contact,"
                   + " @Phone,@Fax,@Email,@City,@Region,@Country,@CostCenter,@CashLoan,@CustInt1,@CustInt2,@CustInt3)";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spLocationDesc, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry,
                    spCostCenter, spCashLoan, spCustInt1, spCustInt2, spCustInt3);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_location;
        }
        public DataTable InsertLocation_MasterData()
        {
            DataTable dt_location = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spLocationDesc = new SqlCeParameter();
                spLocationDesc.ParameterName = "@LocationDesc";
                spLocationDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationDesc.Value = this.LocationDesc;

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

                SqlCeParameter spCostCenter = new SqlCeParameter();
                spCostCenter.ParameterName = "@CostCenter";
                spCostCenter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCostCenter.Value = this.CostCenter;

                SqlCeParameter spCashLoan = new SqlCeParameter();
                spCashLoan.ParameterName = "@CashLoan";
                spCashLoan.SqlDbType = System.Data.SqlDbType.Decimal;
                spCashLoan.Value = this.CashLoan;

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

                string s = "insert into tbl_location(LocationID,LocationDesc,Address1,Address2,Address3,POBox,Contact,Phone,Email,City,Region,Country,"
                    + " CostCenter,CashLoan,CustInt1,CustInt2,CustInt3)values(@LocationID,@LocationDesc,@Address1,@Address2,@Address3,@POBox,@Contact,"
                   + " @Phone,@Email,@City,@Region,@Country,@CostCenter,@CashLoan,@CustInt1,@CustInt2,@CustInt3)";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spLocationDesc, spAddress1, spAddress2, spAddress3, spPOBox, spContact, spPhone, spFax, spEmail, spCity, spRegion, spCountry,
                    spCostCenter, spCashLoan, spCustInt1, spCustInt2, spCustInt3);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_location;
        }
        public DataTable UpdateLocation_MasterData()
        {
            DataTable dt_location = null;
            try
            {
                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spLocationDesc = new SqlCeParameter();
                spLocationDesc.ParameterName = "@LocationDesc";
                spLocationDesc.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationDesc.Value = this.LocationDesc;
               
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

                SqlCeParameter spCostCenter = new SqlCeParameter();
                spCostCenter.ParameterName = "@CostCenter";
                spCostCenter.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCostCenter.Value = this.CostCenter;

                SqlCeParameter spCashLoan = new SqlCeParameter();
                spCashLoan.ParameterName = "@CashLoan";
                spCashLoan.SqlDbType = System.Data.SqlDbType.Decimal;
                spCashLoan.Value = this.CashLoan;


                string s = "update tbl_location set LocationDesc=@LocationDesc,POBox=@POBox,Phone=@Phone,City=@City,Region=@Region,"
                    + " Country=@Country,CostCenter=@CostCenter,CashLoan=@CashLoan where LocationID=@LocationID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spLocationID, spLocationDesc,spPOBox, spContact, spPhone, spEmail, spCity, spRegion, spCountry,
                    spCostCenter, spCashLoan);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_location;

        }
    }
}
