using BombayToolsDataLayer.Master;
using Newtonsoft.Json;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO = BombayToolsEntities.BusinessEntities;
using POBL = BombayToolBusinessLayer.ExportInvoice;
using BombayTools.Filters;
using SelectPdf;
using System.Data;
using BombayToolsEntities.BusinessEntities;

namespace BombayTools.Controllers.ExportInvoice
{
    [UserAuthenticationFilter]
    public class ExportInvoiceController : Controller
    {
        // GET: ExportInvoice

        POBL.ExportInvoiceBusinessLayer DataProvider = new POBL.ExportInvoiceBusinessLayer();

        string ip = System.Web.HttpContext.Current.Request.Url.Authority;

        public ActionResult ExportInvoiceSummary()
        {
            return View();
        }
        
        public JsonResult GetExportInvoiceSummary(BO.ExportInvoiceM data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.ExportInvoiceM> list = new List<BO.ExportInvoiceM>();
            list = DataProvider.GetExportInvoiceSummary(data1, UserID);
            return Json(list);
        }

        public ActionResult _AddOrEditExportInvoice(string EXINO)
        {
            
            List<BO.CustomerM> CustomerList = DataProvider.GetCustomerMasterList();
            ViewBag.ddlCustomerDropdown = new SelectList(CustomerList, "CustomerID", "CustomerName");

            List<BO.DeliveryInfo> DeliveryAddress = DataProvider.GetDeliveryAddressList();
            ViewBag.ddlDeliveryAddress = new SelectList(DeliveryAddress, "DeliveryAddressID", "DeliveryAddress");
            ViewBag.CustomerArr = JsonConvert.SerializeObject(CustomerList);

            List<BO.PurchaseOrderD> ChrgesList = new List<BO.PurchaseOrderD>();
            ChrgesList = DataProvider.GetChrgesList(EXINO);
            ViewBag.ChrgesList = new SelectList(ChrgesList, "ChargeID", "ChargeName");

            List<BO.CurrencyCodeInfo> currency = DataProvider.GetCurrencyList();
            ViewBag.CurrencyDropdown = new SelectList(currency, "ID", "CurrencyCode");

            List<BO.ModeOfShipment> modeList = DataProvider.GetModeOfShipment();
            ViewBag.ModeList = new SelectList(modeList, "ModeID", "ModeName");

            List<BO.ModeOfShipment> PODList = DataProvider.GetPODList();
            ViewBag.PODList = new SelectList(PODList, "PODID", "PODName");

            List<BO.ModeOfShipment> TermList = DataProvider.GetShipMentTermList();
            ViewBag.TermList = new SelectList(TermList, "TermID", "Term");

            List<BO.ModeOfShipment> ExportHeadingList = DataProvider.GetExportHeadingList();
            ViewBag.ExportHeadingList = JsonConvert.SerializeObject(ExportHeadingList);
            ViewBag.ExportHeadingList = new SelectList(ExportHeadingList, "HeadingID", "Heading");

            List<BO.IndentInfo> ProjectList = DataProvider.GetProjectList();
            ViewBag.ProjectDropdown = new SelectList(ProjectList, "ProjectID", "ProjectName");

            BO.ExportInvoiceM data = new BO.ExportInvoiceM();
            if (EXINO != "0")
            {
                data = DataProvider.GetExportInvoiceDetail(EXINO);
                ViewBag.EXINO = data.EXINO;
                ViewBag.PONO = data.PONO;
                ViewBag.LCNO = data.LCNO;
                ViewBag.EXIType = data.EXIType;
                ViewBag.EXIDate = data.EXIDate;
                ViewBag.PODate = data.PODate;
                ViewBag.LCDate = data.LCDate;
                ViewBag.ddlCustomerID = data.CustomerID;
                ViewBag.NetTotal = data.NetTotal;
                ViewBag.ExchangeRate = data.ExchangeRate;
                ViewBag.ddlCurrencyDropdown = data.CurrencyID;
                ViewBag.BillingLocationID = data.BillingLocationID;
                ViewBag.ShippingLocationID = data.ShippingLocationID;
                ViewBag.RevisionNo = data.RevisionNo;
                ViewBag.BillToLocation = data.BillToLocation;
                ViewBag.BillToAddress = data.BillToAddress;
                ViewBag.ShipToLocation = data.ShipToLocation;
                ViewBag.ShipToAddress = data.ShipToAddress;
                ViewBag.PreCarriageBy = data.PreCarriageBy;
                ViewBag.PlaceOfReceipt = data.PlaceOfReceipt;
                ViewBag.VesselNo = data.VesselNo;
                ViewBag.ContainerNo = data.ContainerNo;
                ViewBag.ModeOfShipment = data.ModeOfShipment;
                ViewBag.ShipmentTermID = data.ShipmentTermID;
                ViewBag.PODID = data.PODID;
                ViewBag.StatusID = data.StatusID;
                ViewBag.LicenseID = data.LicenseID;
                ViewBag.Remarks = data.Remarks;
                ViewBag.Others = data.Others;
                ViewBag.PortOfLoading = data.PortOfLoading;
                ViewBag.CountryOfOrigin = data.CountryOfOrigin;
                ViewBag.ExportBenefit = data.ExportBenefit;
                ViewBag.SealNo = data.SealNo;
                ViewBag.CustRefNo = data.CustRefNo;
                ViewBag.FinalDestination = data.FinalDestination;

                ViewBag.POD = JsonConvert.SerializeObject(data.POItem);
                ViewBag.POCharges = JsonConvert.SerializeObject(data.POCharges);
                ViewBag.POPaymentTerm = JsonConvert.SerializeObject(data.POPaymentTerm);
                ViewBag.POPacking = JsonConvert.SerializeObject(data.POPacking);

            }
            else
            {
                ViewBag.NetTotal = "-";
                ViewBag.IndentNo = "";
                ViewBag.FinalTotal = "-";
                ViewBag.POD = "-";
                ViewBag.POC = "-";
                ViewBag.BillingLocationID = 0;
                ViewBag.ShippingLocationID = 0;
                ViewBag.BillToID = 0;
                ViewBag.BillToLocation = "";
                ViewBag.BillToAddress = "";
                ViewBag.ShipToID = 0;
                ViewBag.ShipToLocation = "";
                ViewBag.ShipToAddress = "";
            }
            ViewBag.EXINO = EXINO;

            ViewBag.IsCopy = 0;

            List<BO.PurchaseOrderConditions> POTermAndConditionListArray = new List<BO.PurchaseOrderConditions>();
            POTermAndConditionListArray = DataProvider.GetTermAndConditionsList();
            ViewBag.POTermAndConditionListArray = JsonConvert.SerializeObject(POTermAndConditionListArray);

            return PartialView();
        }

