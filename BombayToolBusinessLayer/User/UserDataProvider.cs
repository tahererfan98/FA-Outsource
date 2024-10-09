using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = BombayToolsEntities.BusinessEntities;
using DF = BombayToolsDataLayer.SelectFilter;
using DB = BombayToolsDataLayer;
using System.Data;
using UDB = BombayToolsDataLayer.User;

namespace BombayToolBusinessLayer.User
{
    public class UserDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
        DF.DBOperationForSelectFilter obj = new DF.DBOperationForSelectFilter();

        public int AddNewUserDetail(BO.User data)
        {
            int i = BTdatamanager.AddNewUserDetail(data.UserName,data.UserEmail,data.UserPassword,data.DateOfJoining,data.AddedOn,data.AddedBy);
            return i;
        }

        public List<BO.User> GetUserSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetUserSummary();
                List<BO.User> dataBL = new List<BO.User>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.User data = new BO.User();
                        i++;
                        data.index = i;
                        data.ID = Convert.ToInt32(row["ID"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.UserEmail = Convert.ToString(row["UserEmail"]);
                        data.Role = Convert.ToString(row["Role"]);
                        data.RoleID = Convert.ToInt32(row["EmployeeID"]);
                        data.Status = Convert.ToBoolean(row["Status"]);
                        data.DisplayDateofJoining = Convert.ToString(row["DisplayDateofJoining"]);
                        data.LastLogin = (Convert.ToDateTime(row["LastLogin"])).ToString("dd-MMM-yyyy HH:mm:ss");
                        data.AddedByName = Convert.ToString(row["AddedByName"]);
                        data.AddedOnDate = Convert.ToString(row["AddedOnDate"]);
                        data.EmployeeName = Convert.ToString(row["Emp_Name"]); 


                        dataBL.Add(data);
                    }
                }
                return dataBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ChangePassword(BO.User data)
        {
            string message = "";
            int i = BTdatamanager.ChangePassword(data.ID, data.UserPassword, data.ModifiedBy, data.ModifiedOn);
            if (i != 0)
            {
                message = "Password Changed Successfully. Login again with new password to continue";
            }
            else { message = "Something went wrong";
            }
            return message;
        }

        public List<BO.User> GetPendingApprovalSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetPendingApprovalSummary();
                List<BO.User> dataBL = new List<BO.User>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.User data = new BO.User();
                        i++;
                        data.index = i;
                        data.ID = Convert.ToInt32(row["ID"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.UserEmail = Convert.ToString(row["UserEmail"]);
                        data.Status = Convert.ToBoolean(row["Status"]);
                        data.DisplayDateofJoining = Convert.ToString(row["DisplayDateofJoining"]);
                        data.AddedByName = Convert.ToString(row["AddedByName"]);
                        data.AddedOnDate = Convert.ToString(row["AddedOnDate"]);
                        dataBL.Add(data);
                    }
                }
                return dataBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangeApprovalStatus(BO.User data)
        {
            int i = BTdatamanager.ChangeApprovalStatus(data.ID);
            return i;
        }

        public List<BO.Role> GetRoleList()
        {
            List<BO.Role> RoleList = new List<BO.Role>();
            DataTable RoleDL = new DataTable();
            RoleDL = obj.GetRoleList();
            int i = 1;
            if (RoleDL != null)
            {
                foreach (DataRow row in RoleDL.Rows)
                {
                    BO.Role RoleData = new BO.Role();
                    RoleData.SrNo = i++;
                    RoleData.RoleID = Convert.ToInt32(row["RoleID"]);
                    RoleData.RoleName = Convert.ToString(row["RoleName"]);

                    RoleList.Add(RoleData);
                }
            }
            return RoleList;
        }

