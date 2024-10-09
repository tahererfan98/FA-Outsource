using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.Sql;
using BO = BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer;
using HDB = BombayToolsDataLayer.Home;
using BombayToolsEntities.BusinessEntities;

namespace BombayToolBusinessLayer.Login
{
    public class LoginDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();

        //public BO.UserDetail LogingetData(string name, string pass, string ip, string mac)
        //{
        //    DataTable loginData = new DataTable();
        //    loginData = BTdatamanager.getLogin(name, pass, ip, mac);
        //    BO.UserDetail objloginentities = new BO.UserDetail();
        //    if (loginData.Rows.Count > 0)
        //    {

        //        foreach (DataRow row in loginData.Rows)
        //        {
        //            objloginentities.ID = Convert.ToInt32(row["ID"]);
        //            objloginentities.SalesPersonID = Convert.ToInt32(row["SalesPersonID"]);
        //            objloginentities.UserName = Convert.ToString(row["UserName"]);
        //            objloginentities.UserType = Convert.ToString(row["UserType"]);
        //            objloginentities.Token = Convert.ToString(row["Token"]);
        //            objloginentities.EmailID = Convert.ToString(row["UserEmail"]);
        //        }
        //    }
        //    return objloginentities;
        //}
        
        public BO.UserDetail LogingetData(string name, string pass, string ip, string mac, string ProjectFor)
        {
            DataTable loginData = new DataTable();
            loginData = BTdatamanager.getLogin(name, pass,ip, mac, ProjectFor);
            BO.UserDetail objloginentities = new BO.UserDetail();
            if (loginData.Rows.Count > 0)
            {
                foreach (DataRow row in loginData.Rows)
                {
                    objloginentities.ID = Convert.ToInt32(row["ID"]);
                    objloginentities.SalesPersonID = Convert.ToInt32(row["SalesPersonID"]);
                    objloginentities.TL_ID = Convert.ToInt32(row["TL_ID"]);
                    objloginentities.UserName = Convert.ToString(row["UserName"]);
                    objloginentities.UserType = Convert.ToString(row["UserType"]);
                    objloginentities.Token = Convert.ToString(row["Token"]);
                    objloginentities.EmailID = Convert.ToString(row["UserEmail"]);
                    objloginentities.DepType = Convert.ToString(row["DepType"]);
                    objloginentities.LoginType = Convert.ToString(row["LoginType"]);
                    objloginentities.FullName = Convert.ToString(row["FullName"]);
                }
            }
            return objloginentities;
        }

       

        public List<BO.SubmenuInfo> AdminMenuList()
        {
            //Your implementation logic
            List<BO.SubmenuInfo> MenuList = new List<BO.SubmenuInfo>();
            DataTable MenurDL = new DataTable();
            MenurDL = BTdatamanager.getAdminMenuList();

            if (MenurDL != null)
            {
                foreach (DataRow row in MenurDL.Rows)
                {
                    BO.SubmenuInfo MenuInfoList = new BO.SubmenuInfo();
                    MenuInfoList.MenuID = Convert.ToInt16(row["MenuID"]);
                    MenuInfoList.MenuText = Convert.ToString(row["MenuName"]);
                    MenuInfoList.ParentID = Convert.ToInt16(row["ParentID"]);
                    MenuInfoList.ControllerName = Convert.ToString(row["Controller"]);
                    MenuInfoList.Action = Convert.ToString(row["Action"]);
                    MenuInfoList.menuIcon = Convert.ToString(row["Icon"]);
                    MenuList.Add(MenuInfoList);
                }
            }
            return MenuList;
        }

