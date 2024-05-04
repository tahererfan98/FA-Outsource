using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO = BombayToolsEntities.BusinessEntities;
using BE = BombayToolsEntities.BusinessEntities;
using BombayTools.Filters;
using DBView = BombayToolBusinessLayer.Master;
using Newtonsoft.Json;
using System.Diagnostics;
using DP = BombayToolBusinessLayer.Login;
using System.IO;
using System.Data;

namespace BombayTools.Controllers.Master
{
    [UserAuthenticationFilter]
    public class MasterController : Controller
    {
        DBView.MasterDataProvider dashboardBussinesManager = new DBView.MasterDataProvider();
        DP.LoginDataProvider LoginManager = new DP.LoginDataProvider();

        //Outsource Partner Master

        public ActionResult OutsourcePartnerSummary()
        {
            List<BO.OutsourcePartner> OSPartnerList = new List<BO.OutsourcePartner>();
            OSPartnerList = dashboardBussinesManager.OutsourcePartnerSummary();
            ViewBag.VendorList = JsonConvert.SerializeObject(OSPartnerList);
            return View(OSPartnerList.ToList());
        }

        public ActionResult _AddOrEditOutsourcePartner(int PartnerID)
        {
            BO.OutsourcePartner data = new BO.OutsourcePartner();
            if (PartnerID != 0)
            {
                data = dashboardBussinesManager.GetOutsourcePartnerDetail(PartnerID);
                ViewBag.PartnerID = PartnerID;
                ViewBag.PartnerName = data.PartnerName;
                ViewBag.PartnerLoc = data.PartnerLoc;
                ViewBag.Address = data.Address;
                ViewBag.VatNo = data.VatNo;
                ViewBag.IsActive = data.IsActive;
                ViewBag.Action = "Edit";

                ViewBag.ContactListD = JsonConvert.SerializeObject(data.POBilling);
            }
            else
            {
                ViewBag.PartnerID = 0;
                ViewBag.PartnerName = "";
                ViewBag.PartnerLoc = "";
                ViewBag.Address = "";
                ViewBag.VatNo = "";
                ViewBag.Action = "Add";
            }
            ViewBag.PartnerID = PartnerID;
            return PartialView();
        }

        public JsonResult SaveOutsourcePartner(BO.OutsourcePartner data, List<BO.OutsourcePartner>  ContactList)
        {
            try
            {
                BO.ResponseMessage response = new BO.ResponseMessage();
                data.AddedBy = Convert.ToInt16(Session["userid"]);
                DataTable dataTable = new DataTable();
                if (ContactList != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("ContactPerson");
                    dataTable.Columns.Add("ContactNo");
                    dataTable.Columns.Add("EmailID");
                    dataTable.TableName = "PT_OSContactList";
                    foreach (BO.OutsourcePartner item in ContactList)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["ContactPerson"] = item.ContactPerson;
                        row["ContactNo"] = item.ContactNo;
                        row["EmailID"] = item.EmailID;
                        dataTable.Rows.Add(row);
                    }
                }
                response = dashboardBussinesManager.SaveOutsourcePartner(data, dataTable);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult DeleteVendorMaster(BO.OutsourcePartner data)
        {
            data.AddedBy = Convert.ToInt16(Session["userid"]);
            //string message = dashboardBussinesManager.DeleteVendorMaster(data);
            string message = "";
            return Json(message);
        }












        public int CheckAuthority(string name)
        {
            int i = 1;
            var list = (List<BO.SubmenuInfo>)Session["MenuList"];
            if (list == null)
            {
                int SessionuserID = Convert.ToInt32(Session["userid"]);

                list = LoginManager.UserMenuList("-", SessionuserID);
            }
            for (int a = 0; a < list.Count; a++)
            {
                string subMenu = list[a].Action;
                if (name == subMenu)
                {
                    i = 0;
                    break;
                }
            }
            return i;
        }
        public ActionResult PrincipalSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.Principal> ItemList = new List<BO.Principal>();
            ItemList = dashboardBussinesManager.PrincipalSummary();
            ViewBag.PrincipalCount = ItemList[0].PrincipalCount;
            ViewBag.PrincipalList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }
        public ActionResult Principal(BO.Principal data)
        {
            ViewBag.PrincipalID = data.PrincipalID;
            if (ViewBag.PrincipalID != 0)
            {
                ViewBag.Principal = data.PrincipalName;
                return PartialView();
            }
            else
            {
                ViewBag.Principal = "";
                return PartialView();

            }
        }
        public ActionResult EditPrincipalItemDetail(int PrincipalID)
        {
            TempData["PrincipalID"] = PrincipalID;
            return Json(PrincipalID);
        }
        public ActionResult DeleteNewPrincipal(BO.Principal data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            data.ModifiedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeletePrincipalDetails(data);
            return Json(message);
        }
        public ActionResult NewPrincipalValidation(BO.Principal data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            data.ModifiedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.BeforeSavePrincipalDetails(data);
            return Json(message);
        }
        public ActionResult NewPrincipal(BO.Principal data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            data.ModifiedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SavePrincipalDetails(data);
            return Json(message);
        }
        public ActionResult UpdateNewPrincipal(BO.Principal data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            data.ModifiedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdatePrincipalDetails(data);
            return Json(message);
        }

