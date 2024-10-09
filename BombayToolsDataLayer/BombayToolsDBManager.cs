using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DB = BombayToolsDBConnector;
using BO = BombayToolsEntities.BusinessEntities;
using HC = BombayToolsDBConnector.Helper;
using FE = BombayToolsDBConnector.FGERPDBConnection;
using BombayToolsEntities.BusinessEntities;

namespace BombayToolsDataLayer
{
    public class BombayToolsDBManager
    {
        HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
        DB.FGERPDBConnection FGERPConn = new DB.FGERPDBConnection();
        DB.FAglassDBConnection FAConn = new DB.FAglassDBConnection();
        DB.DBConnection objConn = new DB.DBConnection();
        //string accessDB = "";
        string sqlCommandString = "";









        public DataTable getLogin(string name, string pass,string ip, string mac, string ProjectFor)
        {
            if (ProjectFor == "FA")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_ValidateLoginTypeCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@EmpID", name);
                        objCommand.Parameters.AddWithValue("@pswrd", pass);
                        objCommand.Parameters.AddWithValue("@IP", ip);
                        objCommand.Parameters.AddWithValue("@Mac", mac);
                        objCommand.Parameters.AddWithValue("@City", '-');
                        objCommand.Parameters.AddWithValue("@Country", '-');

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_ValidateLoginTypeCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@EmpID", name);
                        objCommand.Parameters.AddWithValue("@pswrd", pass);
                        objCommand.Parameters.AddWithValue("@IP", ip);
                        objCommand.Parameters.AddWithValue("@Mac", mac);
                        objCommand.Parameters.AddWithValue("@City", '-');
                        objCommand.Parameters.AddWithValue("@Country", '-');

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        //User
        public int AddNewUserDetail(string userName, string userEmail, string userPassword, DateTime dateOfJoining, DateTime addedOn, int addedBy)
        {
            int i = db.sub_ExecuteNonQuery("USP_AddNewUserDetail '" + userName + "','" + userEmail + "','" + userPassword + "','" + Convert.ToDateTime(dateOfJoining).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + addedBy + " ");
            return i;
        }

        public int ChangePassword(int ID, string userPassword, int ModifiedBy, DateTime ModifiedOn)
        {
            int i = db.sub_ExecuteNonQuery("USP_ChangePassword " + ID + ",'" + userPassword + "'," + ModifiedBy + ",'" + Convert.ToDateTime(ModifiedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "' ");
            return i;
        }

        public DataTable MarkMeetAsComplete(int autoID, int addedBy, DateTime addedOn,string logType)
        {

            if (logType == "FAGlass")
            {
                DataTable loginDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                loginDL = db.sub_GetDatatableForFA("USP_MarkMeetAsComplete '" + autoID + "','" + addedBy + "','" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
                return loginDL;
            }
            else
            {
                DataTable loginDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                loginDL = db.sub_GetDatatableForFG("USP_MarkMeetAsComplete '" + autoID + "','" + addedBy + "','" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
                return loginDL;
            }
        }

        public DataTable GetUserSummary()
        {
            DataTable dataDL = new DataTable();
            dataDL = db.sub_GetDatatableForFG("USP_UserSummary");
            return dataDL;
        }

        public DataSet GetFollowUpReminder(string month, int addedBy, int userid,string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetFollowUpReminderNew";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@MonthName", month);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@UserID", userid);

                        DataSet dtLoginDetails = new DataSet();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetFollowUpReminder";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@MonthName", month);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@UserID", userid);

                        DataSet dtLoginDetails = new DataSet();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataTable GetDetailsFollowUpList(int tID, int AddedBy , int Userid, string ScheduleType, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetFollowUpDetailList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TID", tID);
                        objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                        objCommand.Parameters.AddWithValue("@UserID", Userid);
                        objCommand.Parameters.AddWithValue("@ScheduleType", ScheduleType);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetFollowUpDetailList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TID", tID);
                        objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                        objCommand.Parameters.AddWithValue("@UserID", Userid);
                        objCommand.Parameters.AddWithValue("@ScheduleType", ScheduleType);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetDetailsFollowUpDates(DateTime AddedOn, int FollowUpBoxID)
        {
            DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
            string sqlCommandString;
            using (SqlConnection connection = accessDB.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetFollowUpDetailDates";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AddedOn", Convert.ToDateTime(AddedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":"));
                    objCommand.Parameters.AddWithValue("@RequirementID", FollowUpBoxID);

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable GetSalesPersonList(int userID, string logType)
        {
            //DataTable DataDL = new DataTable(); 
            //DataDL = db.sub_GetDatatable("USP_SalesPersonDDL " + userID + " ");
            //return DataDL;

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_SalesPersonDDL";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_SalesPersonDDL";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public int SaveEMailAganistBox(int autoID, string messageID, string threadID, string snippet, int addedBy, int modifiedBy, int isActive)
        {
            int i = db.sub_ExecuteNonQuery("USP_EmailAganistSalespipeline " + autoID + ",'" + messageID + "','" + snippet + "','" + threadID + "'," + addedBy + "," + modifiedBy + "," + isActive + "");
            return i;
        }

        public DataTable GetcurrencyList(string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CurrencyDDLCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CurrencyDDLCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetAllAdminEMail()
        {
            DataTable dataDL = new DataTable();
            dataDL = db.sub_GetDatatable("USP_AllAdminEMail");
            return dataDL;
        }


        public DataTable GetPendingApprovalSummary()
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_PendingApprovalSummary");
            return DataDL;
        }


        public DataSet GetAllMenuAndSubMenu(int iD)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_MenuListDetail " + iD + " ");
            return Stats;
        }


        public int ChangeApprovalStatus(int ID)
        {
            int i = db.sub_ExecuteNonQuery("USP_ApproveUser " + ID + "");
            return i;
        }

        public int DeclineUserForm(int ID)
        {
            int i = db.sub_ExecuteNonQuery("USP_DeclineUser " + ID + "");
            return i;
        }

        public DataTable DeleteUser(int UserID, int AddedBy)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_INACTIVEUSER " + UserID + ", " + AddedBy + "");
            return DataDL;
        }

        public DataTable GetTagIDList(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_GetItemsTagID " + iD + "");
            return DataDL;
        }

        public DataTable GetTagsCount(int userID, string logType)
        {

            if (logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetTagsCount";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@userID", userID);
                        DataTable dtClass = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetTagsCount";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@userID", userID);
                        DataTable dtClass = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        //User Code End
        //Calendar
        //public int AddNewCalendarEvent(int id, string calendarID, string start, string description, string location, string summary, int addedBy, DateTime addedOn,string logType)
        //{
        //    if(logType == "FAGlass")
        //    {
        //        int i = db.sub_ExecuteNonQueryForFA("USP_AddOrEditScheduledFollowUp 0," + id + ",'" + Convert.ToDateTime(start).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + description + "','" + location + "','" + summary + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
        //        return i;
        //    }
        //    else
        //    {
        //        int i = db.sub_ExecuteNonQueryForFG("USP_AddOrEditScheduledFollowUp 0," + id + ",'" + Convert.ToDateTime(start).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + description + "','" + location + "','" + summary + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
        //        return i;
        //    }
        //}

        //Calendar
        public DataTable AddNewCalendarEvent(int id, string calendarID, string start, string description, string location, string summary, int addedBy, DateTime addedOn, string logType, int ScheduleType, string EndDate)
        {
            string sqlCommandString;
            DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_AddOrEditScheduledFollowUp";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AutoID", 0);
                    objCommand.Parameters.AddWithValue("@RequirementID", id);
                    objCommand.Parameters.AddWithValue("@Schedule", Convert.ToDateTime(start).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":"));
                    objCommand.Parameters.AddWithValue("@Summary", description);
                    objCommand.Parameters.AddWithValue("@location", location != null ? location.ToString() : "");
                    objCommand.Parameters.AddWithValue("@title", summary != null ? summary.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":"));
                    objCommand.Parameters.AddWithValue("@ScheduleType", ScheduleType);
                    objCommand.Parameters.AddWithValue("@EndDate", EndDate);


                    DataTable dtClass = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtClass);
                    }
                    connection.Close();
                    return dtClass;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }
        //Calendar

        public int UpdadeCalendarEvent(int id, string calendarID, string start, string description, string location, string summary, int addedBy, DateTime addedOn, string logType)
        {
            if (logType == "FAGlass")
            {
                int i = db.sub_ExecuteNonQueryForFA("USP_AddOrEditScheduledFollowUp " + calendarID + "," + id + ",'" + Convert.ToDateTime(start).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + description + "','" + location + "','" + summary + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
                return i;
            }
            else
            {
                int i = db.sub_ExecuteNonQueryForFG("USP_AddOrEditScheduledFollowUp " + calendarID + "," + id + ",'" + Convert.ToDateTime(start).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + description + "','" + location + "','" + summary + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
                return i;
            }
        }

        //
        // REquirement
        public DataTable GetRequirementList(string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementSummary";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementSummary";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }
        //
        public DataTable GetStageForTemplate(int requirmentID, int stageID, string fromDate, string toDate, string vertical, string user, string subStage, string assignTo, int userID, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_StageTemplateViewOPT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TemplateID", requirmentID);
                        objCommand.Parameters.AddWithValue("@StageID", stageID);
                        objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", toDate);
                        objCommand.Parameters.AddWithValue("@Vertical", vertical);
                        objCommand.Parameters.AddWithValue("@User", user);
                        objCommand.Parameters.AddWithValue("@SubStageID", subStage);
                        objCommand.Parameters.AddWithValue("@AssignTo", assignTo);
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_StageTemplateView";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TemplateID", requirmentID);
                        objCommand.Parameters.AddWithValue("@StageID", stageID);
                        objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", toDate);
                        objCommand.Parameters.AddWithValue("@Vertical", vertical);
                        objCommand.Parameters.AddWithValue("@User", user);
                        objCommand.Parameters.AddWithValue("@SubStageID", subStage);
                        objCommand.Parameters.AddWithValue("@AssignTo", assignTo);
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }
        //

        public DataSet GetAllFieldForSelectedTemplate(int templateID,string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFieldUIDetail";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@templateID", templateID);

                        DataSet dtLoginDetails = new DataSet();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFieldUIDetail";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@templateID", templateID);

