using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using DB = BombayToolsDBConnector;

namespace BombayToolsDBConnector.Helper
{
    public class DBOperationsForBombayTools
    {
        //SqlCommand command;
        SqlConnection connection;


        //start : creates a new DB connection
        private void sub_ConnectDB()
        {

            DB.DBConnection objConn = new DB.DBConnection();
            //string connetionString = null;
            connection = objConn.GetConnection;
            // connection = new SqlConnection(connetionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection = objConn.GetConnection;
                    connection.Open();

                }
            }
        }
        private void sub_ConnectDBForFGERP()
        {

            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            //string connetionString = null;
            connection = objConn.GetConnection;
            // connection = new SqlConnection(connetionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection = objConn.GetConnection;
                    connection.Open();

                }
            }
        }
        private void sub_ConnectDBForOpusPro()
        {

            DB.OpusProDBConnection objConn = new DB.OpusProDBConnection();
            //string connetionString = null;
            connection = objConn.GetConnection;
            // connection = new SqlConnection(connetionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection = objConn.GetConnection;
                    connection.Open();

                }
            }
        }

        public DataTable sub_GetDatatable(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                sub_ConnectDB();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                objCommand.CommandTimeout = 300;
                da.Fill(dt);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
            return dt;
        }

        public DataTable sub_GetDatatableForFG(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                sub_ConnectDBForFGERP();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                objCommand.CommandTimeout = 300;
                da.Fill(dt);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
            return dt;
        }

        public DataTable sub_GetDatatableForOpusPRO(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                sub_ConnectDBForOpusPro();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                objCommand.CommandTimeout = 300;
                da.Fill(dt);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
            return dt;
        }

        public DataSet sub_GetDataSets(string strSQL)
        {
            DataSet ds = new DataSet();


            try
            {
                sub_ConnectDB();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                objCommand.CommandTimeout = 600;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                da.Fill(ds);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int sub_ExecuteNonQueryForFA(string strSQL)
        {
            int i = 0;
            try
            {
                sub_ConnectDBForFAGlass();
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public DataSet sub_GetDataSetsForFA(string strSQL)
        {
            DataSet ds = new DataSet();


            try
            {
                sub_ConnectDBForFAGlass();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                objCommand.CommandTimeout = 600;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                da.Fill(ds);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        private void sub_ConnectDBForFAGlass()
        {

            DB.FAglassDBConnection objConn = new DB.FAglassDBConnection();
            //string connetionString = null;
            connection = objConn.GetConnection;
            // connection = new SqlConnection(connetionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection = objConn.GetConnection;
                    connection.Open();

                }
            }
        }

        public DataTable sub_GetDatatableForFA(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                sub_ConnectDBForFAGlass();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                objCommand.CommandTimeout = 300;
                da.Fill(dt);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
            return dt;
        }

        public DataSet sub_GetDataSetsForFG(string strSQL)
        {
            DataSet ds = new DataSet();


            try
            {
                sub_ConnectDBForFGERP();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand objCommand = new SqlCommand(strSQL, connection);
                objCommand.CommandTimeout = 600;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = objCommand;
                da.Fill(ds);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int sub_ExecuteNonQuery(string strSQL)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int sub_ExecuteNonQueryForFG(string strSQL)
        {
            int i = 0;
            try
            {
                sub_ConnectDBForFGERP();
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }


        //For Attachment
        public DataTable AddAttachment(int Userid, byte[] bytes, string contentType, string fname)
        {
            sub_ConnectDB();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("USP_QuotationTEMPdata", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FNAME", fname);
                cmd.Parameters.AddWithValue("@BYTES", bytes);
                cmd.Parameters.AddWithValue("@CONTENTTYPE", contentType);
                cmd.Parameters.AddWithValue("@USERID", Userid);


                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

            }
            return dt;
        }

        // For adding new quotation 
        public int sub_ExecuteNonQuery_SaveQuotationItemData(string SP_Name, Dictionary<object, object> lstparam, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in lstparam)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_QuotationItem";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_QuotationItem";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int sub_ExecuteNonQuery_SaveNewBoxDetail(string SP_Name, Dictionary<object, object> lstparam)
        {
            int i = 0;
            try
            {
                sub_ConnectDBForFGERP();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in lstparam)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }



                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int sub_ExecuteNonQuery_SaveNewDirectBoxDetail(string SP_Name, Dictionary<object, object> lstparam)
        {
            int i = 0;
            try
            {
                sub_ConnectDBForFGERP();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in lstparam)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                //if (dataTable1 != null)
                //{
                //    SqlParameter param1 = new SqlParameter();
                //    param1.ParameterName = "@PT_RequirementBox";
                //    param1.Value = dataTable1;
                //    param1.TypeName = "PT_RequirementBox";
                //    param1.SqlDbType = SqlDbType.Structured;
                //    cmd.Parameters.Add(param1);
                //}
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }


        public int sub_ExecuteNonQuery_UpdateDetails(string SP_Name, Dictionary<object, object> parameterList, string logType)
        {
            if(logType == "FAGlass")
            {
                int i = 0;
                try
                {
                    DataTable DataDL = new DataTable();
                    sub_ConnectDBForFAGlass();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameterList)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    DataSet ds = new DataSet();
                    cmd.CommandText = SP_Name;
                    cmd.Connection = connection;
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return i;
            }
            else
            {
                int i = 0;
                try
                {
                    DataTable DataDL = new DataTable();
                    sub_ConnectDBForFGERP();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameterList)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    DataSet ds = new DataSet();
                    cmd.CommandText = SP_Name;
                    cmd.Connection = connection;
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return i;
            }
        }

        public int sub_ExecuteNonQuery_SaveNewBOMItem(string SP_Name, Dictionary<object, object> lstparam, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in lstparam)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_BOMItemGroup";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_BOMItemGroup";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public DataSet AddAttendanceTableData(string SP_Name, Dictionary<object, object> lstparam, DataTable dt)
        {
            DataSet ds = new DataSet();
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in lstparam)
                {

                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                if (dt != null)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Emp_Attendance";
                    param.Value = dt;
                    param.TypeName = "Emp_Attendance";
                    param.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = SP_Name;
                cmd.Connection = connection;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int UpdateDirectRequirementBoxDetail(string SP_Name,Dictionary<object, object> parameterList, string logType)
        {
            if(logType == "FAGlass")
            {
                int i = 0;
                try
                {
                    DataTable DataDL = new DataTable();
                    sub_ConnectDBForFAGlass();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameterList)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    DataSet ds = new DataSet();
                    cmd.CommandText = SP_Name;
                    cmd.Connection = connection;

                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return i;
            }
            else
            {

                int i = 0;
                try
                {
                    DataTable DataDL = new DataTable();
                    sub_ConnectDBForFGERP();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameterList)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    DataSet ds = new DataSet();
                    cmd.CommandText = SP_Name;
                    cmd.Connection = connection;

                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return i;
            }
        }

        public int sub_ExecuteNonQuery_AssignRoleAndMenu(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_Role_Wise_Menu";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_Role_Wise_Menu";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        //verification
        public DataTable sub_Query_GetEmailVerfied(string SP_Name, DataTable dataTable)
        {
            DataTable DataDL = new DataTable();
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_ScanVerification";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_ScanVerification";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(DataDL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DataDL;
        }

        public int AddNewQuotationTemplate(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_QuotationItem";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_QuotationItem";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int UpdateQuotationTemplate(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_QuotationItem";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_QuotationItem";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int LinkingEnquiry(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_LinkingEnq";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_LinkingEnq";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }


        public int sub_ExecuteNonQuery_AddNewRequirements(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable1, DataTable dataTable2, DataTable dataTable3)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable1 != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_StageMaster";
                    param1.Value = dataTable1;
                    param1.TypeName = "PT_StageMaster";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                if (dataTable2 != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_FieldMaster";
                    param1.Value = dataTable2;
                    param1.TypeName = "PT_FieldMaster";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                if (dataTable3 != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_DropdownMaster";
                    param1.Value = dataTable3;
                    param1.TypeName = "PT_DropdownMaster";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }
        //fOR EMPLOYEE ATTACHMENT SAVING
        public int sub_ExecuteNonQuery_EmployeeSaveAttachment(string SP_Name, Dictionary<object, object> parameterList, DataTable dataTable)
        {
            int i = 0;
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                if (dataTable != null)
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@PT_EmployeeAttachments";
                    param1.Value = dataTable;
                    param1.TypeName = "PT_EmployeeAttachments";
                    param1.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param1);
                }
                DataSet ds = new DataSet();
                cmd.CommandText = SP_Name;
                cmd.Connection = connection;

                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public DataTable GetQuotFilterResult(string SP_Name, Dictionary<object, object> parameterList)
        {
            DataTable DataDL = new DataTable();
            try
            {
                sub_ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameterList)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                cmd.CommandText = SP_Name;
                cmd.Connection = connection;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(DataDL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DataDL;
        }

    }
}
