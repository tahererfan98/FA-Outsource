using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DP = BombayToolBusinessLayer.Login;
using BO = BombayToolsEntities.BusinessEntities;
using BombayTools.Filters;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
using System.Linq;
using System.Diagnostics;

namespace BombayTools.Controllers
{

    //[UserAuthenticationFilter]
    public class HomeController : Controller
    {
        string domainName = System.Web.HttpContext.Current.Request.Url.Authority;

        DP.LoginDataProvider objloginDataProvider = new DP.LoginDataProvider();
        HttpCookie sessionInfo = new HttpCookie("sessionInfo");
        public ActionResult Index()
        {

            BO.UserDetail logindata = new BO.UserDetail();
            string User_name = string.Empty;
            //string User_color = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfoBTC"];

            if (reqCookies != null)
            {
                logindata.UserName = reqCookies["UserName"].ToString();
                logindata.Password = reqCookies["Password"].ToString();
                logindata.rememberme = true;
            }

            return View("index", logindata);
        }

        [HttpPost]
        //[UserAuthenticationFilter]
        public ActionResult Login(BO.UserDetail loginEntities)
        {
            string ProjectFor = "FA";  // Note : Change this name based on project -- "FA" for FA-CRM  and "FG" for FG-CRM 

            var name = loginEntities.UserName;
            var pass = loginEntities.Password;
            var rememberme = loginEntities.rememberme;
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            string mac = nics[0].GetPhysicalAddress().ToString();
            BO.UserDetail logindata = new BO.UserDetail();
            string ip = Request.UserHostAddress;
            
            logindata = objloginDataProvider.LogingetData(name, pass, ip, mac, ProjectFor);
            if (logindata.ID != 0)
            {
                RememberMe(name, pass, rememberme);
                Session["usertype"] = logindata.UserType;
                Session["userid"] = logindata.ID;
                Session["TL_ID"] = logindata.TL_ID;
                Session["mainuserid"] = logindata.ID;
                Session["username"] = logindata.UserName;
                Session["tokenpath"] = logindata.Token;
                Session["toUserType"] = logindata.UserType.Trim();
                Session["UserEmailID"] = logindata.EmailID;
                Session["SalesPersonID"] = logindata.SalesPersonID;
                Session["LoginType"] = logindata.LoginType;
                Session["FullName"] = logindata.FullName;
                Session["Project"] = ProjectFor;
                Session["mode"] = "default";

                //Session["UserImage"] = "temp"; // need to ask

                HttpCookie BombayTool_userCookies = new HttpCookie("BombayTool_userCookies");
                BombayTool_userCookies["usertype"] = Convert.ToString(logindata.UserType);
                BombayTool_userCookies["userid"] = Convert.ToString(logindata.ID);
                BombayTool_userCookies["mainuserid"] = Convert.ToString(logindata.ID);
                BombayTool_userCookies["username"] = logindata.UserName;
                BombayTool_userCookies["mode"] = "default";
                BombayTool_userCookies["toUserType"] = Convert.ToString(logindata.UserType);
                BombayTool_userCookies["UserEmailID"] = logindata.EmailID;
                BombayTool_userCookies["SalesPersonID"] = Convert.ToString(logindata.SalesPersonID);
                BombayTool_userCookies["LoginType"] = Convert.ToString(logindata.LoginType);
                BombayTool_userCookies["FullName"] = Convert.ToString(logindata.FullName);
                BombayTool_userCookies["Project"] = ProjectFor;
                
                Response.Cookies.Add(BombayTool_userCookies);
                if (((string)Session["LoginType"]) == "FAGlass")
                {

                    if (((string)Session["usertype"]) != "" && ((string)Session["usertype"]) != null && ((string)Session["usertype"]) != "Staff")
                    {
                        return RedirectToAction("SalesDashboard", "Dashboard");
                    }
                    //else if (((string)Session["usertype"]) == "Staff")
                    //{
                    //    return RedirectToAction("CustomerDesk", "CustomerDesk");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("ApprovalPending", "User");
                    //}

                }
                else
                {
                    if (((string)Session["usertype"]) == "admin" || ((string)Session["usertype"]) == "HR")
                    {
                        return RedirectToAction("SalesDashboard", "Dashboard");
                    }
                    //else if (((string)Session["usertype"]) == "NewUser")
                    //{
                    //    return RedirectToAction("ChangeUserPassword", "User");
                    //}
                    //else if (((string)Session["usertype"]) == "UnVerified")
                    //{
                    //    return RedirectToAction("NewEmployee", "EmployeeManagement");
                    //}
                    //else if (((string)Session["usertype"]) == "PendingApproval")
                    //{
                    //    return RedirectToAction("NewEmployee", "EmployeeManagement");
                    //}
                    //else if (((string)Session["usertype"]) == "SalesPerson" || ((string)Session["usertype"]) == "SalesCordinator" || ((string)Session["usertype"]) == "TeamLeader")
                    //{
                    //    return RedirectToAction("SalesDashboard", "Dashboard");
                    //}
                    //else if (((string)Session["usertype"]) == "Account" || ((string)Session["usertype"]) == "Account")
                    //{
                    //    return RedirectToAction("AccountDashboard", "Dashboard");
                    //}
                    //else if (((string)Session["usertype"]) == "Staff")
                    //{
                    //    return RedirectToAction("CustomerDesk", "CustomerDesk");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("ApprovalPending", "User");
                    //}

                }

                return RedirectToAction("SalesDashboard", "Dashboard");
            }

            else
            {
                logindata.LoginErrorMessage = "Wrong Username or Password.";

                return View("index", logindata);
            }


            ///you can use int txtId  here 
        }

