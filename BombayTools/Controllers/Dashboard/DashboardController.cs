using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBView = BombayToolBusinessLayer.Dashboard;

using BO = BombayToolsEntities.BusinessEntities;
using Newtonsoft.Json;
using System.Diagnostics;
using DP = BombayToolBusinessLayer.Login;
using RB = BombayToolBusinessLayer.User;
using BombayTools.Filters;

namespace BombayTools.Controllers.Dashboard
{
    [UserAuthenticationFilter]
    public class DashboardController : Controller
    {
        DBView.DashboardDataProvider dashboardBussinesManager = new DBView.DashboardDataProvider();
        RB.UserDataProvider ReqBussinesManager = new RB.UserDataProvider();
        DP.LoginDataProvider LoginManager = new DP.LoginDataProvider();


        //Custom Check For Authorization
        //public int CheckAuthority(string name)
        //{
        //    int i = 1;
        //    var list = (List<BO.SubmenuInfo>)Session["MenuList"];
        //    if(list == null )
        //    {
        //        int SessionuserID = Convert.ToInt32(Session["userid"]);

        //        list = LoginManager.UserMenuList("-", SessionuserID);
        //    }
        //    for(int a=0;a<list.Count;a++)
        //    {
        //        string subMenu = list[a].Action;
        //        if (name == subMenu )
        //        {
        //            i = 0;
        //            break;
        //        }
        //    }
        //    return i;
        //}
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
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
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

            BO.AdminDashboard adminDashboard = dashboardBussinesManager.GetDashboardData();
            ViewBag.PrincipalCount = adminDashboard.Count.Principal;
            ViewBag.SectorCount = adminDashboard.Count.Sector;
            ViewBag.IndustryCount = adminDashboard.Count.Industry;
            ViewBag.CompanyCount = adminDashboard.Count.Company;
            ViewBag.PendingApproval = adminDashboard.PendingApproval;
            ViewBag.StreakReport = adminDashboard.StreakDataList;
            ViewBag.UserType = Convert.ToInt16(Session["userid"]);
            List<BO.User> userDetails = new List<BO.User>();
            userDetails = ReqBussinesManager.GetUserSummary();
            ViewBag.UserDetail = new SelectList(userDetails, "ID", "EmployeeName");
            return View();
        }