        public BO.AssignMenu GetAllMenuAndSubMenu(int ID)
        {
            DataSet Stats = new DataSet();
            Stats = BTdatamanager.GetAllMenuAndSubMenu(ID);
            DataTable SubMenuDL = new DataTable();
            DataTable UserDL = new DataTable();
            BO.User userBL = new BO.User();
            List<BO.SubmenuInfo> SubMenuBL = new List<BO.SubmenuInfo>();

            SubMenuDL = Stats.Tables[1];
            UserDL = Stats.Tables[0];
            if (UserDL.Rows.Count != 0)
            {
                foreach (DataRow row in UserDL.Rows)
                {
                    userBL.ID = Convert.ToInt32(row["ID"]);
                    userBL.RoleID = Convert.ToInt32(row["RoleID"]);
                    userBL.UserName = Convert.ToString(row["UserName"]);
                    userBL.UserEmail = Convert.ToString(row["EmailID"]);
                }
            }
            if (SubMenuDL.Rows.Count != 0)
            {
                foreach (DataRow row in SubMenuDL.Rows)
                {
                    BO.SubmenuInfo SubMenu = new BO.SubmenuInfo();
                    SubMenu.MenuID = Convert.ToInt32(row["ID"]);
                    SubMenu.Description = Convert.ToString(row["MenuName"]);
                    SubMenu.SubMenu = Convert.ToString(row["SubMenu"]);
                    SubMenu.SubMenuID = Convert.ToString(row["SubMenuID"]);
                    SubMenu.Priority = Convert.ToInt32(row["Count"]);
                    SubMenu.IsActive = Convert.ToBoolean(row["IsAccess"]);
                    SubMenuBL.Add(SubMenu);
                }
            }

            BO.AssignMenu DataBL = new BO.AssignMenu();
            DataBL.user = userBL;
            DataBL.menuList = SubMenuBL;
            return DataBL;
        }

        public string AssignRoleAndMenu(DataTable dataTable, BO.User user)
        {
            string Message = "";
            BombayToolsDBConnector.Helper.DBOperationsForBombayTools db = new BombayToolsDBConnector.Helper.DBOperationsForBombayTools();

            Dictionary<object, object> parameterList = new Dictionary<object, object>();
            //Master
            parameterList.Add("UserID", user.ID);
            parameterList.Add("RoleID", user.RoleID);
            parameterList.Add("ModifiedBy", user.ModifiedBy);
            parameterList.Add("ModifiedOn", user.ModifiedOn);
            int i = db.sub_ExecuteNonQuery_AssignRoleAndMenu("USP_AssignRoleAndMenu", parameterList, dataTable);

            Message = "Role Updated successfully";
            return Message;
        }

        public string DeclineUserForm(int ID)
        {
            string message = "";
            int i = BTdatamanager.DeclineUserForm(ID);
            if(i != 0)
            {
                message = "Record updated successfully!";
            }
            return message;
        }

        public string DeleteUser(int UserID, int AddedBy)
        {

            try
            {
                string success = "User deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteUser(UserID, AddedBy);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.TargetMonthWise> getTargetForSelectedUser(int employeeID, int year)
        {
            throw new NotImplementedException();
        }

        public BO.UserDetail GetUserDataForControl(int userID)
        {
            DataTable loginData = new DataTable();
            loginData = BTdatamanager.GetUserDataForControl(userID);
            BO.UserDetail objloginentities = new BO.UserDetail();
            if (loginData.Rows.Count > 0)
            {

                foreach (DataRow row in loginData.Rows)
                {
                    objloginentities.ID = Convert.ToInt32(row["ID"]);
                    objloginentities.UserName = Convert.ToString(row["UserName"]);
                    objloginentities.UserType = Convert.ToString(row["UserType"]);
                    objloginentities.Token = Convert.ToString(row["Token"]);
                    objloginentities.EmailID = Convert.ToString(row["EmailID"]);
                }
            }
            return objloginentities;
        }

        public List<BO.SubmenuInfo> GetRoleWiseMenu(int roleID)
        {
            DataTable SubMenuDL = new DataTable();
            SubMenuDL = BTdatamanager.GetRoleWiseMenu(roleID);
            List<BO.SubmenuInfo> SubMenuBL = new List<BO.SubmenuInfo>();
            if (SubMenuDL.Rows.Count != 0)
            {
                foreach (DataRow row in SubMenuDL.Rows)
                {
                    BO.SubmenuInfo SubMenu = new BO.SubmenuInfo();
                    SubMenu.MenuID = Convert.ToInt32(row["ID"]);
                    SubMenu.Description = Convert.ToString(row["MenuName"]);
                    SubMenu.SubMenu = Convert.ToString(row["SubMenu"]);
                    SubMenu.SubMenuID = Convert.ToString(row["SubMenuID"]);
                    SubMenu.Priority = Convert.ToInt32(row["Count"]);
                    SubMenu.IsActive = Convert.ToBoolean(row["IsAccess"]);
                    SubMenuBL.Add(SubMenu);
                }
            }
            return SubMenuBL;
        }

        public BO.ResponseMessage AjaxSaveRoleWiseMenuMapping(BO.Role role, DataTable dataTable)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                UDB.UserBDManager dataProvider = new UDB.UserBDManager();
                DataTable data = new DataTable();
                data = dataProvider.AjaxSaveRoleWiseMenuMapping(role,dataTable);
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
            }
            return message;
        }

