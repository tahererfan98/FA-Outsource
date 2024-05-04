using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = BombayToolsDBConnector;
using BO = BombayToolsEntities.BusinessEntities;
using BombayToolsEntities.BusinessEntities;

namespace BombayToolsDataLayer.Enquiry
{
    public class EnquiryDBManager
    {

        string sqlCommandString;

        public DataTable GetCustomerMasterList()
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
                    sqlCommandString = "USP_CustomerMasterList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable GetOutsourcePartnerList()
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
                    sqlCommandString = "USP_getOutsourcePartnerList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable GetOSPartnerListAgainstENQNO(string ENQNO)
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
                    sqlCommandString = "USP_getOSPartnerListAgainstENQNO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
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

        public DataTable GetEnquiryEntrySummary(string FromDate, string ToDate, string SearchCriteria, string Search, int UserID)
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
                    sqlCommandString = "USP_GetOutsourceEnquirySummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria != null ? SearchCriteria.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Search", Search != null ? Search.ToString() : "");
                    objCommand.Parameters.AddWithValue("@UserID", UserID);
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

        public DataTable GetProjectListAgainstCustomer(int CustomerID)
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
                    sqlCommandString = "SP_GetProjectListAgainstCustomer";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
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

        public DataTable GetPINOListAgainstCustomer(int CustomerID, int ProjectID)
        {
            string sqlCommandString;
            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetPINOAgainstCustomer";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
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

        public DataSet GetItemListAgainstPINONew(DataTable dtWONO)
        {
            string sqlCommandString;
            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetItemListAgainstPINO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@PINo", PINo);

                    if (dtWONO != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_PINOItemList";
                        param1.Value = dtWONO;
                        param1.TypeName = "PT_PINOItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
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

        public DataTable GetPISizesListAgainstWONO(string PINO, string WONO)
        {
            string sqlCommandString;
            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetPISizesListAgainstWONO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PINO", PINO);
                    objCommand.Parameters.AddWithValue("@WONO", WONO);
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

        public DataTable SaveEnquiryEntry(int ENQID, string ENQNO, string ENQDate, int CustomerID, int ProjectID, string Remarks, DateTime AddedOn, int AddedBy, DataTable dataTable, DataTable dataTable1)
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
                    sqlCommandString = "USP_SaveOutsourceEnquiryDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQID", ENQID);
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    objCommand.Parameters.AddWithValue("@ENQDate", ENQDate);
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    objCommand.Parameters.AddWithValue("@Remarks", Remarks != null ? Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", AddedOn);
                    objCommand.CommandTimeout = 500;

                    if (dataTable.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ENQItemList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_ENQItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (dataTable1.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ENQSizesList";
                        param1.Value = dataTable1;
                        param1.TypeName = "PT_ENQSizesList";
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

        public DataSet GetEnquiryDetail( string ENQNO)
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
                    sqlCommandString = "USP_GetEnquiryDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();


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

        public DataSet GetEnquirySentPartnerDetail(string ESNO, string ENQNO)
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
                    sqlCommandString = "USP_EnquirySentPartnerDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();


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

        public DataTable SaveEnquirySendToPartnerEntry(int ESID, string ESNO, string ESDate, string ENQNO, int CustomerID, int ProjectID, int PartnerID, string Remarks, DateTime AddedOn, int AddedBy)
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
                    sqlCommandString = "USP_SaveOSEnquirySentDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ESID", ESID);
                    objCommand.Parameters.AddWithValue("@ESNO", ESNO);
                    objCommand.Parameters.AddWithValue("@ESDate", ESDate);
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    objCommand.Parameters.AddWithValue("@PartnerID", PartnerID);
                    objCommand.Parameters.AddWithValue("@Remarks", Remarks != null ? Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", AddedOn);
                    objCommand.CommandTimeout = 500;

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

        public DataTable SaveEnquirySendToPartnerAttachment(DataTable DataTable, int AddedBY)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveEnquirySendToPartnerAttachment";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AddedBY", AddedBY);
                    if (DataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_AttachmentM";
                        param1.Value = DataTable;
                        param1.TypeName = "PT_AttachmentM";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    DataTable dtSupplierBillDetails = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtSupplierBillDetails);
                    }
                    connection.Close();
                    return dtSupplierBillDetails;
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

        public DataTable GetEnquirySentSummary(string FromDate, string ToDate, string SearchCriteria, string Search, int UserID)
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
                    sqlCommandString = "USP_GetOSEnquirySentSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria != null ? SearchCriteria.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Search", Search != null ? Search.ToString() : "");
                    objCommand.Parameters.AddWithValue("@UserID", UserID);
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

        public DataTable DeleteFileEnquirySentM(string ESNO, string DocName, string Filepath, string ContentType, int AddedBy)
        {
            string sqlCommandString = "";
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    sqlCommandString = "USP_DeleteFileEnquirySentM";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objCommand.Parameters.AddWithValue("@ESNO", ESNO);
                    objCommand.Parameters.AddWithValue("@DocName", DocName);
                    objCommand.Parameters.AddWithValue("@ContentType", ContentType);
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);

                    DataTable dtSupplierBillDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtSupplierBillDetails);
                    }
                    connection.Close();
                    return dtSupplierBillDetails;
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

        public DataSet GetSizesListForTemplateOLD(DataTable dtWONO, string ENQNO)
        {
            string sqlCommandString;
            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetSizesListForTemplateNew";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);

                    //if (dtWONO != null)
                    //{
                    //    SqlParameter param1 = new SqlParameter();
                    //    param1.ParameterName = "@PT_ItemListForTemplate";
                    //    param1.Value = dtWONO;
                    //    param1.TypeName = "PT_ItemListForTemplate";
                    //    param1.SqlDbType = SqlDbType.Structured;
                    //    objCommand.Parameters.Add(param1);
                    //}
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

        /////// Sent Mail
        public DataTable GetContactPersonList(string ENQNO, int PartnerID)
        {
            DB.DBConnection objjConn = new DB.DBConnection();
            using (SqlConnection connection = objjConn.GetConnection)
            {
                connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "[USP_GetContactPersonList]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    objCommand.Parameters.AddWithValue("@PartnerID", PartnerID);
                    DataTable dtgrnDetails = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtgrnDetails);
                    }
                    connection.Close();
                    return dtgrnDetails;
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



        public DataTable GetSizesListForTemplate(DataTable dtWONO)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "[USP_GetSizesListForTemplate]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    if (dtWONO != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ItemListForTemplate";
                        param1.Value = dtWONO;
                        param1.TypeName = "PT_ItemListForTemplate";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    DataTable dtItemList = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtItemList);
                    }
                    connection.Close();

