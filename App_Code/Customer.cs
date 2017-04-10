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
    class Customer
    {
        #region properties
        public string CustomerID { set; get; }
        public string Name1 { set; get; }
        public string Name2 { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string Address3 { set; get; }
        public string POBox { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string City { set; get; }
        public string Region { set; get; }
        public string Country { set; get; }
        public double CreditLimit { set; get; }
        public int CustInt1 { set; get; }
        public int CustInt2 { set; get; }
        public int CustInt3 { set; get; }
        public string CustType { set; get; }
        public double TotalDue { set; get; }
        public string Dcon { set; get; }

        #endregion
        DataCon objDB = new DataCon();

        public DataTable InsertCustomer()
        {
            DataTable dt_cus = null;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName="@CustomerID";
                spCustomerID.SqlDbType=System.Data.SqlDbType.NVarChar;
                spCustomerID.Value=this.CustomerID;

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

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditLimit.Value = this.CreditLimit;

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

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = this.CustType;

                SqlCeParameter spTotalDue = new SqlCeParameter();
                spTotalDue.ParameterName = "@TotalDue";
                spTotalDue.SqlDbType = System.Data.SqlDbType.Decimal;
                spTotalDue.Value = this.TotalDue;

                string s = "insert into tbl_Customer_Temp(CustomerID,Name1,Name2,Address1,Address2,Address3,POBox,Phone,Fax,Email,City,Region,Country,CreditLimit,"
                    + " CustInt1,CustInt2,CustInt3,CustType,TotalDue)values(@CustomerID,@Name1,@Name2,@Address1,@Address2,@Address3,@POBox,@Phone,@Fax,@Email,@City,@Region,@Country,@CreditLimit,"
                    + " @CustInt1,@CustInt2,@CustInt3,@CustType,@TotalDue)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spCustomerID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCreditLimit,
                    spCustInt1, spCustInt2, spCustInt3, spCustType, spTotalDue);

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cus;
        }
        public DataTable InsertCustomer_MasterData()
        {
            DataTable dt_cus = null;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = this.CustomerID;

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

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditLimit.Value = this.CreditLimit;

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

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = this.CustType;

                SqlCeParameter spTotalDue = new SqlCeParameter();
                spTotalDue.ParameterName = "@TotalDue";
                spTotalDue.SqlDbType = System.Data.SqlDbType.Decimal;
                spTotalDue.Value = this.TotalDue;

                string s = "INSERT INTO TBL_CUSTOMER(CUSTOMERID,NAME1,NAME2,ADDRESS1,ADDRESS2,ADDRESS3,POBOX,PHONE,FAX,EMAIL,CITY,REGION,COUNTRY,CREDITLIMIT,"
                    + " CUSTINT1,CUSTINT2,CUSTINT3,CUSTTYPE,TOTALDUE)VALUES(@CUSTOMERID,@NAME1,@NAME2,@ADDRESS1,@ADDRESS2,@ADDRESS3,@POBOX,@PHONE,@FAX,@EMAIL,@CITY,@REGION,@COUNTRY,@CREDITLIMIT,"
                    + " @CUSTINT1,@CUSTINT2,@CUSTINT3,@CUSTTYPE,@TOTALDUE)";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spCustomerID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCreditLimit,
                    spCustInt1, spCustInt2, spCustInt3, spCustType, spTotalDue);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cus;

        }
        public DataTable UpdateCustomer_MasterData()
        {
            DataTable dt_cus = null;
            try
            {
                SqlCeParameter spCustomerID = new SqlCeParameter();
                spCustomerID.ParameterName = "@CustomerID";
                spCustomerID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustomerID.Value = this.CustomerID;

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

                SqlCeParameter spCreditLimit = new SqlCeParameter();
                spCreditLimit.ParameterName = "@CreditLimit";
                spCreditLimit.SqlDbType = System.Data.SqlDbType.Decimal;
                spCreditLimit.Value = this.CreditLimit;

                SqlCeParameter spCustType = new SqlCeParameter();
                spCustType.ParameterName = "@CustType";
                spCustType.SqlDbType = System.Data.SqlDbType.NVarChar;
                spCustType.Value = this.CustType;

                SqlCeParameter spTotalDue = new SqlCeParameter();
                spTotalDue.ParameterName = "@TotalDue";
                spTotalDue.SqlDbType = System.Data.SqlDbType.Decimal;
                spTotalDue.Value = this.TotalDue;

                string s = "UPDATE TBL_CUSTOMER SET NAME1=@NAME1,NAME2=@NAME2,ADDRESS1=@ADDRESS1,ADDRESS2=@ADDRESS2,ADDRESS3=@ADDRESS3,POBOX=@POBOX,PHONE=@PHONE,"
                    + " FAX=@FAX,EMAIL=@EMAIL,CITY=@CITY,REGION=@REGION,COUNTRY=@COUNTRY,CREDITLIMIT=@CREDITLIMIT,CUSTTYPE=@CUSTTYPE,TOTALDUE=@TOTALDUE WHERE CUSTOMERID=@CUSTOMERID";
                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spCustomerID, spName1, spName2, spAddress1, spAddress2, spAddress3, spPOBox, spPhone, spFax, spEmail, spCity, spRegion, spCountry, spCreditLimit,
                     spCustType, spTotalDue);
          
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_cus;

        }
    }
}