        [HttpPost]
        public ActionResult AjaxGetAllPrincipal(BO.Principal data)
        {
            string message = dashboardBussinesManager.ValidPrincipal(data);
            return Json(message);

        }

        //For Industry Master
        public ActionResult IndustrySummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.Industry> ItemList = new List<BO.Industry>();
            ItemList = dashboardBussinesManager.IndustrySummary();
            ViewBag.IndustryCount = ItemList[0].IndustryCount;
            ViewBag.IndustryList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }

        public ActionResult Industry(BO.Industry data)
        {
            ViewBag.IndustryID = data.IndustryId;
            if (ViewBag.IndustryID != 0)
            {
                ViewBag.IndustryName = data.IndustryName;
                return PartialView();
            }
            else
            {
                ViewBag.IndustryName = "";
                return PartialView();

            }
        }
        public ActionResult EditIndustryItemDetail(int IndustryID)
        {
            TempData["IndustryID"] = IndustryID;
            return Json(IndustryID);
        }
        [HttpPost]
        public ActionResult AjaxGetAllIndustry()
        {

            List<BO.Industry> FlightList = dashboardBussinesManager.GetIndustry();
            return Json(FlightList.ToList());
        }
        public ActionResult NewSaveIndustry(BO.Industry data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveIndustry(data);
            return Json(message);
        }