        public ActionResult _ViewExportInvoice(string EXINO)
        {
            //List<BO.Category> CategoryList = new List<BO.Category>();
            //CategoryList = IBDataProvider.GetCategoryList();
            //ViewBag.ddlCategoryDropdown = new SelectList(CategoryList, "CategoryID", "CategoryName");

            List<BO.CustomerM> CustomerList = DataProvider.GetCustomerMasterList();
            ViewBag.ddlCustomerDropdown = new SelectList(CustomerList, "CustomerID", "CustomerName");

            List<BO.DeliveryInfo> DeliveryAddress = DataProvider.GetDeliveryAddressList();
            ViewBag.ddlDeliveryAddress = new SelectList(DeliveryAddress, "DeliveryAddressID", "DeliveryAddress");
            ViewBag.CustomerArr = JsonConvert.SerializeObject(CustomerList);

            //List<BO.SupplierBillM> gstList = new List<BO.SupplierBillM>();
            //gstList = SBBussinesManager.GetGstList();
            //ViewBag.GstDropdown = JsonConvert.SerializeObject(gstList);
            //ViewBag.ddlGstDropdown = new SelectList(gstList, "GSTID", "GSTPercent");

            //List<BO.PurchaseOrderD> ChrgesList = new List<BO.PurchaseOrderD>();
            //ChrgesList = DataProvider.GetChrgesList();
            //ViewBag.ChrgesDropdown = JsonConvert.SerializeObject(ChrgesList);

            //List<BO.IndentInfo> ProjectList = DataProvider.GetProjectList();
            //ViewBag.ProjectDropdown = new SelectList(ProjectList, "ProjectID", "ProjectName");
            //ViewBag.ProjectListM = JsonConvert.SerializeObject(ViewBag.ProjectDropdown);

            //List<BO.IndentInfo> ItemGroupList = DataProvider.GetItemGroupList();
            //ViewBag.ItemGroupList = new SelectList(ItemGroupList, "ItemGroup_ID", "ItemGroup_Name");

            List<BO.CurrencyCodeInfo> currency = DataProvider.GetCurrencyList();
            ViewBag.CurrencyDropdown = new SelectList(currency, "ID", "CurrencyCode");

            List<BO.ModeOfShipment> modeList = DataProvider.GetModeOfShipment();
            ViewBag.ModeList = new SelectList(modeList, "ModeID", "ModeName");

            //List<BO.ModeOfShipment> StausList = DataProvider.GetGSTStatusList();
            //ViewBag.StatusList = new SelectList(StausList, "StausID", "StatusName");

            //List<BO.ModeOfShipment> LicenseList = DataProvider.GetLicenseNoList();
            //ViewBag.LicenseList = new SelectList(LicenseList, "LicenseID", "LicenseNo");

            List<BO.ModeOfShipment> PODList = DataProvider.GetPODList();
            ViewBag.PODList = new SelectList(PODList, "PODID", "PODName");

            List<BO.ModeOfShipment> TermList = DataProvider.GetShipMentTermList();
            ViewBag.TermList = new SelectList(TermList, "TermID", "Term");

            //List<BO.ModeOfShipment> ExportHeadingList = DataProvider.GetExportHeadingList();
            //ViewBag.ExportHeadingList = JsonConvert.SerializeObject(ExportHeadingList);
            //ViewBag.ExportHeadingList = new SelectList(ExportHeadingList, "HeadingID", "Heading");

            List<BO.IndentInfo> CategoryListM = DataProvider.GetCategoryMasterList();
            ViewBag.CategoryListM = new SelectList(CategoryListM, "SubCategoryID", "SubCategoryName");
            ViewBag.CategoryListM = JsonConvert.SerializeObject(ViewBag.CategoryListM);

            List<BO.IndentInfo> CategoryList2M = DataProvider.GetSubCategoryMasterList();
            ViewBag.CategoryList2M = new SelectList(CategoryList2M, "SubCategoryID", "SubCategoryName");
            ViewBag.CategoryList2M = JsonConvert.SerializeObject(ViewBag.CategoryList2M);

            BO.ExportInvoiceM data = new BO.ExportInvoiceM();
            if (EXINO != "0")
            {
                data = DataProvider.GetExportInvoiceDetail(EXINO);
                ViewBag.EXINO = data.EXINO;
                ViewBag.PONO = data.PONO;
                ViewBag.LCNO = data.LCNO;
                ViewBag.EXIType = data.EXIType;
                ViewBag.EXIDate = data.EXIDate;
                ViewBag.PODate = data.PODate;
                ViewBag.LCDate = data.LCDate;
                ViewBag.ddlCustomerID = data.CustomerID;
                ViewBag.NetTotal = data.NetTotal;
                ViewBag.ExchangeRate = data.ExchangeRate;
                ViewBag.ddlCurrencyDropdown = data.CurrencyID;
                ViewBag.BillingLocationID = data.BillingLocationID;
                ViewBag.ShippingLocationID = data.ShippingLocationID;
                ViewBag.RevisionNo = data.RevisionNo;
                ViewBag.BillToLocation = data.BillToLocation;
                ViewBag.BillToAddress = data.BillToAddress;
                ViewBag.ShipToLocation = data.ShipToLocation;
                ViewBag.ShipToAddress = data.ShipToAddress;
                ViewBag.PreCarriageBy = data.PreCarriageBy;
                ViewBag.PlaceOfReceipt = data.PlaceOfReceipt;
                ViewBag.VesselNo = data.VesselNo;
                ViewBag.ContainerNo = data.ContainerNo;
                ViewBag.ModeOfShipment = data.ModeOfShipment;
                ViewBag.ShipmentTermID = data.ShipmentTermID;
                ViewBag.PODID = data.PODID;
                ViewBag.StatusID = data.StatusID;
                ViewBag.LicenseID = data.LicenseID;
                ViewBag.Remarks = data.Remarks;
                ViewBag.Others = data.Others;
                ViewBag.PortOfLoading = data.PortOfLoading;
                ViewBag.CountryOfOrigin = data.CountryOfOrigin;
                ViewBag.ExportBenefit = data.ExportBenefit;
                ViewBag.SealNo = data.SealNo;
                ViewBag.CustRefNo = data.CustRefNo;
                ViewBag.FinalDestination = data.FinalDestination;

                ViewBag.POD = JsonConvert.SerializeObject(data.POItem);
                ViewBag.POCharges = JsonConvert.SerializeObject(data.POCharges);
                ViewBag.POPaymentTerm = JsonConvert.SerializeObject(data.POPaymentTerm);
                ViewBag.POPacking = JsonConvert.SerializeObject(data.POPacking);

            }
            else
            {
                ViewBag.NetTotal = "-";
                ViewBag.IndentNo = "";
                ViewBag.FinalTotal = "-";
                ViewBag.POD = "-";
                ViewBag.POC = "-";
                ViewBag.BillingLocationID = 0;
                ViewBag.ShippingLocationID = 0;
                ViewBag.BillToID = 0;
                ViewBag.BillToLocation = "";
                ViewBag.BillToAddress = "";
                ViewBag.ShipToID = 0;
                ViewBag.ShipToLocation = "";
                ViewBag.ShipToAddress = "";
            }
            ViewBag.EXINO = EXINO;

            ViewBag.IsCopy = 0;

            List<BO.PurchaseOrderConditions> POTermAndConditionListArray = new List<BO.PurchaseOrderConditions>();
            POTermAndConditionListArray = DataProvider.GetTermAndConditionsList();
            ViewBag.POTermAndConditionListArray = JsonConvert.SerializeObject(POTermAndConditionListArray);

            //List<BO.PurchaseOrderPaymentTerm> POPaymentTermListArray = new List<BO.PurchaseOrderPaymentTerm>();
            //POPaymentTermListArray = DataProvider.GetPaymentTermList();
            //ViewBag.POPaymentTermList = new SelectList(POPaymentTermListArray, "PaymentTermID", "PaymentTerm");
            //ViewBag.POPaymentTermListArray = JsonConvert.SerializeObject(POPaymentTermListArray);

            //List<BO.PurchaseOrderConditions> POTermAndConditionListArray = new List<BO.PurchaseOrderConditions>();
            //POTermAndConditionListArray = DataProvider.GetTermAndConditionsList();
            //ViewBag.POTermAndConditionListArray = JsonConvert.SerializeObject(POTermAndConditionListArray);

            return PartialView();
        }

