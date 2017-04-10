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
   public class Tender
   {
       #region Properties
       public string TenderID { get; set; }
       public string TenderName { get; set; }
       public string GL_Debit { get; set; }
       public string GL_Credit { get; set; }
       public string Dcon { get; set; }
       #endregion
       DataCon objDb = new DataCon();
       public DataTable InsertTender_MasterData()
       {
           DataTable dt_tender = null;
           try
           {
               SqlCeParameter spTenderID = new SqlCeParameter();
               spTenderID.ParameterName = "@TenderID";
               spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
               spTenderID.Value = this.TenderID;

               SqlCeParameter spTenderName = new SqlCeParameter();
               spTenderName.ParameterName = "@TenderName";
               spTenderName.SqlDbType = System.Data.SqlDbType.NVarChar;
               spTenderName.Value = this.TenderName;

               SqlCeParameter spGL_Debit = new SqlCeParameter();
               spGL_Debit.ParameterName = "@GL_Debit";
               spGL_Debit.SqlDbType = System.Data.SqlDbType.NVarChar;
               spGL_Debit.Value = this.GL_Debit;

               SqlCeParameter spGL_Credit = new SqlCeParameter();
               spGL_Credit.ParameterName = "@GL_Credit";
               spGL_Credit.SqlDbType = System.Data.SqlDbType.NVarChar;
               spGL_Credit.Value = this.GL_Credit;

               string s = "insert into tbl_tender values(@TenderID,@TenderName,@GL_Debit,@GL_Credit)";
               objDb.ConString = Dcon;
               objDb.CmdType = CommandType.Text;
               objDb.CmdString = s;
               objDb.InsertRecord(spTenderID, spTenderName, spGL_Debit, spGL_Credit);


           }
           catch (Exception ex)
           {

           }
           return dt_tender;
       }
       public DataTable UpdateTender_MasterData()
       {
           DataTable dt_ten = null;
           try
           {
               SqlCeParameter spTenderID = new SqlCeParameter();
               spTenderID.ParameterName = "@TenderID";
               spTenderID.SqlDbType = System.Data.SqlDbType.NVarChar;
               spTenderID.Value = this.TenderID;

               SqlCeParameter spTenderName = new SqlCeParameter();
               spTenderName.ParameterName = "@TenderName";
               spTenderName.SqlDbType = System.Data.SqlDbType.NVarChar;
               spTenderName.Value = this.TenderName;

               SqlCeParameter spGL_Debit = new SqlCeParameter();
               spGL_Debit.ParameterName = "@GL_Debit";
               spGL_Debit.SqlDbType = System.Data.SqlDbType.NVarChar;
               spGL_Debit.Value = this.GL_Debit;

               SqlCeParameter spGL_Credit = new SqlCeParameter();
               spGL_Credit.ParameterName = "@GL_Credit";
               spGL_Credit.SqlDbType = System.Data.SqlDbType.NVarChar;
               spGL_Credit.Value = this.GL_Credit;

               string s = "update tbl_tender set TenderName=@TenderName,GL_Debit=@GL_Debit,GL_Credit=@GL_Credit where TenderID=@TenderID";
               objDb.ConString = Dcon;
               objDb.CmdType = CommandType.Text;
               objDb.CmdString = s;
               objDb.InsertRecord(spTenderID, spTenderName, spGL_Debit, spGL_Credit);
           }
           catch (Exception ex)
           {

           }
           return dt_ten;
       }
   }
}