                    return dtItemList;

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

        public DataTable ApproveSentEnquiry(BO.EnquiryM ENQDetails)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "USP_ApproveSentEnquiryDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ESNO", ENQDetails.ESNO );
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQDetails.ENQNO );
                    objCommand.Parameters.AddWithValue("@AddedBy", ENQDetails.AddedBy);

                    DataTable dtLoginDetails = new DataTable();
                    objCommand.CommandTimeout = 380;
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

        public DataSet GetSentEnquiryDetail( string ENQNO)
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
                    sqlCommandString = "USP_GetSentEnquiryDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();
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

        public DataSet GetSentEnquiryDetailForRRM(string ENQNO)
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
                    sqlCommandString = "USP_GetSentEnquiryDetailForRRM";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();
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


        public DataTable getPartnerLocation(String ESNO)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "USP_getPartnerLocation";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ESNO", ESNO);

                    DataTable dtLoginDetails = new DataTable();
                    objCommand.CommandTimeout = 380;
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

        public DataTable CheckIsEnquirySendToPartner(string ENQNO, int PartnerID)
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
                    sqlCommandString = "USP_CheckIsEnquirySendToPartner";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    objCommand.Parameters.AddWithValue("@PartnerID", PartnerID);
                    objCommand.CommandTimeout = 500;
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

        public DataTable SaveEnquiryApproveDetails(BO.EnquiryM POM, int AddedBy, DataTable dataTable, DataTable dataTable1)
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
                    sqlCommandString = "USP_SaveEnquiryApproveDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EAID", POM.EAID);
                    objCommand.Parameters.AddWithValue("@EANO", POM.EANO);
                    objCommand.Parameters.AddWithValue("@ESNO", POM.ESNO);
                    objCommand.Parameters.AddWithValue("@ENQNO", POM.ENQNO);
                    objCommand.Parameters.AddWithValue("@EADate", POM.EADate);
                    objCommand.Parameters.AddWithValue("@CustomerID", POM.CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", POM.ProjectID);
                    objCommand.Parameters.AddWithValue("@PartnerID", POM.PartnerID);
                    objCommand.Parameters.AddWithValue("@PartnerLoc", POM.PartnerLoc != null ? POM.PartnerLoc.ToString() : "");
                    objCommand.Parameters.AddWithValue("@NoOfVehicle", POM.NoOfVehicle);
                    objCommand.Parameters.AddWithValue("@Destination", POM.Destination != null ? POM.Destination.ToString() : "");
                    objCommand.Parameters.AddWithValue("@PINO", POM.PINO != null ? POM.PINO.ToString() : "");
                    objCommand.Parameters.AddWithValue("@PIAmount", POM.PIAmount );
                    objCommand.Parameters.AddWithValue("@Remarks", POM.Remarks != null ? POM.Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", POM.AddedOn);
                    objCommand.CommandTimeout = 500;

                    if (dataTable.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ApprovedItemList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_ApprovedItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (dataTable1.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ScheduleList";
                        param1.Value = dataTable1;
                        param1.TypeName = "PT_ScheduleList";
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

        public DataTable SaveENQApproveAttachment(DataTable DataTable, int AddedBY)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveENQApproveAttachment";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AddedBY", AddedBY);
                    if (DataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_AttachmentM";
                        param1.Value = DataTable;
                        param1.TypeName = "PT_AttachmentM";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    DataTable dtSupplierBillDetails = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtSupplierBillDetails);
                    }
                    connection.Close();
                    return dtSupplierBillDetails;
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


        public DataSet GetSentEnquiryDetailForReceiveItem(string ENQNO)
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
                    sqlCommandString = "USP_GetSentEnquiryDetailForReceiveItem";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();
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

        public DataSet GetEnquiryReceiveDetails(string ERNO)
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
                    sqlCommandString = "USP_GetEnquiryReceiveDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ERNO", ERNO);
                    DataSet dtClass = new DataSet();


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

        public DataTable GetENQNOTemplateList(string PINO, string WONO, string ENQNO, string EANO)
        {
            string sqlCommandString;
            DB.FGERPDBConnection objConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_GetENQNOTemplateList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PINO", PINO);
                    objCommand.Parameters.AddWithValue("@WONO", WONO);
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    //objCommand.Parameters.AddWithValue("@EANO", EANO);
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


        public DataTable SaveReceiveOutsourceItem(BO.EnquiryM POM, int AddedBy, DataTable dataTable, DataTable dataTable1 )
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
                    sqlCommandString = "USP_SaveOSEnquiryReceiveDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ERID", POM.ERID);
                    objCommand.Parameters.AddWithValue("@ERNO", POM.ERNO);
                    objCommand.Parameters.AddWithValue("@ERDate", POM.ERDate);
                    objCommand.Parameters.AddWithValue("@ENQNO", POM.ENQNO);
                    objCommand.Parameters.AddWithValue("@ESNO", POM.ESNO);
                    objCommand.Parameters.AddWithValue("@EANO", POM.EANO);
                    objCommand.Parameters.AddWithValue("@CustomerID", POM.CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", POM.ProjectID);
                    objCommand.Parameters.AddWithValue("@PartnerID", POM.PartnerID);
                    objCommand.Parameters.AddWithValue("@ChallanNo", POM.ChallanNo != null ? POM.ChallanNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@InvAmount", POM.InvAmount );
                    objCommand.Parameters.AddWithValue("@VehType", POM.VehType != null ? POM.VehType.ToString() : "");
                    objCommand.Parameters.AddWithValue("@TransporterID", POM.TransporterID);
                    objCommand.Parameters.AddWithValue("@DriverName", POM.DriverName != null ? POM.DriverName.ToString() : "");
                    objCommand.Parameters.AddWithValue("@VehicleNo", POM.VehicleNo != null ? POM.VehicleNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@TotalVehCost", POM.TotalVehCost );
                    objCommand.Parameters.AddWithValue("@Remarks", POM.Remarks != null ? POM.Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", POM.AddedOn);
                    objCommand.CommandTimeout = 500;

                    if (dataTable.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ReceiveItemList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_ReceiveItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (dataTable1.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ENQSizesListForReceiveT";
                        param1.Value = dataTable1;
                        param1.TypeName = "PT_ENQSizesListForReceiveT";
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

        public DataTable SaveENQReceiveAttachment(DataTable DataTable, int AddedBY)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_SaveENQReceiveAttachment";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AddedBY", AddedBY);
                    if (DataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_AttachmentM";
                        param1.Value = DataTable;
                        param1.TypeName = "PT_AttachmentM";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    DataTable dtSupplierBillDetails = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtSupplierBillDetails);
                    }
                    connection.Close();
                    return dtSupplierBillDetails;
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


        public DataTable GetEnquiryReceiveSummary(string FromDate, string ToDate, string SearchCriteria, string Search, int UserID)
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
                    sqlCommandString = "USP_GetOSEnquiryReceiveSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria != null ? SearchCriteria.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Search", Search != null ? Search.ToString() : "");
                    objCommand.Parameters.AddWithValue("@UserID", UserID);
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

        //////////////////// Req Raw Material
        public DataSet GetReqRawMaterialDetails(string RRMNO, string ENQNO)
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
                    sqlCommandString = "USP_GetReqRawMaterialDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RRMNO", RRMNO);
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    DataSet dtClass = new DataSet();


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

        public DataTable GetRMItemList(string Search, string ENQNO)
        {
            string sqlCommandString;
            DateTime date = DateTime.Now;
            string sDate = date.ToString("dd-MM-yyyy");
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_OSGetPurchaseRMList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Search", Search);
                    objCommand.Parameters.AddWithValue("@ENQNO", ENQNO);
                    objCommand.CommandTimeout = 100000;
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
        
        public DataTable GetCOItemList(string Search)
        {
            string sqlCommandString;
            DateTime date = DateTime.Now;
            string sDate = date.ToString("dd-MM-yyyy");
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "[USP_OSGetPurchaseCOList]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Search", Search);
                    objCommand.CommandTimeout = 100000;
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

        public DataTable SaveReqRawMaterialDetails(BO.EnquiryM POM, int AddedBy, DataTable dataTable)
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
                    sqlCommandString = "USP_SaveOSReqRawmaterialDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RRMID", POM.RRMID);
                    objCommand.Parameters.AddWithValue("@RRMNO", POM.RRMNO);
                    objCommand.Parameters.AddWithValue("@RRMDate", POM.RRMDate);
                    objCommand.Parameters.AddWithValue("@ENQNO", POM.ENQNO);
                    objCommand.Parameters.AddWithValue("@ESNO", POM.ESNO);
                    objCommand.Parameters.AddWithValue("@CustomerID", POM.CustomerID);
                    objCommand.Parameters.AddWithValue("@ProjectID", POM.ProjectID);
                    objCommand.Parameters.AddWithValue("@PartnerID", POM.PartnerID);
                    objCommand.Parameters.AddWithValue("@ItemGroupID", POM.ItemGroupID);
                    objCommand.Parameters.AddWithValue("@IsCutSize", POM.IsCutSize);
                    objCommand.Parameters.AddWithValue("@ReqVehicle", POM.ReqVehicle);
                    objCommand.Parameters.AddWithValue("@Total", POM.Total);
                    objCommand.Parameters.AddWithValue("@Remarks", POM.Remarks != null ? POM.Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", POM.AddedOn);
                    objCommand.CommandTimeout = 500;

                    if (dataTable.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_ReqRawMaterialList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_ReqRawMaterialList";
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

        public DataTable GetReqRawMaterialSummary(string FromDate, string ToDate, string SearchCriteria, string Search, int UserID)
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
                    sqlCommandString = "USP_GetOSReqRawMaterialSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria != null ? SearchCriteria.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Search", Search != null ? Search.ToString() : "");
                    objCommand.Parameters.AddWithValue("@UserID", UserID);
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

        public DataTable UpdateClosingRemarkStatus(EnquiryM ProcessDetails)
        {
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "USP_UpdateRemarkClosingStatus";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RRMNO", ProcessDetails.RRMNO != null ? ProcessDetails.RRMNO.ToString() : "");
                    objCommand.Parameters.AddWithValue("@RemarkID", ProcessDetails.RemarkID );
                    objCommand.Parameters.AddWithValue("@AddedBy", ProcessDetails.AddedBy);

                    DataTable dtLoginDetails = new DataTable();
                    objCommand.CommandTimeout = 380;
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



        /////////////////////////////////////*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ END @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        public DataTable GetAjaxEnquirySummary(DateTime fromDate, DateTime toDate, string searchText, int statusID, int userID)
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
                    sqlCommandString = "USP_EnquirySummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", toDate);
                    objCommand.Parameters.AddWithValue("@SearchText", searchText);
                    objCommand.Parameters.AddWithValue("@StatusID", statusID);
                    objCommand.Parameters.AddWithValue("@UserID", userID);
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

        public DataTable GetEnquiryDetails(int enquiryNo)
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
                    sqlCommandString = "USP_EnquiryDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@enquiryNo", enquiryNo);
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

        public DataTable AjaxAddOrEditEnquiry(int enquiryNO, int contactPersonID, int salesPersonID, int salesCoordinatorID, string reference, string desc, int addedBY, DateTime addedON)
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
                    sqlCommandString = "USP_AddOrEditEnquiry";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@enquiryNo", enquiryNO);
                    objCommand.Parameters.AddWithValue("@contactPersonID", contactPersonID);
                    objCommand.Parameters.AddWithValue("@salesPersonID", salesPersonID);
                    objCommand.Parameters.AddWithValue("@salesCoordinatorID", salesCoordinatorID);
                    objCommand.Parameters.AddWithValue("@reference", reference);
                    objCommand.Parameters.AddWithValue("@desc", desc);
                    objCommand.Parameters.AddWithValue("@addedBY", addedBY);
                    objCommand.Parameters.AddWithValue("@addedON", addedON);
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

        public DataTable AjaxDeleteEnquiry(int enquiryNO, string remark, int addedBY, DateTime addedON)
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
                    sqlCommandString = "USP_DeleteEnquiry";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@enquiryNo", enquiryNO);
                    objCommand.Parameters.AddWithValue("@remark", remark);
                    objCommand.Parameters.AddWithValue("@addedBY", addedBY);
                    objCommand.Parameters.AddWithValue("@addedON", addedON);
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

        public DataTable GetLinkPipelineData(int id)
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
                    sqlCommandString = "USP_GetLinkPipelineData";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ID", id);
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