        //User Rights Option
        DB.User.UserBDManager DBManager = new DB.User.UserBDManager();
        public List<BO.Users> GetUserListForRights(string logType)
        {
            List<BO.Users> CompanyUserList = new List<BO.Users>();
            DataTable companySummaryDL = new DataTable();
            companySummaryDL = DBManager.GetUserListForRights(logType);
            if (companySummaryDL != null)
            {
                int Count = 0;
                foreach (DataRow row in companySummaryDL.Rows)
                {
                    BO.Users CompanyUserInfoList = new BO.Users();

                    CompanyUserInfoList.UserName = Convert.ToString(row["UserName"]);
                    CompanyUserInfoList.UserID = Convert.ToInt32(row["UserID"]);
                    CompanyUserInfoList.UserType = Convert.ToString(row["UserType"]);
                    CompanyUserInfoList.EmpID = Convert.ToString(row["EmpId"]);
                    CompanyUserInfoList.ContactNo = Convert.ToString(row["ContactNo"]);

                    CompanyUserList.Add(CompanyUserInfoList);
                }
            }
            return CompanyUserList;

        }
        public BO.Users GetAllMenuAndSubMenuRights(int UserID, string logType)
        {
            DataSet Stats = new DataSet();
            Stats = DBManager.GetMenuRightsForWebUser(UserID, logType);
            DataTable SubMenuDL = new DataTable();
            DataTable MenuDL = new DataTable();
            List<BO.Users> SubMenuBL = new List<BO.Users>();
            List<BO.Users> MenuBL = new List<BO.Users>();

            SubMenuDL = Stats.Tables[0];
            MenuDL = Stats.Tables[1];

            if (SubMenuDL.Rows.Count != 0)
            {
                foreach (DataRow row in SubMenuDL.Rows)
                {
                    BO.Users SubMenu = new BO.Users();
                    SubMenu.MenuID = Convert.ToInt32(row["MenuID"]);
                    SubMenu.MenuName = Convert.ToString(row["MenuName"]);
                    SubMenu.SubMenu = Convert.ToString(row["SubMenu"]);
                    SubMenu.SubMenuID = Convert.ToInt32(row["SubMenuID"]);
                    SubMenu.Count = Convert.ToInt32(row["Count"]);
                    SubMenu.IsAccess = Convert.ToInt32(row["IsAccess"]);

                    SubMenuBL.Add(SubMenu);
                }
            }


            BO.Users DataBL = new BO.Users();
            DataBL.MenuList = MenuBL;
            DataBL.SubMenuList = SubMenuBL;
            return DataBL;
        }
        public string AssignRightsAndMenu(DataTable dataTable, DataTable dataMenu, BO.Users user, string logType)
        {
            string Message = "";

            Dictionary<object, object> parameterList = new Dictionary<object, object>();
            //Master
            parameterList.Add("UserID", user.UserID);
            parameterList.Add("AddedBy", user.AddedBy);
            parameterList.Add("AddedOn", user.AddedOn);
            int i = DBManager.sub_ExecuteNonQuery_AssignRoleAndMenu("USP_AssignMenuRightsCRM", parameterList, dataTable, dataMenu,logType);

            Message = "Menu rights updated successfully";
            return Message;
        }
        //End For User Rights Option
    }
}