                        DataSet dtLoginDetails = new DataSet();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetLinkedPipelineMail(int id)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_SalesPipelineLinkedEmail "  + id + "");
            return DataDL;
        }
        
        public DataTable GetStageDropDownForTemplate(int templateID, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Requiremnt", templateID);

                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Requiremnt", templateID);

                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }


        public DataSet RequirementFollowUp(int id,string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFollowUp";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", id);

                        DataSet dtLoginDetails = new DataSet();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFollowUp";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", id);

                        DataSet dtLoginDetails = new DataSet();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public int AddRequirementFollowUpDetails(int id, int followUPID, string followUPNote, int addedBy, DateTime addedOn, string logType)
        {
            if(logType == "FAGlass")
            {
                int i = db.sub_ExecuteNonQueryForFA("USP_RequirementFollowComment " + id + "," + followUPID + ",'" + followUPNote.Replace("'", "''") + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy").Replace(".", ":") + "'");
                return i;
            }
            else
            {
                int i = db.sub_ExecuteNonQueryForFG("USP_RequirementFollowComment " + id + "," + followUPID + ",'" + followUPNote.Replace("'", "''") + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy").Replace(".", ":") + "'");
                return i;
            }
        }

        public DataTable AddRequirementFollowUpDetails(int bOXID, int followUPID, string followUPNote, int addedBy, DateTime addedOn, DataTable tagsD, string logType)
        {
            if (logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFollowCommentT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", bOXID);
                        objCommand.Parameters.AddWithValue("@FollowUpType", followUPID);
                        objCommand.Parameters.AddWithValue("@FollowUpNote", followUPNote);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@AddedOn", addedOn);

                        if (tagsD != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_TagsMaster";
                            param2.Value = tagsD;
                            param2.TypeName = "PT_TagsMaster";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementFollowCommentT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", bOXID);
                        objCommand.Parameters.AddWithValue("@FollowUpType", followUPID);
                        objCommand.Parameters.AddWithValue("@FollowUpNote", followUPNote);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@AddedOn", addedOn);

                        if (tagsD != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_TagsMaster";
                            param2.Value = tagsD;
                            param2.TypeName = "PT_TagsMaster";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataTable UpdateProjectDetails(string ProjectName, string Developer, string Fabricator, string Architect, string Consultant, decimal ProjectSize, decimal DealSize, int bOXID, int addedBy, string logType)
        {
            if (logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateProjectDetails";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", bOXID);
                        objCommand.Parameters.AddWithValue("@ProjectName", ProjectName);
                        objCommand.Parameters.AddWithValue("@Developer", Developer != null ? Developer.ToString() : "");
                        objCommand.Parameters.AddWithValue("@Fabricator", Fabricator != null ? Fabricator.ToString() : "");
                        objCommand.Parameters.AddWithValue("@Architect", Architect != null ? Architect.ToString() : "");
                        objCommand.Parameters.AddWithValue("@Consultant", Consultant != null ? Consultant.ToString() : "");
                        objCommand.Parameters.AddWithValue("@ProjectSize", ProjectSize);
                        objCommand.Parameters.AddWithValue("@DealSize", DealSize);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);

                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateProjectDetails";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", bOXID);
                        objCommand.Parameters.AddWithValue("@ProjectName", ProjectName);
                        objCommand.Parameters.AddWithValue("@Developer", Developer);
                        objCommand.Parameters.AddWithValue("@Fabricator", Fabricator);
                        objCommand.Parameters.AddWithValue("@Architect", Architect);
                        objCommand.Parameters.AddWithValue("@Consultant", Consultant);
                        objCommand.Parameters.AddWithValue("@ProjectSize", ProjectSize);
                        objCommand.Parameters.AddWithValue("@DealSize", DealSize);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);

                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }




        public DataTable GetMainStageDropDownForTemplate(string logType)
        {
            //DataTable DataDL = new DataTable();
            //DataDL = db.sub_GetDatatable("USP_TemplateMainStageDropDown ");
            //return DataDL;

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateMainStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateMainStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetUserDropdownForRequiremnt(string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementAddedByDDL";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementAddedByDDL";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }


        public DataTable GetNotification(int userID)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatableForFG("USP_NotificationForUser " + userID + "");
            return DataDL;
        }

        public DataTable GetSubStageDropDownForTemplate(int StageID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateSubStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@StageID", StageID);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_TemplateSubStageDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@StageID", StageID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }
        // Requirement Code end

        //Schedule Type
        public DataTable GetScheduleList(string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetScheduleFollowupMaster";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetScheduleFollowupMaster";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }
        // Schedule Type End

        //Email(00Email)

        public int SaveTokenPathForUser(int userID, string credPath)
        {
            int i = db.sub_ExecuteNonQuery("USP_EmailVerificationToken " + userID + ",'" + credPath + "'");
            return i;
        }

        public int SaveEMailAganistQuotation(int quotID, string messageID, string threadID, string snippet, int addedBy, int modifiedBy, int isActive)
        {
            int i = db.sub_ExecuteNonQuery("USP_QuotationAganistEmail " + quotID + ",'" + messageID + "','" + snippet + "','" + threadID + "'," + addedBy + "," + modifiedBy + "," + isActive + "");
            return i;
        }

        public DataTable GetUserDataForControl(int userID)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_UserDataForControl "  + userID + "");
            return DataDL;
        }

        public DataTable MarkAsReadNotification(int iD, int userID, string logType)
        {
            if (logType == "FAGlass")
            {
                DataTable DataDL = new DataTable();
                DataDL = db.sub_GetDatatableForFA("USP_MarkAsReadNotification " + iD + "," + userID + "");
                return DataDL;
            }
            else
            {
                DataTable DataDL = new DataTable();
                DataDL = db.sub_GetDatatableForFG("USP_MarkAsReadNotification " + iD + "," + userID + "");
                return DataDL;
            }
        }

        public DataTable GetLinkedMailDetail(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_QuotationLinkedToEmail " + iD + "");
            return DataDL;
        }

        public DataTable GetRoleWiseMenu(int roleID)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_RoleWiseMenuList " + roleID + "");
            return DataDL;
        }

        //EmailCodeEnd
        public DataTable GetQuotationNumberList(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_EnquiryForCustomer " + iD + "");
            return DataDL;
        }

        public DataTable GetEMailListForQuotation(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_QuotationListAganistEmail " + iD + "");
            return DataDL;
        }

        //Salespipeline code(00SalesPipeline)
        public DataTable GetSalesPipelineDashboardDetail()
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_SalesPipelineDashboard");
            return DataDL;
        }


        public DataTable GetQuotationStageWiseList(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable("USP_StageWiseQuotation " + iD + "");
            return DataDL;
        }


        public DataSet DashboardReport(DateTime from)
        {
            DataSet data = new DataSet();
            data = db.sub_GetDataSets("USP_AdminDashboardLiveData '" + Convert.ToDateTime(from).ToString("dd-MMM-yyyy").Replace(".", ":") + "'");
            return data;
        }


        //Salespipeline code ens

        //VisitReport
        //For Adding and Updating Visit Report
        public DataTable AddORUpdateNewVisitReport(int IsNew, Int64 VisitID, Int32 RevisionNo, String VisitName, DateTime VisitDate, String Company, String Location, String ContactPerson, String Remark, Int64 AddedBy, DateTime AddedOn, Int64 ModifiedBy, DateTime ModifiedOn, Int64 CancelledBy, DateTime CancelledOn, bool IsActive)
        {
            DataTable VisitMaster = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            VisitMaster = db.sub_GetDatatable("USP_INSERT_OR_UPDATE_VISITMASTER " + IsNew + "," + VisitID + "," + RevisionNo + ", '" + VisitName + "','" + Convert.ToDateTime(VisitDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + Company + "','" + Location + "','" + ContactPerson + "','" + Remark.Replace("'", "''") + "'," + AddedBy + ",'" + Convert.ToDateTime(AddedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + ModifiedBy + ",'" + Convert.ToDateTime(ModifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + CancelledBy + ",'" + Convert.ToDateTime(CancelledOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + IsActive + "");
            return VisitMaster;
        }

        public DataTable GetSearchResult(string searchText)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_GetSearchResult '" + searchText + "'");
            return data;
        }

        public DataTable GetStreakData(int ID)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_StreakListForUser '" + ID + "'");
            return data;
        }
        public DataSet GetStreakStages(int ID)
        {
            DataSet data = new DataSet();
            data = db.sub_GetDataSets("USP_StreakListForUser '" + ID + "'");
            return data;
        }

        public DataTable GetUserActivityLog(int userID, DateTime fromDate, DateTime toDate)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_ActivityLogSummary '" + userID + "','" + Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
            return data;
        }

        public DataTable GetStageDetails(int TemplateID, int StageID, string FromDate, string ToDate, string Vertical, string User, string subStage, string assignTo, int IsLead, int userID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_NewRequirmentTestOPT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TemplateID", TemplateID);
                        objCommand.Parameters.AddWithValue("@StageID", StageID);
                        objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                        objCommand.Parameters.AddWithValue("@Vertical", Vertical);
                        objCommand.Parameters.AddWithValue("@User", User);
                        objCommand.Parameters.AddWithValue("@SubStage", subStage);
                        objCommand.Parameters.AddWithValue("@AssignTo", assignTo);
                        objCommand.Parameters.AddWithValue("@IsLead", IsLead);
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_NewRequirmentTest";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@TemplateID", TemplateID);
                        objCommand.Parameters.AddWithValue("@StageID", StageID);
                        objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                        objCommand.Parameters.AddWithValue("@Vertical", Vertical);
                        objCommand.Parameters.AddWithValue("@User", User);
                        objCommand.Parameters.AddWithValue("@SubStage", subStage);
                        objCommand.Parameters.AddWithValue("@AssignTo", assignTo);
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

            //DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            //string sqlCommandString = "";
            //using (SqlConnection connection = objConn.GetConnection)
            //{
            //    //connection.Open();
            //    try
            //    {
            //        if (connection.State != ConnectionState.Open)
            //        {
            //            connection.Open();
            //        }
            //        sqlCommandString = "USP_NewRequirmentTest";
            //        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
            //        objCommand.CommandType = CommandType.StoredProcedure;
            //        objCommand.Parameters.AddWithValue("@TemplateID", TemplateID);
            //        objCommand.Parameters.AddWithValue("@StageID", StageID);
            //        objCommand.Parameters.AddWithValue("@FromDate", FromDate);
            //        objCommand.Parameters.AddWithValue("@ToDate", ToDate);
            //        objCommand.Parameters.AddWithValue("@Vertical", Vertical);
            //        objCommand.Parameters.AddWithValue("@User", User);
            //        objCommand.Parameters.AddWithValue("@SubStage", subStage);
            //        objCommand.Parameters.AddWithValue("@AssignTo", assignTo);
            //        objCommand.Parameters.AddWithValue("@UserID", userID);

            //        DataTable dtLoginDetails = new DataTable();

            //        using (SqlDataAdapter _Data = new SqlDataAdapter())
            //        {
            //            _Data.SelectCommand = objCommand;
            //            _Data.Fill(dtLoginDetails);
            //        }
            //        connection.Close();
            //        return dtLoginDetails;
            //    }
            //    catch (Exception ex)
            //    {
            //        if (connection.State == ConnectionState.Open)
            //        {
            //            connection.Close();
            //        }
            //        throw ex;
            //    }
            //}
        }

        public DataTable GetStreakDataStageWise(int ID, string Stages)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_GetStreakDataStageWise '" + ID + "','" + Stages + "'");
            return data;
        }
        //For Getting visit summary data
        public DataTable GetVisitList(string searchText)
        {
            DataTable VisitList = new DataTable();
            VisitList = db.sub_GetDatatable("USP_VisitSummaryList '" + searchText + "'");
            return VisitList;
        }

        //For Getting Date Wise visit summary data
        public DataTable GetDateVisitList(DateTime FromDate, DateTime ToDate, string searchText, string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable VisitList = new DataTable();
                VisitList = db.sub_GetDatatableForFA("USP_VisitList '" + Convert.ToDateTime(FromDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + Convert.ToDateTime(ToDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + searchText + "'");
                return VisitList;
            }
            else
            {
                DataTable VisitList = new DataTable();
                VisitList = db.sub_GetDatatableForFG("USP_VisitList '" + Convert.ToDateTime(FromDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + Convert.ToDateTime(ToDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + searchText + "'");
                return VisitList;
            }
        }

        public DataTable UpdateCommentForBox(int followUpID, string followUpNote, int addedBy, DateTime addedOn, DataTable tagsD, string logType)
        {
            if (logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateRequirmentFollowupNoteT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@autoID", followUpID);
                        objCommand.Parameters.AddWithValue("@followUpNote", followUpNote);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@AddedOn", addedOn);

                        if (tagsD != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_TagsMaster";
                            param2.Value = tagsD;
                            param2.TypeName = "PT_TagsMaster";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateRequirmentFollowupNoteT";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@autoID", followUpID);
                        objCommand.Parameters.AddWithValue("@followUpNote", followUpNote);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        objCommand.Parameters.AddWithValue("@AddedOn", addedOn);

                        if (tagsD != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_TagsMaster";
                            param2.Value = tagsD;
                            param2.TypeName = "PT_TagsMaster";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        //For Edit Visit Report
        public DataTable GetVisitReportList(int VisitID)
        {
            DataTable VisitList = new DataTable();
            VisitList = db.sub_GetDatatable("USP_EditVisitReport " + VisitID + " ");
            return VisitList;
        }

        public DataTable FetchItemDataByPartNo(string partNo)
        {
            DataTable VisitList = new DataTable();
            VisitList = db.sub_GetDatatable("USP_GetItemDetailsByPartNo '" + partNo + "' ");
            return VisitList;
        }

        //For Delete Visit Report
        public DataTable DeleteVisitDetails(Int64 VisitID, Int64 AddedBy, bool IsActive)
        {
            DataTable Item = new DataTable();
            Item = db.sub_GetDatatableForFG("SP_InactiveVisitData  " + VisitID + ", '" + AddedBy + "'," + IsActive + "");
            return Item;
        }

        //For Adding Visit Location Entries
        public DataTable AddVisitLocation(String Location, float Longitude, float Latitude, Int64 AddedBy, DateTime AddedOn)
        {
            DataTable VisitMaster = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            VisitMaster = db.sub_GetDatatable("USP_INSERT_VISITLOCATION_MASTER '" + Location + "','" + Longitude + "','" + Latitude + "'," + AddedBy + ",'" + Convert.ToDateTime(AddedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
            return VisitMaster;
        }



        //For Getting Pending visit summary data
        public DataTable GetPendingVisitList(string searchText)
        {
            DataTable VisitList = new DataTable();
            VisitList = db.sub_GetDatatableForFG("USP_PendingVisitList '" + searchText + "'");
            return VisitList;
        }


        //VisitReport end
        //DashBoard Admin
        public DataSet GetDashboardData()
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_DashboardForAdmin ");
            return Stats;
        }

        public DataTable GetPrincipalDetail()
        {
            DataTable Principal = new DataTable();
            Principal = db.sub_GetDatatable("USP_CompanyPrincipalWise ");
            return Principal;
        }

        public DataTable GetSectorDetail()
        {
            DataTable Sector = new DataTable();
            Sector = db.sub_GetDatatable("USP_CompanySectorWise ");
            return Sector;
        }

        public DataTable GetIndustryDetail()
        {
            DataTable Industry = new DataTable();
            Industry = db.sub_GetDatatable("USP_CompanyIndustryWise ");
            return Industry;
        }

        public DataTable GetCompanyListForSelectedPrincipal(int type, int id)
        {
            DataTable companyDetailList = new DataTable();
            companyDetailList = db.sub_GetDatatable("USP_DashboardCompanyListTypelWise  " + type + "," + id + "");
            return companyDetailList;
        }

        public DataSet GetSalaespersonDetail(int id)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_DashboardForSalesPerson " + id + "");
            return Stats;
        }

        public DataSet GetSalaespersonDashboardDetail(int id)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_DashboardForSalesPerson1 " + id + "");
            return Stats;
        }
        //Menu List
        public DataTable getAdminMenuList()
        {
            DataTable AdminMenuDL = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            AdminMenuDL = db.sub_GetDatatable("USP_MenuFetchDetails");
            return AdminMenuDL;
        }
        public DataTable getMenuList(string toUserType, int sessionuserID)
        {
            DataTable MenuDL = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            MenuDL = db.sub_GetDatatable("USP_MenuListForSelectedUser '" + toUserType + "', " + sessionuserID + "");
            return MenuDL;
        }

        public DataTable getMenuListNew(int userid, string logType)
        {
            if(logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_MenuListForSelectedUserOS";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userid);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_MenuListForSelectedUserOS";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userid);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }
        public DataTable RequestRestPassword(string emailID, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_ResetPaswordRequest";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@EmailID", emailID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_ResetPaswordRequest";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@EmailID", emailID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

            //DataTable MenuDL = new DataTable();
            //HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            //MenuDL = db.sub_GetDatatable("USP_ResetPaswordRequest '" + emailID + "'");
            //return MenuDL;
        }
        public DataTable CheckTokenValidity(string token, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CheckTokenValidity";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Token", token);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CheckTokenValidity";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Token", token);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

            //DataTable MenuDL = new DataTable();
            //HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            //MenuDL = db.sub_GetDatatable("USP_CheckTokenValidity '" + token + "'");
            //return MenuDL;
        }

        public DataTable SetNewPassword(string token, string password, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_SetPaswordRequest";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Token", token);
                        objCommand.Parameters.AddWithValue("@Password", password);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_SetPaswordRequest";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Token", token);
                        objCommand.Parameters.AddWithValue("@Password", password);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            //DataTable MenuDL = new DataTable();
            //HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            //MenuDL = db.sub_GetDatatable("USP_SetPaswordRequest '" + token + "','" + password + "'");
            //return MenuDL;
        }
        //Enquiry starts
        public DataTable GetCompanyDetailsFromEmailORContactNoORMobileNO(string searchText, int UserID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CompanyInfoAgainstEMailORMobileNo";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Search", searchText);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CompanyInfoAgainstEMailORMobileNo";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Search", searchText);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetEnquirySummaryForAdmin(DateTime fromDate, DateTime to)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryListForAdmin '" + Convert.ToDateTime(fromDate).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "','" + Convert.ToDateTime(to).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "'");
            return EnquiryList;
        }

        public DataSet GetVendorDropdownDetails()
        {
            DataSet ddl = new DataSet();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            ddl = db.sub_GetDataSets("USP_GetVedorMasterDropdown  ");
            return ddl;
        }

        public DataTable AddORUpdateNewEnquiry(int enquiryNO, int revisionNo, DateTime enqDate, int contactPersonID, string reference, string desc, int salesPersonID, int statusID, int addedBY, DateTime addedON, int modifiedBY, DateTime modifiedON, bool isDeleted, int SalesCoordinatorID, string Remark)
        {
            DataTable EnquiryMaster = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            EnquiryMaster = db.sub_GetDatatable("USP_EnquiryAddOrEditDetail " + enquiryNO + "," + revisionNo + ", '" + Convert.ToDateTime(enqDate).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + contactPersonID + ",'" + reference.Replace("'", "''") + "','" + desc.Replace("'", "\"") + "'," + salesPersonID + "," + statusID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isDeleted + "," + SalesCoordinatorID + ",'" + Remark + "'" + "");
            return EnquiryMaster;
        }


        public DataTable GetEnquirySummary(int isFilterBYDate, DateTime from, DateTime to, string searchText, int AddedBY)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryList " + AddedBY + "," + isFilterBYDate + ",'" + Convert.ToDateTime(from).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "','" + Convert.ToDateTime(to).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "','" + searchText + "'");
            return EnquiryList;
        }

        public DataSet GetSalesDashboardData(int userID, string logType)
        {
            if(logType == "FAGlass")
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataSet EnquiryList = new DataSet();
                EnquiryList = db.sub_GetDataSetsForFG("USP_SalesDashboardData " + userID);
                return EnquiryList;
            }
            else
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataSet EnquiryList = new DataSet();
                EnquiryList = db.sub_GetDataSetsForFA("USP_SalesDashboardData " + userID);
                return EnquiryList;
            }
        }

        public DataTable GetCloseEnquiryList(int status, int AddedBY, DateTime fromDate, DateTime to)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryCloseList " + status + "," + AddedBY + ",'" + Convert.ToDateTime(fromDate).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "','" + Convert.ToDateTime(to).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "'");
            return EnquiryList;
        }

        public DataTable DeleteItemDetailsForMerging(int itemID, int SetID, string ItemNote, string checkedItemMergeID)
        {
            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("USP_DeleteItemDetailsForMergeItem " + itemID + "," + SetID + ",'" + ItemNote + "','" + checkedItemMergeID + "'");
            return Item;
        }

        public DataTable GetEnquiryListCount(int typeID, DateTime from)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryListCount " + typeID + ",'" + Convert.ToDateTime(from).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "'");
            return EnquiryList;
        }

        public DataTable GetEnquiryListCountAganistCustomer(int statusID, int iD)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryCountAgainstCustomer " + statusID + "," + iD + "");
            return EnquiryList;
        }

        public DataTable GetEnquiryCustomerSummary(int status, int cPID)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryAgainstCustomer " + status + "," + cPID + "");
            return EnquiryList;
        }


        public DataTable GetEnquiryDetail(int id)
        {
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquirySelectedDetail " + id + "");
            return EnquiryList;
        }

        public int SaveEmailLog(int logno, int quotationNo, string to, string bCC, string cC, string subject, string path, string contentType, string body, int addedBY)
        {
            int k = db.sub_ExecuteNonQuery("USP_QuotationEmailLog " + logno + "," + quotationNo + ",'" + to + "', '" + bCC + "','" + cC + "','" + subject + "', '" + path + "','" + contentType + "','" + body + "', " + addedBY + "");
            return k;
        }

        public DataTable GetStateCode(string stateID)
        {
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_GetStateCode '" + stateID + "'");
            return EnquiryList;
        }

        public int AddEnquiryFollowUp(int enquiryNo, int followUpID, string followUpNote, int addedBy)
        {
            int i = db.sub_ExecuteNonQuery("USP_EnquiryNewFollowUp " + enquiryNo + "," + followUpID + ",'" + followUpNote.Replace("'", "''") + "'," + addedBy + "");
            return i;
        }

        public DataTable SaveSalesOrderLink(int boxID, string SalesOrderNo, decimal BasicTotal, int userID)
        {
            string sqlCommandString;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveSalesOrderLink";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@BoxID", boxID);
                    objCommand.Parameters.AddWithValue("@SalesOrderNo", SalesOrderNo);
                    objCommand.Parameters.AddWithValue("@BasicTotal", BasicTotal);
                    //objCommand.Parameters.AddWithValue("@QuotID", quoteID);
                    objCommand.Parameters.AddWithValue("@userID", userID);
                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable SaveClosedQuotForSOLink(string salesOrderNo, DateTime SODate, string quotID, string quotNo, int VerticalID, DateTime AddedOnDate, decimal BasicTotal, int userID)
        {
            string sqlCommandString;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SavetUnlinkedQuotForSO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure; 
                    objCommand.Parameters.AddWithValue("@SalesOrderNo", salesOrderNo);
                    objCommand.Parameters.AddWithValue("@QuotID", quotID);
                    objCommand.Parameters.AddWithValue("@QuotationNo", quotNo);
                    objCommand.Parameters.AddWithValue("@CloseDate", SODate);
                    objCommand.Parameters.AddWithValue("@DealSize", BasicTotal);
                    objCommand.Parameters.AddWithValue("@AddedBy", userID);
                    objCommand.Parameters.AddWithValue("@VerticalID", VerticalID);
                    objCommand.Parameters.AddWithValue("@AddedOn", AddedOnDate);
                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable UpdateAssignToIncentive(SalesPipeline master, DataTable assignM, string logType)
        {
            if(logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateAssignToIncentive";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", master.BoxID);
                        objCommand.Parameters.AddWithValue("@AddedBy", master.AddedBy);

                        if (assignM != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "@PT_AssignToIncentive";
                            param1.Value = assignM;
                            param1.TypeName = "PT_AssignToIncentive";
                            param1.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param1);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_UpdateAssignToIncentive";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", master.BoxID);
                        objCommand.Parameters.AddWithValue("@AddedBy", master.AddedBy);

                        if (assignM != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "@PT_AssignToIncentive";
                            param1.Value = assignM;
                            param1.TypeName = "PT_AssignToIncentive";
                            param1.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param1);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();
                        return dtClass;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataSet GetIncentiveAssignToList()
        {
            DB.DBConnection objConn = new DB.DBConnection();
            string sqlCommandString = "";
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetIncentiveAssignToList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dtLoginDetails = new DataSet();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable GetVerticalBasisIncentive(int iD, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetVerticalBasisIncentive";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@SPID", iD);

                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetVerticalBasisIncentive";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@SPID", iD);

                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable SaveQuotAgainstSOLink(int autoID, string salesOrderNo, decimal BasicTotal, string quoteID, string quotationNo, string type, int IsQuotAgainst, int userID)
        {
            string sqlCommandString;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveAgainstQuotSOLink";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AutoID", autoID);
                    objCommand.Parameters.AddWithValue("@SalesOrderNo", salesOrderNo);
                    objCommand.Parameters.AddWithValue("@BasicTotal", BasicTotal);
                    objCommand.Parameters.AddWithValue("@QuotID", quoteID);
                    objCommand.Parameters.AddWithValue("@QuotationNo", quotationNo);
                    objCommand.Parameters.AddWithValue("@Type", type);
                    objCommand.Parameters.AddWithValue("@IsQuotAgainst", IsQuotAgainst);
                    objCommand.Parameters.AddWithValue("@userID", userID);
                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable SaveThroughSalesOrder(int boxID, string salesOrderNo, decimal BasicTotal, int userID)
        {
            string sqlCommandString;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveSalesOrderLink";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@BoxID", boxID);
                    objCommand.Parameters.AddWithValue("@SalesOrderNo", salesOrderNo);
                    objCommand.Parameters.AddWithValue("@BasicTotal", BasicTotal);
                    objCommand.Parameters.AddWithValue("@userID", userID);
                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        public DataTable GetFollowUpListForSelectedEnquiry(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable(" USP_EnquiryFollowUpReport " + iD + "");
            return DataDL;
        }


        public int LinkEmailToEnquiry(string messageID, string threadID, int addedBY, DateTime addedON)
        {
            int i = db.sub_ExecuteNonQuery("USP_LinkEmailWithEnquiry '" + messageID + "','" + threadID + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
            return i;
        }

        public DataTable AjaxLinkSelectedEmail(int box, int userID, DataTable linkingList)
        {
            throw new NotImplementedException();
        }

        public DataTable CheckEnquiryForMail(string messageID, string threadID)
        {
            DataTable EnquiryList = new DataTable();
            EnquiryList = db.sub_GetDatatable("USP_EnquiryMailDuplicationCheck '" + messageID + "','" + threadID + "'");
            return EnquiryList;
        }

        public int SaveSharedList(string sharedWith, int modifiedBy, DateTime modifiedOn, int ID)
        {
            int i = db.sub_ExecuteNonQuery("USP_EnquirySharedWith '" + sharedWith + "'," + modifiedBy + ",'" + Convert.ToDateTime(modifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + ID + "");
            return i;
        }
        //Enquiry Ends

        //Quotation


        public DataSet GetQuotationParmeter()
        {
            DataSet data = new DataSet();
            data = db.sub_GetDataSets("USP_QuotationSummaryParameters");
            return data;
        }

        public DataTable DeleteRequirementBox(int boxID, DateTime addedOn, int userID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_DeleteRequirementBox";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", boxID);
                        objCommand.Parameters.AddWithValue("@userID", userID);
                        objCommand.Parameters.AddWithValue("@Date", addedOn);
                        
                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_DeleteRequirementBox";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", boxID);
                        objCommand.Parameters.AddWithValue("@userID", userID);
                        objCommand.Parameters.AddWithValue("@Date", addedOn);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }


        }

        public DataTable GetNewQuotationID()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotID = new DataTable();
            QuotID = db.sub_GetDatatable("USP_NewQuotationID");
            return QuotID;
        }

        public DataTable GetContactPersonsForLocation(int id)
        {
            DataTable companyDetailList = new DataTable();
            companyDetailList = db.sub_GetDatatable("USP_ContactPersonForLocation  '" + id + "'");
            return companyDetailList;
        }

        public DataTable GetSalutationForContact(int contactPersonID)
        {
            DataTable QuotID = new DataTable();
            QuotID = db.sub_GetDatatable("USP_SalutationForContact " + contactPersonID + "");
            return QuotID;
        }


        public DataTable GetQuotTemplate()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotID = new DataTable();
            QuotID = db.sub_GetDatatable("USP_QuotationTermsTemplate");
            return QuotID;
        }

        public DataTable GetQuotationList(int status, DateTime fromDate, DateTime to, int VerticalID, int UserID)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationStatusWise  " + status + "," + VerticalID + ",'" + UserID + "','" + Convert.ToDateTime(fromDate).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "','" + Convert.ToDateTime(to).ToString("yyyy-MMM-dd HH:mm:ss").Replace(".", ":") + "'");
            return QuotList;
        }

        public DataTable GetQuotationListCount(int p, int AddedBy)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable Count = new DataTable();
            Count = db.sub_GetDatatable("USP_QuotationCountForDashboard  '" + p + "','" + AddedBy + "'");
            return Count;
        }

        public DataTable GetQuotationItemDetails(int quotId)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotItem = new DataTable();
            QuotItem = db.sub_GetDatatable("USP_QuotationDetailsAganistQuotNo  '" + quotId + "'");
            return QuotItem;
        }



        public DataTable AddORUpdateNewQuotationMaster(int qtnNO, int revNO, DateTime qtnDate, string refe, int enqNo, DateTime dueDate, int salesPersonID, int contactPersonID, int statusID, int addedBY, DateTime addedON, bool isCancelled, int cancelledBY, DateTime cancelledON)
        {

            DataTable quotationMaster = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            quotationMaster = db.sub_GetDatatable("USP_QuotationInsertNewData  " + qtnNO + "," + revNO + ",'" + Convert.ToDateTime(qtnDate).ToString("dd-MMM-yyyy HH:mm:ss") + "','" + refe.Replace("'", "''") + "'," + enqNo + ",'" + Convert.ToDateTime(dueDate).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + salesPersonID + "," + contactPersonID + "," + statusID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isCancelled + "," + cancelledBY + ",'" + Convert.ToDateTime(cancelledON).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
            return quotationMaster;
        }

        public DataTable GetItemCategoryAndPartNOForBOM(string searchText)
        {
            DataTable itemList = new DataTable(searchText);
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            itemList = db.sub_GetDatatable("USP_ItemDetailsForBOM  '" + searchText + "'");
            return itemList;
        }

        public DataTable GetItemCategoryAndPartNOForQoutation(string searchText)
        {
            DataTable itemList = new DataTable(searchText);
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            itemList = db.sub_GetDatatable("USP_ItemDetails  '" + searchText + "'");
            return itemList;
        }

        public DataTable QuotationCustomerWise()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationCountCustomerWise");
            return QuotList;
        }

        public DataTable QuotationListCustomerWise(int quotID)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationListForSpecificPerson  '" + quotID + "'");
            return QuotList;
        }


        public DataTable GetQuotationCloseReason()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationClosingReason");
            return QuotList;
        }

        public DataTable QuotationDataForQuotNo(int QuotNo)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationDataAganistQuotationNO  '" + QuotNo + "'");
            return QuotList;
        }

        public DataTable QuotationInsertCloseDetails(int QuotID, int CloseID, string Notes, int ClosedBy, DateTime ClosedON)
        {
            DataTable quotationMaster = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            quotationMaster = db.sub_GetDatatable("USP_QuotationInsertCloseDetail  " + QuotID + "," + CloseID + ",'" + Notes + "'," + ClosedBy + ",'" + Convert.ToDateTime(ClosedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
            return quotationMaster;
        }

        public DataTable QuotationGetClosedDetail(int QuotNo)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable QuotList = new DataTable();
            QuotList = db.sub_GetDatatable("USP_QuotationCloseInfoByQuotNo  '" + QuotNo + "'");
            return QuotList;
        }

        //Export Invoice
        public DataTable CurrencyCodeList()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable CurrencyDL = new DataTable();
            CurrencyDL = db.sub_GetDatatableForFG(" USP_CurrencyCodeListFetchSummaryDetails ");
            return CurrencyDL;
        }

        public DataTable GetModeOfShipment()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable CurrencyDL = new DataTable();
            CurrencyDL = db.sub_GetDatatableForFG(" USP_GetShipmemtModeList ");
            return CurrencyDL;
        }
        //End

        public DataTable AddAttachment(int Userid, byte[] bytes, string contentType, string fname)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.AddAttachment(Userid, bytes, contentType, fname);
            return AttachmentDT;
        }

        public DataTable GetAllEmailBodyTemplate()
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable CurrencyDL = new DataTable();
            CurrencyDL = db.sub_GetDatatable(" USP_EmailBodyTemplateList ");
            return CurrencyDL;
        }

        public DataTable AddQuotationToPipeline(int quotID, decimal probalilty, DateTime expectedClose, int statusID, int stageID, string remark, int Revesion, int addedBy, DateTime addedOn, int modifiedBy, DateTime modifiedOn, int isActive)
        {
            DataTable quotationMaster = new DataTable();
            quotationMaster = db.sub_GetDatatable("USP_NewQuotationToSalesPipeline  " + quotID + ",'" + probalilty + "','" + Convert.ToDateTime(expectedClose).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + statusID + "," + stageID + ",'" + remark + "'," + Revesion + "," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + modifiedBy + ", '" + Convert.ToDateTime(modifiedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isActive + "");
            return quotationMaster;
        }


        public DataTable GetFollowUPList(string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_FollowUp";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_FollowUp";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetFollowUpData(int quot)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable(" USP_QuotationFollowUpReport " + quot + "");
            return DataDL;
        }

        public int AddFollowUpDetails(int quotationNo, int followUpID, string followUpNote, int addedBy, DateTime addedOn)
        {
            int i = db.sub_ExecuteNonQuery("USP_QuotationNewFollowUp " + quotationNo + "," + followUpID + ",'" + followUpNote.Replace("'", "''") + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
            return i;
        }

        public DataTable GetQuotationHistory(int iD)
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable(" USP_QuotationHistory " + iD + "");
            return DataDL;
        }


        public DataTable GetStandardQuotationSummary()
        {
            DataTable DataDL = new DataTable();
            DataDL = db.sub_GetDatatable(" USP_QuotationTemplateSummary ");
            return DataDL;
        }


        public DataSet GetQuotTemplateDetail(int templateID)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_StandardQuotTemplateDetail " + templateID + " ");
            return Stats;
        }


        public DataSet CopyQuotDetail(int quotationID)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_QuotationCopyDetail " + quotationID + " ");
            return Stats;
        }


        public DataTable GetQuotationNo(string searchText)
        {
            DataTable dt = new DataTable();
            dt = db.sub_GetDatatableForFG("USP_SearchQuotation  '" + searchText + "'");
            return dt;
        }


        public int DeleteSelectedTemplate(int qutationSTID, int modifiedBy, DateTime modifiedOn, int isActive)
        {
            int i = db.sub_ExecuteNonQuery("USP_DeleteStandardTemplate " + qutationSTID + "," + modifiedBy + ",'" + Convert.ToDateTime(modifiedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "', " + isActive + "");
            return i;
        }


        public DataTable QuotationForSelectedUser(int id, DateTime date)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_QuotationDailyData '" + id + "' , '" + Convert.ToDateTime(date).ToString("dd-MMM-yyyy") + "'");
            return LeaveList;
        }
        //Quotation ENds      

        //Contact Management
        public DataTable AddNewLocation(bool isNew, int locationID, int compaID, string locationName, string address, string city, int stateID, int countryID, 
            string zipCode, double contactNO, string emailID, int addedBY, DateTime addedON, int modifiedID, DateTime modifiedDate,
            bool isCancel, int canceledID, DateTime canceledON, string logType)
        {
            if(logType == "FAGlass")
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Location = new DataTable();
                Location = db.sub_GetDatatableForFA(" USP_TEMPLocationNewDetail " + isNew + "," + locationID + "," + compaID + ",'" + locationName + "','" + address + "', '" + city + "'," + stateID + "," + countryID + ",'" + zipCode + "'," + contactNO + ",'" + emailID + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + modifiedID + ", '" + Convert.ToDateTime(modifiedDate).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isCancel + "," + canceledID + ",'" + Convert.ToDateTime(canceledON).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
                return Location;
            }
            else
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Location = new DataTable();
                Location = db.sub_GetDatatableForFG(" USP_TEMPLocationNewDetail " + isNew + "," + locationID + "," + compaID + ",'" + locationName + "','" + address + "', '" + city + "'," + stateID + "," + countryID + ",'" + zipCode + "'," + contactNO + ",'" + emailID + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + modifiedID + ", '" + Convert.ToDateTime(modifiedDate).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isCancel + "," + canceledID + ",'" + Convert.ToDateTime(canceledON).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
                return Location;
            }
        }

        public DataTable AddNewContact(bool isNew, int companyID, int locationID, int contactPersonID, string personName, int departmentID, string designationID, string contact, string emailID, string mobileNO, int addedBY, DateTime addedON, int modifiedBY, DateTime modifiedON, bool isCancel, int cancelledBY, DateTime cancelledON)
        {
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DataTable Contact = new DataTable();
            Contact = db.sub_GetDatatable(" USP_TEMPContactNewDetail " + isNew + "," + companyID + ", " + locationID + "," + contactPersonID + ",'" + personName.Replace("'", "''") + "'," + departmentID + ",'" + designationID + "','" + contact + "','" + emailID + "','" + mobileNO + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ", '" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isCancel + "," + cancelledBY + ",'" + Convert.ToDateTime(cancelledON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'");
            return Contact;
        }

        public DataTable AddNewAccount(bool isNew, int companyID, int locationID, string gstNO, int gstRegistered, string registerationDate, string panNO, int addedBY, 
            DateTime addedON, int modifiedBY, DateTime modifiedON, bool isCancel, int cancelledBY, DateTime cancelledON, int PanStatus, string logType)
        {
            if(logType == "FAGlass")
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFA(" USP_TEMPAccountNewDetail " + isNew + "," + companyID + "," + locationID + ", '" + gstNO + "', " + gstRegistered + ",'" + registerationDate + "','" + panNO + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isCancel + "," + cancelledBY + ",'" + Convert.ToDateTime(cancelledON).ToString("dd-MMM-yyyy HH:mm:ss") + "', " + PanStatus + "");
                //Contact = db.sub_GetDatatable(" USP_TEMPAccountNewDetail " + isNew + "," + companyID + ", " + locationID + ",'" + gstNO.Replace("'", "''") + "'," + gstRegistered + ",'" + Convert.ToDateTime(registerationDate).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + panNO + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ", '" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "', " + isCancel + ", " + cancelledBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "',"+ PanStatus + "");
                return Contact;
            }
            else
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFG(" USP_TEMPAccountNewDetail " + isNew + "," + companyID + "," + locationID + ", '" + gstNO + "', " + gstRegistered + ",'" + registerationDate + "','" + panNO + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + isCancel + "," + cancelledBY + ",'" + Convert.ToDateTime(cancelledON).ToString("dd-MMM-yyyy HH:mm:ss") + "', " + PanStatus + "");
                //Contact = db.sub_GetDatatable(" USP_TEMPAccountNewDetail " + isNew + "," + companyID + ", " + locationID + ",'" + gstNO.Replace("'", "''") + "'," + gstRegistered + ",'" + Convert.ToDateTime(registerationDate).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "','" + panNO + "'," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ", '" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "', " + isCancel + ", " + cancelledBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "',"+ PanStatus + "");
                return Contact;
            }
        }

        public DataTable QuickAddCustomer(string company, string location, int stateID, int countryID, string contactPersonName, string contactNo, string contactEmail, int addedBy, DateTime addedOn, int principalID, int sectorID, int industryID,string logType)
        {

            if (logType == "FAGlass")
            {
                DataTable data = new DataTable();
                data = db.sub_GetDatatableForFA("USP_CompanyQuickAddDetail '" + company + "','" + location + "'," + stateID + "," + countryID + ",'" + contactPersonName + "','" + contactNo + "','" + contactEmail + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + principalID + "," + sectorID + "," + industryID + "");
                return data;
            }
            else
            {
                DataTable data = new DataTable();
                data = db.sub_GetDatatableForFG("USP_CompanyQuickAddDetail '" + company + "','" + location + "'," + stateID + "," + countryID + ",'" + contactPersonName + "','" + contactNo + "','" + contactEmail + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + principalID + "," + sectorID + "," + industryID + "");
                return data;
            }
        }

        public DataTable AddORUpdateNewCompany(bool isNewAdded, int companyID, string companyName, int principalID, int industryID, int sectorID, int addedBY, DateTime addedON, 
            int modifiedBY, DateTime modifiedON, bool isActive, string logType)
        {
            if (logType == "FAGlass")
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFA(" USP_CustomerNewDetail " + isNewAdded + "," + companyID + ", '" + companyName.Replace("'", "''") + "'," + principalID + "," + industryID + "," + sectorID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Contact;
            }
            else
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFG(" USP_CustomerNewDetail " + isNewAdded + "," + companyID + ", '" + companyName.Replace("'", "''") + "'," + principalID + "," + industryID + "," + sectorID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Contact;
            }
        }

        public DataTable UpdateCustomer(bool isNewAdded, int companyID, string companyName, int principalID, int industryID, int sectorID, int addedBY, DateTime addedON, int modifiedBY, 
            DateTime modifiedON, bool isActive, string logType)
        {
            if(logType == "FAGlass")
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFA(" USP_CustomerUpdateDetail " + isNewAdded + "," + companyID + ", '" + companyName.Replace("'", "''") + "'," + principalID + "," + industryID + "," + sectorID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Contact;
            }
            else
            {
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                DataTable Contact = new DataTable();
                Contact = db.sub_GetDatatableForFG(" USP_CustomerUpdateDetail " + isNewAdded + "," + companyID + ", '" + companyName.Replace("'", "''") + "'," + principalID + "," + industryID + "," + sectorID + "," + addedBY + ",'" + Convert.ToDateTime(addedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBY + ",'" + Convert.ToDateTime(modifiedON).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Contact;
            }
        }

        public DataTable ValidateCompanyName(string data)
        {
            DataTable Company = new DataTable();
            Company = db.sub_GetDatatableForFG("USP_CompanyVerification  '" + data + "'");
            return Company;
        }

        public DataTable GetCompanyList(string searchText, int UserID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CompanyList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Search", searchText);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_CompanyList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Search", searchText);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetCompanyData(int USP_CompanyDetail, string location, string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFA("USP_CompanyDetail  " + USP_CompanyDetail + ",'" + location + "'");
                return Company;
            }
            else
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFG("USP_CompanyDetail  " + USP_CompanyDetail + ",'" + location + "'");
                return Company;
            }
        }

        public DataTable GetAccountData(int companyID, int AddedBY)
        {
            DataTable Company = new DataTable();
            Company = db.sub_GetDatatableForFG("USP_AccountDetail " + companyID + "," + AddedBY + "");
            return Company;
        }

        public DataTable GetContactData(int companyID, int AddedBY)
        {
            DataTable Company = new DataTable();
            Company = db.sub_GetDatatableForFG("USP_ContactDetail " + companyID + "," + AddedBY + "");
            return Company;
        }

        public DataTable GetLocationData(int companyID, int AddedBY)
        {
            DataTable Company = new DataTable();
            Company = db.sub_GetDatatableForFG("USP_LocationDetail " + companyID + "," + AddedBY + "");
            return Company;
        }

        public DataTable GetNotesForLocation(int compID, string loc, string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFA("USP_NotesList " + compID + ",'" + loc + "'");
                return Company;
            }
            else
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFG("USP_NotesList " + compID + ",'" + loc + "'");
                return Company;
            }
        }


        public DataTable QuickUpdateCustomer(int companyID, int locationID, string location, int stateID, int countryID, string contactPersonName, string contactNo, string contactEmail, int addedBy, DateTime addedOn)
        {
            DataTable dataDL = new DataTable();
            dataDL = db.sub_GetDatatable("USP_CompanyQuickUpdateDetail " + companyID + "," + locationID + ",'" + location + "'," + stateID + "," + countryID + ",'" + contactPersonName + "','" + contactNo + "','" + contactEmail + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'");
            return dataDL;
        }

        public DataSet GetCompanyBussienssDetail(string logType)
        {
            if(logType == "FAGlass")
            {
                DataSet Stats = new DataSet();
                Stats = db.sub_GetDataSetsForFA("USP_AtAGlance ");
                return Stats;
            }
            else
            {
                DataSet Stats = new DataSet();
                Stats = db.sub_GetDataSetsForFG("USP_AtAGlance ");
                return Stats;
            }
        }


        public int ClearTempTableForUser(int currentUser, int ID, string logType)
        {
            if(logType == "FAGlass")
            {
                int i = db.sub_ExecuteNonQueryForFA("USP_ClearTempTableForUser " + currentUser + "," + ID + "");
                return i;
            }
            else
            {
                int i = db.sub_ExecuteNonQueryForFG("USP_ClearTempTableForUser " + currentUser + "," + ID + "");
                return i;
            }
        }

        public int MergeSelectedCompany(int iD, int companyID)
        {
            int i = db.sub_ExecuteNonQuery("USP_MERGECOMPANYNAME " + companyID + "," + iD + "");
            return i;
        }

        //Item Module
        public DataTable SaveItemDetails(bool isNew, int itemID, string itemDescription, string TallyName, string itemNote, string partNo, string hSNCode, string unit, string manufacture, int categoryID, int addedBy, DateTime addedOn, int lastModifiedBy, DateTime lastModifiedOn, bool isActive, float CostPrice, decimal SellingPrice, int itemType)
        {
            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("USP_ItemNewDetails " + isNew + "," + itemID + ", '" + itemDescription + "','" + TallyName + "', '" + itemNote + "','" + partNo + "','" + hSNCode + "','" + unit + "', '" + manufacture + "', " + categoryID + "," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + lastModifiedBy + ",'" + Convert.ToDateTime(lastModifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "', " + isActive + "," + CostPrice + "," + SellingPrice + " , " + itemType + "");
            return Item;
        }


        public DataTable GetSelectedItemEditData(int itemID)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_ItemDataToEdit " + itemID + " ");
            return List;
        }

        public DataTable GetItemPartNo(string partno)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_ItemPartNo '"+partno+"'");
            return List;
        }


        public DataTable GetItemList(int Type, string Text, int ID, string TagID)
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_ItemSummaryList " + Type + ",'" + Text + "', " + ID + ", '" + TagID + "' " );
            return ItemList;
        }

        public DataTable GetSummaryListWithoutTagID(int Type, string Text, int ID)
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_ItemSummaryListWithoutTagID " + Type + ",'" + Text + "', " + ID + "");
            return ItemList;
        }

        public DataTable GetItemBOMSummary()
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_ItemBOMSummaryList ");
            return ItemList;
        }

        public DataTable GetBOMItemDetail(int SetID)
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_ItemBOMDetails " + SetID + "");
            return ItemList;
        }


        public DataTable GetCompanyData(int companyID)
        {
            DataTable Company = new DataTable();
            Company = db.sub_GetDatatableForFG("USP_CompanyDetailsEdit " + companyID + "");
            return Company;
        }

        public DataTable AddNewNotes(int companyID, int locationID, string subject, string notes, int addedBy, DateTime addedOn, int modifiedBy, DateTime modifiedOn, int isActive, string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFA("USP_NotesInsert " + companyID + "," + locationID + ",'" + subject.Replace("'", "/'") + "','" + notes.Replace("'", "/'") + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBy + ",'" + Convert.ToDateTime(modifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Company;
            }
            else
            {
                DataTable Company = new DataTable();
                Company = db.sub_GetDatatableForFG("USP_NotesInsert " + companyID + "," + locationID + ",'" + subject.Replace("'", "/'") + "','" + notes.Replace("'", "/'") + "'," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + modifiedBy + ",'" + Convert.ToDateTime(modifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + isActive + "");
                return Company;
            }
        }


        // AT A GLANCE

        public DataSet GetEnquiryReport()
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_AtAGlanceEnquiry ");
            return Stats;
        }

        public DataSet GetQuotationReport()
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_AtAGlanceQuotation ");
            return Stats;
        }

        public DataTable GetEnquiryDetails(int type, int id)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_AtAGlanceSeletedDetailForEnquiry " + type + "," + id + "");
            return List;
        }

        public DataTable GetQuotationDetails(int type, int id)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_AtAGlanceSeletedDetailForQuotation " + type + "," + id + "");
            return List;
        }

        public DataTable GetSalesmanReport()
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_AtAGlanceSalesPerson");
            return List;
        }


        public DataTable GetSalesPersonDetails(int id)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_AtAGlanceSelectedDetailFroSalesman " + id + "");
            return List;
        }


        public DataSet GetLocationSummary(int companyID, int locationID)
        {
            DataSet Stats = new DataSet();
            Stats = db.sub_GetDataSets("USP_CompanyBussiness " + companyID + "," + locationID + "");
            return Stats;
        }

        public DataTable GetEnquiryListForLocation(int companyID, int locationID, int status)
        {
            {
                DataTable List = new DataTable();
                List = db.sub_GetDatatable("USP_AtAGlanceLocationEnquiry " + companyID + "," + locationID + "," + status + "");
                return List;
            }
        }

        public DataTable GetQuotationListForLocation(int companyID, int locationID, int statusID)
        {
            DataTable List = new DataTable();
            List = db.sub_GetDatatable("USP_AtAGlanceLocationQuotation " + companyID + "," + locationID + "," + statusID + "");
            return List;
        }

        public DataTable GetCloseStageList()
        {
            DataTable close = new DataTable();
            close = db.sub_GetDatatable(" USP_CloseStage ");
            return close;
        }

        public DataTable GetOpenStageList()
        {
            DataTable open = new DataTable();
            open = db.sub_GetDatatable(" USP_OpenStage ");
            return open;
        }


        // EMployeee Management Code
        public DataTable SaveEmployeeDetails(bool isNew, Int64 EmployeeID, string Emp_Name, string Emp_CurrentAddress, string Emp_MobileNo, DateTime DateOfBirth, string BloodGroup, string Currently_LivingWith, string Emp_FatherName, string Emp_MotherName,
                   string Emp_BrotherSister, string Parent_ContNo, string ParentAddress, string VillageAddress, string EmergencyContact, string EducationQualification, string OtherCertification, Int64 AddedBy, DateTime AddedOn, String EmployeeDeviceID, String SpouseName, String Gender, string CompanyContactNo)
        {

            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("USP_INSERT_EMPLOYEEMASTER " + isNew + ", " + EmployeeID + ", '" + Emp_Name + "', '" + Emp_CurrentAddress + "','" + Emp_MobileNo + "','" + Convert.ToDateTime(DateOfBirth).ToString("yyyy-MM-dd") + "','" + BloodGroup + "','" + Currently_LivingWith + "','" + Emp_FatherName + "','" + Emp_MotherName + "','" + Emp_BrotherSister + "', '" + Parent_ContNo + "','" + ParentAddress + "','" + VillageAddress + "','" + EmergencyContact + "','" + EducationQualification + "','" + OtherCertification + "','" + AddedBy + "','" + EmployeeDeviceID + "','" + SpouseName + "','" + Gender + "','" + CompanyContactNo + "'");
            return Item;

        }
        public DataTable UpdateEmployeeDetails(bool isNew, Int64 EmployeeID, string Emp_Name, string Emp_CurrentAddress, string Emp_MobileNo, DateTime DateOfBirth, string BloodGroup, string Currently_LivingWith, string Emp_FatherName, string Emp_MotherName,
             string Emp_BrotherSister, string Parent_ContNo, string ParentAddress, string VillageAddress, string EmergencyContact, string EducationQualification, string OtherCertification, Int64 AddedBy, DateTime AddedOn, String EmployeeDeviceID, String SpouseName, String Gender, string CompanyContactNo)
        {

            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("USP_INSERT_EMPLOYEEMASTER " + isNew + ", " + EmployeeID + ", '" + Emp_Name + "', '" + Emp_CurrentAddress + "','" + Emp_MobileNo + "','" + Convert.ToDateTime(DateOfBirth).ToString("yyyy-MM-dd") + "','" + BloodGroup + "','" + Currently_LivingWith + "','" + Emp_FatherName + "','" + Emp_MotherName + "','" + Emp_BrotherSister + "', '" + Parent_ContNo + "','" + ParentAddress + "','" + VillageAddress + "','" + EmergencyContact + "','" + EducationQualification + "','" + OtherCertification + "','" + AddedBy + "','" + EmployeeDeviceID + "','" + SpouseName + "','" + Gender + "','" + CompanyContactNo + "'");
            return Item;

        }
        public DataTable GetEmployeeSummary()
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_EmployeeSummary ");
            return ItemList;
        }

        public DataSet GetEmployeeList(int EmployeeID)
        {
            DataSet ItemList = new DataSet();
            ItemList = db.sub_GetDataSets("USP_EmployeeSummaryList " + EmployeeID + " ");
            return ItemList;
        }

        public DataTable GetEmployeeItemList(int EmployeeID)
        {
            DataTable ItemList = new DataTable();
            ItemList = db.sub_GetDatatable("USP_EmployeeSummaryList " + EmployeeID + " ");
            return ItemList;
        }
        public DataTable DeleteEmployeeDetails(Int64 EmployeeID, Int64 AddedBy, bool IsCancel)
        {
            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("SP_InactiveEmployeeMasterData  " + EmployeeID + ", '" + AddedBy + "'," + IsCancel + "");
            return Item;
        }


        public DataTable GetUnverifiedUserDetail(int userID)
        {
            DataTable Data = new DataTable();
            Data = db.sub_GetDatatable("USP_UnverifiedUserDetail  " + userID + "");
            return Data;
        }

        public DataTable GetLeaveSummary(int UserID)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_GETRecentFiveLeave " + UserID + "");
            return LeaveList;
        }
        // Attendance
        public DataTable GetContainerUpdateDischargeData(string EmployeeName)
        {
            DataTable dt = new DataTable();
            dt = db.sub_GetDatatable("USP_getUpdateData  '" + EmployeeName + "'");
            return dt;
        }
        public DataSet getDuplicateData(string InTime, string Employee)
        {
            DataSet PaymentDS = new DataSet();
            PaymentDS = db.sub_GetDataSets("USP_GET_DUPLICATE_InTime_Employee '" + InTime + "','" + Employee + "'");
            return PaymentDS;
        }

        public DataTable GetAttendaceDetail(int iD, string monthName, string year)
        {
            DataTable dt = new DataTable();
            dt = db.sub_GetDatatable("USP_AttendanceReportForSelectedUser  " + iD + ",'" + monthName + "'," + year + "");
            return dt;
        }

        public DataTable GetHolidayList()
        {
            DataTable dt = new DataTable();
            dt = db.sub_GetDatatable("USP_HolidayList");
            return dt;
        }

        public DataSet GetFullQuotDetail(int ID)
        {
            DataSet data = new DataSet();
            data = db.sub_GetDataSets("USP_FullQuotation " + ID + "");
            return data;
        }

        //Dynamic Report

        public DataTable GetAllFieldForSelectedTable(int tableID, string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable dt = new DataTable();
                dt = db.sub_GetDatatableForFA("USP_DynamicReportField  " + tableID + "");
                return dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt = db.sub_GetDatatableForFG("USP_DynamicReportField  " + tableID + "");
                return dt;
            }
        }

        public DataSet QuotationFilter()
        {
            DataSet data = new DataSet();
            data = db.sub_GetDataSets("USP_FilterForQuotationReport ");
            return data;
        }

        //streak data 

        public DataTable GetStreakList(int AddedBy)
        {
            DataTable dt = new DataTable();
            dt = db.sub_GetDatatable("USP_STreakDataList " + AddedBy + " ");
            return dt;
        }

        public int DataValidation(int type, int companyID, int locationID, string companyName, string location, int iD, int addedBy, DateTime addedOn, int principalID, int industryID, int sectorID, int Isupdate)
        {
            int i = db.sub_ExecuteNonQuery("USP_UpdateValidatedData " + type + "," + companyID + "," + locationID + ",'" + companyName + "','" + location + "'," + iD + "," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss") + "'," + principalID + "," + industryID + "," + sectorID + ", " + Isupdate + "");
            return i;
        }


        public DataTable GetReportParameteterOperator(int ID)
        {
            DataTable Data = new DataTable();
            Data = db.sub_GetDatatable("USP_DynamicReportSelectorData  " + ID + "");
            return Data;
        }

        public DataTable GetReportParameteterOptions(int fieldID)
        {
            DataTable Data = new DataTable();
            Data = db.sub_GetDatatable("USP_DynamicReportOptionValues  " + fieldID + "");
            return Data;
        }
        //start Principal Master
        public DataTable GetPrincipalDetails(Int32 PrincipalID)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetID_wise_Principal " + PrincipalID + "");
            return AttachmentDT;
        }
        public DataTable GetPrincipalSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetPrincipalList");
            return AttachmentDT;
        }
        public DataTable DeletePrincipalDetails(Int32 PrincipalID, Int32 AddedBy)
        {

            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_Principal " + PrincipalID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable SavePrincipalDetails(bool IsNew, string Principal, Int32 PrincipalID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_Principal " + IsNew + ",'" + Principal + "'," + PrincipalID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable UpdatePrincipalDetails(bool IsNew, string Principal, Int32 PrincipalID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_Principal " + IsNew + ",'" + Principal + "'," + PrincipalID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable ValidPrincipal(string Principal)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Valid_Principal  '" + Principal + "'");
            return AttachmentDT;
        }
        //INdustry
        public DataTable SaveIndustry(bool IsNew, string IndustryName, Int32 IndustryID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_Industry " + IsNew + ",'" + IndustryName + "'," + IndustryID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable DeleteIndustry(Int32 IndustryID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_Industry " + IndustryID + "," + AddedBy + "");
            return AttachmentDT;
        }

        public DataTable GetIndustrySummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetIndustryList");
            return AttachmentDT;
        }
        public DataTable GetIndustryDetails(Int32 IndustryID)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetID_wise_Industry " + IndustryID + "");
            return AttachmentDT;
        }
        //INdustry
        //for Sector
        public DataTable SaveSector(bool IsNew, string SectorName, Int32 SectorID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_Sector " + IsNew + ",'" + SectorName + "'," + SectorID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable DeleteSector(Int32 SectorID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_sector " + SectorID + "," + AddedBy + "");
            return AttachmentDT;
        }

        public DataTable GetSectorSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetSectorList");
            return AttachmentDT;
        }
        public DataTable GetSectorDetails(Int32 SectorID)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetID_wise_Sector " + SectorID + "");
            return AttachmentDT;
        }
        // Sector
        public DataTable GetStreakDataForID(int iD)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_StreakDataForID " + iD + "");
            return AttachmentDT;
        }

        public int CompanyDataUpdation(int type, int companyID, int iD)
        {
            int i = db.sub_ExecuteNonQuery("USP_CompanyUpdateSD " + type + "," + companyID + "," + iD + "");
            return i;
        }


        public int UpdateStreakStage(int type, int id, string stage)
        {
            int i = db.sub_ExecuteNonQuery("USP_StreakStageUpdation " + type + "," + id + ",'" + stage + "'");
            return i;
        }
        //To save Gmail Pwd
        public DataTable SaveGmailPwd(Int64 EmployeeID, string GmailPwd)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_SAVEGmailPassword " + EmployeeID + ",'" + GmailPwd + "'");
            return AttachmentDT;
        }


        public DataTable GetGmailPassword(int addedBY)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetGmailPassword '" + addedBY + "'");
            return AttachmentDT;
        }
        //End For Gmail Pwd
        //For Department
        public DataTable GetDepartmentSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetDepartmentList");
            return AttachmentDT;
        }
        public DataTable DeleteDepartment(Int32 DepartmentID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_DEPARTMENT " + DepartmentID + "," + AddedBy + "");
            return AttachmentDT;
        }
        public DataTable SaveDepartment(bool IsNew, string DepartmentName, Int32 DepartmentID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_DEPARTMENT " + IsNew + ",'" + DepartmentName + "'," + DepartmentID + "," + AddedBy + "");
            return AttachmentDT;
        }

        //End Department

        public DataTable GetZoneSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetZoneList");
            return AttachmentDT;
        }
        public DataTable GetStateSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_State");
            return AttachmentDT;
        }
        public DataTable AddorEditZone(bool IsNew, int ZoneID, string ZoneName, string State, int AddedBY, DateTime AddedON, int IsActive)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_AddorEditZone " + IsNew + "," + ZoneID + ",'" + ZoneName + "'," + "'" + State + "'," + AddedBY + "," + IsActive + "");
            return AttachmentDT;
        }

        public DataTable SaveOrEditZone(int id)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GETZoneWiseStateDetails " + id + "");// 
            return AttachmentDT;
        }


        //For email
        public DataTable GetEmailSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetTemplateList");
            return AttachmentDT;
        }

        public DataTable SaveTemplate(bool IsNew, string TemplateName, Int32 TemplateID, Int32 AddedBy, string Body)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_Template " + IsNew + ",'" + TemplateName + "'," + TemplateID + "," + AddedBy + ",'" + Body + "'");
            return AttachmentDT;
        }
        public DataTable DeleteTemplate(Int32 TemplateID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_template " + TemplateID + "," + AddedBy + "");
            return AttachmentDT;
        }
        //End email
        //For Quotation Terms and Condition
        public DataTable GetQuotTermConditionSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_GetQuotationTermsTemplateList");
            return AttachmentDT;
        }
        public DataTable SaveQuotTermCondition(bool IsNew, string TemplateName, Int32 TemplateID, Int32 AddedBy, string Packing, string Freight, string ExGodown,
            string Taxes, string Warranty, string Payment, string Delivery)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Save_QuotationTermsTemplate " + IsNew + ",'" + TemplateName + "'," + TemplateID + "," + AddedBy + ",'" + Packing + "','" + Freight + "'," +
                "'" + ExGodown + "','" + Taxes + "','" + Warranty + "','" + Payment + "','" + Delivery + "'");
            return AttachmentDT;
        }
        public DataTable DeleteQuotTermCondition(Int32 TemplateID, Int32 AddedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_Delete_QuotTermCondition " + TemplateID + "," + AddedBy + "");
            return AttachmentDT;
        }
        //End Quotation Terms and Condition

        //Start Of leave Planning
        public DataTable GetLeaveList()
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_LEAVETYPELIST");
            return LeaveList;
        }
        public DataTable Saveleave(int IsNew, int LeaveID, string FromDate, string Todate,
                        int Days, int LeaveTypeID, string LeaveReason, int ApprovedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_INSERT_INTO_LEAVEPLAN " + IsNew + "," + LeaveID + ",'" + FromDate + "','" + Todate + "'," + Days + "," + LeaveTypeID + ",'" + LeaveReason + "'," + ApprovedBy + "");
            return AttachmentDT;
        }

        public DataTable GetLeaveSummary(string fromdate, string Todate, int UserID)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_LEAVESummary '" + fromdate + "' , '" + Todate + "'," + UserID + "");
            return LeaveList;
        }

        public DataTable GetPendingLeaveSummary()
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_PendingLeaveSummary ");
            return LeaveList;
        }
        public DataTable GetAdminLeaveSummary(string fromdate, string Todate, int UserID)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_ADMINLEAVESummary '" + fromdate + "' , '" + Todate + "'," + UserID + "");
            return LeaveList;
        }

        public DataTable GetUserList()
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_UserLIST");
            return LeaveList;
        }
        public DataTable GetEditLeaveData(int LeaveID)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_GetEditLeaveData " + LeaveID + "");
            return LeaveList;
        }
        public DataTable Declineleave(int IsNew, int LeaveID, string FromDate, string Todate,
                        int Days, int LeaveTypeID, string LeaveReason, int ApprovedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_DECLINE_LEAVEPLAN " + IsNew + "," + LeaveID + ",'" + FromDate + "','" + Todate + "'," + Days + "," + LeaveTypeID + ",'" + LeaveReason + "'," + ApprovedBy + "");
            return AttachmentDT;
        }
        public DataTable SaveAdminleave(int LeaveID, string FromDate, string Todate,
                        int Days, int LeaveTypeID, string LeaveReason, int AddedBy, int ApprovedBy)
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_INSERT_INTO_ADMIN_LEAVEPLAN " + LeaveID + ",'" + FromDate + "','" + Todate + "'," + Days + "," + LeaveTypeID + ",'" + LeaveReason + "'," + AddedBy + "," + ApprovedBy + "");
            return AttachmentDT;
        }

     

        public DataTable GetEmailDataForLeavePlan(int UserID)
        {
            DataTable LeaveList = new DataTable();
            LeaveList = db.sub_GetDatatable("USP_GetEmailDataForLeavePlan " + UserID + "");
            return LeaveList;
        }
        //END Of leave Planning

        public DataTable GetSavedData(int id, string logType)
        {

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementDetailsForBox";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", id);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_RequirementDetailsForBox";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ID", id);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable ValidateUserForEdit(int id, int userID)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_QuotationValidateRights " + userID + ", " + id + "");
            return data;

        }

        public int RequestForQuotationEditRight(int id, string remark, int userID, DateTime date)
        {
            int i = db.sub_ExecuteNonQuery("USP_QuotationRequestPermission " + id + "," + userID + ",'" + remark + "','" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "'");
            return i;
        }

        public DataTable NewEditPermissionSummary(int userID)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_QuotationNewPermissionRequest " + userID + "");
            return data;
        }

        public int ChangePermission(int id, int status, int userID, DateTime date)
        {
            int i = db.sub_ExecuteNonQuery("USP_QuotationChangePermission " + id + "," + userID + ",'" + status + "','" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "'");
            return i;
        }

        public DataTable PermmisionSummary(int status, int userID, DateTime fromDate, DateTime toDate)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_QuotationPermissionSummary " + status + "," + userID + ",'" + Convert.ToDateTime(fromDate).ToString("yyyy-MMM-dd HH:mm:ss") + "','" + Convert.ToDateTime(toDate).ToString("yyyy-MMM-dd HH:mm:ss") + "'");
            return data;
        }
        
        public DataTable GetSearchResultForPipeline(string searchText)
        {
            DataTable data = new DataTable();
            data = db.sub_GetDatatable("USP_SearchBoxInSalesPipeline '" + searchText +"'");
            return data;
        }
        public DataTable GetAssignToDropdownForRequiremnt(int userID, string logType)
        {
            //DataTable DataDL = new DataTable();
            //DataDL = db.sub_GetDatatable("USP_GetAssignToUserList " + userID  );
            //return DataDL;

            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection accessDB = new DB.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetAssignToUserList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection accessDB = new DB.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetAssignToUserList";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataTable GetAssignToListForSP(int userID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetAssignToListForSP";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetAssignToListForSP";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable SaveQuotationLink(int BoxID,string QuoteID,int userID)
        {
            DateTime d = DateTime.Now;

            DataTable data = new DataTable();
            data = db.sub_GetDatatableForFG("USP_SaveQuotationLink " + BoxID + ",'" + QuoteID + "'," + userID  );
            return data;
        }

        
        public DataTable GetLinkedQuotation(int BoxID, string logType)
        {
            if(logType == "FAGlass")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetLinkedQuotation";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", BoxID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetLinkedQuotation";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", BoxID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        // developed by prathamesh mane
        public DataTable SaveItemDetailsForMerging(bool isNew, int itemID, string itemDescription, string TallyName, string itemNote, string hSNCode, string unit, string manufacture, int categoryID, int addedBy, DateTime addedOn, int lastModifiedBy, DateTime lastModifiedOn, bool isActive, float SellingPrice, string checkedItemMergeID)
        {
            DataTable Item = new DataTable();
            Item = db.sub_GetDatatable("USP_ItemNewDetailsForMergeItem " + isNew + "," + itemID + ", '" + itemDescription + "','" + TallyName + "', '" + itemNote + "','" + hSNCode + "','" + unit + "', '" + manufacture + "', " + categoryID + "," + addedBy + ",'" + Convert.ToDateTime(addedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "'," + lastModifiedBy + ",'" + Convert.ToDateTime(lastModifiedOn).ToString("dd-MMM-yyyy HH:mm:ss").Replace(".", ":") + "', " + isActive + "," + SellingPrice + " ,'" + checkedItemMergeID + "'");
            return Item;
        }

        public DataTable SaveMenuLogDetails(int menuID, int subMenuID, string redirectView, string ip, string mac, int addedBy, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_AddMenuLogDetailsCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@MenuID", menuID);
                        objCommand.Parameters.AddWithValue("@SubMenuID", subMenuID);
                        objCommand.Parameters.AddWithValue("@RedirectView", redirectView);
                        objCommand.Parameters.AddWithValue("@IPAddress", ip);
                        objCommand.Parameters.AddWithValue("@MACAddress", mac);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_AddMenuLogDetailsCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@MenuID", menuID);
                        objCommand.Parameters.AddWithValue("@SubMenuID", subMenuID);
                        objCommand.Parameters.AddWithValue("@RedirectView", redirectView);
                        objCommand.Parameters.AddWithValue("@IPAddress", ip);
                        objCommand.Parameters.AddWithValue("@MACAddress", mac);
                        objCommand.Parameters.AddWithValue("@AddedBy", addedBy);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataTable GetUserDropDownList(int userID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetUserListForLog";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetUserListForLog";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        public DataTable GetActivityLogSummary(string fromDate, string toDate, int userID,int tl_id, int sessionID, string logType)
        {
            if (logType == "FAGlass")
            {
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetActivityLogData";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", toDate);
                        objCommand.Parameters.AddWithValue("@UserID", userID);
                        objCommand.Parameters.AddWithValue("@SessionID", sessionID);
                        objCommand.Parameters.AddWithValue("@TL_ID", tl_id);
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                string sqlCommandString = "";
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_GetActivityLogData";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                        objCommand.Parameters.AddWithValue("@ToDate", toDate);
                        objCommand.Parameters.AddWithValue("@UserID", userID);
                        objCommand.Parameters.AddWithValue("@SessionID", sessionID);
                        objCommand.Parameters.AddWithValue("@TL_ID", tl_id);

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }

        //New For Export Invoice
        public DataTable GetDropdownList(string Table, string Column, string Condition, string OrderBy)
        {
            DataTable DT = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            DT = db.sub_GetDatatableForFG("get_sp_table  '" + Table + "','" + Column + "','" + Condition + "','" + OrderBy + "'");
            return DT;
        }


        ////////  27-07-23
        public DataTable AddOrEditProjectImage(SalesPipeline master, DataTable fUAttach, string logType)
        {
            if (logType == "FAGlass")
            {
                string sqlCommandString;
                DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_AddOrEditProjectImage";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", master.BoxID);
                        objCommand.Parameters.AddWithValue("@AddedBy", master.AddedBy);

                        if (fUAttach != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_SPAttachments";
                            param2.Value = fUAttach;
                            param2.TypeName = "PT_SPAttachments";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();

                        return dtClass;

                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                string sqlCommandString;
                DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
                using (SqlConnection connection = objConn.GetConnection)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_AddOrEditProjectImage";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@BoxID", master.BoxID);
                        objCommand.Parameters.AddWithValue("@AddedBy", master.AddedBy);

                        if (fUAttach != null)
                        {
                            SqlCommand objCommand1 = new SqlCommand(sqlCommandString, connection);
                            objCommand1.CommandType = CommandType.StoredProcedure;
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@PT_SPAttachments";
                            param2.Value = fUAttach;
                            param2.TypeName = "PT_SPAttachments";
                            param2.SqlDbType = SqlDbType.Structured;
                            objCommand.Parameters.Add(param2);
                        }
                        DataTable dtClass = new DataTable();
                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtClass);
                        }
                        connection.Close();

                        return dtClass;

                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
        }









    }
}
