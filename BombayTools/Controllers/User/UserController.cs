using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO = BombayToolsEntities.BusinessEntities;
using DBView = BombayToolBusinessLayer.User;
using System.Net.Mail;
using System.Net;
using System.Data;
using BombayTools.Filters;
using Newtonsoft.Json;

namespace BombayTools.Controllers.User
{
    [UserAuthenticationFilter]
    public class UserController : Controller
    {
        // GET: User
        DBView.UserDataProvider dashboardBussinesManager = new DBView.UserDataProvider();
        //NEW USER
        public ActionResult UserSummary()
        {
            List<BO.User> UserList = new List<BO.User>();
            UserList = dashboardBussinesManager.GetUserSummary();
            return View(UserList.ToList());
        }

        public ActionResult CreateNewUser()
        {
            return View();
        }

        //save new user and send email
        [HttpPost]
        public ActionResult AddNewUser(BO.User data)
        {
            data.AddedBy = Convert.ToInt16(Session["userid"]);
            int i = dashboardBussinesManager.AddNewUserDetail(data);
            string from = "phoenixtechnosoftkreation@gmail.com";
            using (MailMessage mail = new MailMessage(from, data.UserEmail))
            {
                mail.Subject = "BombayTool ERP credentials";
                mail.Body = data.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "phoenix@kumar");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
                return Json(data);
        }

        //Verify User Screen
        public ActionResult ChangeUserPassword()
        {
            return View();
        }

        public ActionResult UserDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(BO.User data)
        {
            data.ID = Convert.ToInt16(Session["userid"]);
            data.ModifiedBy = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.ChangePassword(data);
            return Json(message);
        }

        public ActionResult ApprovalPending()
        {
            return View();
        }

        //public ActionResult SelectedUserDetails(int ID)
        //{
        //    BO.Employee data = new BO.Employee();
        //    data = employeeManagement.GetUnverifiedUserDetail(ID);
        //    ViewBag.FullName = data.Emp_Name;
        //    ViewBag.EmployeeID = data.EmployeeID;
        //    ViewBag.CurrentAddress = data.Emp_CurrentAddress;
        //    ViewBag.MobileNo = data.Emp_MobileNo;
        //    ViewBag.datePicker = data.DateOfBirth;
        //    ViewBag.BloodGroup = data.BloodGroup;
        //    ViewBag.CurrentlyLivingWith = data.Currently_LivingWith;
        //    ViewBag.FatherName = data.Emp_FatherName;
        //    ViewBag.MotherName = data.Emp_MotherName;
        //    ViewBag.BrotherSister = data.Emp_BrotherSister;
        //    ViewBag.ContactNumber = data.Parent_ContNo;
        //    ViewBag.ParentAddress = data.ParentAddress;
        //    ViewBag.PermanantAddress = data.VillageAddress;
        //    ViewBag.EmergencyContact = data.EmergencyContact;
        //    ViewBag.EducationQualification = data.EducationQualification;
        //    ViewBag.OtherCertification = data.OtherCertification;
        //    ViewBag.EmployeeDeviceID = data.EmployeeDeviceID;
        //    ViewBag.SpouseName = data.SpouseName;
        //    ViewBag.Gender = data.Gender;
        //    ViewBag.Email = data.Email;
        //    return PartialView();
        //}

        public ActionResult PendingApprovalSummary()
        {
            List<BO.User> UserList = new List<BO.User>();
            UserList = dashboardBussinesManager.GetPendingApprovalSummary();
            return PartialView(UserList.ToList());
        }

        [HttpPost]
        public ActionResult ChangeApprovalStatus(BO.User data)
        {
            int i = dashboardBussinesManager.ChangeApprovalStatus(data);
            TempData["AssignRoleForID"] = data.ID;
            return Json(i);
        }

        [HttpPost]
        public ActionResult StoreTempDateForUser(BO.User data)
        {
            TempData["AssignRoleForID"] = data.ID;
            return Json(data.ID);
        }