        public List<BO.SubmenuInfo> UserMenuList(string toUserType, int sessionuserID)
        {
            List<BO.SubmenuInfo> MenuList = new List<BO.SubmenuInfo>();
            DataTable MenurDL = new DataTable();
            MenurDL = BTdatamanager.getMenuList(toUserType, sessionuserID);

            if (MenurDL != null)
            {
                foreach (DataRow row in MenurDL.Rows)
                {
                    BO.SubmenuInfo MenuInfoList = new BO.SubmenuInfo();
                    MenuInfoList.MenuID = Convert.ToInt16(row["MenuID"]);
                    MenuInfoList.MenuText = Convert.ToString(row["MenuName"]);
                    MenuInfoList.ParentID = Convert.ToInt16(row["ParentID"]);
                    MenuInfoList.ControllerName = Convert.ToString(row["Controller"]);
                    MenuInfoList.Action = Convert.ToString(row["Action"]);
                    MenuInfoList.menuIcon = Convert.ToString(row["Icon"]);
                    MenuList.Add(MenuInfoList);
                }
            }
            return MenuList;
        }
        public List<BO.SubmenuInfo> UserMenuListNew(int userid, string logType)
        {
            List<BO.SubmenuInfo> MenuList = new List<BO.SubmenuInfo>();
            DataTable MenurDL = new DataTable();
            MenurDL = BTdatamanager.getMenuListNew(userid, logType);

            if (MenurDL != null)
            {
                foreach (DataRow row in MenurDL.Rows)
                {
                    BO.SubmenuInfo MenuInfoList = new BO.SubmenuInfo();
                    MenuInfoList.MenuID = Convert.ToInt16(row["MenuID"]);
                    MenuInfoList.SubMenu_ID = Convert.ToInt32(row["SubMenu_ID"]);
                    MenuInfoList.MenuText = Convert.ToString(row["MenuName"]);
                    MenuInfoList.ParentID = Convert.ToInt16(row["ParentID"]);
                    MenuInfoList.ControllerName = Convert.ToString(row["Controller"]);
                    MenuInfoList.Action = Convert.ToString(row["Action"]);
                    MenuInfoList.menuIcon = Convert.ToString(row["Icon"]);
                    MenuList.Add(MenuInfoList);
                }
            }
            return MenuList;
        }
        public BO.ResponseMessage RequestRestPassword(string emailID, string LogType)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();

            try
            {
                DataTable dt = new DataTable();
                dt = BTdatamanager.RequestRestPassword(emailID.Trim(), LogType);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                        message.Data = Convert.ToString(row["Data"]);
                    }

                }
                return message;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Status = 0;
                return message;
            }
        }

        public BO.ResponseMessage CheckTokenValidity(string token, string LogType)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();

            try
            {
                DataTable dt = new DataTable();
                dt = BTdatamanager.CheckTokenValidity(token.Trim(), LogType);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                        message.Data = Convert.ToString(row["Data"]);
                    }

                }
                return message;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Status = 0;
                return message;
            }
        }
        public BO.ResponseMessage SetNewPassword(BO.UserDetail data, string logType)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();

            try
            {
                DataTable dt = new DataTable();
                dt = BTdatamanager.SetNewPassword(data.Token, data.Password, logType);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                    }

                }
                return message;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Status = 0;
                return message;
            }
        }

        public List<BO.NotificationData> GetNotification(int userID)
        {

            try
            {
                List<BO.NotificationData> notifications =new List<BO.NotificationData>();
                DataTable dt = new DataTable();
                dt = BTdatamanager.GetNotification(userID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BO.NotificationData message = new BO.NotificationData();
                        message.NotificationID = Convert.ToInt32(row["AutoID"]);
                        message.NoticiationData = Convert.ToString(row["Note"]);
                        message.NoticiationTitle = Convert.ToString(row["NotificationType"]);
                        message.DependentID = Convert.ToInt32(row["DependentID"]);
                        message.Datetime = Convert.ToString(row["AddedOn"]);
                        message.URL = Convert.ToString(row["URL"]);
                        notifications.Add(message);
                    }

                }
                return notifications;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BO.ResponseMessage MarkAsReadNotification(int iD, int userID, string logType)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                DataTable dt = new DataTable();
                dt = BTdatamanager.MarkAsReadNotification(iD, userID, logType);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                    }

                }
                return message;
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.Status = 0;
                return message;
            }
        }

        public void addErrorLogDetails(int userID, DateTime errorDate, string errorLocation, string errorDetails)
        {
            HDB.HomeDBManager dBManager = new HDB.HomeDBManager();
            dBManager.addErrorLogDetails(userID,errorDate,errorLocation,errorDetails);
        }

        public ResponseMessage SaveMenuLogDetails(int menuID, int subMenuID, string redirectView, string ip, string mac, int addedBy, string logType)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = BTdatamanager.SaveMenuLogDetails(menuID, subMenuID, redirectView, ip,mac, addedBy, logType);
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }
    }
}
