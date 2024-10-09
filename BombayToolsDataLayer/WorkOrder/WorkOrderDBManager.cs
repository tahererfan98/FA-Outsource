using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DB = BombayToolsDBConnector;

namespace BombayToolsDataLayer.WorkOrder
{
    public class WorkOrderDBManager
    {
        DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
        public DataTable GetWorkOrder(DateTime startDate, DateTime endDate, int userTypeID, int userID, string SearchCriteria, string Search, string logType)
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
                        sqlCommandString = "USP_WebWOListCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@FromDate", startDate.ToString("dd-MMM-yyyy"));
                        objCommand.Parameters.AddWithValue("@ToDate", endDate.ToString("dd-MMM-yyyy"));
                        objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria);
                        objCommand.Parameters.AddWithValue("@Search", Search);
                        objCommand.Parameters.AddWithValue("@UserTypeID", userTypeID);
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
                        sqlCommandString = "USP_WebWOListCRM";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@FromDate", startDate.ToString("dd-MMM-yyyy"));
                        objCommand.Parameters.AddWithValue("@ToDate", endDate.ToString("dd-MMM-yyyy"));
                        objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria);
                        objCommand.Parameters.AddWithValue("@Search", Search);
                        objCommand.Parameters.AddWithValue("@UserTypeID", userTypeID);
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

            //string sqlCommandString;
            //using (SqlConnection connection = objConn.GetConnection)
            //{
            //    try
            //    {
            //        if (connection.State != ConnectionState.Open)
            //        {
            //            connection.Open();
            //        }
            //        sqlCommandString = "USP_WebWOListCRM";
            //        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
            //        objCommand.CommandType = CommandType.StoredProcedure;
            //        objCommand.Parameters.AddWithValue("@FromDate", startDate.ToString("dd-MMM-yyyy"));
            //        objCommand.Parameters.AddWithValue("@ToDate", endDate.ToString("dd-MMM-yyyy"));
            //        objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria);
            //        objCommand.Parameters.AddWithValue("@Search", Search);
            //        objCommand.Parameters.AddWithValue("@UserTypeID", userTypeID);
            //        objCommand.Parameters.AddWithValue("@UserID", userID);
            //        DataTable dtClass = new DataTable();


            //        using (SqlDataAdapter _Data = new SqlDataAdapter())
            //        {
            //            _Data.SelectCommand = objCommand;

            //            _Data.Fill(dtClass);
            //        }
            //        connection.Close();

            //        return dtClass;

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
    }
}