        public ActionResult AssignRoleForUser(BO.User data)
        {
            int ID = Convert.ToInt32(TempData["AssignRoleForID"]);
            List<BO.Role> RoleList = new List<BO.Role>();
            RoleList = dashboardBussinesManager.GetRoleList();
            ViewBag.ddlRoleDropdown = new SelectList(RoleList, "RoleID", "RoleName");
            BO.AssignMenu menu = dashboardBussinesManager.GetAllMenuAndSubMenu(ID);
            ViewBag.UserName = menu.user.UserName;
            ViewBag.Email = menu.user.UserEmail;
            ViewBag.UserID = menu.user.ID;
            ViewBag.RoleID = menu.user.RoleID;
            List<BO.SubmenuInfo> menuList = new List<BO.SubmenuInfo>();
            menuList = menu.menuList;
            return View(menuList.ToList());
        }

        [HttpPost]
        public ActionResult AssignRoleAndMenu(List<BO.SubmenuInfo> ListObject, BO.User User)
        {
            string message = "";
            User.AddedBy = Convert.ToInt32(Session["userid"]);
            User.ModifiedBy = Convert.ToInt32(Session["userid"]);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Status");
            dataTable.TableName = "PT_Role_Wise_Menu";
            foreach (BO.SubmenuInfo item in ListObject)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = item.ID;
                row["Status"] = item.Status;
                dataTable.Rows.Add(row);
            }
            message = dashboardBussinesManager.AssignRoleAndMenu(dataTable, User);
            string from = "phoenixtechnosoftkreation@gmail.com";
            User.Body = "Your user rights have been updated by " + Convert.ToString(Session["username"]) + ". Please login to check for details.";
            using (MailMessage mail = new MailMessage(from, User.UserEmail))
            {
                mail.Subject = "FG: User Rights & Role";
                mail.Body = User.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "phoenix@kumar");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            return Json(message);
        }

        [HttpPost]
        public ActionResult DeclineUserForm(BO.Recieved_Emails element, int ID)
        {
            string message;
            string from = "phoenixtechnosoftkreation@gmail.com";
            using (MailMessage mail = new MailMessage(from, element.FromEmail))
            {
                mail.Subject = element.Subject;
                mail.Body = element.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "phoenix@kumar");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            message = dashboardBussinesManager.DeclineUserForm(ID);
                return Json(message);
        }
        [HttpPost]
        public ActionResult DeleteUser(int UserID)
        {
            int AddedBy = Convert.ToInt16(Session["userid"]);        
            string message = dashboardBussinesManager.DeleteUser( UserID,  AddedBy);
            return Json(message);
        }

        public ActionResult SwitchUserControl()
        {
            List<BO.User> UserList = new List<BO.User>();
            UserList = dashboardBussinesManager.GetUserSummary();
            ViewBag.List = JsonConvert.SerializeObject(UserList);
            return View(UserList);
        }

        public ActionResult NavigationMode()
        {
            return View();
        }

        public ActionResult AjaxSetUserDataForUserControl(BO.UserDetail User)
        {
            int CurrentUserID = Convert.ToInt32(Session["mainuserid"]); 
            string CurrentUserMode = Convert.ToString(Session["mode"]);

            if(CurrentUserID == User.ID)
            {
                BO.UserDetail data = dashboardBussinesManager.GetUserDataForControl(CurrentUserID);
                Session["usertype"] = data.UserType;
                Session["userid"] = data.ID;
                Session["mainuserid"] = CurrentUserID;
                Session["username"] = data.UserName;
                Session["tokenpath"] = data.Token;

                Session["mode"] = "default";
                Session["UserEmailID"] = data.EmailID;

                HttpCookie BombayTool_userCookies = new HttpCookie("BombayTool_userCookies");

                BombayTool_userCookies["usertype"] = Convert.ToString(data.UserType);
                BombayTool_userCookies["userid"] = Convert.ToString(data.ID);
                BombayTool_userCookies["mainuserid"] = Convert.ToString(data.ID);
                BombayTool_userCookies["username"] = data.UserName;
                BombayTool_userCookies["mode"] = "default";
                BombayTool_userCookies["toUserType"] = Convert.ToString(data.UserType);
                BombayTool_userCookies["UserEmailID"] = data.EmailID;
            }
            else
            {
                User = dashboardBussinesManager.GetUserDataForControl(User.ID);
                Session["usertype"] = User.UserType;
                Session["userid"] = User.ID;
                Session["mainuserid"] = CurrentUserID;
                Session["username"] = User.UserName;
                Session["tokenpath"] = User.Token;

                Session["mode"] = "navigation";
                Session["UserEmailID"] = User.EmailID;

                HttpCookie BombayTool_userCookies = new HttpCookie("BombayTool_userCookies");

                BombayTool_userCookies["usertype"] = Convert.ToString(User.UserType);
                BombayTool_userCookies["userid"] = Convert.ToString(User.ID);
                BombayTool_userCookies["mainuserid"] = Convert.ToString(User.ID);
                BombayTool_userCookies["username"] = User.UserName;
                BombayTool_userCookies["mode"] = "navigation";
                BombayTool_userCookies["toUserType"] = Convert.ToString(User.UserType);
                BombayTool_userCookies["UserEmailID"] = User.EmailID;

            }

            return Json("");
        }