        public ActionResult logout()
        {
            if (Request.Cookies["BombayTool_userCookies"] != null)
            {
                var c = new HttpCookie("BombayTool_userCookies");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }


        private void RememberMe(String name, String password, Boolean rememberme)
        {

            if (rememberme)
            {
                HttpCookie userInfo = new HttpCookie("userInfoBTC");
                userInfo["UserName"] = name;
                userInfo["Password"] = password;
                userInfo.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(userInfo);

            }
            else
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userInfo);
            }



        }

        [UserAuthenticationFilter]
        //public ActionResult SideMenu()
        //{
        //    List<BO.SubmenuInfo> MenuList = new List<BO.SubmenuInfo>();
        //    if (((string)Session["username"]) == "admin")
        //    {

        //        List<BO.SubmenuInfo> AdminMenuList = new List<BO.SubmenuInfo>();
        //        AdminMenuList = objloginDataProvider.AdminMenuList();
        //        Session["MenuList"] = AdminMenuList;
        //        return PartialView("SideMenu", AdminMenuList);

        //    }
        //    else 
        //    {
        //        string toUserType = "-";
        //        int SessionuserID = Convert.ToInt32(Session["userid"]);
        //        MenuList = objloginDataProvider.UserMenuList(toUserType, SessionuserID);
        //        Session["MenuList"] = MenuList;
        //        return PartialView("SideMenu", MenuList);
        //    }

        //    //return PartialView("SideMenu", MenuList);
        //}

        public ActionResult SideMenu()
        {
            List<BO.SubmenuInfo> MenuList = new List<BO.SubmenuInfo>();
            
            string toUserType = "-";
            int userid = Convert.ToInt32(Session["userid"]);
            MenuList = objloginDataProvider.UserMenuListNew(userid, Convert.ToString(Session["LoginType"]));
            Session["MenuList"] = MenuList;
            return PartialView("SideMenu", MenuList);

            //return PartialView("SideMenu", MenuList);
        }