        public ActionResult SalesPersonDashboard()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            int id = Convert.ToInt16(Session["userid"]); ;
            BO.SalesPersonDashboard salesPersonDashboard = dashboardBussinesManager.GetSalaespersonDetail(id);
            ViewBag.Enqlist = salesPersonDashboard.EnquiryList;
            //ViewBag.QuotList = salesPersonDashboard.QuotationList;
            ViewBag.ReportList = salesPersonDashboard.SaleReport;
            return View();
        }

        public ActionResult SalesPerson1Dashboard()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(0);
            var currentMethodName = sf.GetMethod();
            string Name = currentMethodName.Name;
            int v = CheckAuthority(Name);
            if (v == 1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            int id = Convert.ToInt16(Session["userid"]);
            BO.SalesPersonDashboard salesPersonDashboard = dashboardBussinesManager.GetSalaespersonDashboardDetail(id);
            ViewBag.Enqlist = salesPersonDashboard.EnquiryList;
            //ViewBag.QuotList = salesPersonDashboard.QuotationList;
            ViewBag.OpenEnquiry = salesPersonDashboard.OpenEnquiry;
            ViewBag.OpenQuotation = salesPersonDashboard.OpenQuotation;
            ViewBag.StreakData = salesPersonDashboard.StreakDataList;
            return View();
        }

        public ActionResult CountWiseData()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetPrincipalDetail()
        {
            List<BO.Principal> principal = dashboardBussinesManager.GetPrincipalDetail();
            return Json(principal.ToList());
        }
        [HttpPost]
        public ActionResult GetSectorDetail()
        {
            List<BO.Sector> principal = dashboardBussinesManager.GetSectorDetail();
            return Json(principal.ToList());
        }
        [HttpPost]
        public ActionResult GetIndustryDetail()
        {
            List<BO.Industry> principal = dashboardBussinesManager.GetIndustryDetail();
            return Json(principal.ToList());
        }

        [HttpPost]
        public ActionResult GetCompanyListForSelectedPrincipal(int Type ,int Id)
        {
            List<BO.CompanyDetail> principal = dashboardBussinesManager.GetCompanyListForSelectedPrincipal(Type,Id);
            return Json(principal.ToList());
        }

        //public ActionResult StreakDataView(int ID)
        //{
        //    //For Principal List
        //    List<BO.Principal> principalList = new List<BO.Principal>();
        //    principalList = dashboardBussinesManagerC.GetPrincipalList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.PrincipalDropdownD = new SelectList(principalList, "PrincipalID", "PrincipalName");
        //    //For Sector List
        //    List<BO.Sector> sectorList = new List<BO.Sector>();
        //    sectorList = dashboardBussinesManagerC.GetSectorList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.SectorDropdownD = new SelectList(sectorList, "SectorID", "SectorName");
        //    //For Industry List
        //    List<BO.Industry> IndustryList = new List<BO.Industry>();
        //    IndustryList = dashboardBussinesManagerC.GetIndustryList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.IndustryDropdownD = new SelectList(IndustryList, "IndustryID", "IndustryName");
        //    //FOR STAGE
        //    List<BO.StreakData> StageList = new List<BO.StreakData>();
        //    StageList = dashboardBussinesManager.GetStreakStages(ID);
        //    ViewBag.StageDropdownD = new SelectList(StageList, "SrNo", "Stage");
        //    ViewBag.StreakMaster = JsonConvert.SerializeObject(StageList);
        //    List<BO.StreakData> Data = dashboardBussinesManager.GetStreakData(ID);
        //    ViewBag.ID = ID;
        //    return PartialView(Data.ToList());
        //}
        [HttpPost]
        public ActionResult AjaxGetSearchDetailStageWise(int ID, string Stage)
        {
            List<BO.StreakData> SearchList = new List<BO.StreakData>();
            SearchList = dashboardBussinesManager.GetStreakDataStageWise(ID, Stage);
            var jsonResult = Json(SearchList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        //public ActionResult StreakDataCheck(int ID)
        //{
        //    //For Principal List
        //    List<BO.Principal> principalList = new List<BO.Principal>();
        //    principalList = dashboardBussinesManagerC.GetPrincipalList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.PrincipalDropdown = new SelectList(principalList, "PrincipalID", "PrincipalName");
        //    //For Sector List
        //    List<BO.Sector> sectorList = new List<BO.Sector>();
        //    sectorList = dashboardBussinesManagerC.GetSectorList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.SectorDropdown = new SelectList(sectorList, "SectorID", "SectorName");
        //    //For Industry List
        //    List<BO.Industry> IndustryList = new List<BO.Industry>();
        //    IndustryList = dashboardBussinesManagerC.GetIndustryList(Convert.ToString(Session["LoginType"]));
        //    ViewBag.IndustryDropdown = new SelectList(IndustryList, "IndustryID", "IndustryName");
        //    BO.StreakData data = dashboardBussinesManager.GetStreakDataForID(ID);
        //    ViewBag.ID = data.ID;
        //    ViewBag.SDName = data.Name;
        //    ViewBag.SDStage = data.Stage;
        //    ViewBag.SDProbabilty = data.Probabilty;
        //    ViewBag.SDLeadSource = data.LeadSource;
        //    ViewBag.SDDealSize = data.DealSize;
        //    ViewBag.SDVertical = data.Vertical;
        //    ViewBag.SDCompanyName = data.CompanyFromMaster;
        //    ViewBag.SDLocationN = data.Location;
        //    ViewBag.PrincipalID = data.PrincipalID;
        //    ViewBag.SectorID = data.SectorID;
        //    ViewBag.IndustryID = data.IndustryID;
        //    ViewBag.CompanyID = data.CompanyID;
        //    ViewBag.LocationID = data.LocationID;
        //    return PartialView();
        //}

        public ActionResult DashboardReport(DateTime From)
        {
            BO.AdminDashboardCount count = dashboardBussinesManager.DashboardReport(From);
            ViewBag.Quotation = count.DailyQuot;
            ViewBag.Pipleine = count.PipelineCount;
            return PartialView();
        }

        public ActionResult ActivityLog(int UserID, DateTime FromDate, DateTime ToDate)
        {
            List<BO.ActivityLog> activities = dashboardBussinesManager.GetUserActivityLog(UserID,FromDate,ToDate);
            return PartialView(activities);
        }

        public ActionResult handleSearch(string searchTextContactGlobal)
        {
            TempData["GlobalSearch"] = searchTextContactGlobal;
            return RedirectToAction("GlobalSearch");
        }

        public ActionResult GlobalSearch()
        {
            ViewBag.SearchText = Convert.ToString(TempData["GlobalSearch"]);
            return View();
        }

        public PartialViewResult _SearchResult(string SearchText)
        {
            List<BO.SearchResult> results = new List<BO.SearchResult>();
            results = dashboardBussinesManager.GetSearchResult(SearchText);
            return PartialView(results);
        }

        public ActionResult AccountDashboard()
        {
            return View();
        }

        public ActionResult SalesDashboard()
        {
            int userID = Convert.ToInt16(Session["userid"]);
            int SalesPersonID = Convert.ToInt16(Session["SalesPersonID"]);
            string roleName = Convert.ToString(Session["usertype"]);
            if (roleName == "admin" || roleName == "Administrator")
            {
                ViewBag.RoleUser = "Administrator";
                ViewBag.RoleWiseUserID = 0;
            }
            else if (roleName == "TeamLeader")
            {
                ViewBag.RoleUser = "Administrator";
                ViewBag.RoleWiseUserID = userID;
            }
            else
            {
                ViewBag.RoleUser = "Sales Person";
                ViewBag.RoleWiseUserID = SalesPersonID;
            }
            BO.SalesDashboard sales = dashboardBussinesManager.GetSalesDashboardData(userID, Convert.ToString(Session["LoginType"]));
            List<BO.UserDetail> userDetails = new List<BO.UserDetail>();
            //userDetails = reqBL.GetAssignToDropdownForRequiremnt(userID, Convert.ToString(Session["LoginType"]));
            //ViewBag.UserDetail = new SelectList(userDetails, "ID", "UserName");
            //ViewBag.GraphData = JsonConvert.SerializeObject(sales.Graph);

            //List<BO.DailyVisitReport> tagsData = new List<BO.DailyVisitReport>();
            //tagsData = reqBL.GetTagsCount(userID, Convert.ToString(Session["LoginType"]));
            //ViewBag.TagsDataList = tagsData;
            return View(sales);
        }

        public ActionResult FGBIReport()
        {
            return View();
        }

        public ActionResult FGPurchaseReport()
        {
            return View();
        }

        public ActionResult FGProductionReport()
        {
            return View();
        }
        public ActionResult FGInsightsReport()
        {
            return View();
        }
        public ActionResult FGAnalyticsReport()
        {
            return View();
        }
        //public ActionResult ActivityLogData()
        //{
        //    int userID = Convert.ToInt16(Session["userid"]);
        //    List<BO.UserDetail> AssignToList = reqBL.GetUserDropDownList(userID, Convert.ToString(Session["LoginType"]));
        //    ViewBag.AssignToList = new SelectList(AssignToList, "ID", "UserName");
        //    return View();
        //}

        [HttpPost]
        public ActionResult AjaxGetActivityLogSummary(string FromDate, string ToDate,int UserID)
        {
            int tl_id = Convert.ToInt16(Session["TL_ID"]);
            int sessionID = Convert.ToInt16(Session["userid"]);
            List<BO.ActivityLog> logData = new List<BO.ActivityLog>();
            logData = dashboardBussinesManager.GetActivityLogSummary(FromDate, ToDate, UserID, tl_id, sessionID, Convert.ToString(Session["LoginType"]));
            var jsonResult = Json(logData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }


        public ActionResult FABIReport()
        {
            int userID = Convert.ToInt16(Session["userid"]);
            ViewBag.UserID = userID;

            return View();
        }


    }
}