        public ActionResult RoleWiseMenuMappingSummary()
        {
            List<BO.Role> RoleList = new List<BO.Role>();
            RoleList = dashboardBussinesManager.GetRoleList();
            return View(RoleList.ToList());
        }

        public ActionResult AddRoleWiseMenu(int RoleID,string RoleName)
        {
            ViewBag.RoleID = RoleID;
            ViewBag.RoleName = RoleName;
            List<BO.SubmenuInfo> menuList = new List<BO.SubmenuInfo>();
            menuList = dashboardBussinesManager.GetRoleWiseMenu(RoleID);
            return View(menuList.ToList());
        }

        public ActionResult AjaxSaveRoleWiseMenuMapping(List<BO.SubmenuInfo> ListObject, BO.Role role)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Status");
            dataTable.TableName = "PT_Role_Wise_Menu";
            foreach (BO.SubmenuInfo item in ListObject)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = item.ID;
                row["Status"] = item.Status;
                dataTable.Rows.Add(row);
            }
            int AddedBy = Convert.ToInt32(Session["userid"]);
            message = dashboardBussinesManager.AjaxSaveRoleWiseMenuMapping(role, dataTable);
            return Json(message);
        }

        public JsonResult getAssignedMenuForRole(int ID)
        {
            List<BO.SubmenuInfo> menuList = new List<BO.SubmenuInfo>();
            menuList = dashboardBussinesManager.GetRoleWiseMenu(ID);
            return Json(menuList);
        }

        //User Rights Option
        public ActionResult UserRightSummary()
        {
            List<BO.Users> userList = new List<BO.Users>();
            userList = dashboardBussinesManager.GetUserListForRights(Convert.ToString(Session["LoginType"]));
            ViewBag.UserArray = JsonConvert.SerializeObject(userList);
            return View(userList);
        }
        public PartialViewResult _AssignUserRights(int UserID)
        {
            ViewBag.UserID = UserID;
            BO.Users data = dashboardBussinesManager.GetAllMenuAndSubMenuRights(UserID, Convert.ToString(Session["LoginType"]));
            List<BO.Users> menuList = new List<BO.Users>();
            menuList = data.SubMenuList;
            return PartialView(menuList.ToList());
        }
        public ActionResult AssignRightsAndMenu(List<BO.Users> ListObject, List<BO.Users> SideMenus, BO.Users User)
        {
            string message = "";
            User.AddedBy = Convert.ToInt32(Session["userid"]);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Status");

            dataTable.TableName = "PT_User_Wise_Menu_Rights";
            foreach (BO.Users item in ListObject)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = item.ID;
                row["Status"] = item.Status;
                dataTable.Rows.Add(row);
            }
            DataTable dataMenu = new DataTable();
            dataMenu.Columns.Add("ID");
            dataMenu.Columns.Add("MenuID");
            dataMenu.Columns.Add("Status");
            dataMenu.TableName = "PT_User_Wise_MainMenu_Rights";
            foreach (BO.Users Menu in SideMenus)
            {
                DataRow Row = dataMenu.NewRow();
                Row["ID"] = Menu.ID;
                Row["MenuID"] = Menu.MenuID;
                Row["Status"] = Menu.Status;
                dataMenu.Rows.Add(Row);
            }
            message = dashboardBussinesManager.AssignRightsAndMenu(dataTable, dataMenu, User, Convert.ToString(Session["LoginType"]));

            return Json(message);
        }
        //End For User Rights Option

    }
}