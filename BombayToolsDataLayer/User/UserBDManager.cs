using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDBConnector;
namespace BombayToolsDataLayer.User
{
    public class UserBDManager
    {
        public DataTable AjaxSaveRoleWiseMenuMapping(Role role, DataTable dataTable)
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
                    sqlCommandString = "USP_AddRoleWiseMenu";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RoleID", role.RoleID);
                    objCommand.Parameters.AddWithValue("@AddedBy", role.AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", role.AddedOn);

                    if (dataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_Role_Wise_Menu";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_Role_Wise_Menu";
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


        //User Rights Option
        public DataTable GetUserListForRights(string logType)
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
                        sqlCommandString = "[USP_GetUserListForWebCRM]";
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

                        sqlCommandString = "[USP_GetUserListForWebCRM]";
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

        public DataSet GetMenuRightsForWebUser(int UserID, string logType)
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
                        sqlCommandString = "[USP_MenuRightsForWebUserOutS]";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", UserID);

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
                        sqlCommandString = "[USP_MenuRightsForWebUserCRM]";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@UserID", UserID);

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
        public int sub_ExecuteNonQuery_AssignRoleAndMenu(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable, DataTable dataMenu, string logType)
        {
            int i = 0;

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

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in parameterList)
                        {
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                        if (dataTable != null)
                        {
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "PT_User_Wise_Menu_Rights";
                            param1.Value = dataTable;
                            param1.TypeName = "PT_User_Wise_Menu_Rights";
                            param1.SqlDbType = SqlDbType.Structured;
                            cmd.Parameters.Add(param1);
                        }
                        if (dataMenu != null)
                        {
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "PT_User_Wise_MainMenu_Rights";
                            param2.Value = dataMenu;
                            param2.TypeName = "PT_User_Wise_MainMenu_Rights";
                            param2.SqlDbType = SqlDbType.Structured;
                            cmd.Parameters.Add(param2);
                        }
                        DataSet ds = new DataSet();
                        cmd.CommandText = SP_Name;
                        cmd.Connection = connection;

                        i = cmd.ExecuteNonQuery();
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

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in parameterList)
                        {
                            cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                        }
                        if (dataTable != null)
                        {
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "PT_User_Wise_Menu_Rights";
                            param1.Value = dataTable;
                            param1.TypeName = "PT_User_Wise_Menu_Rights";
                            param1.SqlDbType = SqlDbType.Structured;
                            cmd.Parameters.Add(param1);
                        }
                        if (dataMenu != null)
                        {
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "PT_User_Wise_MainMenu_Rights";
                            param2.Value = dataMenu;
                            param2.TypeName = "PT_User_Wise_MainMenu_Rights";
                            param2.SqlDbType = SqlDbType.Structured;
                            cmd.Parameters.Add(param2);
                        }
                        DataSet ds = new DataSet();
                        cmd.CommandText = SP_Name;
                        cmd.Connection = connection;

                        i = cmd.ExecuteNonQuery();
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
            
            return i;
        }
        //End For User Rights Option
    }
}