        public ActionResult UpdateIndustry(BO.Industry data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdateIndustry(data);
            return Json(message);
        }
        public ActionResult DeleteNewIndustry(BO.Industry data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeleteIndustryDetails(data);
            return Json(message);
        }
        //end For Industry Master
        //For Sector Master
        public ActionResult SectorSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.Sector> ItemList = new List<BO.Sector>();
            ItemList = dashboardBussinesManager.SectorSummary();
            ViewBag.SectorCount = ItemList[0].SectorCount;
            ViewBag.SectorList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }

        public ActionResult Sector(BO.Sector data)
        {
            ViewBag.SectorID = data.SectorID;
            if (ViewBag.IndustryID != 0)
            {
                ViewBag.SectorName = data.SectorName;
                return PartialView();
            }
            else
            {
                ViewBag.SectorName = "";
                return PartialView();

            }
        }
        public ActionResult EditSectorItemDetail(int SectorID)
        {
            TempData["SectorID"] = SectorID;
            return Json(SectorID);
        }
        [HttpPost]
        public ActionResult AjaxGetAllSector()
        {

            List<BO.Sector> FlightList = dashboardBussinesManager.GetSector();
            return Json(FlightList.ToList());
        }
        public ActionResult NewSaveSector(BO.Sector data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveSector(data);
            return Json(message);
        }

        public ActionResult UpdateSector(BO.Sector data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdateSector(data);
            return Json(message);
        }
        public ActionResult DeleteNewSector(BO.Sector data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeleteSectorDetails(data);
            return Json(message);
        }
        //end For sector Master
        //For Department
        public ActionResult DepartmentSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.Department> ItemList = new List<BO.Department>();
            ItemList = dashboardBussinesManager.DepartmentSummary();
            ViewBag.DepartmentCount = ItemList[0].DepartmentCount;
            ViewBag.DepartmentList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }

        public ActionResult Department(BO.Department data)
        {
            ViewBag.DepartmentID = data.DepartmentID;
            if (ViewBag.DepartmentID != 0)
            {
                ViewBag.DepartmentName = data.DepartmentName;
                return PartialView();
            }
            else
            {
                ViewBag.DepartmentName = "";
                return PartialView();

            }
        }
        public ActionResult DeleteNewDepartment(BO.Department data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeleteDepartmentDetails(data);
            return Json(message);
        }
        public ActionResult NewSaveDepartment(BO.Department data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveDepartment(data);
            return Json(message);
        }
        public ActionResult UpdateDepartment(BO.Department data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdateDepartment(data);
            return Json(message);
        }
        [HttpPost]
        public ActionResult AjaxGetAllDepartment()
        {

            List<BO.Department> FlightList = dashboardBussinesManager.GetDepartment();
            return Json(FlightList.ToList());
        }
        public ActionResult EditDepartmentItemDetail(int DepartmentID)
        {
            TempData["DepartmentID"] = DepartmentID;
            return Json(DepartmentID);
        }
        //END For Department
        //For EMAIL
        public ActionResult TemplateSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.EmailBodyTemplate> ItemList = new List<BO.EmailBodyTemplate>();
            ItemList = dashboardBussinesManager.EmailSummary();
            ViewBag.TemplateCount = ItemList[0].TemplateCount;
            ViewBag.TemplateList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }
        public ActionResult Template(BO.EmailBodyTemplate data)
        {
            ViewBag.TemplateID = data.TemplateID;
            if (ViewBag.TemplateID != 0)
            {
                ViewBag.TemplateName = data.TemplateName;
                ViewBag.Body = data.Body;
                return PartialView();
            }
            else
            {
                ViewBag.TemplateName = "";
                ViewBag.Body = "";
                return PartialView();

            }
        }
        public ActionResult EditTemplateItemDetail(int TemplateID)
        {
            TempData["TemplateID"] = TemplateID;
            return Json(TemplateID);
        }
        public ActionResult NewSaveTemplate(BO.EmailBodyTemplate data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveTemplate(data);
            return Json(message);
        }
        public ActionResult UpdateTemplate(BO.EmailBodyTemplate data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdateTemplate(data);
            return Json(message);
        }
        [HttpPost]
        public ActionResult AjaxGetAllTemplate()
        {

            List<BO.EmailBodyTemplate> FlightList = dashboardBussinesManager.GetTemplate();
            return Json(FlightList.ToList());
        }
        public ActionResult DeleteNewTemplate(BO.EmailBodyTemplate data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeleteTemplateDetails(data);
            return Json(message);
        }
        //end For EMAIL
        //For terms and Conditions
        public ActionResult QuotTermConditionSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.QuotationTermsTemplate> ItemList = new List<BO.QuotationTermsTemplate>();
            ItemList = dashboardBussinesManager.QuotTermConditionSummary();
            ViewBag.TemplateCount = ItemList[0].TemplateCount;
            ViewBag.TemplateList = JsonConvert.SerializeObject(ItemList);
            return View(ItemList.ToList());
        }
        public ActionResult QuotTermCondition(BO.QuotationTermsTemplate data)
        {
            ViewBag.TemplateID = data.TemplateID;
            if (ViewBag.TemplateID != 0)
            {
                ViewBag.TemplateName = data.TemplateName;
                ViewBag.Packing = data.Packing;
                ViewBag.Freight = data.Freight;
                ViewBag.Exgodown = data.Exgodown;
                ViewBag.Tax = data.Tax;
                ViewBag.Warranty = data.Warranty;
                ViewBag.Payment = data.Payment;
                ViewBag.Delivery = data.Delivery;
                return PartialView();
            }
            else
            {
                ViewBag.TemplateName = "";
                ViewBag.Packing = "";
                ViewBag.Freight = "";
                ViewBag.Exgodown = "";
                ViewBag.Tax = "";
                ViewBag.Warranty = "";
                ViewBag.Payment = "";
                ViewBag.Delivery = "";
                return PartialView();

            }
        }
        public ActionResult EditQuotTermCondition(int TemplateID)
        {
            TempData["TemplateID"] = TemplateID;
            return Json(TemplateID);
        }
        public ActionResult NewSaveQuotTermCondition(BO.QuotationTermsTemplate data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveQuotTermCondition(data);
            return Json(message);
        }
        public ActionResult UpdateQuotTermCondition(BO.QuotationTermsTemplate data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.UpdateQuotTermCondition(data);
            return Json(message);
        }
        [HttpPost]
        public ActionResult AjaxGetAllQuotTermCondition()
        {

            List<BO.QuotationTermsTemplate> FlightList = dashboardBussinesManager.GetQuotTermCondition();
            return Json(FlightList.ToList());
        }
        public ActionResult DeleteNewQuotTermCondition(BO.QuotationTermsTemplate data)
        {

            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.DeleteQuotTermConditionDetails(data);
            return Json(message);
        }
        //end For EMAIL

        public ActionResult ZoneSummary()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            string url = Request.Url.AbsoluteUri;
            url = url.Substring(7);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            List<BO.Zone> ZoneMaster = new List<BO.Zone>();
            ZoneMaster = dashboardBussinesManager.ZoneSummary();
            if(ZoneMaster.Count != 0)
            {
                ViewBag.ZoneCount = ZoneMaster.Count;
            }
            else
            {
                ViewBag.ZoneCount = 0;
            }
            ViewBag.ZoneMaster = JsonConvert.SerializeObject(ZoneMaster);
            return View(ZoneMaster.ToList());
        }

        public ActionResult AjaxAddorEditZone(BO.Zone data)
        {
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.AddorEditZone(data);
            return Json(message);

        }

        public ActionResult AddOrEditZone(int ID)
        {
            List<BO.State> Statelist = new List<BO.State>();
            Statelist = dashboardBussinesManager.SaveOrEditZone(ID);
            ViewBag.StateList = JsonConvert.SerializeObject(Statelist);
            return PartialView(Statelist.ToList());
        }

        //////////////////////////////
        ///Vendor Summary ANd FOrm
        ///

        public ActionResult VendorSummary()
        {
            List<BO.VendorM> vendors = dashboardBussinesManager.GetVendorSummary();
            return View(vendors.ToList());
        }

        public PartialViewResult _AddorEditVendor(int ID)
        {
            BO.Vendor GetDropdown = new BO.Vendor();
            GetDropdown = dashboardBussinesManager.GetVendorDropdownDetails();
            List<BO.Locationmaster> Locationmaster = new List<BO.Locationmaster>();
            List<BO.StateMaster> stateMasters = new List<BO.StateMaster>();
            List<BO.GSTRegistrationType> GSTRegistrationTypes = new List<BO.GSTRegistrationType>();
            List<BO.Vendor_Docs> VendorDocList = new List<BO.Vendor_Docs>();
            List<BO.Item> ItemList = new List<BO.Item>();
            List<BO.BankList> Bankdetails = new List<BO.BankList>();

            Locationmaster = GetDropdown.Locationmaster;
            stateMasters = GetDropdown.StateMaster;
            GSTRegistrationTypes = GetDropdown.GSTRegistrationType;
            VendorDocList = GetDropdown.Vendor_Docs;
            ItemList = GetDropdown.Item;
            Bankdetails = GetDropdown.BankList;

            ViewBag.locationList = new SelectList(Locationmaster, "LocationID", "LocationName");
            ViewBag.StateList = new SelectList(stateMasters, "StateID", "StateName");
            ViewBag.GSTType = new SelectList(GSTRegistrationTypes, "RGID", "RGType");
            ViewBag.VendorDocs = new SelectList(VendorDocList, "Docid", "DocType");
            ViewBag.BankList = new SelectList(Bankdetails, "BankID", "BankName");
            BO.Vendor vendor = new BO.Vendor();
            if(ID != 0)
            {
                vendor = dashboardBussinesManager.GetVendorDetails(ID);
                ViewBag.ContactList = JsonConvert.SerializeObject(vendor.VendorContactDetails);
                ViewBag.AccountList = JsonConvert.SerializeObject(vendor.VendorAccountDetails);
                ViewBag.Terms = JsonConvert.SerializeObject(vendor.Terms);
                ViewBag.Docs = JsonConvert.SerializeObject(vendor.VendorDoc);
                ViewBag.TxtVendorID = vendor.VendorID;
                ViewBag.TxtVendorName = vendor.VendorName;
                ViewBag.TxtVendorCode = vendor.Vendor_Code;
                ViewBag.TxttallyName = vendor.TallyName;
                ViewBag.Address = vendor.Vendor_Address;
                ViewBag.Txtaddress2 = vendor.address2;
                ViewBag.ddlDiscountable = vendor.Discountable;
                ViewBag.TxtCreditores = vendor.Creditores;
                ViewBag.TxtrelatedPerson = vendor.relatedPerson;
                ViewBag.ddlGstscheme = vendor.Gstscheme;
                ViewBag.ddlstatus = vendor.status;
                ViewBag.Txtregistration = vendor.registration;
                ViewBag.TxtContactNo = vendor.ContactPerson;
                ViewBag.ddlRegisterType = vendor.RegisterTypeID;
                ViewBag.txtGSTNo = vendor.GSTNo;
                ViewBag.txtPANNo = vendor.PANNo;
                ViewBag.GstLocation = vendor.GSTLocation;
                ViewBag.datePicker1 = vendor.GSTRegistrationDate;
                ViewBag.txtState = vendor.StateID;
                ViewBag.txtAddress = vendor.GSTAddress; 
                ViewBag.tXtGStEmail = vendor.EmailAddress; 
                ViewBag.txtContact = vendor.GSTContactNo; 
            }
            else
            {
                ViewBag.ContactList = "";
                ViewBag.AccountList = "";
                ViewBag.Terms = "";
                ViewBag.Docs = "";
                ViewBag.TxtVendorID = 0;
            }
            return PartialView();
        }

        public JsonResult GetSateCode(string StateID)
        {
            string message = "";
            message = dashboardBussinesManager.GetstateCode(StateID);
            return Json(message);
        }

        [HttpPost]
        public JsonResult SaveAttachmentToDirectory(BO.Vendor fileData)
        {
            int Userid = Convert.ToInt16(Session["userid"]);
            BO.VendorDocs data = new BO.VendorDocs();
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string contentType;
                        Stream fs = Request.Files[i].InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        contentType = MimeMapping.GetMimeMapping(fname);
                        //string MSNO = fileData.MSNoFile;
                        string DocumenttypeID = fileData.DocumenttypeID;
                        string root = Path.Combine(Server.MapPath("~/Uploads/temp/"), Convert.ToString(Userid));
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        fname = Path.Combine(Server.MapPath("~/Uploads/temp/" + Userid + "/"), fname);
                        //fname = Path.Combine(root, "/" + fname);
                        if (System.IO.File.Exists(fname))
                        {
                            System.IO.File.Delete(fname);
                        }
                        file.SaveAs(fname);
                        data.DocumentType = contentType;
                        data.FilePath = fname;
                        data.FileName =  file.FileName;
                    }
                    return Json(data);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public JsonResult AjaxAddOrEditVendor(BO.Vendor Basic, List<BO.VendorContactDetails> VendorList,List<BO.VendorAccountDetails> BankList, List<BO.VendorTerms> TermList,List<BO.VendorDocs> Upload)
        {
            Basic.AddedBy = Convert.ToInt32(Session["userid"]);
            BO.ResponseMessage message = new BO.ResponseMessage();
            DataTable vendorContact = new DataTable();
            vendorContact.Columns.Add("ID");
            vendorContact.Columns.Add("Name");
            vendorContact.Columns.Add("Email");
            vendorContact.Columns.Add("Mobile");
            vendorContact.Columns.Add("Location");
            vendorContact.Columns.Add("IsActive");
            vendorContact.TableName = "PT_VendorContact";
            if(VendorList != null)
            {
                foreach (BO.VendorContactDetails item in VendorList)
                {
                    DataRow row = vendorContact.NewRow();
                    if (item.ID == 0)
                    {
                        row["ID"] = 0;
                    }
                    else
                    {
                        row["ID"] = item.ID;
                    }
                    row["Name"] = item.Name;
                    row["Email"] = item.Email;
                    row["Mobile"] = item.Mobile;
                    row["Location"] = item.Location;
                    if(item.IsCancel == 0)
                    {
                        row["IsActive"] = 1;
                    }
                    else
                    {
                        row["IsActive"] = 0;
                    }
                    vendorContact.Rows.Add(row);
                }

            }

            DataTable bankListDT = new DataTable();
            bankListDT.Columns.Add("Auto");
            bankListDT.Columns.Add("BankID");
            bankListDT.Columns.Add("BankName");
            bankListDT.Columns.Add("AccountNo");
            bankListDT.Columns.Add("IFSCCode");
            bankListDT.Columns.Add("AccountName");
            bankListDT.Columns.Add("BranchName");
            bankListDT.Columns.Add("IsActive");
            bankListDT.TableName = "PT_BankList";
            if(BankList != null)
            {
                foreach (BO.VendorAccountDetails details in BankList)
                {
                    DataRow row = bankListDT.NewRow();
                    row["Auto"] = details.AutoID;
                    row["BankID"] = details.BankID;
                    row["BankName"] = details.BankName;
                    row["AccountNo"] = details.AccountNo;
                    row["IFSCCode"] = details.IFSCCode;
                    row["AccountName"] = details.AccountName;
                    row["BranchName"] = details.BranchName;
                    row["IsActive"] = details.IsActive;
                    bankListDT.Rows.Add(row);
                }

            }
            
            DataTable TermListDT = new DataTable();
            TermListDT.Columns.Add("ID");
            TermListDT.Columns.Add("Term");
            TermListDT.Columns.Add("IsActive");
            TermListDT.TableName = "PT_VendorTerm";
            if(TermList != null)
            {
                foreach (BO.VendorTerms item in TermList)
                {
                    DataRow row = TermListDT.NewRow();
                    row["ID"] = item.ID;
                    row["Term"] = item.Term;
                    row["IsActive"] = item.IsActive;
                    TermListDT.Rows.Add(row);
                }
            }

            /////GetVendorID Data
            message = dashboardBussinesManager.AddOrEditVendorData(Basic, vendorContact,bankListDT, TermListDT);
            if(Upload != null)
            {
                string root = Path.Combine(Server.MapPath("~/Uploads/VendorDocs/"), Convert.ToString(message.Data));
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                foreach (BO.VendorDocs d in Upload)
                {
                    if(d.DocID != 0)
                    {
                        d.FilePath = root;
                        System.IO.File.Move(d.FilePath,root+d.FileName);
                    }
                }
                DataTable UploadDT = new DataTable();
                UploadDT.Columns.Add("ID");
                UploadDT.Columns.Add("DocumentType");
                UploadDT.Columns.Add("FileName");
                UploadDT.Columns.Add("FilePath");
                UploadDT.Columns.Add("IsActive");
                UploadDT.TableName = "PT_VendorDoc";
                foreach (BO.VendorDocs item in Upload)
                {
                    DataRow row = UploadDT.NewRow();
                    row["ID"] = item.DocID;
                    row["DocumentType"] = item.DocumentType;
                    row["FileName"] = item.FileName;
                    row["FilePath"] = item.FilePath;
                    row["IsActive"] = item.IsActive;
                    UploadDT.Rows.Add(row);
                }
                dashboardBussinesManager.UpdateVendorDocs(message.Data,UploadDT);
            }

            return Json(message);
        }


        public ActionResult FreightSummary()
        {
            return View();
        }


        //[HttpPost]
        //public JsonResult AjaxAddOrEditFrieght(BO.FreightMaster master)
        //{
        //    BO.ResponseMessage response = new BO.ResponseMessage();
        //    master.AddedBy = Convert.ToInt32(Session["userid"]);
        //    response = dashboardBussinesManager.AddOrEditFrieght(master);
        //    //
        //    return Json(response);
        //}
     
        public ActionResult AddOrEditSummary()
        {
            return View();
        }

        public ActionResult MailTemplateSummary()
        {
            List<BO.MailCampaignTemplate> templates = dashboardBussinesManager.GetMailTemplateSummary();
            return View(templates.ToList());
        }

        public ActionResult NewMailTemplate(int ID)
        {
            BO.MailCampaignTemplate document = new BO.MailCampaignTemplate();
            if (ID != 0)
            {
                document = dashboardBussinesManager.GetDocumentDetails(ID);
                ViewBag.AutoID = ID;
                ViewBag.Attachment = JsonConvert.SerializeObject(document.Attachments);
                ViewBag.Html = JsonConvert.SerializeObject(document.DocHTML);
            }
            return View(document);
        }

        public JsonResult AjaxAddorEditMailTemplate(BO.MailCampaignTemplate doc,List<BO.SupplierInfoAttach> attachment)
        {
            BO.ResponseMessage response = new BO.ResponseMessage();
            try
            {
                doc.AddedBy = Convert.ToInt32(Session["userid"]);
                DataTable UploadDT = new DataTable();
                UploadDT.Columns.Add("DocName");
                UploadDT.Columns.Add("FilePath");
                UploadDT.Columns.Add("ContentType");
                UploadDT.TableName = "PT_EmployeeAttachments";
                foreach (BO.SupplierInfoAttach item in attachment)
                {
                    DataRow row = UploadDT.NewRow();
                    row["DocName"] = item.DocName;
                    row["ContentType"] = item.ContentType;
                    row["FilePath"] = item.FilePath;
                    UploadDT.Rows.Add(row);
                }
                response = dashboardBussinesManager.AjaxAddorEditMailTemplate(doc, UploadDT);
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message;
            }
            return Json(response);
        }
        //----------------------------------
        const string filesavepath = "~/Content/Uploads/Ckeditor";
        const string baseUrl = @"/Content/Uploads/Ckeditor/";

        const string scriptTag = "<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({0}, '{1}', '{2}')</script>";

        public ActionResult UploadImage()
        {
            var funcNum = 0;
            int.TryParse(Request["CKEditorFuncNum"], out funcNum);

            if (Request.Files == null || Request.Files.Count < 1)
                return BuildReturnScript(funcNum, null, "No file has been sent");

            string fileName = string.Empty;
            SaveAttatchedFile(filesavepath, Request, ref fileName);
            string Domain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

            var url = Domain + baseUrl + fileName;
            return Json(new { uploaded = true, url });

            //return BuildReturnScript(funcNum, url, null);
        }

        private ContentResult BuildReturnScript(int functionNumber, string url, string errorMessage)
        {
            return Content(
                string.Format(scriptTag, functionNumber, HttpUtility.JavaScriptStringEncode(url ?? ""), HttpUtility.JavaScriptStringEncode(errorMessage ?? "")),
                "text/html"
                );
        }

        private void SaveAttatchedFile(string filepath, HttpRequestBase Request, ref string fileName)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    string targetPath = Server.MapPath(filepath);
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    fileName = Guid.NewGuid() + fileName;//To create more unique add datetimestamp
                    string fileSavePath = Path.Combine(targetPath, fileName);
                    file.SaveAs(fileSavePath);
                }
            }
        }

        public JsonResult UploadTemplateAttachment(BO.SupplierInfoAttach fileData)
        {
            BO.SupplierInfoAttach SupplierInfoAttach = new BO.SupplierInfoAttach();
            if (Request.Files.Count > 0)
            {
                try
                {
                    int Userid = Convert.ToInt16(Session["userid"]);
                    string Type = DateTime.Now.ToString("dd_MMM_yyyy_HHss_");
                    Type = Type + Userid;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;
                        string root = Server.MapPath("~/Uploads/Campaign/" + Type + "/");
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string contentType;
                        contentType = MimeMapping.GetMimeMapping(fname);

                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string check = Path.Combine(Server.MapPath("~/Uploads/Campaign/" + Type + "/"), fname);
                        if (System.IO.File.Exists(fname))
                        {
                            System.IO.File.Delete(fname);
                        }
                        file.SaveAs(check);
                        SupplierInfoAttach.DocName = fname;
                        SupplierInfoAttach.FilePath = check;
                        SupplierInfoAttach.ContentType = contentType;
                    }
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            return Json(SupplierInfoAttach);
        }

        public PartialViewResult ItemBulkEdit()
        {
            return PartialView();
        }

    }
}