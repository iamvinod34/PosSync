using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using DBConnection;
using System.Data.SqlClient;
using System.Configuration;

namespace PosSync.App_Code
{
    public  class ServerConn
    {
        public static string ServerConnection()
        {
            string Connection = null;
            try
            {
                Connection = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;
            }
            catch (Exception ex)
            {

                throw;
            }
            return Connection;
        }

        public static string LocalConnection()
        {
            string Connection = null;
            try
            {
                Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {

                throw;
            }
            return Connection;
        }

    }
    public class Users
    {
        DataCon objDB = new DataCon();
        MyDataConnection objServer = new MyDataConnection();

        #region Properties

        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string LocationID { set; get; }
        public string Payment { get; set; }
        public string ReturnInv { get; set; }
        public string ReturnNoInv { get; set; }
        public string DeleteInv { get; set; }
        public string Cash { get; set; }
        public string CreditCard { get; set; }
        public string DebitCard { get; set; }
        public string OnAccount { get; set; }
        public string Den1 { get; set; }
        public string Den5 { get; set; }
        public string Den10 { get; set; }
        public string Den20 { get; set; }
        public string Den50 { get; set; }
        public string Den100 { get; set; }
        public string Den500 { get; set; }
        public string HoldInv { get; set; }
        public string unholdInv { get; set; }
        public string Barcode { get; set; }
        public string Quantity { get; set; }
        public string Inventory { get; set; }
        public string POReceive { get; set; }
        public string ReturnSupp { get; set; }
        public string TransferDisp { get; set; }
        public string TransferIn { get; set; }
        public string TransferOut { get; set; }
        public string PhyInventory { get; set; }
        public string StockReport { get; set; }
        public string Settingbutt { get; set; }
        public string PrinterSetup { get; set; }
        public string EOD { get; set; }
        public string FavoritePannel { get; set; }
        public string LockUser { get; set; }
        public string DeleteItem { get; set; }
        public string OrderButton { get; set; }
        public string OrderTextBox { set; get; }
        public string SampleButton { get; set; }
        public string MaterialMenu { get; set; }
        public string ItemCardReportButton { get; set; }
        public string ProductionOrder { get; set; }
        public string Register { get; set; }
        public string TranfterOutToLocationID { get; set; }
        public string Button_Delivery { get; set; }


        public string Dcon { set; get; }

        #endregion

