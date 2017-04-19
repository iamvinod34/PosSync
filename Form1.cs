using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlServerCe;
using System.Configuration;
using DBConnection;
using PosSync.App_Code;
using System.IO;

namespace PosSync
{
    public partial class Form1 : Form
    {

        Invoice objInvc = new Invoice();
        InvoiceDtls objInvcDtls = new InvoiceDtls();
        TenderDtls objTendDtls = new TenderDtls();
        ClientData objClient = new ClientData();
        MasterData objMaster = new MasterData();

        AllMaterTable AllMaterTable = new AllMaterTable();
        Eod objEod = new Eod();
        Eoddtls objEoddtls = new Eoddtls();
        MaterialEAN objMateriEan = new MaterialEAN();
        LocationPrice objLocationPrice = new LocationPrice();
        PriceFile objPriceFile = new PriceFile();
        Material objMaterial = new Material();
        Users objUsers = new Users();
        Location objLocation = new Location();
        Category objCategory = new Category();
        SubCategory objSubCategory = new SubCategory();
        PreferUOM objPreferUOM = new PreferUOM();
        Currency objCurrency = new Currency();
        Customer objCustomer = new Customer();
        City objCity = new City();
        Company objComapany = new Company();
        Storage objStorage = new Storage();
        Tender objTender = new Tender();
        Terminal objTerminal = new Terminal();
        Uom objUOM = new Uom();
        Vendor objVendor = new Vendor();
        ClientEodData objClientEodData = new ClientEodData();
        PhysicalInventory objsysphy = new PhysicalInventory();
        TransfterToDisplayTimeToTime TransfterToDisplayTimeToTime = new TransfterToDisplayTimeToTime();

        Zreport ZReport = new Zreport();

        public decimal AllMasterCount { get; set; } = 0M;
        public decimal RunningCount { get; set; } = 0M;
        public string TableName { get; set; } = "Emtpy";

        DataTable dtFirst = new DataTable("AllMaterData");

        public Form1()
        {
            InitializeComponent();
        }

        #region "Properties"

        public string DocumentID { get; set; }
        public string CompanyID { get; set; }
        public string LocationID { get; set; }
        public string StorageID { get; set; }
        public string TerminalID { get; set; }
        public string PostingType { get; set; }

        public string MasterSyncDate { get; set; }
        public string CurrentSyncDate { get; set; }
        public string SalesOrder { set; get; }
        public string CustomerID { get; set; }
        public string CategoryID { get; set; }
        public string MaterialID { get; set; }
        public string UOM { get; set; }
        public string UserID { get; set; }
        public string MyProperty { get; set; }

        public DateTime DocumentDate { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdDate { get; set; }

        public int Counter { get; set; }
        public int PostKey { get; set; }

        public decimal TranQty { get; set; }
        public decimal BaseQty { get; set; }
        public decimal CreditQty { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Amount { get; set; }
        public decimal CreditAmount { get; set; }

        public string Datacon { get; set; }
        public string SysTerminalID { get; set; }

        public bool Disconnect { get; set; }

        public string EodId { get; set; }

        #endregion

        Timer timer1 = new Timer();
        Timer Customer = new Timer();


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //ConnectionString
                LocalConnectionString();

                //mater tables first time excuted data
                AllMaterDataSync();

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                DataTable dt_date = objClient.GetMasterDate();
                MasterSyncDate = dt_date.Rows[0]["MasterSyncDate"].ToString();
                LocationID = dt_date.Rows[0]["LocationId"].ToString();
                CompanyID = dt_date.Rows[0]["CompanyId"].ToString();
                SysTerminalID = dt_date.Rows[0]["TerminalID"].ToString();
                CurrentSyncDate = System.DateTime.Today.ToShortDateString();

                //if (MasterSyncDate != CurrentSyncDate)
                //{
                //    DeleteTenderDetailArchive();
                //    DeleteSalesDetailArchive();
                //    DeleteSalesArchive();
                //    DeleteSalesRawData();
                //    UpdateSyncDate();
                //}

                MasterDataSync();

                AllMaterTable.LocationID = LocationID;
                AllMaterTable.Insert_Local_PI_TimeTable();


                timer1.Interval = 120000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();

                Customer.Interval = 1920000;
                Customer.Tick += new EventHandler(Customer_Tick);
                Customer.Start();
            }

            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Form Load : " + ex.Message + ex.StackTrace);
            }

        }

        private void Customer_Tick(object sender, EventArgs e)
        {
            try
            {
                AllMaterTable.MainCustomerTable();
                AllMaterTable.LocationID = LocationID;
                AllMaterTable.Insert_Local_PI_TimeTable();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Customer_Tick : " + ex.Message + ex.StackTrace);
            }
        }

        public void MasterDataSync()
        {
            try
            {
                objMaster.LocationId = LocationID;
                DataTable dt_users = objMaster.GetUsers_MasterData();
                InsertUsers_MasterData(dt_users);

                DataTable dt_location = objMaster.GetLocation_MasterData();
                InsertLocation_MasterData(dt_location);

                DataTable dt_category = objMaster.GetCategory_MasterData();
                InsertCategory_MasterData(dt_category);

                DataTable dt_subcategory = objMaster.GetSubCategory_MasterData();
                InsertSubCategory_MasterData(dt_subcategory);

                //DataTable dt_prefer = objMaster.GetPreferUOM_MasterData();
                //InsertPreferUOM_MasterData(dt_prefer);

                DataTable dt_currency = objMaster.GetCurrency_MasterData();
                InsertCurrency_MasterData(dt_currency);

                DataTable dt_customer = objMaster.GetCustomer_MasterData();
                InsertCustomer_MasterData(dt_customer);

                DataTable dt_city = objMaster.GetCity_MasterData();
                InsertCity_MasterDate(dt_city);

                DataTable dt_company = objMaster.GetCompany_MasterData();
                InsertCompany_MasterData(dt_company);

                DataTable dt_storage = objMaster.GetStorage_MasterData();
                InsertStorage_MasterData(dt_storage);

                DataTable dt_tender = objMaster.GetTender_MasterData();
                InsertTender_MasteData(dt_tender);

                DataTable dt_terminal = objMaster.GetTerminal_MasterData();
                InsertTerminal_MasterData(dt_terminal);

                DataTable dt_UOM = objMaster.GetUOM_MasterData();
                InsertUOM_MasterData(dt_UOM);

                DataTable dt_vendor = objMaster.GetVendor_MasterData();
                InsertVendor_MasterData(dt_vendor);



            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Mater Data : " + ex.Message + ex.StackTrace);
            }
        }

        private void InsertInvoice(DataTable dt_invc)
        {
            try
            {
                for (int i = 0; i < dt_invc.Rows.Count; i++)
                {
                    objInvc.DocumentID = dt_invc.Rows[i]["Documentid"].ToString();
                    objInvc.SalesOrder = dt_invc.Rows[i]["SalesOrder"].ToString();
                    objInvc.CompanyID = dt_invc.Rows[i]["CompanyID"].ToString();
                    objInvc.LocationID = dt_invc.Rows[i]["Locationid"].ToString();
                    objInvc.StorageID = dt_invc.Rows[i]["StorageID"].ToString();
                    objInvc.TerminalID = dt_invc.Rows[i]["TerminalID"].ToString();
                    objInvc.DocumentDate = Convert.ToDateTime(dt_invc.Rows[i]["DocumentDate"].ToString());
                    objInvc.PostingDate = Convert.ToDateTime(dt_invc.Rows[i]["PostingDate"].ToString());
                    objInvc.CustomerID = dt_invc.Rows[i]["CustomerID"].ToString();
                    objInvc.DocDetail = dt_invc.Rows[i]["DocDetail"].ToString();
                    objInvc.Amount = Convert.ToDecimal(dt_invc.Rows[i]["Amount"].ToString());
                    objInvc.Discount = Convert.ToDecimal(dt_invc.Rows[i]["Discount"].ToString());
                    objInvc.NetValue = Convert.ToDecimal(dt_invc.Rows[i]["NetValue"].ToString());
                    objInvc.UserID = dt_invc.Rows[i]["UserID"].ToString();
                    objInvc.AddDate = Convert.ToDateTime(dt_invc.Rows[i]["AddDate"].ToString());

                    objInvc.DataCon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                    if (dt_invc.Rows[i]["ConRead"].ToString().ToLower().Equals("false"))
                    {
                        objInvc.InsertInvoice();
                    }

                   
                }
                InsertInvoiceDtls(objInvc.DocumentID);
                InsertTenderDtls(objInvc.DocumentID);

                Disconnect = false;
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "POSErrorLog";

                myLog.WriteEntry("InsertInvoice : " + ex.Message + ex.StackTrace);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Disconnect = false;

                objMaster.LocationId = LocationID;
                objMaster.SysTerminalID = SysTerminalID;
                DataTable dt_matEan = objMaster.GetmaterialEAN_MasterData();
                InsertMaterialEAN_MasterData(dt_matEan);
                objMaster.DeleteMaterialEanTemp();

                objMaster.LocationId = LocationID;
                objMaster.SysTerminalID = SysTerminalID;
                DataTable d_locprice = objMaster.GetLocationPrice_MasterData();
                InsertLocationPrice_MasterData(d_locprice);
                objMaster.DeleteLocationPriceTemp();

                objMaster.LocationId = LocationID;
                objMaster.SysTerminalID = SysTerminalID;
                DataTable dt_PriceFile = objMaster.GetPriceFile_masterData();
                InsertPriceFile_MasterData(dt_PriceFile);
                objMaster.DeletePriceFileTemp();

                objMaster.LocationId = LocationID;
                objMaster.SysTerminalID = SysTerminalID;
                DataTable dt_material = objMaster.GetMaterial_MasterData();
                InsertMaterial_MasterData(dt_material);
                objMaster.DeleteMaterialTemp();

                objMaster.LocationId = LocationID;
                objMaster.SysTerminalID = SysTerminalID;

                DataTable dt_prefer = objMaster.GetPreferUOM_MasterData();
                InsertPreferUOM_MasterData(dt_prefer);
                objMaster.DeletePreferUOMTemp();

                DataTable dt_inc = GetInvoice();
                InsertInvoice(dt_inc);

                InsertOrderDetails();
                ZReportMethod();

                //Tranfter To Display Time to time
                GetLocalInsert();
                GetLocalCheck();
                UpdateWeb();


                if (!Disconnect)
                {
                    DeleteInvoicesClient(dt_inc);

                    DataTable dt_Eod_inc = GetEOD();
                    InsertEod(dt_Eod_inc);

                    DeleteEodClient(dt_Eod_inc);

                    ZreportDeleteMethod();
                }


            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "POSErrorLog";

                myLog.WriteEntry("Timer_click : " + ex.Message + ex.StackTrace);
            }
        }