        public JsonResult AjaxAddOrEditExportInvoice(BO.ExportInvoiceM POM, List<BO.ExportInvoiceD> POD, List<BO.PurchaseOrderPaymentTerm> PaymentTermList,
            List<BO.ExportInvoiceCharges> ChargeList, List<BO.ExportInvoicePacking> PackingList)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                POM.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();

                DataTable dataTable = new DataTable();
                if (POD != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("GLNO");
                    dataTable.Columns.Add("ItemDesc");
                    dataTable.Columns.Add("Project_Name");
                    //dataTable.Columns.Add("HeadingID");
                    dataTable.Columns.Add("Unit");
                    dataTable.Columns.Add("SaleUnit");
                    dataTable.Columns.Add("Qty");
                    dataTable.Columns.Add("SQM");
                    dataTable.Columns.Add("SQFT");
                    dataTable.Columns.Add("Rate");
                    dataTable.Columns.Add("NetTotal");
                    dataTable.Columns.Add("NoOfCase");
                    dataTable.Columns.Add("HSNCode");
                    dataTable.Columns.Add("ContainerNo");
                    dataTable.Columns.Add("NetWeight");
                    dataTable.Columns.Add("GrossWeight");
                    dataTable.Columns.Add("DCNO");
                    dataTable.Columns.Add("PINO");
                    dataTable.Columns.Add("WONO");
                    dataTable.Columns.Add("SpecID");

                    dataTable.TableName = "PT_EXIItemList";
                    foreach (BO.ExportInvoiceD item in POD)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["GLNO"] = item.GLNO;
                        row["ItemDesc"] = item.ItemDescription;
                        row["Project_Name"] = item.Project_Name;
                        //row["HeadingID"] = item.HeadingID;
                        row["Unit"] = item.Unit;
                        row["SaleUnit"] = item.SaleUnit;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["SQFT"] = item.SQFT;
                        row["Rate"] = item.Rate;
                        row["NetTotal"] = item.NetTotal;
                        row["NoOfCase"] = item.NoOfCase;
                        row["HSNCode"] = item.HSNCode;
                        row["ContainerNo"] = item.ContainerNo;
                        row["NetWeight"] = item.NetWeight;
                        row["GrossWeight"] = item.GrossWeight;
                        row["DCNO"] = item.DCNO;
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["SpecID"] = item.SpecID;

                        dataTable.Rows.Add(row);
                    }
                }