        public ActionResult GetSubMenuForSelectedUser(string id)
        {
            if(id == "admin")
            {
                Session["mode"] = null;

            }
            else
            {
                Session["mode"] = "inspect";

            }
            Session["toUserType"] = id;
            return Json(id);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestRestPassword(BO.UserDetail loginEntities)
        {
            try
            {
                BO.ResponseMessage response = objloginDataProvider.RequestRestPassword(loginEntities.EmailID, Convert.ToString(Session["LoginType"]));
                if (response.Status != 0)
                {

                    //string link = " https://crm.thebombaytools.com:8443" +
                    string link = domainName + "/home/resetpassword?Token=" + response.Data;
                    //string link = " http://localhost:44951//home/resetpassword?Token=" + response.Data;
                    link = "<div style='margin:20px;'>Please find the password reset link below <br>" + link + " </div>";
                    string from = "do-not-reply@faglass.com";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(loginEntities.EmailID));  // replace with valid value 
                    message.From = new MailAddress(from);  // replace with valid value
                    message.Subject = "Reset Password";
                    message.Body = link;
                    message.IsBodyHtml = true;
                   
                    using (MailMessage mail = new MailMessage(from, loginEntities.EmailID))
                    {
                        mail.To.Add(new MailAddress(loginEntities.EmailID));  // replace with valid value 
                        mail.From = new MailAddress(from);  // replace with valid value
                        mail.Subject = "Reset Password";
                        mail.Body = link;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.office365.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "etisalat@1234");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        smtp.Send(mail);
                    }
                    
                    loginEntities.LoginErrorMessage = response.Message;

                    return View("ForgotPassword", loginEntities);
                }
                else
                {
                    loginEntities.LoginErrorMessage = response.Message;

                    return View("ForgotPassword", loginEntities);
                }

            }
            catch (Exception ex)
            {
                loginEntities.LoginErrorMessage = ex.Message;

                return View("ForgotPassword", loginEntities);
            }
        }
        public ActionResult ResetPassword(string Token)
        {
            BO.ResponseMessage response = new BO.ResponseMessage();
            try
            {
                response = objloginDataProvider.CheckTokenValidity(Token, Convert.ToString(Session["LoginType"]));
                ViewBag.Status = response.Status;
                ViewBag.Token = response.Data;
                ViewBag.Message = response.Message;
                return View();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 0;
                response.Data = "-";
                return View();
            }

        }
        [HttpPost]
        public ActionResult AjaxSetNewPassword(BO.UserDetail loginEntities)
        {
            try
            {
                BO.ResponseMessage response = objloginDataProvider.SetNewPassword(loginEntities, Convert.ToString(Session["LoginType"]));

                return View("Index", loginEntities);


            }
            catch (Exception ex)
            {
                loginEntities.LoginErrorMessage = ex.Message;

                return Json(loginEntities);
            }
        }

        
        //public ActionResult Notication()
        //{
        //    int UserID = Convert.ToInt16(Session["userid"]);
        //    //List<BO.NotificationData> data = objloginDataProvider.GetNotification(UserID);
        //    //ViewBag.Count = data.Count();

        //    List<BO.DailyVisitReport> tagsData = new List<BO.DailyVisitReport>();
        //    tagsData = reqBL.GetTagsCount(UserID, Convert.ToString(Session["LoginType"]));
        //    ViewBag.TagsDataList = tagsData;
        //    ViewBag.Count = tagsData.Count;
        //    return PartialView();
        //    //return PartialView(data);
        //}

        [HttpPost]
        public JsonResult AjaxMarkAsReadNotification(int ID)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            BO.ResponseMessage message = objloginDataProvider.MarkAsReadNotification(ID,UserID, Convert.ToString(Session["LoginType"]));
            return Json(message);
        }


        [HttpPost]
        public ActionResult AjaxSaveMenuLogDetails(int MenuID, int SubMenuID, string RedirectView)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            string mac = nics[0].GetPhysicalAddress().ToString();
            string ip = Request.UserHostAddress;
            int AddedBy = Convert.ToInt16(Session["userid"]);
            DateTime AddedOn = DateTime.Now;
            try
            {
                message = objloginDataProvider.SaveMenuLogDetails(MenuID, SubMenuID, RedirectView, ip, mac, AddedBy, Convert.ToString(Session["LoginType"]));
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                //Error Log Code
                var st = new StackTrace();
                var sf = st.GetFrame(0);
                var currentMethodName = sf.GetMethod();
                string Name = currentMethodName.Name;
                string Controller = currentMethodName.ReflectedType.Namespace;
                string errorLocation = "Controller: " + Controller + ". ActionName: " + Name;
                addErrorLogDetails(AddedBy, AddedOn, errorLocation, ex.Message);
            }
            return Json(message);
        }

        private void addErrorLogDetails(int addedBy, DateTime addedOn, string errorLocation, string message)
        {
            throw new NotImplementedException();
        }
    }
}