        public DataTable Get_ServerUsers()
        {
            DataTable dtUsers = null;
            try
            {
                SqlParameter spLocationID = new SqlParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = LocationID;

                string s = "select * from tbl_Users where LocationID=@LocationID and ConRead='False'";

                objServer.ConString = ServerConn.ServerConnection();
                objServer.CmdType = CommandType.Text;
                objServer.CmdString = s;
               dtUsers= objServer.LoadDataSet(spLocationID).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return dtUsers;
        }
        

        public DataTable InsertUsers()
        {
            DataTable dt_users = null;
            try
            {
                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.Int;
                spUserID.Value = this.UserID;

                SqlCeParameter spUserName = new SqlCeParameter();
                spUserName.ParameterName = "@UserName";
                spUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserName.Value = this.UserName;

                SqlCeParameter spPassword = new SqlCeParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = this.Password;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spPayment = new SqlCeParameter();
                spPayment.ParameterName = "@Payment";
                spPayment.SqlDbType = System.Data.SqlDbType.NChar;
                spPayment.Value = this.Payment;

                SqlCeParameter spReturnInv = new SqlCeParameter();
                spReturnInv.ParameterName = "@ReturnInv";
                spReturnInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnInv.Value = this.ReturnInv;

                SqlCeParameter spReturnNoInv = new SqlCeParameter();
                spReturnNoInv.ParameterName = "@ReturnNoInv";
                spReturnNoInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnNoInv.Value = this.ReturnNoInv;

                SqlCeParameter spDeleteInv = new SqlCeParameter();
                spDeleteInv.ParameterName = "@DeleteInv";
                spDeleteInv.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteInv.Value = this.DeleteInv;

                SqlCeParameter spCash = new SqlCeParameter();
                spCash.ParameterName = "@Cash";
                spCash.SqlDbType = System.Data.SqlDbType.NChar;
                spCash.Value = this.Cash;

                SqlCeParameter spCreditCard = new SqlCeParameter();
                spCreditCard.ParameterName = "@CreditCard";
                spCreditCard.SqlDbType = System.Data.SqlDbType.NChar;
                spCreditCard.Value = this.CreditCard;

                SqlCeParameter spDebitCard = new SqlCeParameter();
                spDebitCard.ParameterName = "@DebitCard";
                spDebitCard.SqlDbType = System.Data.SqlDbType.NChar;
                spDebitCard.Value = this.DebitCard;

                SqlCeParameter spOnAccount = new SqlCeParameter();
                spOnAccount.ParameterName = "@OnAccount";
                spOnAccount.SqlDbType = System.Data.SqlDbType.NChar;
                spOnAccount.Value = this.OnAccount;

                SqlCeParameter spDen1 = new SqlCeParameter();
                spDen1.ParameterName = "@Den1";
                spDen1.SqlDbType = System.Data.SqlDbType.NChar;
                spDen1.Value = this.Den1;

                SqlCeParameter spDen5 = new SqlCeParameter();
                spDen5.ParameterName = "@Den5";
                spDen5.SqlDbType = System.Data.SqlDbType.NChar;
                spDen5.Value = this.Den5;

                SqlCeParameter spDen10 = new SqlCeParameter();
                spDen10.ParameterName = "@Den10";
                spDen10.SqlDbType = System.Data.SqlDbType.NChar;
                spDen10.Value = this.Den10;

                SqlCeParameter spDen20 = new SqlCeParameter();
                spDen20.ParameterName = "@Den20";
                spDen20.SqlDbType = System.Data.SqlDbType.NChar;
                spDen20.Value = this.Den20;

                SqlCeParameter spDen50 = new SqlCeParameter();
                spDen50.ParameterName = "@Den50";
                spDen50.SqlDbType = System.Data.SqlDbType.NChar;
                spDen50.Value = this.Den50;

                SqlCeParameter spDen100 = new SqlCeParameter();
                spDen100.ParameterName = "@Den100";
                spDen100.SqlDbType = System.Data.SqlDbType.NChar;
                spDen100.Value = this.Den100;

                SqlCeParameter spDen500 = new SqlCeParameter();
                spDen500.ParameterName = "@Den500";
                spDen500.SqlDbType = System.Data.SqlDbType.NChar;
                spDen500.Value = this.Den500;

                SqlCeParameter spHoldInv = new SqlCeParameter();
                spHoldInv.ParameterName = "@HoldInv";
                spHoldInv.SqlDbType = System.Data.SqlDbType.NChar;
                spHoldInv.Value = this.HoldInv;

                SqlCeParameter spunholdInv = new SqlCeParameter();
                spunholdInv.ParameterName = "@unholdInv";
                spunholdInv.SqlDbType = System.Data.SqlDbType.NChar;
                spunholdInv.Value = this.unholdInv;

                SqlCeParameter spBarcode = new SqlCeParameter();
                spBarcode.ParameterName = "@Barcode";
                spBarcode.SqlDbType = System.Data.SqlDbType.NChar;
                spBarcode.Value = this.Barcode;

                SqlCeParameter spQuantity = new SqlCeParameter();
                spQuantity.ParameterName = "@Quantity";
                spQuantity.SqlDbType = System.Data.SqlDbType.NChar;
                spQuantity.Value = this.Quantity;

                SqlCeParameter spInventory = new SqlCeParameter();
                spInventory.ParameterName = "@Inventory";
                spInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spInventory.Value = this.Inventory;

                SqlCeParameter spPOReceive = new SqlCeParameter();
                spPOReceive.ParameterName = "@POReceive";
                spPOReceive.SqlDbType = System.Data.SqlDbType.NChar;
                spPOReceive.Value = this.POReceive;

                SqlCeParameter spReturnSupp = new SqlCeParameter();
                spReturnSupp.ParameterName = "@ReturnSupp";
                spReturnSupp.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnSupp.Value = this.ReturnSupp;

                SqlCeParameter spTransferDisp = new SqlCeParameter();
                spTransferDisp.ParameterName = "@TransferDisp";
                spTransferDisp.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferDisp.Value = this.TransferDisp;

                SqlCeParameter spTransferIn = new SqlCeParameter();
                spTransferIn.ParameterName = "@TransferIn";
                spTransferIn.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferIn.Value = this.TransferIn;

                SqlCeParameter spTransferOut = new SqlCeParameter();
                spTransferOut.ParameterName = "@TransferOut";
                spTransferOut.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferOut.Value = this.TransferOut;

                SqlCeParameter spPhyInventory = new SqlCeParameter();
                spPhyInventory.ParameterName = "@PhyInventory";
                spPhyInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spPhyInventory.Value = this.PhyInventory;

                SqlCeParameter spStockReport = new SqlCeParameter();
                spStockReport.ParameterName = "@StockReport";
                spStockReport.SqlDbType = System.Data.SqlDbType.NChar;
                spStockReport.Value = this.StockReport;

                SqlCeParameter spSettingbutt = new SqlCeParameter();
                spSettingbutt.ParameterName = "@Settingbutt";
                spSettingbutt.SqlDbType = System.Data.SqlDbType.NChar;
                spSettingbutt.Value = this.Settingbutt;

                SqlCeParameter spPrinterSetup = new SqlCeParameter();
                spPrinterSetup.ParameterName = "@PrinterSetup";
                spPrinterSetup.SqlDbType = System.Data.SqlDbType.NChar;
                spPrinterSetup.Value = this.PrinterSetup;

                SqlCeParameter spEOD = new SqlCeParameter();
                spEOD.ParameterName = "@EOD";
                spEOD.SqlDbType = System.Data.SqlDbType.NChar;
                spEOD.Value = this.EOD;

                SqlCeParameter spFavoritePannel = new SqlCeParameter();
                spFavoritePannel.ParameterName = "@FavoritePannel";
                spFavoritePannel.SqlDbType = System.Data.SqlDbType.NChar;
                spFavoritePannel.Value = this.FavoritePannel;

                SqlCeParameter spLockUser = new SqlCeParameter();
                spLockUser.ParameterName = "@LockUser";
                spLockUser.SqlDbType = System.Data.SqlDbType.NChar;
                spLockUser.Value = this.LockUser;

                SqlCeParameter spDeleteItem = new SqlCeParameter();
                spDeleteItem.ParameterName = "@DeleteItem";
                spDeleteItem.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteItem.Value = this.DeleteItem;

                SqlCeParameter spOrderButton = new SqlCeParameter();
                spOrderButton.ParameterName = "@OrderButton";
                spOrderButton.SqlDbType = System.Data.SqlDbType.NChar;
                spOrderButton.Value = this.OrderButton;

                SqlCeParameter spOrderTextBox = new SqlCeParameter();
                spOrderTextBox.ParameterName = "@OrderTextBox";
                spOrderTextBox.SqlDbType = System.Data.SqlDbType.NChar;
                spOrderTextBox.Value = this.OrderTextBox;

                SqlCeParameter spSampleButton = new SqlCeParameter();
                spSampleButton.ParameterName = "@SampleButton";
                spSampleButton.SqlDbType = System.Data.SqlDbType.NChar;
                spSampleButton.Value = this.SampleButton;

                SqlCeParameter spMaterialMenu = new SqlCeParameter();
                spMaterialMenu.ParameterName = "@MaterialMenu";
                spMaterialMenu.SqlDbType = System.Data.SqlDbType.NChar;
                spMaterialMenu.Value = this.MaterialMenu;

                SqlCeParameter spItemCardReportButton = new SqlCeParameter();
                spItemCardReportButton.ParameterName = "@ItemCardReportButton";
                spItemCardReportButton.SqlDbType = System.Data.SqlDbType.NChar;
                spItemCardReportButton.Value = this.ItemCardReportButton;

                SqlCeParameter spProductionOrder = new SqlCeParameter();
                spProductionOrder.ParameterName = "@ProductionOrder";
                spProductionOrder.SqlDbType = System.Data.SqlDbType.NChar;
                spProductionOrder.Value = this.ProductionOrder;

                SqlCeParameter spRegister = new SqlCeParameter();
                spRegister.ParameterName = "@Register";
                spRegister.SqlDbType = System.Data.SqlDbType.NChar;
                spRegister.Value = this.Register;

                SqlCeParameter spTranfterOutToLocationID = new SqlCeParameter();
                spTranfterOutToLocationID.ParameterName = "@TranfterOutToLocationID";
                spTranfterOutToLocationID.SqlDbType = System.Data.SqlDbType.NChar;
                spTranfterOutToLocationID.Value = this.TranfterOutToLocationID;

                SqlCeParameter spButton_Delivery = new SqlCeParameter();
                spButton_Delivery.ParameterName = "@Button_Delivery";
                spButton_Delivery.SqlDbType = System.Data.SqlDbType.NChar;
                spButton_Delivery.Value = this.Button_Delivery;


                string s = "INSERT INTO TBL_USERS_TEMP(USERID,USERNAME,PASSWORD,LOCATIONID,PAYMENT,RETURNINV,"+
                    " RETURNNOINV,DELETEINV,CASH,CREDITCARD,DEBITCARD,ONACCOUNT,DEN1,DEN5,DEN10,DEN20,DEN50,"+
                    " DEN100,DEN500,HOLDINV,UNHOLDINV,BARCODE,QUANTITY,INVENTORY,PORECEIVE,RETURNSUPP,"+
                    " TRANSFERDISP,TRANSFERIN,TRANSFEROUT,PHYINVENTORY,STOCKREPORT,SETTINGBUTT,PRINTERSETUP,"+
                     " EOD,FAVORITEPANNEL,LOCKUSER,DELETEITEM,Quantity,OrderButton,OrderTextBox,SampleButton,"+
                     " MaterialMenu,ItemCardReportButton,ProductionOrder,Register,TranfterOutToLocationID," +
                     " Button_Delivery)"
                + " VALUES(@USERID,@USERNAME,@PASSWORD,@LOCATIONID,@PAYMENT,@RETURNINV,@RETURNNOINV,@DELETEINV,"+
                 " @CASH,@CREDITCARD,@DEBITCARD,@ONACCOUNT,@DEN1,@DEN5,@DEN10,@DEN20,@DEN50,@DEN100,@DEN500,"+
                 " @HOLDINV,@UNHOLDINV,@BARCODE,@QUANTITY,@INVENTORY,@PORECEIVE,@RETURNSUPP,@TRANSFERDISP,"+
                 " @TRANSFERIN,@TRANSFEROUT,@PHYINVENTORY,@STOCKREPORT,@SETTINGBUTT,@PRINTERSETUP,@EOD,"+
                 " @FAVORITEPANNEL,@LOCKUSER,@DELETEITEM,@Quantity,@OrderButton,@OrderTextBox,@SampleButton,@MaterialMenu,"+
                 " @ItemCardReportButton,@ProductionOrder,@Register,@TranfterOutToLocationID,@Button_Delivery)";

                objDB.ConString = Dcon;
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spUserID, spUserName, spPassword, spLocationID, spPayment, spReturnInv, spReturnNoInv, spDeleteInv, spCash, spCreditCard, spDebitCard,
                    spOnAccount, spDen1, spDen5, spDen10, spDen20, spDen50, spDen100, spDen500, spHoldInv, spunholdInv, spBarcode, spQuantity, spInventory, spPOReceive, spReturnSupp, spTransferDisp,
                    spTransferIn, spTransferOut, spPhyInventory, spStockReport, spSettingbutt, spPrinterSetup, spEOD, spFavoritePannel, spLockUser, spDeleteItem,
                    spOrderButton,spOrderTextBox,spSampleButton,spMaterialMenu,spItemCardReportButton,spProductionOrder,spRegister,spTranfterOutToLocationID,spButton_Delivery);

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_users;
        }

        internal void DeleteUserId()
        {
            try
            {
                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.Int;
                spUserID.Value = this.UserID;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                string s = "Delete from tbl_users where UserId=@UserID and LocationID=@LocationID";

                objDB.ConString = ServerConn.LocalConnection();
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spUserID, spLocationID);

                //server delete userid
                SqlParameter spDUserID = new SqlParameter();
                spDUserID.ParameterName = "@UserID";
                spDUserID.SqlDbType = System.Data.SqlDbType.Int;
                spDUserID.Value = this.UserID;

                SqlParameter spDLocationID = new SqlParameter();
                spDLocationID.ParameterName = "@LocationID";
                spDLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spDLocationID.Value = this.LocationID;
               
                string svr = "Delete from tbl_users where UserId=@UserID and LocationID=@LocationID";

                objServer.ConString = ServerConn.ServerConnection();
                objServer.CmdType = CommandType.Text;
                objServer.CmdString = svr;
                objServer.InsertRecord(spDUserID, spDLocationID);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable InsertUsers_MasterData()
        {
            DataTable dt_users = null;
            try
            {
                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.Int;
                spUserID.Value = this.UserID;

                SqlCeParameter spUserName = new SqlCeParameter();
                spUserName.ParameterName = "@UserName";
                spUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserName.Value = this.UserName;

                SqlCeParameter spPassword = new SqlCeParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = this.Password;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spPayment = new SqlCeParameter();
                spPayment.ParameterName = "@Payment";
                spPayment.SqlDbType = System.Data.SqlDbType.NChar;
                spPayment.Value = this.Payment;

                SqlCeParameter spReturnInv = new SqlCeParameter();
                spReturnInv.ParameterName = "@ReturnInv";
                spReturnInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnInv.Value = this.ReturnInv;

                SqlCeParameter spReturnNoInv = new SqlCeParameter();
                spReturnNoInv.ParameterName = "@ReturnNoInv";
                spReturnNoInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnNoInv.Value = this.ReturnNoInv;

                SqlCeParameter spDeleteInv = new SqlCeParameter();
                spDeleteInv.ParameterName = "@DeleteInv";
                spDeleteInv.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteInv.Value = this.DeleteInv;

                SqlCeParameter spCash = new SqlCeParameter();
                spCash.ParameterName = "@Cash";
                spCash.SqlDbType = System.Data.SqlDbType.NChar;
                spCash.Value = this.Cash;

                SqlCeParameter spCreditCard = new SqlCeParameter();
                spCreditCard.ParameterName = "@CreditCard";
                spCreditCard.SqlDbType = System.Data.SqlDbType.NChar;
                spCreditCard.Value = this.CreditCard;

                SqlCeParameter spDebitCard = new SqlCeParameter();
                spDebitCard.ParameterName = "@DebitCard";
                spDebitCard.SqlDbType = System.Data.SqlDbType.NChar;
                spDebitCard.Value = this.DebitCard;

                SqlCeParameter spOnAccount = new SqlCeParameter();
                spOnAccount.ParameterName = "@OnAccount";
                spOnAccount.SqlDbType = System.Data.SqlDbType.NChar;
                spOnAccount.Value = this.OnAccount;

                SqlCeParameter spDen1 = new SqlCeParameter();
                spDen1.ParameterName = "@Den1";
                spDen1.SqlDbType = System.Data.SqlDbType.NChar;
                spDen1.Value = this.Den1;

                SqlCeParameter spDen5 = new SqlCeParameter();
                spDen5.ParameterName = "@Den5";
                spDen5.SqlDbType = System.Data.SqlDbType.NChar;
                spDen5.Value = this.Den5;

                SqlCeParameter spDen10 = new SqlCeParameter();
                spDen10.ParameterName = "@Den10";
                spDen10.SqlDbType = System.Data.SqlDbType.NChar;
                spDen10.Value = this.Den10;

                SqlCeParameter spDen20 = new SqlCeParameter();
                spDen20.ParameterName = "@Den20";
                spDen20.SqlDbType = System.Data.SqlDbType.NChar;
                spDen20.Value = this.Den20;

                SqlCeParameter spDen50 = new SqlCeParameter();
                spDen50.ParameterName = "@Den50";
                spDen50.SqlDbType = System.Data.SqlDbType.NChar;
                spDen50.Value = this.Den50;

                SqlCeParameter spDen100 = new SqlCeParameter();
                spDen100.ParameterName = "@Den100";
                spDen100.SqlDbType = System.Data.SqlDbType.NChar;
                spDen100.Value = this.Den100;

                SqlCeParameter spDen500 = new SqlCeParameter();
                spDen500.ParameterName = "@Den500";
                spDen500.SqlDbType = System.Data.SqlDbType.NChar;
                spDen500.Value = this.Den500;

                SqlCeParameter spHoldInv = new SqlCeParameter();
                spHoldInv.ParameterName = "@HoldInv";
                spHoldInv.SqlDbType = System.Data.SqlDbType.NChar;
                spHoldInv.Value = this.HoldInv;

                SqlCeParameter spunholdInv = new SqlCeParameter();
                spunholdInv.ParameterName = "@unholdInv";
                spunholdInv.SqlDbType = System.Data.SqlDbType.NChar;
                spunholdInv.Value = this.unholdInv;

                SqlCeParameter spBarcode = new SqlCeParameter();
                spBarcode.ParameterName = "@Barcode";
                spBarcode.SqlDbType = System.Data.SqlDbType.NChar;
                spBarcode.Value = this.Barcode;

                SqlCeParameter spQuantity = new SqlCeParameter();
                spQuantity.ParameterName = "@Quantity";
                spQuantity.SqlDbType = System.Data.SqlDbType.NChar;
                spQuantity.Value = this.Quantity;

                SqlCeParameter spInventory = new SqlCeParameter();
                spInventory.ParameterName = "@Inventory";
                spInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spInventory.Value = this.Inventory;

                SqlCeParameter spPOReceive = new SqlCeParameter();
                spPOReceive.ParameterName = "@POReceive";
                spPOReceive.SqlDbType = System.Data.SqlDbType.NChar;
                spPOReceive.Value = this.POReceive;

                SqlCeParameter spReturnSupp = new SqlCeParameter();
                spReturnSupp.ParameterName = "@ReturnSupp";
                spReturnSupp.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnSupp.Value = this.ReturnSupp;

                SqlCeParameter spTransferDisp = new SqlCeParameter();
                spTransferDisp.ParameterName = "@TransferDisp";
                spTransferDisp.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferDisp.Value = this.TransferDisp;

                SqlCeParameter spTransferIn = new SqlCeParameter();
                spTransferIn.ParameterName = "@TransferIn";
                spTransferIn.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferIn.Value = this.TransferIn;

                SqlCeParameter spTransferOut = new SqlCeParameter();
                spTransferOut.ParameterName = "@TransferOut";
                spTransferOut.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferOut.Value = this.TransferOut;

                SqlCeParameter spPhyInventory = new SqlCeParameter();
                spPhyInventory.ParameterName = "@PhyInventory";
                spPhyInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spPhyInventory.Value = this.PhyInventory;

                SqlCeParameter spStockReport = new SqlCeParameter();
                spStockReport.ParameterName = "@StockReport";
                spStockReport.SqlDbType = System.Data.SqlDbType.NChar;
                spStockReport.Value = this.StockReport;

                SqlCeParameter spSettingbutt = new SqlCeParameter();
                spSettingbutt.ParameterName = "@Settingbutt";
                spSettingbutt.SqlDbType = System.Data.SqlDbType.NChar;
                spSettingbutt.Value = this.Settingbutt;

                SqlCeParameter spPrinterSetup = new SqlCeParameter();
                spPrinterSetup.ParameterName = "@PrinterSetup";
                spPrinterSetup.SqlDbType = System.Data.SqlDbType.NChar;
                spPrinterSetup.Value = this.PrinterSetup;

                SqlCeParameter spEOD = new SqlCeParameter();
                spEOD.ParameterName = "@EOD";
                spEOD.SqlDbType = System.Data.SqlDbType.NChar;
                spEOD.Value = this.EOD;

                SqlCeParameter spFavoritePannel = new SqlCeParameter();
                spFavoritePannel.ParameterName = "@FavoritePannel";
                spFavoritePannel.SqlDbType = System.Data.SqlDbType.NChar;
                spFavoritePannel.Value = this.FavoritePannel;

                SqlCeParameter spLockUser = new SqlCeParameter();
                spLockUser.ParameterName = "@LockUser";
                spLockUser.SqlDbType = System.Data.SqlDbType.NChar;
                spLockUser.Value = this.LockUser;

                SqlCeParameter spDeleteItem = new SqlCeParameter();
                spDeleteItem.ParameterName = "@DeleteItem";
                spDeleteItem.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteItem.Value = this.DeleteItem;

                string s = "INSERT INTO TBL_USERS(USERID,USERNAME,PASSWORD,LOCATIONID,PAYMENT,RETURNINV,RETURNNOINV,DELETEINV,CASH,CREDITCARD,DEBITCARD,ONACCOUNT,DEN1,DEN5,DEN10,DEN20,DEN50,DEN100,DEN500,HOLDINV,UNHOLDINV,BARCODE,QUANTITY,INVENTORY,PORECEIVE,RETURNSUPP,TRANSFERDISP,TRANSFERIN,TRANSFEROUT,PHYINVENTORY,STOCKREPORT,SETTINGBUTT,PRINTERSETUP,EOD,FAVORITEPANNEL,LOCKUSER,DELETEITEM)"
                + " VALUES(@USERID,@USERNAME,@PASSWORD,@LOCATIONID,@PAYMENT,@RETURNINV,@RETURNNOINV,@DELETEINV,@CASH,@CREDITCARD,@DEBITCARD,@ONACCOUNT,@DEN1,@DEN5,@DEN10,@DEN20,@DEN50,@DEN100,@DEN500,@HOLDINV,@UNHOLDINV,@BARCODE,@QUANTITY,@INVENTORY,@PORECEIVE,@RETURNSUPP,@TRANSFERDISP,@TRANSFERIN,@TRANSFEROUT,@PHYINVENTORY,@STOCKREPORT,@SETTINGBUTT,@PRINTERSETUP,@EOD,@FAVORITEPANNEL,@LOCKUSER,@DELETEITEM)";

                objDB.ConString = ServerConn.LocalConnection();
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spUserID, spUserName, spPassword, spLocationID, spPayment, spReturnInv, spReturnNoInv, spDeleteInv, spCash, spCreditCard, spDebitCard,
                    spOnAccount, spDen1, spDen5, spDen10, spDen20, spDen50, spDen100, spDen500, spHoldInv, spunholdInv, spBarcode, spQuantity, spInventory, spPOReceive, spReturnSupp, spTransferDisp,
                    spTransferIn, spTransferOut, spPhyInventory, spStockReport, spSettingbutt, spPrinterSetup, spEOD, spFavoritePannel, spLockUser, spDeleteItem);

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_users;
        }

        public DataTable UpdateUsers_MasterData()
        {
            DataTable dt_users = null;
            try
            {
                SqlCeParameter spUserID = new SqlCeParameter();
                spUserID.ParameterName = "@UserID";
                spUserID.SqlDbType = System.Data.SqlDbType.Int;
                spUserID.Value = this.UserID;

                SqlCeParameter spUserName = new SqlCeParameter();
                spUserName.ParameterName = "@UserName";
                spUserName.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserName.Value = this.UserName;

                SqlCeParameter spPassword = new SqlCeParameter();
                spPassword.ParameterName = "@Password";
                spPassword.SqlDbType = System.Data.SqlDbType.NVarChar;
                spPassword.Value = this.Password;

                SqlCeParameter spLocationID = new SqlCeParameter();
                spLocationID.ParameterName = "@LocationID";
                spLocationID.SqlDbType = System.Data.SqlDbType.NVarChar;
                spLocationID.Value = this.LocationID;

                SqlCeParameter spPayment = new SqlCeParameter();
                spPayment.ParameterName = "@Payment";
                spPayment.SqlDbType = System.Data.SqlDbType.NChar;
                spPayment.Value = this.Payment;

                SqlCeParameter spReturnInv = new SqlCeParameter();
                spReturnInv.ParameterName = "@ReturnInv";
                spReturnInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnInv.Value = this.ReturnInv;

                SqlCeParameter spReturnNoInv = new SqlCeParameter();
                spReturnNoInv.ParameterName = "@ReturnNoInv";
                spReturnNoInv.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnNoInv.Value = this.ReturnNoInv;

                SqlCeParameter spDeleteInv = new SqlCeParameter();
                spDeleteInv.ParameterName = "@DeleteInv";
                spDeleteInv.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteInv.Value = this.DeleteInv;

                SqlCeParameter spCash = new SqlCeParameter();
                spCash.ParameterName = "@Cash";
                spCash.SqlDbType = System.Data.SqlDbType.NChar;
                spCash.Value = this.Cash;

                SqlCeParameter spCreditCard = new SqlCeParameter();
                spCreditCard.ParameterName = "@CreditCard";
                spCreditCard.SqlDbType = System.Data.SqlDbType.NChar;
                spCreditCard.Value = this.CreditCard;

                SqlCeParameter spDebitCard = new SqlCeParameter();
                spDebitCard.ParameterName = "@DebitCard";
                spDebitCard.SqlDbType = System.Data.SqlDbType.NChar;
                spDebitCard.Value = this.DebitCard;

                SqlCeParameter spOnAccount = new SqlCeParameter();
                spOnAccount.ParameterName = "@OnAccount";
                spOnAccount.SqlDbType = System.Data.SqlDbType.NChar;
                spOnAccount.Value = this.OnAccount;

                SqlCeParameter spDen1 = new SqlCeParameter();
                spDen1.ParameterName = "@Den1";
                spDen1.SqlDbType = System.Data.SqlDbType.NChar;
                spDen1.Value = this.Den1;

                SqlCeParameter spDen5 = new SqlCeParameter();
                spDen5.ParameterName = "@Den5";
                spDen5.SqlDbType = System.Data.SqlDbType.NChar;
                spDen5.Value = this.Den5;

                SqlCeParameter spDen10 = new SqlCeParameter();
                spDen10.ParameterName = "@Den10";
                spDen10.SqlDbType = System.Data.SqlDbType.NChar;
                spDen10.Value = this.Den10;

                SqlCeParameter spDen20 = new SqlCeParameter();
                spDen20.ParameterName = "@Den20";
                spDen20.SqlDbType = System.Data.SqlDbType.NChar;
                spDen20.Value = this.Den20;

                SqlCeParameter spDen50 = new SqlCeParameter();
                spDen50.ParameterName = "@Den50";
                spDen50.SqlDbType = System.Data.SqlDbType.NChar;
                spDen50.Value = this.Den50;

                SqlCeParameter spDen100 = new SqlCeParameter();
                spDen100.ParameterName = "@Den100";
                spDen100.SqlDbType = System.Data.SqlDbType.NChar;
                spDen100.Value = this.Den100;

                SqlCeParameter spDen500 = new SqlCeParameter();
                spDen500.ParameterName = "@Den500";
                spDen500.SqlDbType = System.Data.SqlDbType.NChar;
                spDen500.Value = this.Den500;

                SqlCeParameter spHoldInv = new SqlCeParameter();
                spHoldInv.ParameterName = "@HoldInv";
                spHoldInv.SqlDbType = System.Data.SqlDbType.NChar;
                spHoldInv.Value = this.HoldInv;

                SqlCeParameter spunholdInv = new SqlCeParameter();
                spunholdInv.ParameterName = "@unholdInv";
                spunholdInv.SqlDbType = System.Data.SqlDbType.NChar;
                spunholdInv.Value = this.unholdInv;

                SqlCeParameter spBarcode = new SqlCeParameter();
                spBarcode.ParameterName = "@Barcode";
                spBarcode.SqlDbType = System.Data.SqlDbType.NChar;
                spBarcode.Value = this.Barcode;

                SqlCeParameter spQuantity = new SqlCeParameter();
                spQuantity.ParameterName = "@Quantity";
                spQuantity.SqlDbType = System.Data.SqlDbType.NChar;
                spQuantity.Value = this.Quantity;

                SqlCeParameter spInventory = new SqlCeParameter();
                spInventory.ParameterName = "@Inventory";
                spInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spInventory.Value = this.Inventory;

                SqlCeParameter spPOReceive = new SqlCeParameter();
                spPOReceive.ParameterName = "@POReceive";
                spPOReceive.SqlDbType = System.Data.SqlDbType.NChar;
                spPOReceive.Value = this.POReceive;

                SqlCeParameter spReturnSupp = new SqlCeParameter();
                spReturnSupp.ParameterName = "@ReturnSupp";
                spReturnSupp.SqlDbType = System.Data.SqlDbType.NChar;
                spReturnSupp.Value = this.ReturnSupp;

                SqlCeParameter spTransferDisp = new SqlCeParameter();
                spTransferDisp.ParameterName = "@TransferDisp";
                spTransferDisp.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferDisp.Value = this.TransferDisp;

                SqlCeParameter spTransferIn = new SqlCeParameter();
                spTransferIn.ParameterName = "@TransferIn";
                spTransferIn.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferIn.Value = this.TransferIn;

                SqlCeParameter spTransferOut = new SqlCeParameter();
                spTransferOut.ParameterName = "@TransferOut";
                spTransferOut.SqlDbType = System.Data.SqlDbType.NChar;
                spTransferOut.Value = this.TransferOut;

                SqlCeParameter spPhyInventory = new SqlCeParameter();
                spPhyInventory.ParameterName = "@PhyInventory";
                spPhyInventory.SqlDbType = System.Data.SqlDbType.NChar;
                spPhyInventory.Value = this.PhyInventory;

                SqlCeParameter spStockReport = new SqlCeParameter();
                spStockReport.ParameterName = "@StockReport";
                spStockReport.SqlDbType = System.Data.SqlDbType.NChar;
                spStockReport.Value = this.StockReport;

                SqlCeParameter spSettingbutt = new SqlCeParameter();
                spSettingbutt.ParameterName = "@Settingbutt";
                spSettingbutt.SqlDbType = System.Data.SqlDbType.NChar;
                spSettingbutt.Value = this.Settingbutt;

                SqlCeParameter spPrinterSetup = new SqlCeParameter();
                spPrinterSetup.ParameterName = "@PrinterSetup";
                spPrinterSetup.SqlDbType = System.Data.SqlDbType.NChar;
                spPrinterSetup.Value = this.PrinterSetup;

                SqlCeParameter spEOD = new SqlCeParameter();
                spEOD.ParameterName = "@EOD";
                spEOD.SqlDbType = System.Data.SqlDbType.NChar;
                spEOD.Value = this.EOD;

                SqlCeParameter spFavoritePannel = new SqlCeParameter();
                spFavoritePannel.ParameterName = "@FavoritePannel";
                spFavoritePannel.SqlDbType = System.Data.SqlDbType.NChar;
                spFavoritePannel.Value = this.FavoritePannel;

                SqlCeParameter spLockUser = new SqlCeParameter();
                spLockUser.ParameterName = "@LockUser";
                spLockUser.SqlDbType = System.Data.SqlDbType.NChar;
                spLockUser.Value = this.LockUser;

                SqlCeParameter spDeleteItem = new SqlCeParameter();
                spDeleteItem.ParameterName = "@DeleteItem";
                spDeleteItem.SqlDbType = System.Data.SqlDbType.NChar;
                spDeleteItem.Value = this.DeleteItem;

                SqlCeParameter spOrderButton = new SqlCeParameter();
                spOrderButton.ParameterName = "@OrderButton";
                spOrderButton.SqlDbType = System.Data.SqlDbType.NChar;
                spOrderButton.Value = this.OrderButton;

                SqlCeParameter spOrderTextBox = new SqlCeParameter();
                spOrderTextBox.ParameterName = "@OrderTextBox";
                spOrderTextBox.SqlDbType = System.Data.SqlDbType.NChar;
                spOrderTextBox.Value = this.OrderTextBox;

                SqlCeParameter spSampleButton = new SqlCeParameter();
                spSampleButton.ParameterName = "@SampleButton";
                spSampleButton.SqlDbType = System.Data.SqlDbType.NChar;
                spSampleButton.Value = this.SampleButton;

                SqlCeParameter spMaterialMenu = new SqlCeParameter();
                spMaterialMenu.ParameterName = "@MaterialMenu";
                spMaterialMenu.SqlDbType = System.Data.SqlDbType.NChar;
                spMaterialMenu.Value = this.MaterialMenu;

                SqlCeParameter spItemCardReportButton = new SqlCeParameter();
                spItemCardReportButton.ParameterName = "@ItemCardReportButton";
                spItemCardReportButton.SqlDbType = System.Data.SqlDbType.NChar;
                spItemCardReportButton.Value = this.ItemCardReportButton;

                SqlCeParameter spProductionOrder = new SqlCeParameter();
                spProductionOrder.ParameterName = "@ProductionOrder";
                spProductionOrder.SqlDbType = System.Data.SqlDbType.NChar;
                spProductionOrder.Value = this.ProductionOrder;

                SqlCeParameter spRegister = new SqlCeParameter();
                spRegister.ParameterName = "@Register";
                spRegister.SqlDbType = System.Data.SqlDbType.NChar;
                spRegister.Value = this.Register;

                SqlCeParameter spTranfterOutToLocationID = new SqlCeParameter();
                spTranfterOutToLocationID.ParameterName = "@TranfterOutToLocationID";
                spTranfterOutToLocationID.SqlDbType = System.Data.SqlDbType.NChar;
                spTranfterOutToLocationID.Value = this.TranfterOutToLocationID;

                SqlCeParameter spButton_Delivery = new SqlCeParameter();
                spButton_Delivery.ParameterName = "@Button_Delivery";
                spButton_Delivery.SqlDbType = System.Data.SqlDbType.NChar;
                spButton_Delivery.Value = this.Button_Delivery;


                string s = "UPDATE TBL_USERS SET UserName=@UserName,PASSWORD=@PASSWORD,LOCATIONID=@LOCATIONID,PAYMENT=@PAYMENT,RETURNINV=@RETURNINV,RETURNNOINV=@RETURNNOINV,DELETEINV=@DELETEINV,"
                + "CASH=@CASH,CREDITCARD=@CREDITCARD,DEBITCARD=@DEBITCARD,ONACCOUNT=@ONACCOUNT,DEN1=@DEN1,DEN5=@DEN5,DEN10=@DEN10,DEN20=@DEN20,DEN50=@DEN50,DEN100=@DEN100,DEN500=@DEN500,HOLDINV=@HOLDINV,UNHOLDINV=@UNHOLDINV,"
                + " BARCODE=@BARCODE,QUANTITY=@QUANTITY,INVENTORY=@INVENTORY,PORECEIVE=@PORECEIVE,RETURNSUPP=@RETURNSUPP,TRANSFERDISP=@TRANSFERDISP,TRANSFERIN=@TRANSFERIN,TRANSFEROUT=@TRANSFEROUT,PHYINVENTORY=@PHYINVENTORY,STOCKREPORT=@STOCKREPORT,SETTINGBUTT=@SETTINGBUTT,"
                + " PRINTERSETUP=@PRINTERSETUP,EOD=@EOD,FAVORITEPANNEL=@FAVORITEPANNEL,LOCKUSER=@LOCKUSER,DELETEITEM=@DELETEITEM,"+
                " OrderButton=@OrderButton,OrderTextBox=@OrderTextBox,SampleButton=@SampleButton,MaterialMenu=@MaterialMenu,ItemCardReportButton=@ItemCardReportButton," +
                " ProductionOrder=@ProductionOrder,Register=@Register,TranfterOutToLocationID=@TranfterOutToLocationID,Button_Delivery=@Button_Delivery WHERE UserId=@UserId and LocationID=@LocationID";

                objDB.ConString = ServerConn.LocalConnection();
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                objDB.InsertRecord(spUserName, spPassword, spLocationID, spPayment, spReturnInv, spReturnNoInv, spDeleteInv, spCash, spCreditCard, spDebitCard,
                    spOnAccount, spDen1, spDen5, spDen10, spDen20, spDen50, spDen100, spDen500, spHoldInv, spunholdInv, spBarcode, spQuantity, spInventory, spPOReceive, spReturnSupp, spTransferDisp,
                    spTransferIn, spTransferOut, spPhyInventory, spStockReport, spSettingbutt, spPrinterSetup, spEOD, spFavoritePannel, spLockUser, spDeleteItem,spUserID,
                    spOrderButton, spOrderTextBox, spSampleButton, spMaterialMenu, spItemCardReportButton, spProductionOrder, spRegister, spTranfterOutToLocationID, spButton_Delivery);

            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_users;
        }

        public DataTable Get_By_UserId()
        {
            DataTable dtUsers = null;
            try
            {
                SqlCeParameter spUserId = new SqlCeParameter();
                spUserId.ParameterName = "@UserID";
                spUserId.SqlDbType = System.Data.SqlDbType.NVarChar;
                spUserId.Value = UserID;

                string s = "select * from tbl_Users where UserID=@UserID";

                objDB.ConString = ServerConn.LocalConnection();
                objDB.CmdType = CommandType.Text;
                objDB.CmdString = s;
                dtUsers = objDB.LoadDataSet(spUserId).Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
            return dtUsers;
        }

    }
}