                //Charges List
                DataTable dataTableF2 = new DataTable();
                if (ChargeList != null)
                {
                    dataTableF2.Columns.Add("ChargeID");
                    dataTableF2.Columns.Add("ChargeName");
                    dataTableF2.Columns.Add("ChargeAmount");
                    dataTableF2.TableName = "PT_EXIChargeList";
                    foreach (BO.ExportInvoiceCharges item in ChargeList)
                    {
                        DataRow row = dataTableF2.NewRow();
                        row["ChargeID"] = item.ChargeID;
                        row["ChargeName"] = item.ChargeName;
                        row["ChargeAmount"] = item.ChargeAmount;
                        dataTableF2.Rows.Add(row);
                    }
                }
                //End Charges List

                //Start payment term
                DataTable dataTableP3 = new DataTable();
                if (PaymentTermList != null)
                {
                    dataTableP3.Columns.Add("PaymentTermID");
                    dataTableP3.TableName = "PT_POPaymentTerm";
                    foreach (BO.PurchaseOrderPaymentTerm item in PaymentTermList)
                    {
                        DataRow row = dataTableP3.NewRow();
                        row["PaymentTermID"] = item.PaymentTermID;
                        dataTableP3.Rows.Add(row);
                    }
                }
                /// END Payment term

                // Start packing list
                DataTable dataTable4 = new DataTable();

                dataTable4.Columns.Add("SrNo");
                dataTable4.Columns.Add("ContainerNo");
                dataTable4.Columns.Add("PackingMarks");
                dataTable4.Columns.Add("PackageName");
                dataTable4.Columns.Add("NoOfPackages");
                dataTable4.Columns.Add("TotalPackages");
                dataTable4.Columns.Add("NetWeight");
                dataTable4.Columns.Add("GrossWeight");

                dataTable4.TableName = "PT_EXIPackingList";
                foreach (BO.ExportInvoicePacking item in PackingList)
                {
                    DataRow row = dataTable4.NewRow();
                    row["SrNo"] = item.SrNo;
                    row["ContainerNo"] = item.ContainerNo;
                    row["PackingMarks"] = item.PackingMarks;
                    row["PackageName"] = item.PackageName;
                    row["NoOfPackages"] = item.NoOfPackages;
                    row["TotalPackages"] = item.TotalPackages;
                    row["NetWeight"] = item.NetWeight;
                    row["GrossWeight"] = item.GrossWeight;

                    dataTable4.Rows.Add(row);
                }
                // END Packing List
                message = DataProvider.AddOrEditExportInvoice(POM, AddedBy, dataTable, dataTableF2, dataTableP3, dataTable4);
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult _AddOrEditPackingList(string EXINO)
        //{
        //    List<BO.Category> CategoryList = new List<BO.Category>();
        //    CategoryList = IBDataProvider.GetCategoryList();
        //    ViewBag.ddlCategoryDropdown = new SelectList(CategoryList, "CategoryID", "CategoryName");

        //    List<BO.CustomerM> CustomerList = DataProvider.GetCustomerMasterList();
        //    ViewBag.ddlCustomerDropdown = new SelectList(CustomerList, "CustomerID", "CustomerName");

        //    List<BO.DeliveryInfo> DeliveryAddress = DataProvider.GetDeliveryAddressList();
        //    ViewBag.ddlDeliveryAddress = new SelectList(DeliveryAddress, "DeliveryAddressID", "DeliveryAddress");
        //    ViewBag.CustomerArr = JsonConvert.SerializeObject(CustomerList);

        //    List<BO.SupplierBillM> gstList = new List<BO.SupplierBillM>();
        //    gstList = SBBussinesManager.GetGstList();
        //    ViewBag.GstDropdown = JsonConvert.SerializeObject(gstList);
        //    ViewBag.ddlGstDropdown = new SelectList(gstList, "GSTID", "GSTPercent");

        //    //List<BO.PurchaseOrderD> ChrgesList = new List<BO.PurchaseOrderD>();
        //    //ChrgesList = DataProvider.GetChrgesList();
        //    //ViewBag.ChrgesDropdown = JsonConvert.SerializeObject(ChrgesList);

        //    List<BO.IndentInfo> ProjectList = DataProvider.GetProjectList();
        //    ViewBag.ProjectDropdown = new SelectList(ProjectList, "ProjectID", "ProjectName");
        //    ViewBag.ProjectListM = JsonConvert.SerializeObject(ViewBag.ProjectDropdown);

        //    List<BO.IndentInfo> ItemGroupList = DataProvider.GetItemGroupList();
        //    ViewBag.ItemGroupList = new SelectList(ItemGroupList, "ItemGroup_ID", "ItemGroup_Name");

        //    List<BO.CurrencyCodeInfo> currency = DataProvider.GetCurrencyList();
        //    ViewBag.CurrencyDropdown = new SelectList(currency, "ID", "CurrencyCode");

        //    List<BO.ModeOfShipment> modeList = DataProvider.GetModeOfShipment();
        //    ViewBag.ModeList = new SelectList(modeList, "ModeID", "ModeName");

