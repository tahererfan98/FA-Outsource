using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombayToolsEntities.BusinessEntities;
using HC = BombayToolsDBConnector.Helper;
using DB = BombayToolsDBConnector;

namespace BombayToolsDataLayer.Master
{
    public class Master
    {
        HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();

        public DataTable OutsourcePartnerSummary()
        {
            DataTable AttachmentDT = new DataTable();
            AttachmentDT = db.sub_GetDatatable("USP_OutsourcePartnerMSummary");
            return AttachmentDT;
        }

        public DataSet GetOutsourcePartnerDetail(int PartnerID)
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
                    sqlCommandString = "USP_GetOutsourcePartnerData";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PartnerID", PartnerID);
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





        public DataTable SaveOutsourcePartner(int PartnerID, string PartnerName,string PartnerLoc, string Address,  string VatNo, int IsActive, int AddedBy , DataTable DataTable)
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
                    sqlCommandString = "USP_SaveOutsourcePartnerM";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PartnerID", PartnerID);
                    objCommand.Parameters.AddWithValue("@PartnerName", PartnerName);
                    objCommand.Parameters.AddWithValue("@PartnerLoc", PartnerLoc);
                    objCommand.Parameters.AddWithValue("@Address", Address);
                    objCommand.Parameters.AddWithValue("@VatNo", VatNo != null ? VatNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@IsActive", IsActive);
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    if (DataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_OSContactList";
                        param1.Value = DataTable;
                        param1.TypeName = "PT_OSContactList";
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


        /////////////////////////////////////*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ END @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@







        public DataTable GetPaymentTermList()
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
                    sqlCommandString = "USP_GetPaymentTermsList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@Search", Search);
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

        public DataTable GetAddOrEditVendorData(int vendorID, string vendor_Name, string vendor_Code, string tallyName, string vendor_Address, string contactPerson, string gSTNo, string emailAddress, string address2, string discountable, string creditores, string relatedPerson, string gstscheme, string status, string registration, string pANNo, int stateCode, int registerTypeID, string gSTRegistrationDate, string gSTLocation, string gSTAddress, string gSTContactNo, int stateID, int addedBy, DataTable vendorContact, DataTable bankListDT, DataTable termListDT)
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
                    sqlCommandString = "USP_AddOrEditVendor";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@vendorID", vendorID);
                    objCommand.Parameters.AddWithValue("@vendor_Name", vendor_Name);
                    objCommand.Parameters.AddWithValue("@vendor_Code", vendor_Code != null ? vendor_Code.ToString() : "");
                    objCommand.Parameters.AddWithValue("@tallyName", tallyName);
                    objCommand.Parameters.AddWithValue("@vendor_Address", vendor_Address != null ? vendor_Address.ToString() : "");
                    objCommand.Parameters.AddWithValue("@contactPerson", contactPerson != null ? contactPerson.ToString() : "");
                    objCommand.Parameters.AddWithValue("@gSTNo", gSTNo);
                    objCommand.Parameters.AddWithValue("@emailAddress", emailAddress != null ? emailAddress.ToString() : "");
                    objCommand.Parameters.AddWithValue("@address2", address2 != null ? address2.ToString() : "");
                    objCommand.Parameters.AddWithValue("@discountable", discountable != null ? discountable.ToString() : "");
                    objCommand.Parameters.AddWithValue("@creditores", creditores != null ? creditores.ToString() : "");
                    objCommand.Parameters.AddWithValue("@relatedPerson", relatedPerson != null ? relatedPerson.ToString() : "");
                    objCommand.Parameters.AddWithValue("@gstscheme", gstscheme != null ? gstscheme.ToString() : "");
                    objCommand.Parameters.AddWithValue("@status", status != null ? status.ToString() : "");
                    objCommand.Parameters.AddWithValue("@registration", registration != null ? registration.ToString() : "");
                    objCommand.Parameters.AddWithValue("@pANNo", pANNo);
                    objCommand.Parameters.AddWithValue("@stateCode", stateCode );
                    objCommand.Parameters.AddWithValue("@registerTypeID", registerTypeID);
                    objCommand.Parameters.AddWithValue("@gSTRegistrationDate", gSTRegistrationDate != null ? gSTRegistrationDate.ToString() : "");
                    objCommand.Parameters.AddWithValue("@gSTLocation", gSTLocation != null ? gSTLocation.ToString() : "");
                    objCommand.Parameters.AddWithValue("@gSTAddress", gSTAddress != null ? gSTAddress.ToString() : "");
                    objCommand.Parameters.AddWithValue("@gSTContactNo", gSTContactNo != null ? gSTContactNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@stateID", stateID );
                    objCommand.Parameters.AddWithValue("@addedBy", addedBy);
                    if (vendorContact != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_VendorContact";
                        param1.Value = vendorContact;
                        param1.TypeName = "PT_VendorContact";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (bankListDT != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_BankList";
                        param1.Value = bankListDT;
                        param1.TypeName = "PT_BankList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (termListDT != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_VendorTerm";
                        param1.Value = termListDT;
                        param1.TypeName = "PT_VendorTerm";
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

        public DataTable GetVendorSummary()
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
                    sqlCommandString = "USP_VendorSummaryList";
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

        public DataTable UpdateVendorDocs(string data, DataTable uploadDT)
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
                    sqlCommandString = "USP_AddOrEditVendorDocs";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@vendorID", data);                    
                    if (uploadDT != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_VendorDoc";
                        param1.Value = uploadDT;
                        param1.TypeName = "PT_VendorDoc";
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

        public DataSet GetVendorDetails(int id)
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
                    sqlCommandString = "USP_GetVendorCompleteDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@vendorID", id);

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

        public DataTable AddOrEditFrieght(int autoID, string name, string description, int addedBy, DateTime addedOn)
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
                    sqlCommandString = "USP_AddorEditFrieghtMaster";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@autoID", autoID);
                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@description", description);
                    objCommand.Parameters.AddWithValue("@addedBy", addedBy);
                    objCommand.Parameters.AddWithValue("@addedOn", addedOn);

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

        public DataTable AjaxAddorEditMailTemplate(MailCampaignTemplate doc, DataTable uploadDT)
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
                    sqlCommandString = "USP_AddorEditMailTemplate";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AutoID", doc.AutoID);
                    objCommand.Parameters.AddWithValue("@TemplateName", doc.TemplateName);
                    objCommand.Parameters.AddWithValue("@HTML", doc.DocHTML);
                    objCommand.Parameters.AddWithValue("@Subject", doc.Subject);
                    objCommand.Parameters.AddWithValue("@Remark", doc.Remark);
                    objCommand.Parameters.AddWithValue("@addedBy", doc.AddedBy);
                    objCommand.Parameters.AddWithValue("@addedOn", doc.AddedOn);
                    if (uploadDT != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EmployeeAttachments";
                        param1.Value = uploadDT;
                        param1.TypeName = "PT_EmployeeAttachments";
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

        public DataTable GetMailTemplateSummary()
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
                    sqlCommandString = "USP_MailCampignSummary";
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

        public DataSet GetDocumentDetails(int id)
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
                    sqlCommandString = "USP_GetMailTemplateDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RecordID", id);

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

        public DataSet GetDataForCampaignRecord(int recordID)
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
                    sqlCommandString = "USP_GetDataForCampaignRecord";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RecordID", recordID);

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

        public void setStatusForRecord(int recordID)
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
                    sqlCommandString = "USP_setStatusForRecord";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RecordID", recordID);

                    DataSet dtClass = new DataSet();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(dtClass);
                    }
                    connection.Close();

                    //return dtClass;

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

        public void setCountForRecord(string t)
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
                    sqlCommandString = "USP_SetMailAsRead";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RecordID", t);

                    DataSet dtClass = new DataSet();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(dtClass);
                    }
                    connection.Close();

                    //return dtClass;

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

        public DataTable GetCampaignDetails(int recordID)
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
                    sqlCommandString = "USP_GetMailCampaignDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@RecordID", recordID);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dt);
                    }
                    connection.Close();
                    return dt;
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

        public DataTable GetCampaignSummaryData()
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
                    sqlCommandString = "USP_GetMailCampaignSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dt);
                    }
                    connection.Close();
                    return dt;
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