        public void UpdateSyncDate()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                objClient.MasterSyncDate = MasterSyncDate;
                objClient.NewMasterSyncDate = CurrentSyncDate;
                objClient.UpdateMasterSyncDate();

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Update Sync Data : " + ex.Message + ex.StackTrace);
            }
        }

        public DataTable GetInvoice()
        {
            DataTable dtsales = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dtsales = objClient.LoadInvoices();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Invoice : " + ex.Message + ex.StackTrace);
            }
            return dtsales;

        }

        public DataTable GetInvoiceDtls()
        {
            DataTable dtsalesDtl = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dtsalesDtl = objClient.LoadInvoiceDtls();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get InvoicwDtls : " + ex.Message + ex.StackTrace);
            }
            return dtsalesDtl;

        }

        public DataTable GetTenderDtls()
        {
            DataTable dttenderDtl = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dttenderDtl = objClient.LoadTenderDtls();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get TenderDtls : " + ex.Message + ex.StackTrace);
            }
            return dttenderDtl;

        }

        public void InsertInvoiceDtls(string invc_id)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.InvoiceId = invc_id;

                DataTable dt_invcdtls = objClient.LoadInvoiceDtls();

                for (int i = 0; i < dt_invcdtls.Rows.Count; i++)
                {
                    objInvcDtls.DocumentID = dt_invcdtls.Rows[i]["Documentid"].ToString();
                    objInvcDtls.LocationID = dt_invcdtls.Rows[i]["LocationId"].ToString();
                    objInvcDtls.StorageID = dt_invcdtls.Rows[i]["StorageId"].ToString();
                    objInvcDtls.TerminalID = dt_invcdtls.Rows[i]["TerminalId"].ToString();
                    objInvcDtls.Counter = Convert.ToInt32(dt_invcdtls.Rows[i]["Counter"].ToString());
                    objInvcDtls.SalesOrder = dt_invcdtls.Rows[i]["SalesOrder"].ToString();
                    objInvcDtls.CompanyID = dt_invcdtls.Rows[i]["CompanyID"].ToString();
                    //  objInvcDtls.PostingDate =Convert.ToDateTime( dt_invcdtls.Rows[i]["PostingDate"].ToString());
                    objInvcDtls.DocumentDate = Convert.ToDateTime(dt_invcdtls.Rows[i]["DocumentDate"].ToString());
                    objInvcDtls.PostingType = dt_invcdtls.Rows[i]["PostingType"].ToString();
                    objInvcDtls.CustomerID = dt_invcdtls.Rows[i]["CustomerID"].ToString();
                    objInvcDtls.CategoryID = dt_invcdtls.Rows[i]["CategoryID"].ToString();
                    objInvcDtls.MaterialID = dt_invcdtls.Rows[i]["MaterialID"].ToString();
                    objInvcDtls.UOM = dt_invcdtls.Rows[i]["UOM"].ToString();
                    objInvcDtls.TranQty = Convert.ToDecimal(dt_invcdtls.Rows[i]["TranQty"].ToString());
                    objInvcDtls.BaseQty = Convert.ToDecimal(dt_invcdtls.Rows[i]["BaseQty"].ToString());
                    objInvcDtls.CreditQty = Convert.ToDecimal(dt_invcdtls.Rows[i]["CreditQty"].ToString());
                    objInvcDtls.Cost = Convert.ToDecimal(dt_invcdtls.Rows[i]["Cost"].ToString());
                    objInvcDtls.Price = Convert.ToDecimal(dt_invcdtls.Rows[i]["Price"].ToString());
                    objInvcDtls.DiscountRate = Convert.ToDecimal(dt_invcdtls.Rows[i]["DiscountRate"].ToString());
                    objInvcDtls.Amount = Convert.ToDecimal(dt_invcdtls.Rows[i]["Amount"].ToString());
                    objInvcDtls.CreditAmount = Convert.ToDecimal(dt_invcdtls.Rows[i]["CreditAmount"].ToString());
                    objInvcDtls.UserID = dt_invcdtls.Rows[i]["UserId"].ToString();
                    objInvcDtls.PostKey = Convert.ToInt32(dt_invcdtls.Rows[i]["PostKey"].ToString());
                    objInvcDtls.AddDate = Convert.ToDateTime(dt_invcdtls.Rows[i]["AddDate"].ToString());
                    objInvcDtls.UpdDate = Convert.ToDateTime(dt_invcdtls.Rows[i]["UpdDate"].ToString());
                    objInvcDtls.OrderNo = dt_invcdtls.Rows[i]["OrderNo"].ToString();
                    objInvcDtls.Sales_Comm = dt_invcdtls.Rows[i]["Sales_Comm"].ToString();
                    objInvcDtls.Produc_Comm = dt_invcdtls.Rows[i]["Produc_Comm"].ToString();
                    objInvcDtls.TaxAmount = Convert.ToDecimal(dt_invcdtls.Rows[i]["Tax"].ToString());
                    objInvcDtls.CostAmount = Convert.ToDecimal(dt_invcdtls.Rows[i]["CostAmount"].ToString());
                    if (!string.IsNullOrEmpty(dt_invcdtls.Rows[i]["OrderUserName"].ToString()))
                    {
                        objInvcDtls.OrderUsername = dt_invcdtls.Rows[i]["OrderUserName"].ToString();
                    }
                    else
                    {
                        objInvcDtls.OrderUsername = "0";
                    }

                    if (!string.IsNullOrEmpty(dt_invcdtls.Rows[i]["OrderTransQty"].ToString()))
                    {
                        objInvcDtls.OrderTransQty = dt_invcdtls.Rows[i]["OrderTransQty"].ToString();
                    }
                    else
                    {
                        objInvcDtls.OrderTransQty = "0";
                    }

                    if (!string.IsNullOrEmpty(dt_invcdtls.Rows[i]["OrderBaseQty"].ToString()))
                    {
                        objInvcDtls.OrderBaseQty = dt_invcdtls.Rows[i]["OrderBaseQty"].ToString();
                    }
                    else
                    {
                        objInvcDtls.OrderBaseQty = "0";
                    }

                    objInvcDtls.Datacon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                    if (dt_invcdtls.Rows[i]["ConRead"].ToString().ToLower().Equals("false"))
                    {
                        objInvcDtls.InsertInvoiceDtls();
                    }


                }

                Disconnect = false;

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertInvoiceDtls : " + ex.Message);
            }
        }

        public void InsertTenderDtls(string invc_id)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.InvoiceId = invc_id;

                DataTable dt_tenderdtls = objClient.LoadTenderDtls();

                for (int i = 0; i < dt_tenderdtls.Rows.Count; i++)
                {
                    objTendDtls.DocumentID = dt_tenderdtls.Rows[i]["DocumentId"].ToString();
                    objTendDtls.LocationID = dt_tenderdtls.Rows[i]["LocationId"].ToString();
                    objTendDtls.TerminalID = dt_tenderdtls.Rows[i]["TerminalId"].ToString();
                    objTendDtls.Counter = Convert.ToInt32(dt_tenderdtls.Rows[i]["Counter"].ToString());
                    objTendDtls.CompanyID = dt_tenderdtls.Rows[i]["CompanyId"].ToString();
                    objTendDtls.StorageID = dt_tenderdtls.Rows[i]["StorageId"].ToString();
                    objTendDtls.DocumentDate = Convert.ToDateTime(dt_tenderdtls.Rows[i]["DocumentDate"].ToString());
                    objTendDtls.PostingType = dt_tenderdtls.Rows[i]["PostingType"].ToString();
                    objTendDtls.PostingDate = Convert.ToDateTime(dt_tenderdtls.Rows[i]["PostingDate"].ToString());
                    objTendDtls.CustomerID = dt_tenderdtls.Rows[i]["CustomerId"].ToString();
                    objTendDtls.TenderID = dt_tenderdtls.Rows[i]["TenderId"].ToString();
                    objTendDtls.Amount = Convert.ToDecimal(dt_tenderdtls.Rows[i]["Amount"].ToString());
                    objTendDtls.PaidAmount = Convert.ToDecimal(dt_tenderdtls.Rows[i]["PaidAmount"].ToString());
                    objTendDtls.ChangeAmount = Convert.ToDecimal(dt_tenderdtls.Rows[i]["ChangeAmount"].ToString());
                    objTendDtls.TransCode = dt_tenderdtls.Rows[i]["TransCode"].ToString();

                    objTendDtls.DataCon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                    if (dt_tenderdtls.Rows[i]["ConRead"].ToString().ToLower().Equals("false"))
                    {
                        objTendDtls.InsertTenderDtls();
                    }
                }

                Disconnect = false;

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertTenderDtls : " + ex.Message);
            }
        }

        private void DeleteInvoicesClient(DataTable dt_invc)
        {
            try
            {
                for (int i = 0; i < dt_invc.Rows.Count; i++)
                {
                    string _docId = dt_invc.Rows[i]["DocumentId"].ToString();

                    DeleteTenderDtls(_docId);
                    DeleteInvoiceDtls(_docId);
                    DeleteInvoices(_docId);
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Invoice Client : " + ex.Message + ex.StackTrace);
            }
        }

        private void DeleteTenderDtls(string _docId)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.InvoiceId = _docId;

                objClient.DeleteTenderDtls();

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete TenderDtls : " + ex.Message + ex.StackTrace);
            }
        }

        private void DeleteInvoiceDtls(string _docId)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.InvoiceId = _docId;

                objClient.DeleteInvoiceDtls();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Invoice Dtls : " + ex.Message + ex.StackTrace);
            }
        }


        private void DeleteInvoices(string _docId)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.InvoiceId = _docId;

                objClient.DeleteInvoice();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Invoices : " + ex.Message + ex.StackTrace);
            }
        }

        public DataTable GetEOD()
        {
            DataTable dtEOD = null;
            try
            {
                objClientEodData.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dtEOD = objClientEodData.LoadEOD();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get EOD : " + ex.Message + ex.StackTrace);
            }
            return dtEOD;
        }

        public DataTable GetEoddtls()
        {
            DataTable dtEODdtls = null;
            try
            {
                objClientEodData.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dtEODdtls = objClientEodData.LoadEODdtls();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("EOD Dtls : " + ex.Message + ex.StackTrace);
            }
            return dtEODdtls;
        }

        public DataTable GetPriceFile()
        {
            DataTable dt_priceFile = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_priceFile = objClient.LoadPriceFile();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Price File : " + ex.Message + ex.StackTrace);
            }
            return dt_priceFile;
        }

        public DataTable GetMaterial()
        {
            DataTable dt_material = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_material = objClient.LoadMaterial();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Material : " + ex.Message + ex.StackTrace);
            }
            return dt_material;
        }

        public DataTable GetUsers()
        {
            DataTable dt_users = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_users = objClient.LoadUsers();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Users : " + ex.Message + ex.StackTrace);
            }
            return dt_users;
        }

        #region "PDFSync"

        public byte[] PDFFile()
        {
            byte[] ByteFile = null;
            try
            {
                if (EodId != null)
                {
                    if (EodId != string.Empty)
                    {
                        string File = AppDomain.CurrentDomain.BaseDirectory + "EodPDFFiles/" + EodId + ".pdf";
                        ByteFile = System.IO.File.ReadAllBytes(File);
                        System.IO.File.WriteAllBytes(File, ByteFile);
                    }
                }


            }
            catch (Exception ex)
            {
                throw;
            }
            return ByteFile;
        }

        public void InsertEodFile()
        {
            try
            {
                byte[] FileByte = PDFFile();
                ZReport.LocationId = LocationID;
                ZReport.TerminalId = TerminalID;
                ZReport.FileByte = FileByte;
                ZReport.CompanyId = CompanyID;
                ZReport.EodId = EodId;

                ZReport.InsertEODFile();
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InserEod File : " + ex.Message);
            }
        }

        public void PDFDeleteFile()
        {
            try
            {
                string File = AppDomain.CurrentDomain.BaseDirectory + "EodPDFFiles/" + EodId + ".pdf";

                if (System.IO.File.Exists(File))
                {
                    System.IO.File.Delete(File);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete File : " + ex.Message);
                throw;
            }
        }

        #endregion

        #region "Sync Eod"

        public void InsertEod(DataTable dt_Eod)
        {
            try
            {
                if (dt_Eod.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_Eod.Rows.Count; i++)
                    {

                        objEod.LocationID = dt_Eod.Rows[i]["LocationID"].ToString();
                        objEod.TerminalID = dt_Eod.Rows[i]["TerminialID"].ToString();
                        TerminalID = dt_Eod.Rows[i]["TerminialID"].ToString();
                        objEod.EODID = dt_Eod.Rows[i]["EODID"].ToString();
                        EodId = dt_Eod.Rows[i]["EODID"].ToString();
                        objEod.DocDate = Convert.ToDateTime(dt_Eod.Rows[i]["DocDate"].ToString());
                        objEod.Loan = Convert.ToDecimal(dt_Eod.Rows[i]["Loan"].ToString());
                        objEod.SystemCash = Convert.ToDecimal(dt_Eod.Rows[i]["SystemCash"].ToString());
                        objEod.ActualCash = Convert.ToDecimal(dt_Eod.Rows[i]["ActualCash"].ToString());
                        objEod.Cash1 = Convert.ToInt32(dt_Eod.Rows[i]["1"].ToString());
                        objEod.Cash5 = Convert.ToInt32(dt_Eod.Rows[i]["5"].ToString());
                        objEod.Cash10 = Convert.ToInt32(dt_Eod.Rows[i]["10"].ToString());
                        objEod.Cash20 = Convert.ToInt32(dt_Eod.Rows[i]["20"].ToString());
                        objEod.Cash50 = Convert.ToInt32(dt_Eod.Rows[i]["50"].ToString());
                        objEod.Cash100 = Convert.ToInt32(dt_Eod.Rows[i]["100"].ToString());
                        objEod.Cash200 = Convert.ToInt32(dt_Eod.Rows[i]["200"].ToString());
                        objEod.Cash500 = Convert.ToInt32(dt_Eod.Rows[i]["500"].ToString());
                        objEod.CashDiff = Convert.ToDecimal(dt_Eod.Rows[i]["CashDiff"].ToString());
                        objEod.CashCount = Convert.ToInt32(dt_Eod.Rows[i]["CashCount"].ToString());

                        objEod.CreditAmt = Convert.ToDecimal(dt_Eod.Rows[i]["CreditAmt"].ToString());
                        objEod.CreditCnt = Convert.ToInt32(dt_Eod.Rows[i]["CreditCnt"].ToString());
                        objEod.DebitAmt = Convert.ToDecimal(dt_Eod.Rows[i]["DebitAmt"].ToString());
                        objEod.DebitCnt = Convert.ToInt32(dt_Eod.Rows[i]["DebitCnt"].ToString());
                        objEod.OnAccAmt = Convert.ToDecimal(dt_Eod.Rows[i]["OnAccAmt"].ToString());
                        objEod.OnAccCnt = Convert.ToInt32(dt_Eod.Rows[i]["OnAccCnt"].ToString());
                        objEod.Cust1Amt = Convert.ToDecimal(dt_Eod.Rows[i]["Cust1Amt"].ToString());

                        objEod.DataCon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                        if (dt_Eod.Rows[i]["ConRead"].ToString().ToLower().Equals("false"))
                        {
                            objEod.InsertEOD();
                        }
                    }
                }
                InsertEoddlts(objEod.EODID);
                InsertEodFile();
                PDFDeleteFile();
                Disconnect = false;
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertEod : " + ex.Message);
            }
        }

        public void InsertEoddlts(string _Eod)
        {
            try
            {
                objClientEodData.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClientEodData.EodId = _Eod;

                DataTable dt_Eoddtls = objClientEodData.LoadEODdtls();

                if (dt_Eoddtls.Rows.Count > 0)
                {

                    for (int i = 0; i < dt_Eoddtls.Rows.Count; i++)
                    {
                        objEoddtls.LocationID = dt_Eoddtls.Rows[i]["LocationID"].ToString();
                        objEoddtls.TerminalID = dt_Eoddtls.Rows[i]["TerminalID"].ToString();
                        objEoddtls.EODID = dt_Eoddtls.Rows[i]["EODID"].ToString();
                        objEoddtls.DocDate = Convert.ToDateTime(dt_Eoddtls.Rows[i]["DocDate"].ToString());
                        objEoddtls.TransactionDate = Convert.ToDateTime(dt_Eoddtls.Rows[i]["TransactionDate"].ToString());
                        objEoddtls.TransactionType = dt_Eoddtls.Rows[i]["TransactionType"].ToString();
                        objEoddtls.TransactionID = dt_Eoddtls.Rows[i]["TransactionID"].ToString();
                        objEoddtls.Count = Convert.ToInt32(dt_Eoddtls.Rows[i]["Count"].ToString());
                        objEoddtls.PayType = dt_Eoddtls.Rows[i]["PayType"].ToString();
                        objEoddtls.Amount = Convert.ToDecimal(dt_Eoddtls.Rows[i]["Amount"].ToString());

                        objEoddtls.Datacon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                        if (dt_Eoddtls.Rows[i]["ConRead"].ToString().ToLower().Equals("false"))
                        {
                            objEoddtls.InsertEODdtls();
                        }
                    }

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertEodDtls: " + ex.Message);
            }
        }

        #endregion

        public void InsertMaterial(DataTable dt_material)
        {
            try
            {
                if (dt_material.Rows.Count > 0)
                {
                    DeleteMaterial();
                }
                objMaterial.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_material.Rows.Count; i++)
                {
                    objMaterial.MaterialID = dt_material.Rows[i]["MaterialID"].ToString();
                    objMaterial.MaterialDesc1 = dt_material.Rows[i]["MaterialDesc1"].ToString();
                    objMaterial.MaterialDesc2 = dt_material.Rows[i]["MaterialDesc2"].ToString();
                    objMaterial.MaterialDesc3 = dt_material.Rows[i]["MaterialDesc3"].ToString();
                    objMaterial.ProductURL = dt_material.Rows[i]["ProductURL"].ToString();
                    objMaterial.CategoryID = dt_material.Rows[i]["CategoryID"].ToString();
                    objMaterial.SubCategoryID = dt_material.Rows[i]["SubCategoryID"].ToString();
                    objMaterial.BaseUOM = dt_material.Rows[i]["BaseUOM"].ToString();
                    objMaterial.Cost = Convert.ToDouble(dt_material.Rows[i]["Cost"].ToString());
                    objMaterial.VendorID = dt_material.Rows[i]["VendorID"].ToString();
                    objMaterial.CustInt1 = Convert.ToInt32(dt_material.Rows[i]["CustInt1"].ToString());
                    objMaterial.CustInt2 = Convert.ToInt32(dt_material.Rows[i]["CustInt2"].ToString());
                    objMaterial.CustInt3 = Convert.ToInt32(dt_material.Rows[i]["CustInt3"].ToString());
                    objMaterial.CustDate1 = Convert.ToDateTime(dt_material.Rows[i]["CustDate1"].ToString());
                    objMaterial.CustDate2 = Convert.ToDateTime(dt_material.Rows[i]["CustDate2"].ToString());
                    objMaterial.CustDate3 = Convert.ToDateTime(dt_material.Rows[i]["CustDate3"].ToString());
                    objMaterial.UserID = dt_material.Rows[i]["UserID"].ToString();
                    objMaterial.AddDate = Convert.ToDateTime(dt_material.Rows[i]["AddDate"].ToString());
                    objMaterial.UpdDate = Convert.ToDateTime(dt_material.Rows[i]["UpdDate"].ToString());
                    objMaterial.Dataid = Convert.ToInt32(dt_material.Rows[i]["Dataid"].ToString());
                    objMaterial.InsertMaterial();
                    Disconnect = false;
                }
                if (dt_material.Rows.Count > 0)
                {
                    UpdateMaterial_MasterData(dt_material);
                    InsertMaterial_MasterData(dt_material);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertMaterial_Temp : " + ex.Message);
            }
        }

        public void InsertMaterial_MasterData(DataTable dt_material)
        {
            try
            {

                for (int i = 0; i < dt_material.Rows.Count; i++)
                {
                    objMaterial.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string MaterialID = dt_material.Rows[i]["MaterialID"].ToString();
                    objClient.MaterialID = MaterialID;
                    DataTable dt_mat = GetMaterial();
                    if (dt_mat.Rows.Count <= 0)
                    {
                        objMaterial.MaterialID = dt_material.Rows[i]["MaterialID"].ToString();
                        objMaterial.MaterialDesc1 = dt_material.Rows[i]["MaterialDesc1"].ToString();
                        objMaterial.MaterialDesc2 = dt_material.Rows[i]["MaterialDesc2"].ToString();
                        objMaterial.MaterialDesc3 = dt_material.Rows[i]["MaterialDesc3"].ToString();
                        objMaterial.ProductURL = dt_material.Rows[i]["ProductURL"].ToString();
                        objMaterial.CategoryID = dt_material.Rows[i]["CategoryID"].ToString();
                        objMaterial.SubCategoryID = dt_material.Rows[i]["SubCategoryID"].ToString();
                        objMaterial.BaseUOM = dt_material.Rows[i]["BaseUOM"].ToString();
                        objMaterial.Cost = Convert.ToDouble(dt_material.Rows[i]["Cost"].ToString());
                        objMaterial.VendorID = dt_material.Rows[i]["VendorID"].ToString();
                        objMaterial.CustInt1 = Convert.ToInt32(dt_material.Rows[i]["CustInt1"].ToString());
                        objMaterial.CustInt2 = Convert.ToInt32(dt_material.Rows[i]["CustInt2"].ToString());
                        objMaterial.CustInt3 = Convert.ToInt32(dt_material.Rows[i]["CustInt3"].ToString());
                        objMaterial.CustDate1 = Convert.ToDateTime(dt_material.Rows[i]["CustDate1"].ToString());
                        objMaterial.CustDate2 = Convert.ToDateTime(dt_material.Rows[i]["CustDate2"].ToString());
                        objMaterial.CustDate3 = Convert.ToDateTime(dt_material.Rows[i]["CustDate3"].ToString());
                        objMaterial.UserID = dt_material.Rows[i]["UserID"].ToString();
                        objMaterial.AddDate = Convert.ToDateTime(dt_material.Rows[i]["AddDate"].ToString());
                        objMaterial.UpdDate = Convert.ToDateTime(dt_material.Rows[i]["UpdDate"].ToString());

                        objMaterial.InsertMaterial_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objMaterial.MaterialID = dt_material.Rows[i]["MaterialID"].ToString();
                        objMaterial.MaterialDesc1 = dt_material.Rows[i]["MaterialDesc1"].ToString();
                        objMaterial.MaterialDesc2 = dt_material.Rows[i]["MaterialDesc2"].ToString();
                        objMaterial.MaterialDesc3 = dt_material.Rows[i]["MaterialDesc3"].ToString();
                        objMaterial.ProductURL = dt_material.Rows[i]["ProductURL"].ToString();
                        objMaterial.CategoryID = dt_material.Rows[i]["CategoryID"].ToString();
                        objMaterial.SubCategoryID = dt_material.Rows[i]["SubCategoryID"].ToString();
                        objMaterial.BaseUOM = dt_material.Rows[i]["BaseUOM"].ToString();
                        objMaterial.Cost = Convert.ToDouble(dt_material.Rows[i]["Cost"].ToString());
                        objMaterial.VendorID = dt_material.Rows[i]["VendorID"].ToString();
                        objMaterial.UpdateMaterial_MasterData();

                        Disconnect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertMaterial_Master : " + ex.Message);
            }
        }

        public void UpdateMaterial_MasterData(DataTable dt_material)
        {
            try
            {
                objMaterial.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_material.Rows.Count; i++)
                {
                    objMaterial.MaterialID = dt_material.Rows[i]["MaterialID"].ToString();
                    objMaterial.MaterialDesc1 = dt_material.Rows[i]["MaterialDesc1"].ToString();
                    objMaterial.MaterialDesc2 = dt_material.Rows[i]["MaterialDesc2"].ToString();
                    objMaterial.MaterialDesc3 = dt_material.Rows[i]["MaterialDesc3"].ToString();
                    objMaterial.ProductURL = dt_material.Rows[i]["ProductURL"].ToString();
                    objMaterial.CategoryID = dt_material.Rows[i]["CategoryID"].ToString();
                    objMaterial.SubCategoryID = dt_material.Rows[i]["SubCategoryID"].ToString();
                    objMaterial.BaseUOM = dt_material.Rows[i]["BaseUOM"].ToString();
                    objMaterial.Cost = Convert.ToDouble(dt_material.Rows[i]["Cost"].ToString());
                    objMaterial.VendorID = dt_material.Rows[i]["VendorID"].ToString();
                    objMaterial.UpdateMaterial_MasterData();
                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateMaterial_Master : " + ex.Message);
            }
        }

        //public void InsertMaterialEAN(DataTable dt_matEAN)
        //{

        //    try
        //    {
        //        if (dt_matEAN.Rows.Count > 0)
        //        {
        //            DeleteMaterialEAN();

        //        }
        //        for (int i = 0; i < dt_matEAN.Rows.Count; i++)
        //        {

        //            objMateriEan.EAN13 = dt_matEAN.Rows[i]["EAN13"].ToString();

        //            objMateriEan.MaterialID = dt_matEAN.Rows[i]["MaterialID"].ToString();
        //            objMateriEan.Uom = dt_matEAN.Rows[i]["Uom"].ToString();
        //            objMateriEan.ConvertValue = Convert.ToDouble(dt_matEAN.Rows[i]["ConvertValue"].ToString());
        //            objMateriEan.BaseUom = dt_matEAN.Rows[i]["BaseUom"].ToString();
        //            objMateriEan.MaterialMix = dt_matEAN.Rows[i]["MaterialMix"].ToString();

        //            objMateriEan.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //            objMateriEan.InsertMaterialEAN();
        //            Disconnect = false;

        //        }
        //        if (dt_matEAN.Rows.Count > 0)
        //        {
        //            InsertMaterialEAN_MasterData(dt_matEAN);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Disconnect = true;

        //        if (!EventLog.SourceExists("POSErrorLog"))
        //        {
        //            EventLog.CreateEventSource("EasyPos", "POSErrorLog");
        //        }

        //        EventLog myLog = new EventLog();
        //        myLog.Source = "Pync Error";

        //        myLog.WriteEntry("InsertMaterial_Temp : " + ex.Message);
        //    }
        //}

        public void InsertMaterialEAN_MasterData(DataTable dt_matean13)
        {
            try
            {
                for (int i = 0; i < dt_matean13.Rows.Count; i++)
                {
                    string EAN13 = dt_matean13.Rows[i]["EAN13"].ToString();
                    objClient.EAN13 = EAN13;
                    DataTable dt_matean = GetMaterialEAN();
                    if (dt_matean.Rows.Count <= 0)
                    {
                        objMateriEan.EAN13 = dt_matean13.Rows[i]["EAN13"].ToString();
                        objMateriEan.MaterialID = dt_matean13.Rows[i]["MaterialID"].ToString();
                        objMateriEan.Uom = dt_matean13.Rows[i]["Uom"].ToString();
                        objMateriEan.ConvertValue = Convert.ToDouble(dt_matean13.Rows[i]["ConvertValue"].ToString());
                        objMateriEan.BaseUom = dt_matean13.Rows[i]["BaseUom"].ToString();
                        objMateriEan.MaterialMix = dt_matean13.Rows[i]["MaterialMix"].ToString();

                        objMateriEan.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objMateriEan.InsertMaterialEAN_MasterData();
                    }
                    else
                    {
                        objMateriEan.EAN13 = dt_matean13.Rows[i]["EAN13"].ToString();
                        objMateriEan.MaterialID = dt_matean13.Rows[i]["MaterialID"].ToString();
                        objMateriEan.Uom = dt_matean13.Rows[i]["Uom"].ToString();
                        objMateriEan.ConvertValue = Convert.ToDouble(dt_matean13.Rows[i]["ConvertValue"].ToString());
                        objMateriEan.BaseUom = dt_matean13.Rows[i]["BaseUom"].ToString();
                        objMateriEan.MaterialMix = dt_matean13.Rows[i]["MaterialMix"].ToString();
                        objMateriEan.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objMateriEan.UpdateMaterialEAN_MasterData();

                    }
                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertMaterialEAN_Master : " + ex.Message);
            }
        }

        public void InsertLocationPrice(DataTable dt_locationPrice)
        {
            try
            {
                if (dt_locationPrice.Rows.Count > 0)
                {
                    DeleteLocationPrice();
                }
                for (int i = 0; i < dt_locationPrice.Rows.Count; i++)
                {
                    objLocationPrice.LocationID = dt_locationPrice.Rows[i]["LocationID"].ToString();
                    objLocationPrice.EAN13 = dt_locationPrice.Rows[i]["EAN13"].ToString();
                    objLocationPrice.MaterialID = dt_locationPrice.Rows[i]["MaterialID"].ToString();
                    objLocationPrice.UOM = dt_locationPrice.Rows[i]["UOM"].ToString();
                    objLocationPrice.Price = Convert.ToDouble(dt_locationPrice.Rows[i]["Price"].ToString());

                    objLocationPrice.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    objLocationPrice.InsertLocationPrice();
                    Disconnect = false;
                }
                if (dt_locationPrice.Rows.Count > 0)
                {
                    UpdateLocationPrice_MasterData(dt_locationPrice);
                    InsertLocationPrice_MasterData(dt_locationPrice);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertLocationPrice_Temp : " + ex.Message);
            }
        }

        public void InsertLocation(DataTable dt_location)
        {
            try
            {
                objLocation.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                if (dt_location.Rows.Count > 0)
                {
                    DeleteLocation();
                }
                for (int i = 0; i < dt_location.Rows.Count; i++)
                {
                    objLocation.LocationID = dt_location.Rows[i]["LocationID"].ToString();
                    objLocation.LocationDesc = dt_location.Rows[i]["LocationDesc"].ToString();
                    objLocation.Address1 = dt_location.Rows[i]["Address1"].ToString();
                    objLocation.Address2 = dt_location.Rows[i]["Address2"].ToString();
                    objLocation.Address3 = dt_location.Rows[i]["Address3"].ToString();
                    objLocation.POBox = dt_location.Rows[i]["POBox"].ToString();
                    objLocation.Contact = dt_location.Rows[i]["Contact"].ToString();
                    objLocation.Phone = dt_location.Rows[i]["Phone"].ToString();
                    objLocation.Fax = dt_location.Rows[i]["Fax"].ToString();
                    objLocation.Email = dt_location.Rows[i]["Email"].ToString();
                    objLocation.City = dt_location.Rows[i]["City"].ToString();
                    objLocation.Region = dt_location.Rows[i]["Region"].ToString();
                    objLocation.Country = dt_location.Rows[i]["Country"].ToString();
                    objLocation.CostCenter = dt_location.Rows[i]["CostCenter"].ToString();
                    objLocation.CashLoan = Convert.ToDouble(dt_location.Rows[i]["CashLoan"].ToString());
                    objLocation.CustInt1 = Convert.ToInt32(dt_location.Rows[i]["CustInt1"].ToString());
                    objLocation.CustInt2 = Convert.ToInt32(dt_location.Rows[i]["CustInt2"].ToString());
                    objLocation.CustInt3 = Convert.ToInt32(dt_location.Rows[i]["CustInt3"].ToString());
                    objLocation.InsertLocation();

                    Disconnect = false;
                }
                if (dt_location.Rows.Count > 0)
                {
                    UpdateLocation_MasterData(dt_location);
                    InsertLocation_MasterData(dt_location);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertLocation_Temp : " + ex.Message);
            }
        }

        public void UpdateLocation_MasterData(DataTable dt_location)
        {
            try
            {
                objLocation.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_location.Rows.Count; i++)
                {
                    objLocation.LocationID = dt_location.Rows[i]["LocationID"].ToString();
                    objLocation.LocationDesc = dt_location.Rows[i]["LocationDesc"].ToString();
                    objLocation.POBox = dt_location.Rows[i]["POBox"].ToString();
                    objLocation.Contact = dt_location.Rows[i]["Contact"].ToString();
                    objLocation.Phone = dt_location.Rows[i]["Phone"].ToString();
                    objLocation.Fax = dt_location.Rows[i]["Fax"].ToString();
                    objLocation.Email = dt_location.Rows[i]["Email"].ToString();
                    objLocation.City = dt_location.Rows[i]["City"].ToString();
                    objLocation.Region = dt_location.Rows[i]["Region"].ToString();
                    objLocation.Country = dt_location.Rows[i]["Country"].ToString();
                    objLocation.CostCenter = dt_location.Rows[i]["CostCenter"].ToString();
                    objLocation.CashLoan = Convert.ToDouble(dt_location.Rows[i]["CashLoan"].ToString());
                    objLocation.UpdateLocation_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateLocation_MasterData : " + ex.Message);
            }
        }

        public void InsertLocation_MasterData(DataTable dt_location)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_location.Rows.Count; i++)
                {
                    string LocationID = dt_location.Rows[i]["LocationID"].ToString();
                    objClient.LocationID = LocationID;
                    DataTable dt_loc = GetLocation();
                    if (dt_loc.Rows.Count <= 0)
                    {

                        objLocation.LocationID = dt_location.Rows[i]["LocationID"].ToString();
                        objLocation.LocationDesc = dt_location.Rows[i]["LocationDesc"].ToString();
                        objLocation.Address1 = dt_location.Rows[i]["Address1"].ToString();
                        objLocation.Address2 = dt_location.Rows[i]["Address2"].ToString();
                        objLocation.Address3 = dt_location.Rows[i]["Address3"].ToString();
                        objLocation.POBox = dt_location.Rows[i]["POBox"].ToString();
                        objLocation.Contact = dt_location.Rows[i]["Contact"].ToString();
                        objLocation.Phone = dt_location.Rows[i]["Phone"].ToString();
                        objLocation.Fax = dt_location.Rows[i]["Fax"].ToString();
                        objLocation.Email = dt_location.Rows[i]["Email"].ToString();
                        objLocation.City = dt_location.Rows[i]["City"].ToString();
                        objLocation.Region = dt_location.Rows[i]["Region"].ToString();
                        objLocation.Country = dt_location.Rows[i]["Country"].ToString();
                        objLocation.CostCenter = dt_location.Rows[i]["CostCenter"].ToString();
                        objLocation.CashLoan = Convert.ToDouble(dt_location.Rows[i]["CashLoan"].ToString());
                        objLocation.CustInt1 = Convert.ToInt32(dt_location.Rows[i]["CustInt1"].ToString());
                        objLocation.CustInt2 = Convert.ToInt32(dt_location.Rows[i]["CustInt2"].ToString());
                        objLocation.CustInt3 = Convert.ToInt32(dt_location.Rows[i]["CustInt3"].ToString());
                        objLocation.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objLocation.InsertLocation_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objLocation.LocationID = dt_location.Rows[i]["LocationID"].ToString();
                        objLocation.LocationDesc = dt_location.Rows[i]["LocationDesc"].ToString();
                        objLocation.POBox = dt_location.Rows[i]["POBox"].ToString();
                        objLocation.Contact = dt_location.Rows[i]["Contact"].ToString();
                        objLocation.Phone = dt_location.Rows[i]["Phone"].ToString();
                        objLocation.Fax = dt_location.Rows[i]["Fax"].ToString();
                        objLocation.Email = dt_location.Rows[i]["Email"].ToString();
                        objLocation.City = dt_location.Rows[i]["City"].ToString();
                        objLocation.Region = dt_location.Rows[i]["Region"].ToString();
                        objLocation.Country = dt_location.Rows[i]["Country"].ToString();
                        objLocation.CostCenter = dt_location.Rows[i]["CostCenter"].ToString();
                        objLocation.CashLoan = Convert.ToDouble(dt_location.Rows[i]["CashLoan"].ToString());
                        objLocation.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objLocation.UpdateLocation_MasterData();

                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertLocation_Master : " + ex.Message);
            }
        }

        public void InsertCategory(DataTable dt_category)
        {
            try
            {
                if (dt_category.Rows.Count > 0)
                {
                    DeleteCategory();
                }
                objCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_category.Rows.Count; i++)
                {
                    objCategory.CategoryID = dt_category.Rows[i]["CategoryID"].ToString();
                    objCategory.CategoryDesc = dt_category.Rows[i]["CategoryDesc"].ToString();
                    objCategory.InsertCategory();
                    Disconnect = false;
                }
                if (dt_category.Rows.Count > 0)
                {
                    UpdateCategory_MasterData(dt_category);
                    InsertCategory_MasterData(dt_category);

                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCategory_Temp : " + ex.Message);
            }
        }

        public void UpdateCategory_MasterData(DataTable dt_category)
        {
            try
            {
                objCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_category.Rows.Count; i++)
                {
                    objCategory.CategoryID = dt_category.Rows[i]["CategoryID"].ToString();
                    objCategory.CategoryDesc = dt_category.Rows[i]["CategoryDesc"].ToString();
                    objCategory.UpdateCategory_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateCategory_Master : " + ex.Message);
            }
        }

        public void InsertCategory_MasterData(DataTable dt_category)
        {
            try
            {

                for (int i = 0; i < dt_category.Rows.Count; i++)
                {
                    objCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string CategoryID = dt_category.Rows[i]["CategoryID"].ToString();
                    objClient.CategoryID = CategoryID;
                    DataTable dt_cat = GetCategory();
                    if (dt_cat.Rows.Count <= 0)
                    {
                        objCategory.CategoryID = dt_category.Rows[i]["CategoryID"].ToString();
                        objCategory.CategoryDesc = dt_category.Rows[i]["CategoryDesc"].ToString();
                        objCategory.InsertCategory_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objCategory.CategoryID = dt_category.Rows[i]["CategoryID"].ToString();
                        objCategory.CategoryDesc = dt_category.Rows[i]["CategoryDesc"].ToString();
                        objCategory.UpdateCategory_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCategory_Master : " + ex.Message);
            }
        }

        public void InsertSubCategory(DataTable dt_subcat)
        {
            try
            {
                if (dt_subcat.Rows.Count > 0)
                {
                    DeleteSubCategory();
                }
                objSubCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_subcat.Rows.Count; i++)
                {
                    objSubCategory.SubCategoryID = dt_subcat.Rows[i]["SubCategoryID"].ToString();
                    objSubCategory.SubCategoryDesc = dt_subcat.Rows[i]["SubCategoryDesc"].ToString();
                    objSubCategory.CategoryID = dt_subcat.Rows[i]["CategoryID"].ToString();
                    objSubCategory.InsertSubCategory();

                    Disconnect = false;
                }
                if (dt_subcat.Rows.Count > 0)
                {
                    UpdateSubCategory_MasterData(dt_subcat);
                    InsertSubCategory_MasterData(dt_subcat);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertSubCategory_Temp : " + ex.Message);
            }
        }

        public void UpdateSubCategory_MasterData(DataTable dt_subcat)
        {
            try
            {
                objSubCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_subcat.Rows.Count; i++)
                {
                    objSubCategory.SubCategoryID = dt_subcat.Rows[i]["SubCategoryID"].ToString();
                    objSubCategory.SubCategoryDesc = dt_subcat.Rows[i]["SubCategoryDesc"].ToString();
                    objSubCategory.CategoryID = dt_subcat.Rows[i]["CategoryID"].ToString();
                    objSubCategory.UpdateSubCategory_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateSubCategory_Master : " + ex.Message);
            }
        }

        public void InsertSubCategory_MasterData(DataTable dt_subcat)
        {
            try
            {
                for (int i = 0; i < dt_subcat.Rows.Count; i++)
                {
                    string SubCategoryID = dt_subcat.Rows[i]["SubCategoryID"].ToString();
                    objClient.SubCategoryID = SubCategoryID;
                    DataTable dt_sub = GetSubCategory();
                    if (dt_sub.Rows.Count <= 0)
                    {
                        objSubCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objSubCategory.SubCategoryID = dt_subcat.Rows[i]["SubCategoryID"].ToString();
                        objSubCategory.SubCategoryDesc = dt_subcat.Rows[i]["SubCategoryDesc"].ToString();
                        objSubCategory.CategoryID = dt_subcat.Rows[i]["CategoryID"].ToString();
                        objSubCategory.InsertSubCategory_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objSubCategory.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objSubCategory.SubCategoryID = dt_subcat.Rows[i]["SubCategoryID"].ToString();
                        objSubCategory.SubCategoryDesc = dt_subcat.Rows[i]["SubCategoryDesc"].ToString();
                        objSubCategory.CategoryID = dt_subcat.Rows[i]["CategoryID"].ToString();
                        objSubCategory.UpdateSubCategory_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertSubCategory_Master : " + ex.Message);
            }
        }

        public void InsertLocationPrice_MasterData(DataTable dt_locationPrice)
        {
            try
            {
                objLocationPrice.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_locationPrice.Rows.Count; i++)
                {
                    string LocationID = dt_locationPrice.Rows[i]["LocationID"].ToString();
                    objClient.LocationID = LocationID;
                    DataTable dt_locPrice = Getlocationprice();
                    if (dt_locPrice.Rows.Count <= 0)
                    {
                        objLocationPrice.LocationID = dt_locationPrice.Rows[i]["LocationID"].ToString();
                        objLocationPrice.EAN13 = dt_locationPrice.Rows[i]["EAN13"].ToString();
                        objLocationPrice.MaterialID = dt_locationPrice.Rows[i]["MaterialID"].ToString();
                        objLocationPrice.UOM = dt_locationPrice.Rows[i]["UOM"].ToString();
                        objLocationPrice.Price = Convert.ToDouble(dt_locationPrice.Rows[i]["Price"].ToString());
                        objLocationPrice.InsertLocationPrice_MasterData();
                        Disconnect = false;
                    }
                    else
                    {
                        objLocationPrice.LocationID = dt_locationPrice.Rows[i]["LocationID"].ToString();
                        objLocationPrice.EAN13 = dt_locationPrice.Rows[i]["EAN13"].ToString();
                        objLocationPrice.MaterialID = dt_locationPrice.Rows[i]["MaterialID"].ToString();
                        objLocationPrice.UOM = dt_locationPrice.Rows[i]["UOM"].ToString();
                        objLocationPrice.Price = Convert.ToDouble(dt_locationPrice.Rows[i]["Price"].ToString());
                        objLocationPrice.UpdateLocationPrice_MasterData();

                        Disconnect = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertLocationPrice_Master : " + ex.Message);
            }
        }

        public void InsertPreferUOM(DataTable dt_prefer)
        {
            try
            {
                if (dt_prefer.Rows.Count > 0)
                {
                    DeletePreferUOM();
                }
                objPreferUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_prefer.Rows.Count; i++)
                {
                    objPreferUOM.MaterialID = dt_prefer.Rows[i]["MaterialID"].ToString();
                    objPreferUOM.EAN13 = dt_prefer.Rows[i]["EAN13"].ToString();
                    objPreferUOM.UOM = dt_prefer.Rows[i]["UOM"].ToString();
                    objPreferUOM.InsertPreferUOM();

                    Disconnect = false;
                }
                if (dt_prefer.Rows.Count > 0)
                {

                    UpdatePreferUOM_MasterData(dt_prefer);
                    InsertPreferUOM_MasterData(dt_prefer);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertPreferUOM : " + ex.Message);
            }
        }

        public void UpdatePreferUOM_MasterData(DataTable dt_prefer)
        {
            try
            {
                objPreferUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_prefer.Rows.Count; i++)
                {
                    objPreferUOM.MaterialID = dt_prefer.Rows[i]["MaterialID"].ToString();
                    objPreferUOM.EAN13 = dt_prefer.Rows[i]["EAN13"].ToString();
                    objPreferUOM.UOM = dt_prefer.Rows[i]["UOM"].ToString();
                    objPreferUOM.UpdatePreferUOM_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdatePreferUOM_Master : " + ex.Message);
            }
        }

        public void InsertPreferUOM_MasterData(DataTable dt_prefer)
        {
            try
            {

                for (int i = 0; i < dt_prefer.Rows.Count; i++)
                {
                    objPreferUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string MaterialID = dt_prefer.Rows[i]["MaterialID"].ToString();
                    objClient.MaterialID = MaterialID;
                    DataTable dt_pre = GetPreferUOM();
                    if (dt_pre.Rows.Count <= 0)
                    {
                        objPreferUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objPreferUOM.MaterialID = dt_prefer.Rows[i]["MaterialID"].ToString();
                        objPreferUOM.EAN13 = dt_prefer.Rows[i]["EAN13"].ToString();
                        objPreferUOM.UOM = dt_prefer.Rows[i]["UOM"].ToString();
                        objPreferUOM.TerminalID = dt_prefer.Rows[i]["TerminalID"].ToString();
                        objPreferUOM.InsertPreferUOM_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objPreferUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objPreferUOM.MaterialID = dt_prefer.Rows[i]["MaterialID"].ToString();
                        objPreferUOM.EAN13 = dt_prefer.Rows[i]["EAN13"].ToString();
                        objPreferUOM.UOM = dt_prefer.Rows[i]["UOM"].ToString();
                        objPreferUOM.TerminalID = dt_prefer.Rows[i]["TerminalID"].ToString();
                        objPreferUOM.UpdatePreferUOM_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertPreferUOM_Master : " + ex.Message);
            }
        }

        public void InsertCurrency(DataTable dt_currency)
        {
            try
            {
                if (dt_currency.Rows.Count > 0)
                {
                    DeleteCurrency();
                }
                objCurrency.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_currency.Rows.Count; i++)
                {
                    objCurrency.CurrencyID = dt_currency.Rows[i]["CurrencyID"].ToString();
                    objCurrency.CurrencyName = dt_currency.Rows[i]["CurrencyName"].ToString();
                    objCurrency.CurrRate = Convert.ToDouble(dt_currency.Rows[i]["CurrRate"].ToString());
                    objCurrency.InsertCurrency();

                    Disconnect = false;
                }
                if (dt_currency.Rows.Count > 0)
                {
                    UpdateCurrency_MasterData(dt_currency);
                    InsertCurrency_MasterData(dt_currency);
                }

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCurrency_Temp : " + ex.Message);
            }
        }

        public void UpdateCurrency_MasterData(DataTable dt_currency)
        {
            try
            {
                objCurrency.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_currency.Rows.Count; i++)
                {
                    objCurrency.CurrencyID = dt_currency.Rows[i]["CurrencyID"].ToString();
                    objCurrency.CurrencyName = dt_currency.Rows[i]["CurrencyName"].ToString();
                    objCurrency.CurrRate = Convert.ToDouble(dt_currency.Rows[i]["CurrRate"].ToString());
                    objCurrency.UpdateCurrency_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateCurrency_Master : " + ex.Message);
            }
        }

        public void InsertCurrency_MasterData(DataTable dt_currency)
        {
            try
            {
                objCurrency.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_currency.Rows.Count; i++)
                {
                    string CurrencyID = dt_currency.Rows[i]["CurrencyID"].ToString();
                    objClient.CurrencyID = CurrencyID;
                    DataTable dt_cur = GetCurrency();
                    if (dt_cur.Rows.Count <= 0)
                    {
                        objCurrency.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objCurrency.CurrencyID = dt_currency.Rows[i]["CurrencyID"].ToString();
                        objCurrency.CurrencyName = dt_currency.Rows[i]["CurrencyName"].ToString();
                        objCurrency.CurrRate = Convert.ToDouble(dt_currency.Rows[i]["CurrRate"].ToString());
                        objCurrency.InsertCurrency_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objCurrency.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objCurrency.CurrencyID = dt_currency.Rows[i]["CurrencyID"].ToString();
                        objCurrency.CurrencyName = dt_currency.Rows[i]["CurrencyName"].ToString();
                        objCurrency.CurrRate = Convert.ToDouble(dt_currency.Rows[i]["CurrRate"].ToString());
                        objCurrency.UpdateCurrency_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCurrency_Master : " + ex.Message);
            }
        }

        public void InsertCustomer(DataTable dt_customer)
        {
            try
            {
                objCustomer.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                if (dt_customer.Rows.Count > 0)
                {
                    DeleteCustomer();
                }

                for (int i = 0; i < dt_customer.Rows.Count; i++)
                {
                    objCustomer.CustomerID = dt_customer.Rows[i]["CustomerID"].ToString();
                    objCustomer.Name1 = dt_customer.Rows[i]["Name1"].ToString();
                    objCustomer.Name2 = dt_customer.Rows[i]["Name2"].ToString();
                    objCustomer.Address1 = dt_customer.Rows[i]["Address1"].ToString();
                    objCustomer.Address2 = dt_customer.Rows[i]["Address2"].ToString();
                    objCustomer.Address3 = dt_customer.Rows[i]["Address3"].ToString();
                    objCustomer.POBox = dt_customer.Rows[i]["POBox"].ToString();
                    objCustomer.Phone = dt_customer.Rows[i]["Phone"].ToString();
                    objCustomer.Fax = dt_customer.Rows[i]["Fax"].ToString();
                    objCustomer.Email = dt_customer.Rows[i]["Email"].ToString();
                    objCustomer.City = dt_customer.Rows[i]["City"].ToString();
                    objCustomer.Region = dt_customer.Rows[i]["Region"].ToString();
                    objCustomer.Country = dt_customer.Rows[i]["Country"].ToString();
                    objCustomer.CreditLimit = Convert.ToDouble(dt_customer.Rows[i]["CreditLimit"].ToString());
                    objCustomer.CustInt1 = Convert.ToInt32(dt_customer.Rows[i]["CustInt1"].ToString());
                    objCustomer.CustInt2 = Convert.ToInt32(dt_customer.Rows[i]["CustInt2"].ToString());
                    objCustomer.CustInt3 = Convert.ToInt32(dt_customer.Rows[i]["CustInt3"].ToString());
                    objCustomer.CustType = dt_customer.Rows[i]["CustType"].ToString();
                    objCustomer.TotalDue = Convert.ToDouble(dt_customer.Rows[i]["TotalDue"].ToString());
                    objCustomer.InsertCustomer();

                    Disconnect = false;

                }
                if (dt_customer.Rows.Count > 0)
                {
                    UpdateCustomer_MasterData(dt_customer);
                    InsertCustomer_MasterData(dt_customer);

                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCustomer_Temp : " + ex.Message);
            }
        }

        public void UpdateCustomer_MasterData(DataTable dt_customer)
        {
            try
            {
                objCustomer.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_customer.Rows.Count; i++)
                {
                    objCustomer.CustomerID = dt_customer.Rows[i]["CustomerID"].ToString();
                    objCustomer.Name1 = dt_customer.Rows[i]["Name1"].ToString();
                    objCustomer.Name2 = dt_customer.Rows[i]["Name2"].ToString();
                    objCustomer.Address1 = dt_customer.Rows[i]["Address1"].ToString();
                    objCustomer.Address2 = dt_customer.Rows[i]["Address2"].ToString();
                    objCustomer.Address3 = dt_customer.Rows[i]["Address3"].ToString();
                    objCustomer.POBox = dt_customer.Rows[i]["POBox"].ToString();
                    objCustomer.Phone = dt_customer.Rows[i]["Phone"].ToString();
                    objCustomer.Fax = dt_customer.Rows[i]["Fax"].ToString();
                    objCustomer.Email = dt_customer.Rows[i]["Email"].ToString();
                    objCustomer.City = dt_customer.Rows[i]["City"].ToString();
                    objCustomer.Region = dt_customer.Rows[i]["Region"].ToString();
                    objCustomer.Country = dt_customer.Rows[i]["Country"].ToString();
                    objCustomer.CreditLimit = Convert.ToDouble(dt_customer.Rows[i]["CreditLimit"].ToString());
                    objCustomer.CustType = dt_customer.Rows[i]["CustType"].ToString();
                    objCustomer.TotalDue = Convert.ToDouble(dt_customer.Rows[i]["TotalDue"].ToString());
                    objCustomer.UpdateCustomer_MasterData();

                    Disconnect = false;

                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateCustomer_Master : " + ex.Message);
            }
        }

        public void InsertCustomer_MasterData(DataTable dt_customer)
        {
            try
            {

                for (int i = 0; i < dt_customer.Rows.Count; i++)
                {
                    objCustomer.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string CustomerID = dt_customer.Rows[i]["CustomerID"].ToString();
                    objClient.CustomerID = CustomerID;
                    DataTable dt_cus = GetCustomer();
                    if (dt_cus.Rows.Count <= 0)
                    {
                        objCustomer.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objCustomer.CustomerID = dt_customer.Rows[i]["CustomerID"].ToString();
                        objCustomer.Name1 = dt_customer.Rows[i]["Name1"].ToString();
                        objCustomer.Name2 = dt_customer.Rows[i]["Name2"].ToString();
                        objCustomer.Address1 = dt_customer.Rows[i]["Address1"].ToString();
                        objCustomer.Address2 = dt_customer.Rows[i]["Address2"].ToString();
                        objCustomer.Address3 = dt_customer.Rows[i]["Address3"].ToString();
                        objCustomer.POBox = dt_customer.Rows[i]["POBox"].ToString();
                        objCustomer.Phone = dt_customer.Rows[i]["Phone"].ToString();
                        objCustomer.Fax = dt_customer.Rows[i]["Fax"].ToString();
                        objCustomer.Email = dt_customer.Rows[i]["Email"].ToString();
                        objCustomer.City = dt_customer.Rows[i]["City"].ToString();
                        objCustomer.Region = dt_customer.Rows[i]["Region"].ToString();
                        objCustomer.Country = dt_customer.Rows[i]["Country"].ToString();
                        objCustomer.CreditLimit = Convert.ToDouble(dt_customer.Rows[i]["CreditLimit"].ToString());
                        objCustomer.CustInt1 = Convert.ToInt32(dt_customer.Rows[i]["CustInt1"].ToString());
                        objCustomer.CustInt2 = Convert.ToInt32(dt_customer.Rows[i]["CustInt2"].ToString());
                        objCustomer.CustInt3 = Convert.ToInt32(dt_customer.Rows[i]["CustInt3"].ToString());
                        objCustomer.CustType = dt_customer.Rows[i]["CustType"].ToString();
                        objCustomer.TotalDue = Convert.ToDouble(dt_customer.Rows[i]["TotalDue"].ToString());
                        objCustomer.InsertCustomer_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objCustomer.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        objCustomer.CustomerID = dt_customer.Rows[i]["CustomerID"].ToString();
                        objCustomer.Name1 = dt_customer.Rows[i]["Name1"].ToString();
                        objCustomer.Name2 = dt_customer.Rows[i]["Name2"].ToString();
                        objCustomer.Address1 = dt_customer.Rows[i]["Address1"].ToString();
                        objCustomer.Address2 = dt_customer.Rows[i]["Address2"].ToString();
                        objCustomer.Address3 = dt_customer.Rows[i]["Address3"].ToString();
                        objCustomer.POBox = dt_customer.Rows[i]["POBox"].ToString();
                        objCustomer.Phone = dt_customer.Rows[i]["Phone"].ToString();
                        objCustomer.Fax = dt_customer.Rows[i]["Fax"].ToString();
                        objCustomer.Email = dt_customer.Rows[i]["Email"].ToString();
                        objCustomer.City = dt_customer.Rows[i]["City"].ToString();
                        objCustomer.Region = dt_customer.Rows[i]["Region"].ToString();
                        objCustomer.Country = dt_customer.Rows[i]["Country"].ToString();
                        objCustomer.CreditLimit = Convert.ToDouble(dt_customer.Rows[i]["CreditLimit"].ToString());
                        objCustomer.CustType = dt_customer.Rows[i]["CustType"].ToString().Trim();
                        objCustomer.TotalDue = Convert.ToDouble(dt_customer.Rows[i]["TotalDue"].ToString());
                        objCustomer.UpdateCustomer_MasterData();

                    }
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertCustomer_Master : " + ex.Message);
            }
        }

        public void InsertPriceFile(DataTable dt_PriceFile)
        {
            try
            {
                if (dt_PriceFile.Rows.Count > 0)
                {
                    DeletePriceFile();
                }
                objPriceFile.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_PriceFile.Rows.Count; i++)
                {
                    objPriceFile.EAN13 = dt_PriceFile.Rows[i]["EAN13"].ToString();
                    objPriceFile.MaterialID = dt_PriceFile.Rows[i]["MaterialID"].ToString();
                    objPriceFile.UOM = dt_PriceFile.Rows[i]["UOM"].ToString();
                    objPriceFile.Price = Convert.ToDouble(dt_PriceFile.Rows[i]["Price"].ToString());
                    objPriceFile.InsertPriceFile();
                    Disconnect = false;
                }
                if (dt_PriceFile.Rows.Count > 0)
                {
                    UpdatePriceFile_MasterData(dt_PriceFile);
                    InsertPriceFile_MasterData(dt_PriceFile);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertPriceFile_Temp : " + ex.Message);
            }
        }

        public void InsertPriceFile_MasterData(DataTable dt_pricefile)
        {
            try
            {
                for (int i = 0; i < dt_pricefile.Rows.Count; i++)
                {
                    string EAN13 = dt_pricefile.Rows[i]["EAN13"].ToString();
                    objClient.EAN13 = EAN13;
                    DataTable dt_price = GetPriceFile();
                    objPriceFile.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    if (dt_price.Rows.Count <= 0)
                    {
                        objPriceFile.EAN13 = dt_pricefile.Rows[i]["EAN13"].ToString();
                        objPriceFile.MaterialID = dt_pricefile.Rows[i]["MaterialID"].ToString();
                        objPriceFile.UOM = dt_pricefile.Rows[i]["UOM"].ToString();
                        objPriceFile.Price = Convert.ToDouble(dt_pricefile.Rows[i]["Price"].ToString());
                        objPriceFile.InsertpriceFile_MasterData();
                        Disconnect = false;
                    }
                    else
                    {
                        objPriceFile.EAN13 = dt_pricefile.Rows[i]["EAN13"].ToString();
                        objPriceFile.MaterialID = dt_pricefile.Rows[i]["MaterialID"].ToString();
                        objPriceFile.UOM = dt_pricefile.Rows[i]["UOM"].ToString();
                        objPriceFile.Price = Convert.ToDouble(dt_pricefile.Rows[i]["Price"].ToString());
                        objPriceFile.UpdatePriceFile_MasterData();
                        Disconnect = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertPriceFile_Master : " + ex.Message);
            }
        }

        public void InsertUsers(DataTable dt_users)
        {
            try
            {
                if (dt_users.Rows.Count > 0)
                {
                    DeleteUsers();
                }
                objUsers.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_users.Rows.Count; i++)
                {
                    objUsers.UserID = Convert.ToInt32(dt_users.Rows[i]["UserID"].ToString());
                    objUsers.UserName = dt_users.Rows[i]["UserName"].ToString();
                    objUsers.Password = dt_users.Rows[i]["Password"].ToString();
                    objUsers.LocationID = dt_users.Rows[i]["LocationID"].ToString();
                    objUsers.InsertUsers();

                    Disconnect = false;

                }
                if (dt_users.Rows.Count > 0)
                {
                    UpdateUsers_MasterData(dt_users);
                    InsertUsers_MasterData(dt_users);
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertUsers_Temp : " + ex.Message);
            }
        }

        public void InsertUsers_MasterData(DataTable dt_users)
        {
            try
            {
                for (int i = 0; i < dt_users.Rows.Count; i++)
                {
                    objUsers.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string UserID = dt_users.Rows[i]["UserID"].ToString();
                    objClient.UserID = UserID;
                    DataTable dt_user = GetUsers();


                    if (dt_user.Rows.Count <= 0)
                    {
                        objUsers.UserID = Convert.ToInt32(dt_users.Rows[i]["UserID"].ToString());
                        objUsers.UserName = dt_users.Rows[i]["UserName"].ToString();
                        objUsers.Password = dt_users.Rows[i]["Password"].ToString();
                        objUsers.LocationID = dt_users.Rows[i]["LocationID"].ToString();
                        objUsers.Payment = dt_users.Rows[i]["Payment"].ToString();
                        objUsers.ReturnInv = dt_users.Rows[i]["ReturnInv"].ToString();
                        objUsers.ReturnNoInv = dt_users.Rows[i]["ReturnNoInv"].ToString();
                        objUsers.DeleteInv = dt_users.Rows[i]["DeleteInv"].ToString();
                        objUsers.Cash = dt_users.Rows[i]["Cash"].ToString();
                        objUsers.CreditCard = dt_users.Rows[i]["CreditCard"].ToString();
                        objUsers.DebitCard = dt_users.Rows[i]["DebitCard"].ToString();
                        objUsers.OnAccount = dt_users.Rows[i]["OnAccount"].ToString();
                        objUsers.Den1 = dt_users.Rows[i]["Den1"].ToString();
                        objUsers.Den5 = dt_users.Rows[i]["Den5"].ToString();
                        objUsers.Den10 = dt_users.Rows[i]["Den10"].ToString();
                        objUsers.Den20 = dt_users.Rows[i]["Den20"].ToString();
                        objUsers.Den50 = dt_users.Rows[i]["Den50"].ToString();
                        objUsers.Den100 = dt_users.Rows[i]["Den100"].ToString();
                        objUsers.Den500 = dt_users.Rows[i]["Den500"].ToString();
                        objUsers.HoldInv = dt_users.Rows[i]["HoldInv"].ToString();
                        objUsers.unholdInv = dt_users.Rows[i]["unholdInv"].ToString();
                        objUsers.Barcode = dt_users.Rows[i]["Barcode"].ToString();
                        objUsers.Quantity = dt_users.Rows[i]["Quantity"].ToString();
                        objUsers.Inventory = dt_users.Rows[i]["Inventory"].ToString();
                        objUsers.POReceive = dt_users.Rows[i]["POReceive"].ToString();
                        objUsers.ReturnSupp = dt_users.Rows[i]["ReturnSupp"].ToString();
                        objUsers.TransferDisp = dt_users.Rows[i]["TransferDisp"].ToString();
                        objUsers.TransferIn = dt_users.Rows[i]["TransferIn"].ToString();
                        objUsers.TransferOut = dt_users.Rows[i]["TransferOut"].ToString();
                        objUsers.PhyInventory = dt_users.Rows[i]["PhyInventory"].ToString();
                        objUsers.StockReport = dt_users.Rows[i]["StockReport"].ToString();
                        objUsers.Settingbutt = dt_users.Rows[i]["Settingbutt"].ToString();
                        objUsers.PrinterSetup = dt_users.Rows[i]["PrinterSetup"].ToString();
                        objUsers.EOD = dt_users.Rows[i]["EOD"].ToString();
                        objUsers.FavoritePannel = dt_users.Rows[i]["FavoritePannel"].ToString();
                        objUsers.LockUser = dt_users.Rows[i]["LockUser"].ToString();
                        objUsers.DeleteItem = dt_users.Rows[i]["DeleteItem"].ToString();
                        objUsers.InsertUsers_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objUsers.UserID = Convert.ToInt32(dt_users.Rows[i]["UserID"].ToString());
                        objUsers.UserName = dt_users.Rows[i]["UserName"].ToString();
                        objUsers.Password = dt_users.Rows[i]["Password"].ToString();
                        objUsers.LocationID = dt_users.Rows[i]["LocationID"].ToString();
                        objUsers.Payment = dt_users.Rows[i]["Payment"].ToString();
                        objUsers.ReturnInv = dt_users.Rows[i]["ReturnInv"].ToString();
                        objUsers.ReturnNoInv = dt_users.Rows[i]["ReturnNoInv"].ToString();
                        objUsers.DeleteInv = dt_users.Rows[i]["DeleteInv"].ToString();
                        objUsers.Cash = dt_users.Rows[i]["Cash"].ToString();
                        objUsers.CreditCard = dt_users.Rows[i]["CreditCard"].ToString();
                        objUsers.DebitCard = dt_users.Rows[i]["DebitCard"].ToString();
                        objUsers.OnAccount = dt_users.Rows[i]["OnAccount"].ToString();
                        objUsers.Den1 = dt_users.Rows[i]["Den1"].ToString();
                        objUsers.Den5 = dt_users.Rows[i]["Den5"].ToString();
                        objUsers.Den10 = dt_users.Rows[i]["Den10"].ToString();
                        objUsers.Den20 = dt_users.Rows[i]["Den20"].ToString();
                        objUsers.Den50 = dt_users.Rows[i]["Den50"].ToString();
                        objUsers.Den100 = dt_users.Rows[i]["Den100"].ToString();
                        objUsers.Den500 = dt_users.Rows[i]["Den500"].ToString();
                        objUsers.HoldInv = dt_users.Rows[i]["HoldInv"].ToString();
                        objUsers.unholdInv = dt_users.Rows[i]["unholdInv"].ToString();
                        objUsers.Barcode = dt_users.Rows[i]["Barcode"].ToString();
                        objUsers.Quantity = dt_users.Rows[i]["Quantity"].ToString();
                        objUsers.Inventory = dt_users.Rows[i]["Inventory"].ToString();
                        objUsers.POReceive = dt_users.Rows[i]["POReceive"].ToString();
                        objUsers.ReturnSupp = dt_users.Rows[i]["ReturnSupp"].ToString();
                        objUsers.TransferDisp = dt_users.Rows[i]["TransferDisp"].ToString();
                        objUsers.TransferIn = dt_users.Rows[i]["TransferIn"].ToString();
                        objUsers.TransferOut = dt_users.Rows[i]["TransferOut"].ToString();
                        objUsers.PhyInventory = dt_users.Rows[i]["PhyInventory"].ToString();
                        objUsers.StockReport = dt_users.Rows[i]["StockReport"].ToString();
                        objUsers.Settingbutt = dt_users.Rows[i]["Settingbutt"].ToString();
                        objUsers.PrinterSetup = dt_users.Rows[i]["PrinterSetup"].ToString();
                        objUsers.EOD = dt_users.Rows[i]["EOD"].ToString();
                        objUsers.FavoritePannel = dt_users.Rows[i]["FavoritePannel"].ToString();
                        objUsers.LockUser = dt_users.Rows[i]["LockUser"].ToString();
                        objUsers.DeleteItem = dt_users.Rows[i]["DeleteItem"].ToString();
                        objUsers.UpdateUsers_MasterData();
                        Disconnect = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertUsers_Master : " + ex.Message);
            }
        }


        public void UpdateUsers_MasterData(DataTable dt_users)
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_users.Rows.Count; i++)
                {
                    objUsers.UserID = Convert.ToInt32(dt_users.Rows[i]["UserID"].ToString());
                    objUsers.UserName = dt_users.Rows[i]["UserName"].ToString();
                    objUsers.Password = dt_users.Rows[i]["Password"].ToString();
                    objUsers.LocationID = dt_users.Rows[i]["LocationID"].ToString();
                    objUsers.UpdateUsers_MasterData();

                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateUsers_Master : " + ex.Message);
            }

        }
        public void DeleteEodClient(DataTable dt_CDel)
        {
            try
            {
                if (Disconnect == false)
                {
                    for (int i = 0; i < dt_CDel.Rows.Count; i++)
                    {
                        string _Eodid = dt_CDel.Rows[i]["EODID"].ToString();

                        DeleteEoddtls(_Eodid);
                        DeleteEod(_Eodid);

                    }
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Eod Client : " + ex.Message + ex.StackTrace);
            }
        }

        public void DeleteEod(string _Eodid)
        {
            try
            {
                objClientEodData.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClientEodData.EodId = _Eodid;

                objClientEodData.DeleteEOD();

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Eod : " + ex.Message + ex.StackTrace);
            }

        }

        public void DeleteEoddtls(string _Eodid)
        {
            try
            {
                objClientEodData.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClientEodData.EodId = _Eodid;

                objClientEodData.DeleteEODdtls();

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete EOD Dtls : " + ex.Message + ex.StackTrace);
            }
        }
        public DataTable GetMaterialEAN()
        {
            DataTable dt_material = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //objClient.EAN13 = dt_EAN.Rows[0]["EAN13"].ToString();
                dt_material = objClient.LoadMaterialEAN();

                //for (int i = 0; i < dt_material.Rows.Count; i++)
                //{
                //    //string _EAN13 = dt_material.Rows[i]["EAN13"].ToString();
                //    //DeleteMaterialEAN(_EAN13);
                //}
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Material EAN : " + ex.Message + ex.StackTrace);
            }
            return dt_material;
        }
        public DataTable Getlocationprice()
        {
            DataTable dt_loc = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_loc = objClient.LoadLocationprice();
                //for (int i = 0; i < dt_loc.Rows.Count; i++)
                //{
                //    string _locid = dt_loc.Rows[i]["LocationID"].ToString();
                //}
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Localtion Price : " + ex.Message + ex.StackTrace);
            }
            return dt_loc;
        }
        public DataTable GetLocation()
        {
            DataTable dt_location = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_location = objClient.LoadLocation();

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Location : " + ex.Message + ex.StackTrace);
            }
            return dt_location;
        }
        public DataTable GetCategory()
        {
            DataTable dt_cat = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_cat = objClient.LoadCategory();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Category : " + ex.Message + ex.StackTrace);

            }
            return dt_cat;
        }

        public DataTable GetSubCategory()
        {
            DataTable dt_subcat = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_subcat = objClient.LoadSubCategory();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Sub Category : " + ex.Message + ex.StackTrace);
            }
            return dt_subcat;
        }
        public DataTable GetPreferUOM()
        {
            DataTable dt_prefer = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_prefer = objClient.LoadPreferUOM();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get PreFer UOM : " + ex.Message + ex.StackTrace);
            }
            return dt_prefer;
        }
        public DataTable GetCurrency()
        {
            DataTable dt_curr = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_curr = objClient.LoadCurency();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Currency : " + ex.Message + ex.StackTrace);
            }
            return dt_curr;
        }
        public DataTable GetCustomer()
        {
            DataTable dt_curr = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_curr = objClient.LoadCustomer();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Customer : " + ex.Message + ex.StackTrace);
            }
            return dt_curr;
        }
        public DataTable GetCity()
        {
            DataTable dt_city = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_city = objClient.LoadCity();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get City : " + ex.Message + ex.StackTrace);
            }
            return dt_city;
        }
        public DataTable GetCompany()
        {
            DataTable dt_company = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_company = objClient.LoadCompany();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Company : " + ex.Message + ex.StackTrace);
            }
            return dt_company;
        }
        public DataTable GetStorage()
        {
            DataTable dt_st = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_st = objClient.LoadStorage();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Storage : " + ex.Message + ex.StackTrace);
            }
            return dt_st;
        }
        public DataTable GetTender()
        {
            DataTable dt_ten = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_ten = objClient.LoadTender();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Tender : " + ex.Message + ex.StackTrace);
            }
            return dt_ten;
        }
        public DataTable GetTerminal()
        {

            DataTable dt_ter = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_ter = objClient.LoadTerminal();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Terminal : " + ex.Message + ex.StackTrace);
            }
            return dt_ter;
        }
        public DataTable GetUOM()
        {

            DataTable dt_ter = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_ter = objClient.LoadUOM();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get UOM : " + ex.Message + ex.StackTrace);
            }
            return dt_ter;
        }
        public DataTable GetVendor()
        {

            DataTable dt_ter = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                dt_ter = objClient.LoadVendor();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get Vendor : " + ex.Message + ex.StackTrace);
            }
            return dt_ter;
        }
        public void DeleteCustomer()
        {

            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                // objClient.EAN13 = _EAN13;
                objClient.DeleteCustomer();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Customer : " + ex.Message + ex.StackTrace);
            }
        }

        public void DeleteMaterialEAN()
        {

            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteMaterialEAN();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete MaterialEAN : " + ex.Message + ex.StackTrace);
            }
        }
        public void DeleteLocationPrice()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                // objClient.LocationID = _loc;
                objClient.DeleteLocationPrice();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Location Price : " + ex.Message + ex.StackTrace);
            }
        }
        public void DeletePriceFile()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeletePriceFile();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Price File : " + ex.Message + ex.StackTrace);
            }
        }
        public void DeleteMaterial()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteMaterial();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Material  : " + ex.Message + ex.StackTrace);
            }
        }
        public void DeleteUsers()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteUsers();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Users : " + ex.Message + ex.StackTrace);
            }

        }
        public void DeleteLocation()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteLocation();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Location : " + ex.Message + ex.StackTrace);
            }

        }
        public void DeleteCategory()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteCategory();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delte Category : " + ex.Message + ex.StackTrace);
            }

        }

        public void DeleteSubCategory()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteSubCategory();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Sub Category : " + ex.Message + ex.StackTrace);
            }

        }
        public void DeletePreferUOM()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeletePreferUOM();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete PreferUOM : " + ex.Message + ex.StackTrace);
            }

        }
        public void DeleteCurrency()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteCurrency();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Currenry : " + ex.Message + ex.StackTrace);
            }

        }

        public void UpdateMaterialEAN_MasterData(DataTable dt_upMatEAN)
        {
            try
            {
                objMateriEan.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_upMatEAN.Rows.Count; i++)
                {

                    objMateriEan.EAN13 = dt_upMatEAN.Rows[i]["EAN13"].ToString();
                    objMateriEan.MaterialID = dt_upMatEAN.Rows[i]["MaterialID"].ToString();
                    objMateriEan.Uom = dt_upMatEAN.Rows[i]["Uom"].ToString();
                    objMateriEan.ConvertValue = Convert.ToDouble(dt_upMatEAN.Rows[i]["ConvertValue"].ToString());
                    objMateriEan.BaseUom = dt_upMatEAN.Rows[i]["BaseUom"].ToString();
                    objMateriEan.MaterialMix = dt_upMatEAN.Rows[i]["MaterialMix"].ToString();
                    objMateriEan.UpdateMaterialEAN_MasterData();
                    Disconnect = false;
                }

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateMaterialEAN_Master : " + ex.Message);
            }
        }
        public void UpdateLocationPrice_MasterData(DataTable dt_locationPrice)
        {
            objLocationPrice.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                for (int i = 0; i < dt_locationPrice.Rows.Count; i++)
                {
                    objLocationPrice.LocationID = dt_locationPrice.Rows[i]["LocationID"].ToString();
                    objLocationPrice.EAN13 = dt_locationPrice.Rows[i]["EAN13"].ToString();
                    objLocationPrice.MaterialID = dt_locationPrice.Rows[i]["MaterialID"].ToString();
                    objLocationPrice.UOM = dt_locationPrice.Rows[i]["UOM"].ToString();
                    objLocationPrice.Price = Convert.ToDouble(dt_locationPrice.Rows[i]["Price"].ToString());

                    objLocationPrice.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    objLocationPrice.UpdateLocationPrice_MasterData();
                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateLocationPrice_Master : " + ex.Message);
            }
        }
        public void UpdatePriceFile_MasterData(DataTable dt_PriceFile)
        {
            try
            {
                objPriceFile.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_PriceFile.Rows.Count; i++)
                {
                    objPriceFile.EAN13 = dt_PriceFile.Rows[i]["EAN13"].ToString();
                    objPriceFile.MaterialID = dt_PriceFile.Rows[i]["MaterialID"].ToString();
                    objPriceFile.UOM = dt_PriceFile.Rows[i]["UOM"].ToString();
                    objPriceFile.Price = Convert.ToDouble(dt_PriceFile.Rows[i]["Price"].ToString());
                    objPriceFile.UpdatePriceFile_MasterData();
                    Disconnect = false;
                }
            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdatePriceFile_Master : " + ex.Message);
            }
        }
        public void InsertCity_MasterDate(DataTable dt_City)
        {

            try
            {
                objCity.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                for (int i = 0; i < dt_City.Rows.Count; i++)
                {
                    string CityID = dt_City.Rows[i]["CityID"].ToString();
                    objClient.CityID = CityID;
                    DataTable dt_ct = GetCity();
                    if (dt_ct.Rows.Count <= 0)
                    {
                        objCity.CityID = dt_City.Rows[i]["CityID"].ToString();
                        objCity.CityName = dt_City.Rows[i]["CityName"].ToString();
                        objCity.InsertCity_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objCity.CityID = dt_City.Rows[i]["CityID"].ToString();
                        objCity.CityName = dt_City.Rows[i]["CityName"].ToString();
                        objCity.UpdateCity_MasterData();

                        Disconnect = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertCompany_MasterData(DataTable dt_company)
        {
            try
            {
                for (int i = 0; i < dt_company.Rows.Count; i++)
                {
                    objComapany.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string CompanyID = dt_company.Rows[i]["CompanyID"].ToString();
                    objClient.CompanyID = CompanyID;
                    DataTable dt_co = GetCompany();
                    if (dt_co.Rows.Count <= 0)
                    {
                        objComapany.CompanyID = dt_company.Rows[i]["CompanyID"].ToString();
                        objComapany.LongName = dt_company.Rows[i]["LongName"].ToString();
                        objComapany.ShortName = dt_company.Rows[i]["ShortName"].ToString();
                        objComapany.Address1 = dt_company.Rows[i]["Address1"].ToString();
                        objComapany.Address2 = dt_company.Rows[i]["Address2"].ToString();
                        objComapany.Address3 = dt_company.Rows[i]["Address3"].ToString();
                        objComapany.POBox = dt_company.Rows[i]["POBox"].ToString();
                        objComapany.Contact = dt_company.Rows[i]["Contact"].ToString();
                        objComapany.Phone = dt_company.Rows[i]["Phone"].ToString();
                        objComapany.Fax = dt_company.Rows[i]["Fax"].ToString();
                        objComapany.Email = dt_company.Rows[i]["Email"].ToString();
                        objComapany.City = dt_company.Rows[i]["City"].ToString();
                        objComapany.Region = dt_company.Rows[i]["Region"].ToString();
                        objComapany.Country = dt_company.Rows[i]["Country"].ToString();
                        objComapany.DefaultCurrency = dt_company.Rows[i]["DefaultCurrency"].ToString();

                        objComapany.InsertCompany_MaserData();

                        Disconnect = false;
                    }
                    else
                    {
                        objComapany.CompanyID = dt_company.Rows[i]["CompanyID"].ToString();
                        objComapany.LongName = dt_company.Rows[i]["LongName"].ToString();
                        objComapany.ShortName = dt_company.Rows[i]["ShortName"].ToString();
                        objComapany.Address1 = dt_company.Rows[i]["Address1"].ToString();
                        objComapany.Address2 = dt_company.Rows[i]["Address2"].ToString();
                        objComapany.Address3 = dt_company.Rows[i]["Address3"].ToString();
                        objComapany.POBox = dt_company.Rows[i]["POBox"].ToString();
                        objComapany.Contact = dt_company.Rows[i]["Contact"].ToString();
                        objComapany.Phone = dt_company.Rows[i]["Phone"].ToString();
                        objComapany.Fax = dt_company.Rows[i]["Fax"].ToString();
                        objComapany.Email = dt_company.Rows[i]["Email"].ToString();
                        objComapany.City = dt_company.Rows[i]["City"].ToString();
                        objComapany.Region = dt_company.Rows[i]["Region"].ToString();
                        objComapany.Country = dt_company.Rows[i]["Country"].ToString();
                        objComapany.DefaultCurrency = dt_company.Rows[i]["DefaultCurrency"].ToString();
                        objComapany.UpdateCompany_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertStorage_MasterData(DataTable dt_storage)
        {
            try
            {
               
                for (int i = 0; i < dt_storage.Rows.Count; i++)
                {
                    objStorage.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string LocationID = dt_storage.Rows[i]["LocationID"].ToString();
                    objClient.LocationID = LocationID;
                    DataTable dt_st = GetStorage();
                    if (dt_st.Rows.Count == dt_storage.Rows.Count)
                    {

                    }
                    else
                    {
                        if (dt_st.Rows.Count <= 0)
                        {
                            objStorage.StorageID = dt_storage.Rows[i]["StorageID"].ToString();
                            objStorage.StorageName = dt_storage.Rows[i]["StorageName"].ToString();
                            objStorage.StorageType = dt_storage.Rows[i]["StorageType"].ToString();
                            objStorage.LocationID = dt_storage.Rows[i]["LocationID"].ToString();
                            objStorage.InsertStorage_MasterData();

                            Disconnect = false;
                        }
                        else
                        {

                            //objStorage.StorageID = dt_storage.Rows[i]["StorageID"].ToString();
                            //objStorage.StorageName = dt_storage.Rows[i]["StorageName"].ToString();
                            //objStorage.StorageType = dt_storage.Rows[i]["StorageType"].ToString();
                            //objStorage.LocationID = dt_storage.Rows[i]["LocationID"].ToString();
                            //objStorage.UpdateStrorage_MasteData();

                            //Disconnect = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertTender_MasteData(DataTable dt_tender)
        {
            try
            {
                for (int i = 0; i < dt_tender.Rows.Count; i++)
                {
                    objTender.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string TenderID = dt_tender.Rows[i]["TenderID"].ToString();
                    objClient.TenderID = TenderID;
                    DataTable dt_te = GetTender();
                    if (dt_te.Rows.Count <= 0)
                    {
                        objTender.TenderID = dt_tender.Rows[i]["TenderID"].ToString();
                        objTender.TenderName = dt_tender.Rows[i]["TenderName"].ToString();
                        objTender.GL_Debit = dt_tender.Rows[i]["GL_Debit"].ToString();
                        objTender.GL_Credit = dt_tender.Rows[i]["GL_Credit"].ToString();
                        objTender.InsertTender_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objTender.TenderID = dt_tender.Rows[i]["TenderID"].ToString();
                        objTender.TenderName = dt_tender.Rows[i]["TenderName"].ToString();
                        objTender.GL_Debit = dt_tender.Rows[i]["GL_Debit"].ToString();
                        objTender.GL_Credit = dt_tender.Rows[i]["GL_Credit"].ToString();
                        objTender.UpdateTender_MasterData();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertTerminal_MasterData(DataTable dt_terminal)
        {
            try
            {
                for (int i = 0; i <= dt_terminal.Rows.Count; i++)
                {
                    objTerminal.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string LocationID = dt_terminal.Rows[i]["LocationID"].ToString();
                    objClient.LocationID = LocationID;
                    DataTable dt_ter = GetTerminal();
                    if (dt_ter.Rows.Count <= 0)
                    {
                        objTerminal.LocationID = dt_terminal.Rows[i]["LocationID"].ToString();
                        objTerminal.TerminalID = dt_terminal.Rows[i]["TerminalID"].ToString();
                        objTerminal.InsertTerminal_MasterData();
                    }
                    else
                    {
                        objTerminal.LocationID = dt_terminal.Rows[i]["LocationID"].ToString();
                        objTerminal.TerminalID = dt_terminal.Rows[i]["TerminalID"].ToString();
                        objTerminal.UpdateTerminal_MasterData();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertUOM_MasterData(DataTable dt_UOM)
        {
            try
            {
                for (int i = 0; i < dt_UOM.Rows.Count; i++)
                {
                    objUOM.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string UOM = dt_UOM.Rows[i]["UOM"].ToString();
                    objClient.UOM = UOM;
                    DataTable dt_u = GetUOM();
                    if (dt_u.Rows.Count <= 0)
                    {
                        objUOM.UOM = dt_UOM.Rows[i]["UOM"].ToString();
                        objUOM.UOMDesc = dt_UOM.Rows[i]["UOMDesc"].ToString();
                        objUOM.InsertUom_MasterData();

                        Disconnect = false;
                    }
                    else
                    {
                        objUOM.UOM = dt_UOM.Rows[i]["UOM"].ToString();
                        objUOM.UOMDesc = dt_UOM.Rows[i]["UOMDesc"].ToString();
                        objUOM.UpdateUom_MasterData();

                        Disconnect = false;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertVendor_MasterData(DataTable dt_vendor)
        {
            try
            {
                for (int i = 0; i < dt_vendor.Rows.Count; i++)
                {
                    objVendor.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string VendorID = dt_vendor.Rows[i]["VendorID"].ToString();
                    objClient.VendorID = VendorID;
                    DataTable dt = GetVendor();
                    if (dt.Rows.Count <= 0)
                    {
                        objVendor.VendorID = dt_vendor.Rows[i]["VendorID"].ToString();
                        objVendor.Name1 = dt_vendor.Rows[i]["Name1"].ToString();
                        objVendor.Name2 = dt_vendor.Rows[i]["Name2"].ToString();
                        objVendor.Address1 = dt_vendor.Rows[i]["Address1"].ToString();
                        objVendor.Address2 = dt_vendor.Rows[i]["Address2"].ToString();
                        objVendor.Address3 = dt_vendor.Rows[i]["Address3"].ToString();
                        objVendor.POBox = dt_vendor.Rows[i]["POBox"].ToString();
                        objVendor.Contact = dt_vendor.Rows[i]["Contact"].ToString();
                        objVendor.Phone = dt_vendor.Rows[i]["Phone"].ToString();
                        objVendor.Fax = dt_vendor.Rows[i]["Fax"].ToString();
                        objVendor.Email = dt_vendor.Rows[i]["Email"].ToString();
                        objVendor.City = dt_vendor.Rows[i]["City"].ToString();
                        objVendor.Region = dt_vendor.Rows[i]["Region"].ToString();
                        objVendor.Country = dt_vendor.Rows[i]["Country"].ToString();
                        objVendor.CustInt1 = Convert.ToInt32(dt_vendor.Rows[i]["CustInt1"].ToString());
                        objVendor.CustInt2 = Convert.ToInt32(dt_vendor.Rows[i]["CustInt2"].ToString());
                        objVendor.CustInt3 = Convert.ToInt32(dt_vendor.Rows[i]["CustInt3"].ToString());
                        objVendor.CustText1 = dt_vendor.Rows[i]["CustText1"].ToString();
                        objVendor.CustText2 = dt_vendor.Rows[i]["CustText2"].ToString();
                        objVendor.CustText3 = dt_vendor.Rows[i]["CustText3"].ToString();
                        objVendor.InsertVendor_MasterData();

                        Disconnect = false;

                    }
                    else
                    {
                        objVendor.VendorID = dt_vendor.Rows[i]["VendorID"].ToString();
                        objVendor.Name1 = dt_vendor.Rows[i]["Name1"].ToString();
                        objVendor.Name2 = dt_vendor.Rows[i]["Name2"].ToString();
                        objVendor.Address1 = dt_vendor.Rows[i]["Address1"].ToString();
                        objVendor.Address2 = dt_vendor.Rows[i]["Address2"].ToString();
                        objVendor.Address3 = dt_vendor.Rows[i]["Address3"].ToString();
                        objVendor.POBox = dt_vendor.Rows[i]["POBox"].ToString();
                        objVendor.Contact = dt_vendor.Rows[i]["Contact"].ToString();
                        objVendor.Phone = dt_vendor.Rows[i]["Phone"].ToString();
                        objVendor.Fax = dt_vendor.Rows[i]["Fax"].ToString();
                        objVendor.Email = dt_vendor.Rows[i]["Email"].ToString();
                        objVendor.City = dt_vendor.Rows[i]["City"].ToString();
                        objVendor.Region = dt_vendor.Rows[i]["Region"].ToString();
                        objVendor.Country = dt_vendor.Rows[i]["Country"].ToString();
                        objVendor.UpdateVendor_MasterData();

                        Disconnect = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteSalesArchive()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteSalesArchive();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteSalesArchive : " + ex.Message);
            }
        }
        public void DeleteSalesDetailArchive()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteSalesDetailArchive();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteSalesDetailArchive : " + ex.Message);
            }
        }
        public void DeleteTenderDetailArchive()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteTenderDetailArchive();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteTenderDetailArchive : " + ex.Message);
            }
        }
        public void DeleteSalesRawData()
        {
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                objClient.DeleteSalesRawData();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("DeleteSalesRawData : " + ex.Message);
            }
        }


        #region "Zreport"

        public void ZReportMethod()
        {
            try
            {
                SalesCategory();
                SalesDeleteLineitem();
                SalesUnHold();
                SalesUserTender_Detail();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("ZreportMethod : " + ex.StackTrace);
            }
        }

        public void SalesCategory()
        {
            try
            {
                DataTable dtSalesCategory = ZReport.GetSalesCategory();

                if (dtSalesCategory.Rows.Count > 0)
                {
                    ZReport.LocationId = LocationID;
                    ZReport.TerminalId = SysTerminalID;
                    ZReport.CompanyId = CompanyID;
                    for (int i = 0; i < dtSalesCategory.Rows.Count; i++)
                    {
                        ZReport.DocumentId = dtSalesCategory.Rows[i]["Documentid"].ToString();
                        ZReport.CategoryName = dtSalesCategory.Rows[i]["Categoryname"].ToString();
                        ZReport.UserName = dtSalesCategory.Rows[i]["UserName"].ToString();
                        ZReport.Amount = dtSalesCategory.Rows[i]["Amount"].ToString();
                        ZReport.Date = dtSalesCategory.Rows[i]["DocumentDate"].ToString();

                        ZReport.InsertSalesCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("SalesCategory : " + ex.StackTrace);
            }
        }

        public void SalesDeleteLineitem()
        {
            try
            {
                DataTable dtSalesDeleteLineItem = ZReport.GetDeleteLineItem();

                if (dtSalesDeleteLineItem.Rows.Count > 0)
                {
                    ZReport.LocationId = LocationID;
                    ZReport.TerminalId = SysTerminalID;
                    ZReport.CompanyId = CompanyID;
                    for (int i = 0; i < dtSalesDeleteLineItem.Rows.Count; i++)
                    {
                        ZReport.DocumentId = dtSalesDeleteLineItem.Rows[i]["DocumentId"].ToString();
                        ZReport.CategoryId = dtSalesDeleteLineItem.Rows[i]["CategoryId"].ToString();
                        ZReport.Amount = dtSalesDeleteLineItem.Rows[i]["Amount"].ToString();
                        ZReport.UOM = dtSalesDeleteLineItem.Rows[i]["UOM"].ToString();
                        ZReport.MaterialId = dtSalesDeleteLineItem.Rows[i]["MaterialId"].ToString();
                        ZReport.UserName = dtSalesDeleteLineItem.Rows[i]["UserId"].ToString();
                        ZReport.AddDate = dtSalesDeleteLineItem.Rows[i]["AddDate"].ToString();
                        ZReport.Date = DateTime.Now.ToString();

                        ZReport.InsertSalesDeleteLineItem();
                    }
                }

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("SalesDeleteLineItem : " + ex.StackTrace);
            }
        }

        public void SalesUnHold()
        {
            try
            {
                DataTable dtSalesUnHold = ZReport.GetUnHold();

                if (dtSalesUnHold.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSalesUnHold.Rows.Count; i++)
                    {
                        ZReport.DocumentId = dtSalesUnHold.Rows[i]["DocumentId"].ToString();
                        ZReport.SalesOrder = dtSalesUnHold.Rows[i]["SalesOrder"].ToString();
                        ZReport.CompanyId = dtSalesUnHold.Rows[i]["CompanyId"].ToString();
                        ZReport.LocationId = dtSalesUnHold.Rows[i]["LocationId"].ToString();
                        ZReport.StorageId = dtSalesUnHold.Rows[i]["StorageId"].ToString();
                        ZReport.TerminalId = dtSalesUnHold.Rows[i]["TerminalId"].ToString();
                        ZReport.Date = dtSalesUnHold.Rows[i]["DocumentDate"].ToString();
                        ZReport.PostingType = dtSalesUnHold.Rows[i]["PostingType"].ToString();
                        ZReport.CusmoterId = dtSalesUnHold.Rows[i]["CustomerId"].ToString();
                        ZReport.Counter = dtSalesUnHold.Rows[i]["Counter"].ToString();
                        ZReport.CategoryId = dtSalesUnHold.Rows[i]["CategoryId"].ToString();
                        ZReport.MaterialId = dtSalesUnHold.Rows[i]["MaterialId"].ToString();
                        ZReport.UOM = dtSalesUnHold.Rows[i]["UOM"].ToString();
                        ZReport.TranQty = dtSalesUnHold.Rows[i]["TranQty"].ToString();
                        ZReport.BaseQty = dtSalesUnHold.Rows[i]["BaseQty"].ToString();
                        ZReport.CreditQty = dtSalesUnHold.Rows[i]["CreditQty"].ToString();
                        ZReport.Cost = dtSalesUnHold.Rows[i]["Cost"].ToString();
                        ZReport.Price = dtSalesUnHold.Rows[i]["Price"].ToString();
                        ZReport.DiscountRate = dtSalesUnHold.Rows[i]["DiscountRate"].ToString();
                        ZReport.Amount = dtSalesUnHold.Rows[i]["Amount"].ToString();
                        ZReport.CreditAmount = dtSalesUnHold.Rows[i]["CreditAmount"].ToString();
                        ZReport.UserName = dtSalesUnHold.Rows[i]["UserId"].ToString();
                        ZReport.PostKey = dtSalesUnHold.Rows[i]["PostKey"].ToString();
                        ZReport.AddDate = dtSalesUnHold.Rows[i]["AddDate"].ToString();
                        ZReport.UppDate = dtSalesUnHold.Rows[i]["UpdDate"].ToString();

                        ZReport.InsertsalesUnHold();

                    }
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("SalesUnHold : " + ex.StackTrace);
            }
        }

        public void SalesUserTender_Detail()
        {
            try
            {
                DataTable dtSalesTendrdtls = ZReport.GetUserTender_Detail();

                if (dtSalesTendrdtls.Rows.Count > 0)
                {
                    ZReport.LocationId = LocationID;
                    ZReport.CompanyId = CompanyID;
                    for (int i = 0; i < dtSalesTendrdtls.Rows.Count; i++)
                    {
                        ZReport.DocumentId = dtSalesTendrdtls.Rows[i]["DocumentId"].ToString();
                        ZReport.UserName = dtSalesTendrdtls.Rows[i]["UserName"].ToString();
                        ZReport.TerminalId = dtSalesTendrdtls.Rows[i]["TenderType"].ToString();
                        ZReport.Amount = dtSalesTendrdtls.Rows[i]["Amount"].ToString();
                        ZReport.Date = dtSalesTendrdtls.Rows[i]["DocumentDate"].ToString();
                        ZReport.Counter = dtSalesTendrdtls.Rows[i]["Counter"].ToString();
                        ZReport.ChangeAmount = dtSalesTendrdtls.Rows[i]["ChangeAmount"].ToString();
                        ZReport.PaidAmount = dtSalesTendrdtls.Rows[i]["PaidAmount"].ToString();

                        ZReport.InsertSalesUserTender_Detail();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("SalesTenderdtls : " + ex.StackTrace);
            }
        }


        public void ZreportDeleteMethod()
        {
            try
            {
                ZReport.DeleteSalesCategory();
                ZReport.DeleteSalesDeleteLineItem();
                ZReport.DeleteUnhold();
                ZReport.DeleteTender_Detail();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Delete Zreport : " + ex.StackTrace);
            }

        }


        #endregion

        #region "Order"

        public DataTable GetOrderDetails()
        {
            DataTable dtorderdtls = null;
            try
            {
                objClient.Dcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                dtorderdtls = objClient.LoadOrderDtls();
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("Get InvoicwDtls : " + ex.Message + ex.StackTrace);
            }
            return dtorderdtls;

        }

        public void InsertOrderDetails()
        {
            try
            {
                objInvcDtls.Datacon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                DataTable dt_orderdtls = GetOrderDetails();

                for (int i = 0; i < dt_orderdtls.Rows.Count; i++)
                {
                    objInvcDtls.DocumentID = dt_orderdtls.Rows[i]["Documentid"].ToString();
                    objInvcDtls.LocationID = dt_orderdtls.Rows[i]["LocationId"].ToString();
                    objInvcDtls.StorageID = dt_orderdtls.Rows[i]["StorageId"].ToString();
                    objInvcDtls.TerminalID = dt_orderdtls.Rows[i]["TerminalId"].ToString();
                    objInvcDtls.Counter = Convert.ToInt32(dt_orderdtls.Rows[i]["Counter"].ToString());
                    objInvcDtls.SalesOrder = dt_orderdtls.Rows[i]["SalesOrder"].ToString();
                    objInvcDtls.CompanyID = dt_orderdtls.Rows[i]["CompanyID"].ToString();
                    //  objInvcDtls.PostingDate =Convert.ToDateTime( dt_invcdtls.Rows[i]["PostingDate"].ToString());
                    objInvcDtls.DocumentDate = Convert.ToDateTime(dt_orderdtls.Rows[i]["DocumentDate"].ToString());
                    objInvcDtls.PostingType = dt_orderdtls.Rows[i]["PostingType"].ToString();
                    objInvcDtls.CustomerID = dt_orderdtls.Rows[i]["CustomerID"].ToString();
                    objInvcDtls.CategoryID = dt_orderdtls.Rows[i]["CategoryID"].ToString();
                    objInvcDtls.MaterialID = dt_orderdtls.Rows[i]["MaterialID"].ToString();
                    objInvcDtls.UOM = dt_orderdtls.Rows[i]["UOM"].ToString();
                    objInvcDtls.TranQty = Convert.ToDecimal(dt_orderdtls.Rows[i]["TranQty"].ToString());
                    objInvcDtls.BaseQty = Convert.ToDecimal(dt_orderdtls.Rows[i]["BaseQty"].ToString());
                    objInvcDtls.CreditQty = Convert.ToDecimal(dt_orderdtls.Rows[i]["CreditQty"].ToString());
                    objInvcDtls.Cost = Convert.ToDecimal(dt_orderdtls.Rows[i]["Cost"].ToString());
                    objInvcDtls.Price = Convert.ToDecimal(dt_orderdtls.Rows[i]["Price"].ToString());
                    objInvcDtls.DiscountRate = Convert.ToDecimal(dt_orderdtls.Rows[i]["DiscountRate"].ToString());
                    objInvcDtls.Amount = Convert.ToDecimal(dt_orderdtls.Rows[i]["Amount"].ToString());
                    objInvcDtls.CreditAmount = Convert.ToDecimal(dt_orderdtls.Rows[i]["CreditAmount"].ToString());
                    objInvcDtls.UserID = dt_orderdtls.Rows[i]["UserId"].ToString();
                    objInvcDtls.PostKey = Convert.ToInt32(dt_orderdtls.Rows[i]["PostKey"].ToString());
                    objInvcDtls.AddDate = Convert.ToDateTime(dt_orderdtls.Rows[i]["AddDate"].ToString());
                    objInvcDtls.UpdDate = Convert.ToDateTime(dt_orderdtls.Rows[i]["UpdDate"].ToString());
                    objInvcDtls.PostingDate = Convert.ToDateTime(dt_orderdtls.Rows[i]["PostingDate"].ToString());

                    objInvcDtls.Datacon = ConfigurationManager.ConnectionStrings["ConnectionStringSvr"].ConnectionString;

                    objInvcDtls.InsertInvoiceDtls();
                }

                Disconnect = false;

            }
            catch (Exception ex)
            {
                Disconnect = true;

                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("InsertInvoiceDtls : " + ex.Message);
            }
        }

        #endregion

        #region "Tranfter To Display Time to time"

        public DataTable GetLocalInsert()
        {
            DataTable dtGetWebInsert = null;
            try
            {
                TransfterToDisplayTimeToTime.LocationID = LocationID;
                dtGetWebInsert = TransfterToDisplayTimeToTime.GetWeb();
                if (dtGetWebInsert.Rows.Count > 0)
                {
                    for (int i = 0; i < dtGetWebInsert.Rows.Count; i++)
                    {
                        TransfterToDisplayTimeToTime.ID = dtGetWebInsert.Rows[i]["ID"].ToString();
                        TransfterToDisplayTimeToTime.LocationID = dtGetWebInsert.Rows[i]["LocationID"].ToString();
                        TransfterToDisplayTimeToTime.CrateDate = dtGetWebInsert.Rows[i]["CreateDate"].ToString();
                        TransfterToDisplayTimeToTime.Warning1 = dtGetWebInsert.Rows[i]["Warning1"].ToString();
                        TransfterToDisplayTimeToTime.Warning2 = dtGetWebInsert.Rows[i]["Warning2"].ToString();
                        TransfterToDisplayTimeToTime.Warning3 = dtGetWebInsert.Rows[i]["Warning3"].ToString();
                        TransfterToDisplayTimeToTime.Warning1Status = dtGetWebInsert.Rows[i]["Warning1Status"].ToString();
                        TransfterToDisplayTimeToTime.Warning2Status = dtGetWebInsert.Rows[i]["Warning2Status"].ToString();
                        TransfterToDisplayTimeToTime.Warning3Status = dtGetWebInsert.Rows[i]["Warning3Status"].ToString();
                        TransfterToDisplayTimeToTime.TDDocumentID = dtGetWebInsert.Rows[i]["TDDocumentID"].ToString();
                        TransfterToDisplayTimeToTime.UserID = dtGetWebInsert.Rows[i]["UserID"].ToString();
                        TransfterToDisplayTimeToTime.CreatedDate = dtGetWebInsert.Rows[i]["CreatedDate"].ToString();
                        TransfterToDisplayTimeToTime.WLDbStatus = dtGetWebInsert.Rows[i]["WLDbStatus"].ToString();
                        TransfterToDisplayTimeToTime.LDbStatus = dtGetWebInsert.Rows[i]["LDbStatus"].ToString();
                        TransfterToDisplayTimeToTime.TDDocumentIDStatus = dtGetWebInsert.Rows[i]["TDDocumentIDStatus"].ToString();
                        TransfterToDisplayTimeToTime.LocalInsert();
                    }
                }
                //web to local insert methoe
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("GetLocalInsert : " + ex.Message + ex.StackTrace);
            }
            return dtGetWebInsert;
        }

        public DataTable GetLocalCheck()
        {
            DataTable dtGetLocalCheck = null;
            try
            {
                //Check Methoed

                dtGetLocalCheck = TransfterToDisplayTimeToTime.GetLocal();
                if (dtGetLocalCheck.Rows.Count > 0)
                {
                    DateTime CreateDate = Convert.ToDateTime(dtGetLocalCheck.Rows[0]["CreateDate"].ToString());
                    DateTime CurrentDate = DateTime.Now;

                    if (dtGetLocalCheck.Rows[0]["Warning1Status"].ToString() == "False")
                    {
                        TimeSpan Warning1 = TimeSpan.Parse(dtGetLocalCheck.Rows[0]["Warning1"].ToString());
                        DateTime ErrorTime = CreateDate - Warning1;

                        if (CurrentDate >= ErrorTime)
                        {
                            MessageBox.Show("Please Create Tranfter To Display", "Warning1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //update warning1 status
                            TransfterToDisplayTimeToTime.GetLocalUpdate("Warning1Status");
                        }

                    }
                    else
                        if (dtGetLocalCheck.Rows[0]["Warning2Status"].ToString() == "False")
                    {
                        TimeSpan Warning2 = TimeSpan.Parse(dtGetLocalCheck.Rows[0]["Warning2"].ToString());
                        DateTime ErrorTime = CreateDate - Warning2;

                        if (CurrentDate >= ErrorTime)
                        {

                            MessageBox.Show("Please Create Tranfter To Display", "Warning2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //update warning2 status
                            TransfterToDisplayTimeToTime.GetLocalUpdate("Warning2Status");
                        }

                    }
                    else if (dtGetLocalCheck.Rows[0]["Warning3Status"].ToString() == "False")
                    {
                        TimeSpan Warning3 = TimeSpan.Parse(dtGetLocalCheck.Rows[0]["Warning3"].ToString());
                        DateTime ErrorTime = CreateDate - Warning3;

                        if (CurrentDate >= ErrorTime)
                        {
                            MessageBox.Show("Please Create Tranfter To Display", "Warning3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //update warning3 status
                            TransfterToDisplayTimeToTime.GetLocalUpdate("Warning3Status");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("GetLocalCheck : " + ex.Message + ex.StackTrace);
            }
            return dtGetLocalCheck;
        }
        //2min update status
        public DataTable UpdateWeb()
        {
            DataTable dtUpdate = null;
            try
            {
                dtUpdate = TransfterToDisplayTimeToTime.GetLocalforWeb();
                if (dtUpdate.Rows.Count > 0)
                {
                    for (int i = 0; i < dtUpdate.Rows.Count; i++)
                    {
                        TransfterToDisplayTimeToTime.ID = dtUpdate.Rows[i]["ID"].ToString();
                        TransfterToDisplayTimeToTime.Warning1Status = dtUpdate.Rows[i]["Warning1Status"].ToString();
                        TransfterToDisplayTimeToTime.Warning2Status = dtUpdate.Rows[i]["Warning2Status"].ToString();
                        TransfterToDisplayTimeToTime.Warning3Status = dtUpdate.Rows[i]["Warning3Status"].ToString();
                        TransfterToDisplayTimeToTime.TDDocumentID = dtUpdate.Rows[i]["TDDocumentID"].ToString();
                        TransfterToDisplayTimeToTime.UserID = dtUpdate.Rows[i]["UserID"].ToString();
                        TransfterToDisplayTimeToTime.CreatedDate = dtUpdate.Rows[i]["CreatedDate"].ToString();
                        TransfterToDisplayTimeToTime.WLDbStatus = dtUpdate.Rows[i]["WLDbStatus"].ToString();
                        TransfterToDisplayTimeToTime.LDbStatus = dtUpdate.Rows[i]["LDbStatus"].ToString();
                        TransfterToDisplayTimeToTime.TDDocumentIDStatus = dtUpdate.Rows[i]["TDDocumentIDStatus"].ToString();
                        TransfterToDisplayTimeToTime.UpdateWeb();
                    }
                }

            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("POSErrorLog"))
                {
                    EventLog.CreateEventSource("EasyPos", "POSErrorLog");
                }

                EventLog myLog = new EventLog();
                myLog.Source = "Pync Error";

                myLog.WriteEntry("UpdateWeb : " + ex.Message + ex.StackTrace);
            }
            return dtUpdate;
        }

        #endregion

        #region "all Mater Tables"

        public void AllMaterDataSync()
        {
            try
            {
                //System.Threading.Thread.Sleep(5000);

                FileInfo fileinfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");
                if (fileinfo.Exists)
                {
                    DataSet dsmasterdata = new DataSet();
                    dsmasterdata.ReadXml(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");
                    DataTable dtmaster = new DataTable();
                    dtmaster = dsmasterdata.Tables[0];

                    dtFirst = dtmaster.Clone();
                    foreach (DataRow item in dtmaster.Rows)
                    {
                        dtFirst.Rows.Add(item.ItemArray);
                    }

                    if (dtmaster.Rows.Count > 0)
                    {
                        if (dtmaster.Rows[0][0].ToString() == "Completed")
                        {

                        }
                        else
                        {
                            LocalCateogry();
                            LocalCity();
                            LocalCompany();
                            LocalCurrency();
                            LocalCustomter();
                            LocalLocation();
                            LocalLocationPrice();
                            LocalMaterial();
                            LocalMaterialEAN();
                            LocalMaterialKit();
                            LocalPreferUOM();
                            LocalPriceFile();
                            LocalStorage();
                            LocalSubCategory();
                            LocalTender();
                            LocalTerminal();
                            LocalUOM();
                            LocalVendor();
                            LocalBOM();
                            LocalCustType();
                            LocalCountry();
                            LocalRegion();
                            LocalPhoneCode();

                            TableName = "Completed";
                            AllMasterCount = 0M;
                            RunningCount = 0M;
                            updatetworows();
                        }

                    }
                }
              else
                {
                    DataColumn dc_tableName = new DataColumn("TableName");
                    DataColumn dc_allmatercount = new DataColumn("AllMaterCount");
                    DataColumn dc_runningcount = new DataColumn("RunningCount");

                    dtFirst.Columns.Add(dc_tableName);
                    dtFirst.Columns.Add(dc_allmatercount);
                    dtFirst.Columns.Add(dc_runningcount);

                    DataRow drrow = dtFirst.NewRow();
                    drrow[0] = "Emtpy";
                    drrow[1] = "0";
                    drrow[2] = "0";

                    dtFirst.Rows.Add(drrow);
                    dtFirst.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "AllMaterData.xml");


                    LocalCateogry();
                    LocalCity();
                    LocalCompany();
                    LocalCurrency();
                    LocalCustomter();
                    LocalLocation();
                    LocalLocationPrice();
                    LocalMaterial();
                    LocalMaterialEAN();
                    LocalMaterialKit();
                    LocalPreferUOM();
                    LocalPriceFile();
                    LocalStorage();
                    LocalSubCategory();
                    LocalTender();
                    LocalTerminal();
                    LocalUOM();
                    LocalVendor();
                    LocalBOM();
                    LocalCountry();
                    LocalRegion();
                    LocalCustType();
                    LocalCountry();
                    LocalRegion();
                    LocalPhoneCode();


                    TableName = "Completed";
                    AllMasterCount = 0M;
                    RunningCount = 0M;
                    updatetworows();
                }

            }
            catch (Exception ex)
            {

            }
        }
     
        public void LocalCateogry()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalCateogry();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCategory();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Category";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.CategoryID = dtserver.Rows[i]["CategoryID"].ToString();
                            AllMaterTable.CategoryDesc = dtserver.Rows[i]["CategoryDesc"].ToString();
                            AllMaterTable.InsertLocalCateogry();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCategory()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCategory();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalCity()
        {

            try
            {
                DataTable dtlocal = AllMaterTable.LocalCity();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCity();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "City";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.CityID = dtserver.Rows[i]["CityID"].ToString();
                            AllMaterTable.CityName = dtserver.Rows[i]["CityName"].ToString();
                            AllMaterTable.InsertLocalCity();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCity()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCity();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public DataTable ServerPhoneCode()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerPhoneCode();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public void LocalCompany()
        {

            try
            {
                DataTable dtlocal = AllMaterTable.LocalCompany();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCompany();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Company";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.CompanyID = dtserver.Rows[i]["CompanyID"].ToString();
                            AllMaterTable.LongName = dtserver.Rows[i]["LongName"].ToString();
                            AllMaterTable.ShortName = dtserver.Rows[i]["ShortName"].ToString();
                            AllMaterTable.Address1 = dtserver.Rows[i]["Address1"].ToString();
                            AllMaterTable.Address2 = dtserver.Rows[i]["Address2"].ToString();
                            AllMaterTable.Address3 = dtserver.Rows[i]["Address3"].ToString();
                            AllMaterTable.POBox = dtserver.Rows[i]["POBox"].ToString();
                            AllMaterTable.Contact = dtserver.Rows[i]["Contact"].ToString();
                            AllMaterTable.Phone = dtserver.Rows[i]["Phone"].ToString();
                            AllMaterTable.Fax = dtserver.Rows[i]["Fax"].ToString();
                            AllMaterTable.Email = dtserver.Rows[i]["Email"].ToString();
                            AllMaterTable.City = dtserver.Rows[i]["City"].ToString();
                            AllMaterTable.Region = dtserver.Rows[i]["Region"].ToString();
                            AllMaterTable.Country = dtserver.Rows[i]["Country"].ToString();
                            AllMaterTable.DefaultCurrency = dtserver.Rows[i]["DefaultCurrency"].ToString();
                            AllMaterTable.InsertLocalCompany();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCompany()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCompany();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public void LocalCountry()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalCountry();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCountry();

                    if (dtserver.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.CountryID = dtserver.Rows[i]["CountryID"].ToString();
                            AllMaterTable.CountryName = dtserver.Rows[i]["CountryName"].ToString();
                            AllMaterTable.InsertLocationCountry();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCountry()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCountry();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public void LocalCurrency()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalCurrency();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCurrency();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Currency";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.CurrencyID = dtserver.Rows[i]["CurrencyID"].ToString();
                            AllMaterTable.CurrencyName = dtserver.Rows[i]["CurrencyName"].ToString();
                            AllMaterTable.CurrRate = dtserver.Rows[i]["CurrRate"].ToString();
                            AllMaterTable.InsertLocalCurrency();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCurrency()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCurrency();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalCustomter()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalCustomter();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCusomter();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Customer";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {

                            AllMaterTable.CustomerID = dtserver.Rows[i]["CustomerID"].ToString();
                            AllMaterTable.Name1 = dtserver.Rows[i]["Name1"].ToString();
                            AllMaterTable.Name2 = dtserver.Rows[i]["Name2"].ToString();
                            AllMaterTable.Address1 = dtserver.Rows[i]["Address1"].ToString();
                            AllMaterTable.Address2 = dtserver.Rows[i]["Address2"].ToString();
                            AllMaterTable.Address3 = dtserver.Rows[i]["Address3"].ToString();
                            AllMaterTable.POBox = dtserver.Rows[i]["POBox"].ToString();
                            AllMaterTable.Phone = dtserver.Rows[i]["Phone"].ToString();
                            AllMaterTable.Fax = dtserver.Rows[i]["Fax"].ToString();
                            AllMaterTable.Email = dtserver.Rows[i]["Email"].ToString();
                            AllMaterTable.City = dtserver.Rows[i]["City"].ToString();
                            AllMaterTable.Region = dtserver.Rows[i]["Region"].ToString();
                            AllMaterTable.Country = dtserver.Rows[i]["Country"].ToString();
                            AllMaterTable.CreditLimit = Convert.ToDecimal(dtserver.Rows[i]["CreditLimit"].ToString());
                            AllMaterTable.CustInt1 = dtserver.Rows[i]["CustInt1"].ToString();
                            AllMaterTable.CustInt2 = dtserver.Rows[i]["CustInt2"].ToString();
                            AllMaterTable.CustInt3 = dtserver.Rows[i]["CustInt3"].ToString();
                            AllMaterTable.CustText1 = dtserver.Rows[i]["CustText1"].ToString();
                            AllMaterTable.CustText2 = dtserver.Rows[i]["CustText2"].ToString();
                            AllMaterTable.CustText3 = dtserver.Rows[i]["CustText3"].ToString();
                            AllMaterTable.CustType = dtserver.Rows[i]["CustType"].ToString();
                            AllMaterTable.TotalDue = dtserver.Rows[i]["TotalDue"].ToString();
                            AllMaterTable.Password= dtserver.Rows[i]["Password"].ToString();
                            AllMaterTable.Gender = dtserver.Rows[i]["Gender"].ToString();
                            AllMaterTable.DateOfBirth = dtserver.Rows[i]["DateOfBirth"].ToString();
                            AllMaterTable.InsertLocalCustomter();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCusomter()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCusomter();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public void LocalLocation()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalLocation();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerLocation();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Location";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {

                            AllMaterTable.LocationID = dtserver.Rows[i]["LocationID"].ToString();
                            AllMaterTable.LocationDesc = dtserver.Rows[i]["LocationDesc"].ToString();
                            AllMaterTable.Address1 = dtserver.Rows[i]["Address1"].ToString();
                            AllMaterTable.Address2 = dtserver.Rows[i]["Address2"].ToString();
                            AllMaterTable.Address3 = dtserver.Rows[i]["Address3"].ToString();
                            AllMaterTable.POBox = dtserver.Rows[i]["POBox"].ToString();
                            AllMaterTable.Contact = dtserver.Rows[i]["Contact"].ToString();
                            AllMaterTable.Phone = dtserver.Rows[i]["Phone"].ToString();
                            AllMaterTable.Fax = dtserver.Rows[i]["Fax"].ToString();
                            AllMaterTable.Email = dtserver.Rows[i]["Email"].ToString();
                            AllMaterTable.City = dtserver.Rows[i]["City"].ToString();
                            AllMaterTable.Region = dtserver.Rows[i]["Region"].ToString();
                            AllMaterTable.Country = dtserver.Rows[i]["Country"].ToString();
                            AllMaterTable.CostCenter = dtserver.Rows[i]["CostCenter"].ToString();
                            AllMaterTable.BusinessArea = dtserver.Rows[i]["BusinessArea"].ToString();
                            AllMaterTable.FieldArea = dtserver.Rows[i]["FieldArea"].ToString();
                            AllMaterTable.CashLoan = dtserver.Rows[i]["CashLoan"].ToString();
                            AllMaterTable.CustInt1 = dtserver.Rows[i]["CustInt1"].ToString();
                            AllMaterTable.CustInt2 = dtserver.Rows[i]["CustInt2"].ToString();
                            AllMaterTable.CustInt3 = dtserver.Rows[i]["CustInt3"].ToString();
                            AllMaterTable.CustText1 = dtserver.Rows[i]["CustText1"].ToString();
                            AllMaterTable.CustText2 = dtserver.Rows[i]["CustText2"].ToString();
                            AllMaterTable.CustText3 = dtserver.Rows[i]["CustText3"].ToString();
                            AllMaterTable.InsertLocalLocation();
                            RunningCount = i;
                            updatetworows();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerLocation()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerLocation();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalLocationPrice()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalLocationPrice();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerLocationPrice();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Location Price";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {

                            AllMaterTable.LocationID = dtserver.Rows[i]["LocationID"].ToString();
                            AllMaterTable.EAN13 = dtserver.Rows[i]["EAN13"].ToString();
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.Price = dtserver.Rows[i]["Price"].ToString();
                            AllMaterTable.CustType= dtserver.Rows[i]["CustType"].ToString();
                            AllMaterTable.LocalLInsertocationPrice();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerLocationPrice()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerLocationPrice();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalMaterial()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalMaterial();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerMaterial();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Material";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.MaterialDesc1 = dtserver.Rows[i]["MaterialDesc1"].ToString();
                            AllMaterTable.MaterialDesc2 = dtserver.Rows[i]["MaterialDesc2"].ToString();
                            AllMaterTable.MaterialDesc3 = dtserver.Rows[i]["MaterialDesc3"].ToString();
                            AllMaterTable.ProductURL = dtserver.Rows[i]["ProductURL"].ToString();
                            AllMaterTable.CategoryID = dtserver.Rows[i]["CategoryID"].ToString();
                            AllMaterTable.SubCategoryID = dtserver.Rows[i]["SubCategoryID"].ToString();
                            AllMaterTable.BaseUOM = dtserver.Rows[i]["BaseUOM"].ToString();
                            AllMaterTable.Cost = dtserver.Rows[i]["Cost"].ToString();
                            AllMaterTable.VendorID = dtserver.Rows[i]["VendorID"].ToString();
                            AllMaterTable.CustInt1 = dtserver.Rows[i]["CustInt1"].ToString();
                            AllMaterTable.CustInt2 = dtserver.Rows[i]["CustInt2"].ToString();
                            AllMaterTable.CustInt3 = dtserver.Rows[i]["CustInt3"].ToString();
                            AllMaterTable.CustDate1 = dtserver.Rows[i]["CustDate1"].ToString();
                            AllMaterTable.CustDate2 = dtserver.Rows[i]["CustDate2"].ToString();
                            AllMaterTable.CustDate3 = dtserver.Rows[i]["CustDate3"].ToString();
                            AllMaterTable.CustText1 = dtserver.Rows[i]["CustText1"].ToString();
                            AllMaterTable.CustText2 = dtserver.Rows[i]["CustText2"].ToString();
                            AllMaterTable.CustText3 = dtserver.Rows[i]["CustText3"].ToString();
                            AllMaterTable.UserID = dtserver.Rows[i]["UserID"].ToString();
                            AllMaterTable.AddDate = dtserver.Rows[i]["AddDate"].ToString();
                            AllMaterTable.UpdDate = dtserver.Rows[i]["UpdDate"].ToString();
                            AllMaterTable.Dataid = dtserver.Rows[i]["Dataid"].ToString();
                            AllMaterTable.Sales_Comm = dtserver.Rows[i]["Sales_Comm"].ToString();
                            AllMaterTable.Produc_Comm = dtserver.Rows[i]["Produc_Comm"].ToString();
                            AllMaterTable.InsertLocalMaterial();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerMaterial()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerMaterial();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalMaterialEAN()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalMaterialEAN();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerMaterialEAN();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "MaterialEAN";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.EAN13 = dtserver.Rows[i]["EAN13"].ToString();
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.ConvertValue = dtserver.Rows[i]["ConvertValue"].ToString();
                            AllMaterTable.BaseUOM = dtserver.Rows[i]["BaseUOM"].ToString();
                            AllMaterTable.MaterialMix = dtserver.Rows[i]["MaterialMix"].ToString();
                            AllMaterTable.InsertLocalMaterialEAN();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerMaterialEAN()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerMaterialEAN();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalMaterialKit()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalMaterialKit();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerMatterialKit();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "MaterialKit";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.KitID = dtserver.Rows[i]["KitID"].ToString();
                            AllMaterTable.KitDescription = dtserver.Rows[i]["KitDescription"].ToString();
                            AllMaterTable.MaterialLess = dtserver.Rows[i]["MaterialLess"].ToString();
                            AllMaterTable.UOMLess = dtserver.Rows[i]["UOMLess"].ToString();
                            AllMaterTable.QuantityLess = dtserver.Rows[i]["QuantityLess"].ToString();
                            AllMaterTable.MaterialAdd = dtserver.Rows[i]["MaterialAdd"].ToString();
                            AllMaterTable.UOMAdd = dtserver.Rows[i]["UOMAdd"].ToString();
                            AllMaterTable.QuantityAdd = dtserver.Rows[i]["QuantityAdd"].ToString();
                            AllMaterTable.InsertLocalMaterialKit();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerMatterialKit()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerMatterialKit();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalPreferUOM()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalPreferUOM();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerPreferUOM();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "PreferUOM";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.EAN13 = dtserver.Rows[i]["EAN13"].ToString();
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.TerminalID = dtserver.Rows[i]["TerminalID"].ToString();
                            AllMaterTable.InsertLocalPreferUOM();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerPreferUOM()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerPreferUOM();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalPriceFile()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalPriceFile();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerPriceFile();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "PriceFile";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.EAN13 = dtserver.Rows[i]["EAN13"].ToString();
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.Price = dtserver.Rows[i]["Price"].ToString();
                            AllMaterTable.CustType= dtserver.Rows[i]["CustType"].ToString();
                            AllMaterTable.InsertLocalPriceFile();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerPriceFile()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerPriceFile();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalRegion()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalRegion();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerRegion();

                    if (dtserver.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.RegionID = dtserver.Rows[i]["RegionID"].ToString();
                            AllMaterTable.RegionName = dtserver.Rows[i]["RegionName"].ToString();
                            AllMaterTable.InsertLocationRegion();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerRegion()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerRegion();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalCustType()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalCustType();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerCustType();

                    if (dtserver.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.ID = dtserver.Rows[i]["ID"].ToString();
                            AllMaterTable.CustType = dtserver.Rows[i]["CustType"].ToString();
                            AllMaterTable.InsertLocationCustType();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerCustType()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerCustType();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalStorage()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalStorage();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerStorage();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Storage";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.StorageID = dtserver.Rows[i]["StorageID"].ToString();
                            AllMaterTable.StorageName = dtserver.Rows[i]["StorageName"].ToString();
                            AllMaterTable.StorageType = dtserver.Rows[i]["StorageType"].ToString();
                            AllMaterTable.LocationID = dtserver.Rows[i]["LocationID"].ToString();
                            AllMaterTable.InsertLocalStorage();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerStorage()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerStorage();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalSubCategory()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalSubCategory();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerSubCategory();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Sub Category";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.SubCategoryID = dtserver.Rows[i]["SubCategoryID"].ToString();
                            AllMaterTable.SubCategoryDesc = dtserver.Rows[i]["SubCategoryDesc"].ToString();
                            AllMaterTable.CategoryID = dtserver.Rows[i]["CategoryID"].ToString();
                            AllMaterTable.InsertLocalSubCategory();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerSubCategory()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerSubCategory();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalTender()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalTender();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerTender();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Tender";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.TenderID = dtserver.Rows[i]["TenderID"].ToString();
                            AllMaterTable.TenderName = dtserver.Rows[i]["TenderName"].ToString();
                            AllMaterTable.GL_Debit = dtserver.Rows[i]["GL_Debit"].ToString();
                            AllMaterTable.GL_Credit = dtserver.Rows[i]["GL_Credit"].ToString();
                            AllMaterTable.InsertLocalTender();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerTender()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerTender();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalTerminal()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalTerminal();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerTerminal();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Terminal";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.TerminalID = dtserver.Rows[i]["TerminalID"].ToString();
                            AllMaterTable.LocationID = dtserver.Rows[i]["LocationID"].ToString();
                            AllMaterTable.InsertLocalTerminal();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerTerminal()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerTerminal();
            }
            catch (Exception ex)
            {

            }
            return dtserver;

        }

        public void LocalUOM()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalUOM();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerUOM();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "UOM";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.UOMDesc = dtserver.Rows[i]["UOMDesc"].ToString();
                            AllMaterTable.InsertLocalUOM();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerUOM()
        {
            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerUOM();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalVendor()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalVendor();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerVendor();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Vendor";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.VendorID = dtserver.Rows[i]["VendorID"].ToString();
                            AllMaterTable.Name1 = dtserver.Rows[i]["Name1"].ToString();
                            AllMaterTable.Name2 = dtserver.Rows[i]["Name2"].ToString();
                            AllMaterTable.Address1 = dtserver.Rows[i]["Address1"].ToString();
                            AllMaterTable.Address2 = dtserver.Rows[i]["Address2"].ToString();
                            AllMaterTable.Address3 = dtserver.Rows[i]["Address3"].ToString();
                            AllMaterTable.POBox = dtserver.Rows[i]["POBox"].ToString();
                            AllMaterTable.Contact = dtserver.Rows[i]["Contact"].ToString();
                            AllMaterTable.Phone = dtserver.Rows[i]["Phone"].ToString();
                            AllMaterTable.Fax = dtserver.Rows[i]["Fax"].ToString();
                            AllMaterTable.Email = dtserver.Rows[i]["Email"].ToString();
                            AllMaterTable.City = dtserver.Rows[i]["City"].ToString();
                            AllMaterTable.Region = dtserver.Rows[i]["Region"].ToString();
                            AllMaterTable.Country = dtserver.Rows[i]["Country"].ToString();
                            AllMaterTable.CustInt1 = dtserver.Rows[i]["CustInt1"].ToString();
                            AllMaterTable.CustInt2 = dtserver.Rows[i]["CustInt2"].ToString();
                            AllMaterTable.CustInt3 = dtserver.Rows[i]["CustInt3"].ToString();
                            AllMaterTable.CustText1 = dtserver.Rows[i]["CustText1"].ToString();
                            AllMaterTable.CustText2 = dtserver.Rows[i]["CustText2"].ToString();
                            AllMaterTable.CustText3 = dtserver.Rows[i]["CustText3"].ToString();
                            AllMaterTable.InsertLocalVendor();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerVendor()
        {

            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerVendor();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalBOM()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalBOM();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerBOM();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "BOM";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                          AllMaterTable.BOMID=  dtserver.Rows[i]["BOMID"].ToString();
                            AllMaterTable.MaterialID = dtserver.Rows[i]["MaterialID"].ToString();
                            AllMaterTable.UOM = dtserver.Rows[i]["UOM"].ToString();
                            AllMaterTable.BOMQty = dtserver.Rows[i]["BOMQty"].ToString();
                            AllMaterTable.InsertLocalBOM();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerBOM()
        {

            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerBOM();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void LocalConnectionString()
        {
            try
            {
                DataTable dtlocal = AllMaterTable.LocalConnectionString();

                if (dtlocal.Rows.Count > 0 || dtlocal.Rows.Count ==0)
                {
                    DataTable dtserver = ServerConnectionString();

                    if (dtserver.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.Id =Convert.ToInt32(dtserver.Rows[i]["Id"].ToString());
                            AllMaterTable.ConnectionStringName= dtserver.Rows[i]["ConnectionStringName"].ToString();
                            AllMaterTable.ServerIP = dtserver.Rows[i]["ServerIP"].ToString();
                            AllMaterTable.ServerUserName = dtserver.Rows[i]["ServerUserName"].ToString();
                            AllMaterTable.ServerPassword = dtserver.Rows[i]["ServerPassword"].ToString();
                            AllMaterTable.ServerDataBaseName = dtserver.Rows[i]["ServerDataBaseName"].ToString();
                            AllMaterTable.Security = dtserver.Rows[i]["Security"].ToString();
                            AllMaterTable.DominName = dtserver.Rows[i]["DominName"].ToString();
                            AllMaterTable.InsertLocalConnectionString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        public DataTable ServerConnectionString()
        {

            DataTable dtserver = null;
            try
            {
                dtserver = AllMaterTable.ServerConnectionString();
            }
            catch (Exception ex)
            {

            }
            return dtserver;
        }

        public void updatetworows()
        {
            try
            {
                FileInfo fileinfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");

                if (fileinfo.Exists)
                {
                    //update

                    dtFirst.Rows[0][0] = TableName;
                    dtFirst.Rows[0][1] = AllMasterCount;
                    dtFirst.Rows[0][2] = RunningCount;

                    dtFirst.WriteXml(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");

                }
                else
                {
                    //create and update
                    dtFirst.WriteXml(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");

                    dtFirst.Rows[0][0] = TableName;
                    dtFirst.Rows[0][1] = AllMasterCount;
                    dtFirst.Rows[0][2] = RunningCount;

                    dtFirst.WriteXml(AppDomain.CurrentDomain.BaseDirectory+ "AllMaterData.xml");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LocalPhoneCode()
        {

            try
            {
                DataTable dtlocal = AllMaterTable.LocalPhoneCode();

                if (dtlocal.Rows.Count == 0)
                {
                    DataTable dtserver = ServerPhoneCode();

                    if (dtserver.Rows.Count > 0)
                    {
                        TableName = "Phone Code";
                        AllMasterCount = dtserver.Rows.Count;
                        updatetworows();
                        for (int i = 0; i < dtserver.Rows.Count; i++)
                        {
                            AllMaterTable.PhoneCode = dtserver.Rows[i]["PhoneCode"].ToString();
                            AllMaterTable.PhoneDigit = dtserver.Rows[i]["PhoneDigits"].ToString();
                            AllMaterTable.PhoneDescription = dtserver.Rows[i]["PhoneDescription"].ToString();
                            AllMaterTable.InsertLocalPhoneCode();
                            RunningCount = i;
                            updatetworows();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion
    }
}