        //    List<BO.ModeOfShipment> StausList = DataProvider.GetGSTStatusList();
        //    ViewBag.StatusList = new SelectList(StausList, "StausID", "StatusName");

        //    List<BO.ModeOfShipment> LicenseList = DataProvider.GetLicenseNoList();
        //    ViewBag.LicenseList = new SelectList(LicenseList, "LicenseID", "LicenseNo");

        //    List<BO.ModeOfShipment> PODList = DataProvider.GetPODList();
        //    ViewBag.PODList = new SelectList(PODList, "PODID", "PODName");

        //    List<BO.ModeOfShipment> TermList = DataProvider.GetShipMentTermList();
        //    ViewBag.TermList = new SelectList(TermList, "TermID", "Term");

        //    List<BO.ModeOfShipment> ExportHeadingList = DataProvider.GetExportHeadingList();
        //    ViewBag.ExportHeadingList = JsonConvert.SerializeObject(ExportHeadingList);
        //    //ViewBag.ExportHeadingList = new SelectList(ExportHeadingList, "HeadingID", "Heading");

        //    List<BO.IndentInfo> CategoryListM = DataProvider.GetCategoryMasterList();
        //    ViewBag.CategoryListM = new SelectList(CategoryListM, "SubCategoryID", "SubCategoryName");
        //    ViewBag.CategoryListM = JsonConvert.SerializeObject(ViewBag.CategoryListM);

        //    List<BO.IndentInfo> CategoryList2M = DataProvider.GetSubCategoryMasterList();
        //    ViewBag.CategoryList2M = new SelectList(CategoryList2M, "SubCategoryID", "SubCategoryName");
        //    ViewBag.CategoryList2M = JsonConvert.SerializeObject(ViewBag.CategoryList2M);

        //    BO.ExportInvoiceM data = new BO.ExportInvoiceM();
        //    if (EXINO != "0")
        //    {
        //        data = DataProvider.GetExportInvoiceDetail(EXINO);
        //        ViewBag.EXINO = data.EXINO;
        //        ViewBag.PONO = data.PONO;
        //        ViewBag.LCNO = data.LCNO;
        //        ViewBag.EXIType = data.EXIType;
        //        ViewBag.EXIDate = data.EXIDate;
        //        ViewBag.PODate = data.PODate;
        //        ViewBag.LCDate = data.LCDate;
        //        ViewBag.ddlCustomerID = data.CustomerID;
        //        ViewBag.NetTotal = data.NetTotal;
        //        ViewBag.ExchangeRate = data.ExchangeRate;
        //        ViewBag.ddlCurrencyDropdown = data.CurrencyID;
        //        ViewBag.BillingLocationID = data.BillingLocationID;
        //        ViewBag.ShippingLocationID = data.ShippingLocationID;
        //        ViewBag.RevisionNo = data.RevisionNo;
        //        ViewBag.BillToLocation = data.BillToLocation;
        //        ViewBag.BillToAddress = data.BillToAddress;
        //        ViewBag.ShipToLocation = data.ShipToLocation;
        //        ViewBag.ShipToAddress = data.ShipToAddress;
        //        ViewBag.PreCarriageBy = data.PreCarriageBy;
        //        ViewBag.PlaceOfReceipt = data.PlaceOfReceipt;
        //        ViewBag.VesselNo = data.VesselNo;
        //        ViewBag.ContainerNo = data.ContainerNo;
        //        ViewBag.ModeOfShipment = data.ModeOfShipment;
        //        ViewBag.ShipmentTermID = data.ShipmentTermID;
        //        ViewBag.PODID = data.PODID;
        //        ViewBag.StatusID = data.StatusID;
        //        ViewBag.LicenseID = data.LicenseID;
        //        ViewBag.Remarks = data.Remarks;
        //        ViewBag.Others = data.Others;
        //        ViewBag.ExportBenefit = data.ExportBenefit;

        //        ViewBag.POD = JsonConvert.SerializeObject(data.POItem);
        //        ViewBag.POCharges = JsonConvert.SerializeObject(data.POCharges);
        //        ViewBag.POPaymentTerm = JsonConvert.SerializeObject(data.POPaymentTerm);
        //        ViewBag.POPacking = JsonConvert.SerializeObject(data.POPacking);

        //    }
        //    else
        //    {
        //        ViewBag.NetTotal = "-";
        //        ViewBag.IndentNo = "";
        //        ViewBag.FinalTotal = "-";
        //        ViewBag.POD = "-";
        //        ViewBag.POC = "-";
        //        ViewBag.BillingLocationID = 0;
        //        ViewBag.ShippingLocationID = 0;
        //        ViewBag.BillToID = 0;
        //        ViewBag.BillToLocation = "";
        //        ViewBag.BillToAddress = "";
        //        ViewBag.ShipToID = 0;
        //        ViewBag.ShipToLocation = "";
        //        ViewBag.ShipToAddress = "";
        //    }
        //    ViewBag.EXINO = EXINO;

        //    ViewBag.IsCopy = 0;

        //    List<BO.PurchaseOrderPaymentTerm> POPaymentTermListArray = new List<BO.PurchaseOrderPaymentTerm>();
        //    POPaymentTermListArray = DataProvider.GetPaymentTermList();
        //    ViewBag.POPaymentTermList = new SelectList(POPaymentTermListArray, "PaymentTermID", "PaymentTerm");
        //    ViewBag.POPaymentTermListArray = JsonConvert.SerializeObject(POPaymentTermListArray);

        //    List<BO.PurchaseOrderConditions> POTermAndConditionListArray = new List<BO.PurchaseOrderConditions>();
        //    POTermAndConditionListArray = DataProvider.GetTermAndConditionsList();
        //    ViewBag.POTermAndConditionListArray = JsonConvert.SerializeObject(POTermAndConditionListArray);

        //    return PartialView();
        //}

        public ActionResult DirectApprovePO(string PONo)
        {
            int AddedBy = Convert.ToInt16(Session["userid"]);
            BO.ResponseMessage message = DataProvider.DirectApprovePO(PONo, AddedBy);
            return Json(message);
        }

        public ActionResult GetBillingAddress(int CustID)
        {
            DataTable dtIssueTositeList = new DataTable();
            int UserID = Convert.ToInt32(Session["Tracker_userID"]);
            dtIssueTositeList = DataProvider.GetBillingAddress(CustID);
            Session["GetIssueToSiteSummaryList"] = dtIssueTositeList;
            string json = JsonConvert.SerializeObject(dtIssueTositeList);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        public ActionResult GetShippingAddress(int CustID)
        {
            DataTable dtIssueTositeList = new DataTable();
            int UserID = Convert.ToInt32(Session["Tracker_userID"]);
            dtIssueTositeList = DataProvider.GetShippingAddress(CustID);
            Session["GetIssueToSiteSummaryList"] = dtIssueTositeList;
            string json = JsonConvert.SerializeObject(dtIssueTositeList);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        public PartialViewResult _PurchaseOrderDetail(string PONo)
        {
            BO.ExportInvoiceM data = new BO.ExportInvoiceM();
            data = DataProvider.GetExportInvoiceDetail(PONo);
            return PartialView(data);
        }

        //For Email Table
        public JsonResult POItemsDetails(string PONo)
        {
            List<BO.ItemList> detail = new List<BO.ItemList>();
            detail = DataProvider.POItemsDetails(PONo);
            var jsonResult = Json(detail, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return Json(detail);
        }
        //End For Email Table

        public JsonResult GetVendorDetails(int VendorID)
        {
            List<BO.VendorD> detail = new List<BO.VendorD>();
            detail = DataProvider.GetVendorDetails(VendorID);
            return Json(detail);
        }

        public JsonResult AjaxAddOrEditPackingList(BO.ExportInvoiceM POM, List<BO.ExportInvoiceD> POD, List<BO.PurchaseOrderPaymentTerm> PaymentTermList,
            List<BO.ExportInvoiceCharges> ChargeList, List<BO.ExportInvoicePacking> PackingList)
        {
            try
            {
                POM.AddedBy = Convert.ToInt16(Session["userid"]);
                POM.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("SrNo");
                dataTable.Columns.Add("ItemDesc");
                dataTable.Columns.Add("HeadingID");
                dataTable.Columns.Add("Unit");
                dataTable.Columns.Add("Qty");
                dataTable.Columns.Add("SQM");
                dataTable.Columns.Add("SQFT");
                dataTable.Columns.Add("Rate");
                dataTable.Columns.Add("NetTotal");
                dataTable.Columns.Add("NoOfCase");
                dataTable.Columns.Add("HSNCode");
                dataTable.Columns.Add("ContainerNo");
                dataTable.Columns.Add("NetWeight");
                dataTable.Columns.Add("GrossWeight");
                dataTable.Columns.Add("PINO");
                dataTable.Columns.Add("WONO");
                dataTable.Columns.Add("SpecID");

                dataTable.TableName = "PT_EXIItemList";
                foreach (BO.ExportInvoiceD item in POD)
                {
                    DataRow row = dataTable.NewRow();
                    row["SrNo"] = item.SrNo;
                    row["ItemDesc"] = item.ItemDescription;
                    row["HeadingID"] = item.HeadingID;
                    row["Unit"] = item.Unit;
                    row["Qty"] = item.Qty;
                    row["SQM"] = item.SQM;
                    row["SQFT"] = item.SQFT;
                    row["Rate"] = item.Rate;
                    row["NetTotal"] = item.NetTotal;
                    row["NoOfCase"] = item.NoOfCase;
                    row["HSNCode"] = item.HSNCode;
                    row["ContainerNo"] = item.ContainerNo;
                    row["NetWeight"] = item.NetWeight;
                    row["GrossWeight"] = item.GrossWeight;
                    row["PINO"] = item.PINO;
                    row["WONO"] = item.WONO;
                    row["SpecID"] = item.SpecID;

                    dataTable.Rows.Add(row);
                }

                //Charges List
                DataTable dataTableF2 = new DataTable();

                dataTableF2.Columns.Add("ChargeID");
                dataTableF2.Columns.Add("ChargeName");
                dataTableF2.Columns.Add("ChargeAmount");
                dataTableF2.TableName = "PT_EXIChargeList";
                foreach (BO.ExportInvoiceCharges item in ChargeList)
                {
                    DataRow row = dataTableF2.NewRow();
                    row["ChargeID"] = item.ChargeID;
                    row["ChargeName"] = item.ChargeName;
                    row["ChargeAmount"] = item.ChargeAmount;
                    dataTableF2.Rows.Add(row);
                }
                //End Charges List

                //Start payment term
                DataTable dataTableP3 = new DataTable();
                dataTableP3.Columns.Add("PaymentTermID");
                dataTableP3.TableName = "PT_POPaymentTerm";
                foreach (BO.PurchaseOrderPaymentTerm item in PaymentTermList)
                {
                    DataRow row = dataTableP3.NewRow();
                    row["PaymentTermID"] = item.PaymentTermID;
                    dataTableP3.Rows.Add(row);
                }
                ///end Payment term

                //Start packing list
                DataTable dataTable4 = new DataTable();

                dataTable4.Columns.Add("SrNo");
                dataTable4.Columns.Add("ContainerNo");
                dataTable4.Columns.Add("PackingMarks");
                dataTable4.Columns.Add("PackageName");
                dataTable4.Columns.Add("NoOfPackages");
                dataTable4.Columns.Add("TotalPackages");
                dataTable4.Columns.Add("NetWeight");
                dataTable4.Columns.Add("GrossWeight");

                dataTable4.TableName = "PT_EXIPackingList";
                foreach (BO.ExportInvoicePacking item in PackingList)
                {
                    DataRow row = dataTable4.NewRow();
                    row["SrNo"] = item.SrNo;
                    row["ContainerNo"] = item.ContainerNo;
                    row["PackingMarks"] = item.PackingMarks;
                    row["PackageName"] = item.PackageName;
                    row["NoOfPackages"] = item.NoOfPackages;
                    row["TotalPackages"] = item.TotalPackages;
                    row["NetWeight"] = item.NetWeight;
                    row["GrossWeight"] = item.GrossWeight;

                    dataTable4.Rows.Add(row);
                }
                //END Packing List

                message = DataProvider.AjaxAddOrEditPackingList(POM, dataTable, dataTableF2, dataTableP3, dataTable4);


                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ActionResult ClosePO(string PONo, string Reason)
        {
            int AddedBy = Convert.ToInt16(Session["userid"]);
            string message = DataProvider.ClosePO(PONo, Reason, AddedBy);
            return Json(message);
        }
        public ActionResult AjaxGetCancelPO(string PONo, string Reason)
        {
            int AddedBy = Convert.ToInt16(Session["userid"]);
            BO.ResponseMessage responce = DataProvider.AjaxGetCancelPO(PONo, Reason, AddedBy);
            return Json(responce);
        }

        /// developed new by prathamesh
        public ActionResult GetDNNOListAgainstCustomer(int CustomerID)
        {
            List<BO.PIMaster> OpenIndentList = new List<BO.PIMaster>();
            OpenIndentList = DataProvider.GetDNNOListAgainstCustomer(CustomerID);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult GetItemListAgainstPINo(string PINo)
        {
            List<BO.PIDetails> OpenIndentList = new List<BO.PIDetails>();
            OpenIndentList = DataProvider.GetItemListAgainstPINo(PINo);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult GetItemListAgainstDCNO(List<PIMaster> PIItemListSearch)
        {
            //List<BO.PIDetails> OpenIndentList = new List<BO.PIDetails>();
            BO.PIDetails OpenIndentList = new BO.PIDetails();
            
            DataTable dtWONO = new DataTable();
            dtWONO.Columns.Add("DCNO");
            //dtWONO.Columns.Add("WONO");
            //dtWONO.Columns.Add("SpecID");
            dtWONO.TableName = "PT_DCNOItemListForEXI";
            foreach (BO.PIMaster item in PIItemListSearch)
            {
                DataRow row = dtWONO.NewRow();
                row["DCNO"] = item.DCNO;
                //row["WONO"] = item.WONO;
                //row["SpecID"] = item.SpecID;
                dtWONO.Rows.Add(row);
            }

            OpenIndentList = DataProvider.GetItemListAgainstDCNO(dtWONO);
            var CurrencyID = OpenIndentList.CurrencyID;
            var ExchangeRate = OpenIndentList.ExchangeRate;
            List<BO.PIDetails> POBilling = OpenIndentList.POBilling;
            
            return Json(new
            {
                CurrencyID = CurrencyID,
                ExchangeRate = ExchangeRate,
                POBilling = POBilling
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateDCMasterFlagToZero(List<PIMaster> DelDCNOArray)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            ResponseMessage response = new ResponseMessage();
            try
            {
                List<BO.PIDetails> OpenIndentList = new List<BO.PIDetails>();
                DataTable dtWONO = new DataTable();
                if (DelDCNOArray != null) { 
                    dtWONO.Columns.Add("DCNO");
                //dtWONO.Columns.Add("WONO");
                //dtWONO.Columns.Add("SpecID");
                dtWONO.TableName = "PT_DCNOItemListForEXI";
                foreach (BO.PIMaster item in DelDCNOArray)
                {
                    DataRow row = dtWONO.NewRow();
                    row["DCNO"] = item.DCNO;
                    //row["WONO"] = item.WONO;
                    //row["SpecID"] = item.SpecID;
                    dtWONO.Rows.Add(row);
                }
            }
                response = DataProvider.updateDCMasterFlagToZero(dtWONO, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(response);
        }


        //Last Purchase History
        public ActionResult ViewLastPurchaseHistoryCO(int ItemID, int IsLastMonth)
        {
            List<BO.ItemList> OpenIndentList = new List<BO.ItemList>();
            OpenIndentList = DataProvider.ViewLastPurchaseHistoryCO(ItemID, IsLastMonth);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult ViewLastPurchaseHistoryRM(int ItemID, int IsLastMonth)
        {
            List<BO.ItemList> OpenIndentList = new List<BO.ItemList>();
            OpenIndentList = DataProvider.ViewLastPurchaseHistoryRM(ItemID, IsLastMonth);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        //End Last Purchase History
        public ActionResult POApprovalView(string PONO)
        {
            ViewBag.PONO = PONO;
            return PartialView();
        }

        public ActionResult POApproval(BO.PurchaseOrderM data)
        {
            data.ApprovedBy = Convert.ToInt16(Session["userid"]);
            string message = DataProvider.POApproval(data);
            return Json(message);
        }

        public JsonResult GetPurchaseStatus()
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPurchaseStatus();
            return Json(list);
        }

        public ActionResult PendingPurchaseOrderSummary()
        {

            return View();
        }
        [HttpGet]
        public JsonResult GetPendingPurchaseOrderSummary()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingPurchaseOrderSummary();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPendingCOPOList()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingCOPOList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPendingRMPOList()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingRMPOList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPendingPurchaseOrderForAppr()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingPurchaseOrderForAppr();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPendingCOPOForAppr()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingCOPOForAppr();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPendingRMPOForAppr()
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.GetPendingRMPOForAppr();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCurrentCOStockValueList()
        {
            List<BO.PurchaseOrderD> list = new List<BO.PurchaseOrderD>();
            list = DataProvider.GetCurrentCOStockValueList();

            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetCurrentRMStockValueList()
        {
            List<BO.PurchaseOrderD> list = new List<BO.PurchaseOrderD>();
            list = DataProvider.GetCurrentRMStockValueList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ViewPoDetail(string PONO)
        {
            List<BO.PurchaseOrderM> list = new List<BO.PurchaseOrderM>();
            list = DataProvider.ViewPoDetail(PONO);
            return Json(list);
        }

        [HttpPost]
        public ActionResult GetApprovalMailDetails(string IndentNo)
        {

            ViewBag.DocName = IndentNo + ".pdf";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("RunningID");
            dataTable.Columns.Add("SrNo");
            dataTable.Columns.Add("DocFileName");
            dataTable.Columns.Add("FilePath");
            dataTable.Columns.Add("ContentType");

            DataRow row = dataTable.NewRow();
            row["RunningID"] = 1;
            row["SrNo"] = 1;
            row["DocFileName"] = IndentNo + ".pdf";
            row["FilePath"] = Server.MapPath("~/PurchaseOrderPDF/" + IndentNo + "/" + ViewBag.DocName);
            row["ContentType"] = "application/pdf";
            dataTable.Rows.Add(row);

            ViewBag.QuotationPDFList = JsonConvert.SerializeObject(dataTable);

            var returnField = new { QuotationPDFList = ViewBag.QuotationPDFList };
            var jsonResult = Json(returnField, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public ActionResult StoreFileDataInTemp(string DocName, string Filepath, string ContentType)
        {
            TempData["DocName"] = DocName;
            TempData["Filepath"] = Filepath;
            TempData["ContentType"] = ContentType;
            int i = 1;
            return Json(i);

        }
        [HttpPost]
        public FileResult DownLoadFile(int id)
        {
            string DocName = Convert.ToString(TempData["DocName"]);
            string Filepath = Convert.ToString(TempData["Filepath"]);
            string ContentType = Convert.ToString(TempData["ContentType"]);

            byte[] fileBytes = System.IO.File.ReadAllBytes(Filepath);

            return File(fileBytes, ContentType, DocName);

        }
        public ActionResult AjaxGetApprovePO(string IndentNo)
        {
            int AddedBy = Convert.ToInt16(Session["userid"]);
            BO.ResponseMessage responce = DataProvider.AjaxGetApprovePO(IndentNo, AddedBy);
            return Json(responce);
        }

        public ActionResult SetCustomerData(int CustomerID)
        {
            BO.PurchaseOrderM dtIssueTositeList = new BO.PurchaseOrderM();

            dtIssueTositeList = DataProvider.SetCustomerData(CustomerID);

            var CurrencyID = dtIssueTositeList.CurrencyID;
            var ExchangeRate = dtIssueTositeList.ExchangeRate;
            List<BO.PurchaseOrderM> POBilling = dtIssueTositeList.POBilling;
            List<BO.PurchaseOrderM> POShipping = dtIssueTositeList.POShipping;
            List<BO.PurchaseOrderPaymentTerm> POPaymentTerm = dtIssueTositeList.POPaymentTerm;

            return Json(new
            {
                CurrencyID = CurrencyID,
                ExchangeRate = ExchangeRate,
                POBilling = POBilling,
                POShipping = POShipping,
                POPaymentTerm = POPaymentTerm
            }, JsonRequestBehavior.AllowGet);


        }

        ///// 04-09-23
        public ActionResult GetFreightListAgainstDCNO(List<PIMaster> poItemM)
        {
            List<BO.PurchaseOrderD> OpenIndentList = new List<BO.PurchaseOrderD>();
            DataTable dtWONO = new DataTable();

            dtWONO.Columns.Add("DCNO");
            //dtWONO.Columns.Add("WONO");
            //dtWONO.Columns.Add("SpecID");
            dtWONO.TableName = "PT_DCNOItemListForEXI";
            foreach (BO.PIMaster item in poItemM)
            {
                DataRow row = dtWONO.NewRow();
                row["DCNO"] = item.DCNO;
                //row["WONO"] = item.WONO;
                //row["SpecID"] = item.SpecID;
                dtWONO.Rows.Add(row);
            }
            OpenIndentList = DataProvider.GetFreightListAgainstDCNO(dtWONO);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult updateDCMasterFlag(string DCNO)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            ResponseMessage response = new ResponseMessage();
            try
            {
                response = DataProvider.updateDCMasterFlag(DCNO, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(response);
        }

        public ActionResult PODMasterSummary()
        {
            return View();
        }
        public JsonResult GetPODMasterSummary(BO.ModeOfShipment data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.ModeOfShipment> list = new List<BO.ModeOfShipment>();
            list = DataProvider.GetPODMasterSummary();
            return Json(list);
        }

        public ActionResult _AddOrEditPOD(int PODID)
        {
            return PartialView();
        }

        public JsonResult AjaxAddOrEdit(string PODName)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BO.ResponseMessage message = new BO.ResponseMessage();

                // END Packing List
                message = DataProvider.AjaxAddOrEdit(PODName, AddedBy);
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}