using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = BombayToolsDBConnector;

namespace BombayToolsDataLayer.ExportInvoice
{
    public class ExportInvoiceDataLayer
    {
        public DataTable GetBillingAddress(int CustID)
        {
            DB.FGERPDBConnection objjConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objjConn.GetConnection)
            {
                connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "[USP_GetBillingAddressOfExportCustomer]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustID", CustID);
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
        public DataTable GetShippingAddress(int CustID)
        {
            DB.FGERPDBConnection objjConn = new DB.FGERPDBConnection();
            using (SqlConnection connection = objjConn.GetConnection)
            {
                connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string sqlCommandString = "[USP_GetShippingAddressOfExportCustomer]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustID", CustID);
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
        public DataTable GetVendorDetails(int vendorID)
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
                    sqlCommandString = "USP_VendorLocationDetail";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@vendorID", vendorID);
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
        public DataTable GetExportInvoiceSummary(string FromDate, string ToDate, string SearchCriteria, string Search, int UserID)
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
                    sqlCommandString = "USP_GetExportInvoiceSummary";
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

        public DataTable DirectApprovePO(string PONo, int AddedBy)
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


                    sqlCommandString = "USP_UpdateForPOApprove";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", PONo);
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);


                    DataTable dtGRNDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtGRNDetails);
                    }
                    connection.Close();
                    return dtGRNDetails;
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


        public DataSet GetExportInvoiceDetail(string pONo)
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
                    sqlCommandString = "USP_GetExportInvoiceData";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EXINO", pONo);
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

        public DataSet GetExportInvoiceDetailPrint(string pONo)
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
                    sqlCommandString = "USP_GetExportInvoiceDataPrint";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EXINO", pONo);
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

        public DataSet GetExportInvoicePackingPrint(string pONo)
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
                    sqlCommandString = "USP_GetExportInvoicePackingPrint";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EXINO", pONo);
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

        public DataSet GetPackingListDetailPrint(string pONo)
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
                    sqlCommandString = "USP_GetPackingListDataPrint";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PackingNo", pONo);
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

        public DataTable GetPurchaseOrderUsername(string PONo)
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


                    sqlCommandString = "USP_GetPurchaseOrderUsername";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", PONo);

                    DataTable dtGRNDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtGRNDetails);
                    }
                    connection.Close();
                    return dtGRNDetails;
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


        public DataSet GetPurchaseOrderDetail1(string pONo)
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
                    sqlCommandString = "USP_GetPurchaseOrderData1";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONO", pONo);
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

        //For Email Table
        public DataTable POItemsDetails(string PONo)
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
                    sqlCommandString = "USP_GetPOItemsDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONO", PONo);
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
        //End For Email Table

        public DataTable GetChrgesList()
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
                    sqlCommandString = "[USP_GetChrgesListForExportInvoice]";
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
        public DataTable GetDeliveryAddressList()
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
                    sqlCommandString = "USP_GetDeliveryAddressList";
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
        public DataTable AddOrEditExportInvoice(int EXID, string EXINO, string EXIDate, string PONO, string PODate, string LCNO, string LCDate, string EXIType,  int CustomerID,
            decimal FinalTotal,  DateTime AddedOn, int CurrencyID, decimal ExchangeRate, int BillingLocationID, int ShippingLocationID, string BillToAddress, string ShipToAddress,
            decimal TotChrgAmt, decimal GrandTotal, string Remarks,  string VesselNo, string ContainerNo, int ModeOfShipment, int ShipmentTermID,
           int PODID, string Others, string ExportBenefit, string PortOfLoading , string CountryOfOrigin , string SealNo , string FinalDestination, string CustRefNo , int AddedBy,
           DataTable dataTable, DataTable dataTableF2, DataTable dataTableP3, DataTable dataTableT4)
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
                    sqlCommandString = "USP_AddOrEditExportInvoice";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EXIID", EXID);
                    objCommand.Parameters.AddWithValue("@EXINO", EXINO);
                    objCommand.Parameters.AddWithValue("@EXIDate", EXIDate);
                    objCommand.Parameters.AddWithValue("@PONO", PONO);
                    objCommand.Parameters.AddWithValue("@PODate", PODate);
                    objCommand.Parameters.AddWithValue("@LCNO", LCNO);
                    objCommand.Parameters.AddWithValue("@LCDate", LCDate);
                    objCommand.Parameters.AddWithValue("@EXIType", EXIType != null ? EXIType.ToString() : "");
                    //objCommand.Parameters.AddWithValue("@PINo", PINNo != null ? PINNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                    objCommand.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                    objCommand.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);
                    objCommand.Parameters.AddWithValue("@BillingLocationID", BillingLocationID);
                    objCommand.Parameters.AddWithValue("@BillToAddress", BillToAddress);
                    objCommand.Parameters.AddWithValue("@ShippingLocationID", ShippingLocationID);
                    objCommand.Parameters.AddWithValue("@ShipToAddress", ShipToAddress);
                    //objCommand.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
                    //objCommand.Parameters.AddWithValue("@PlaceOfReceipt", PlaceOfReceipt);
                    objCommand.Parameters.AddWithValue("@VesselNo", VesselNo  != null ? VesselNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@ContainerNo", ContainerNo  != null ? ContainerNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@ModeOfShipment", ModeOfShipment);
                    objCommand.Parameters.AddWithValue("@ShipmentTermID", ShipmentTermID);
                    objCommand.Parameters.AddWithValue("@PODID", PODID);
                    //objCommand.Parameters.AddWithValue("@StatusID", StatusID);
                    //objCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
                    objCommand.Parameters.AddWithValue("@FinalTotal", FinalTotal);
                    objCommand.Parameters.AddWithValue("@TotChrgAmt", TotChrgAmt);
                    objCommand.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                    objCommand.Parameters.AddWithValue("@Remarks", Remarks != null ? Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Others", Others != null ? Others.ToString() : "");
                    objCommand.Parameters.AddWithValue("@ExportBenefit", ExportBenefit != null ? ExportBenefit.ToString() : "");
                    objCommand.Parameters.AddWithValue("@PortOfLoading", PortOfLoading != null ? PortOfLoading.ToString() : "");
                    objCommand.Parameters.AddWithValue("@CountryOfOrigin", CountryOfOrigin != null ? CountryOfOrigin.ToString() : "");
                    objCommand.Parameters.AddWithValue("@SealNo", SealNo != null ? SealNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@FinalDestination", FinalDestination != null ? FinalDestination.ToString() : "");
                    objCommand.Parameters.AddWithValue("@CustRefNo", CustRefNo != null ? CustRefNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", AddedOn);
                    objCommand.CommandTimeout = 500;

                    if (dataTable.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EXIItemList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_EXIItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (dataTableF2.Rows.Count >0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EXIChargeList";
                        param1.Value = dataTableF2;
                        param1.TypeName = "PT_EXIChargeList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

                    if (dataTableP3.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_POPaymentTerm";
                        param1.Value = dataTableP3;
                        param1.TypeName = "PT_POPaymentTerm";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

                    if (dataTableT4 != null)
                    {
                        SqlParameter param4 = new SqlParameter();
                        param4.ParameterName = "@PT_EXIPackingList";
                        param4.Value = dataTableT4;
                        param4.TypeName = "PT_EXIPackingList";
                        param4.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param4);
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


        public DataTable AjaxAddOrEditPackingList(int EXID, string EXINO, string EXIDate, string PONO, string PODate, string LCNO, string LCDate, string EXIType, string PINNo, int CustomerID,
            decimal FinalTotal, int AddedBy, DateTime AddedOn, int CurrencyID, decimal ExchangeRate, int BillingLocationID, int ShippingLocationID, string BillToAddress, string ShipToAddress,
            decimal TotChrgAmt, decimal GrandTotal, string Remarks, string PreCarriageBy, string PlaceOfReceipt, string VesselNo, string ContainerNo, int ModeOfShipment, int ShipmentTermID,
           int PODID, int StatusID, int LicenseID, string Others, string ExportBenefit, DataTable dataTable, DataTable dataTableF2, DataTable dataTableP3, DataTable dataTableT4)
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
                    sqlCommandString = "USP_AddOrEditPackingList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EXIID", EXID);
                    objCommand.Parameters.AddWithValue("@EXINO", EXINO);
                    objCommand.Parameters.AddWithValue("@EXIDate", EXIDate);
                    objCommand.Parameters.AddWithValue("@PONO", PONO);
                    objCommand.Parameters.AddWithValue("@PODate", PODate);
                    objCommand.Parameters.AddWithValue("@LCNO", LCNO);
                    objCommand.Parameters.AddWithValue("@LCDate", LCDate);
                    objCommand.Parameters.AddWithValue("@EXIType", EXIType != null ? EXIType.ToString() : "");
                    objCommand.Parameters.AddWithValue("@PINNo", PINNo != null ? PINNo.ToString() : "");
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                    objCommand.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                    objCommand.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);
                    objCommand.Parameters.AddWithValue("@BillingLocationID", BillingLocationID);
                    objCommand.Parameters.AddWithValue("@BillToAddress", BillToAddress);
                    objCommand.Parameters.AddWithValue("@ShippingLocationID", ShippingLocationID);
                    objCommand.Parameters.AddWithValue("@ShipToAddress", ShipToAddress);
                    objCommand.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
                    objCommand.Parameters.AddWithValue("@PlaceOfReceipt", PlaceOfReceipt);
                    objCommand.Parameters.AddWithValue("@VesselNo", VesselNo);
                    objCommand.Parameters.AddWithValue("@ContainerNo", ContainerNo);
                    objCommand.Parameters.AddWithValue("@ModeOfShipment", ModeOfShipment);
                    objCommand.Parameters.AddWithValue("@ShipmentTermID", ShipmentTermID);
                    objCommand.Parameters.AddWithValue("@PODID", PODID);
                    objCommand.Parameters.AddWithValue("@StatusID", StatusID);
                    objCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
                    objCommand.Parameters.AddWithValue("@FinalTotal", FinalTotal);
                    objCommand.Parameters.AddWithValue("@TotChrgAmt", TotChrgAmt);
                    objCommand.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                    objCommand.Parameters.AddWithValue("@Remarks", Remarks != null ? Remarks.ToString() : "");
                    objCommand.Parameters.AddWithValue("@Others", Others != null ? Others.ToString() : "");
                    objCommand.Parameters.AddWithValue("@ExportBenefit", ExportBenefit != null ? ExportBenefit.ToString() : "");
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", AddedOn);

                    if (dataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EXIItemList";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_EXIItemList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    if (dataTableF2 != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EXIChargeList";
                        param1.Value = dataTableF2;
                        param1.TypeName = "PT_EXIChargeList";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

                    if (dataTableP3 != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_POPaymentTerm";
                        param1.Value = dataTableP3;
                        param1.TypeName = "PT_POPaymentTerm";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

                    if (dataTableT4 != null)
                    {
                        SqlParameter param4 = new SqlParameter();
                        param4.ParameterName = "@PT_EXIPackingList";
                        param4.Value = dataTableT4;
                        param4.TypeName = "PT_EXIPackingList";
                        param4.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param4);
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
        public DataTable GetPurchaseOrderMDataForXML()
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
                    sqlCommandString = "USP_XMLPurchaseOrder";
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
        public DataSet GetPurchaseOrderDDataForXML(string PONO)
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
                    sqlCommandString = "USP_XMLPurchaseOrderDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", PONO);
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
        public DataTable GetDNNOListAgainstCustomer(int CustomerID)
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
                    sqlCommandString = "USP_GetDNNOAgainstCustomer";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public DataTable GetItemListAgainstPINo(string PINo)
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
                    sqlCommandString = "USP_GetOpenPIListAgainstPINo";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PINo", PINo);

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
        public DataSet GetItemListAgainstDCNO(DataTable dtWONO)
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
                    sqlCommandString = "USP_GetOpenItenmListAgainstDCNO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@PINo", PINo);

                    if (dtWONO != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_DCNOItemListForEXI";
                        param1.Value = dtWONO;
                        param1.TypeName = "PT_DCNOItemListForEXI";
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
        //Last Purchase History
        public DataTable ViewLastPurchaseHistoryCO(int ItemID, int IsLastMonth)
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
                    sqlCommandString = "USP_GetLastPurchaseHistoryCO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ItemID", ItemID);
                    objCommand.Parameters.AddWithValue("@IsLastMonth", IsLastMonth);

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
        public DataTable ViewLastPurchaseHistoryRM(int ItemID, int IsLastMonth)
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
                    sqlCommandString = "USP_GetLastPurchaseHistoryRM";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ItemID", ItemID);
                    objCommand.Parameters.AddWithValue("@IsLastMonth", IsLastMonth);

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
        //End Last Purchase History

        public DataTable POApproval(string PONO, int ApprovedBy, string ApprovedRemarks, int postatus)
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


                    sqlCommandString = "USP_UpdateForPOApproval";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@WORKYEAR",DateTime.Now.ToString("yyyy-MM"));
                    objCommand.Parameters.AddWithValue("@PONO", PONO);
                    objCommand.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);
                    objCommand.Parameters.AddWithValue("@postatus", postatus);
                    objCommand.Parameters.AddWithValue("@ApprovedRemarks", ApprovedRemarks != null ? ApprovedRemarks.ToString() : "");

                    DataTable dtGRNDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtGRNDetails);
                    }
                    connection.Close();
                    return dtGRNDetails;
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
        public DataTable GetPurchaseStatus()
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
                    sqlCommandString = "USP_GetPurchaseStatus";
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
        public DataTable GetPendingPurchaseOrderSummary()
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

                    sqlCommandString = "[USP_GetPendingPurchaseOrderSummary1]";
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
        public DataTable GetPendingCOPOList()
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

                    sqlCommandString = "[USP_GetPendingCOPOList]";
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
        public DataTable GetPendingRMPOList()
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

                    sqlCommandString = "[USP_GetPendingRMPOList]";
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
        public DataTable GetPendingPurchaseOrderForAppr()
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

                    sqlCommandString = "[USP_GetPendingPurchaseOrderForAppr]";
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
        public DataTable GetPendingCOPOForAppr()
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

                    sqlCommandString = "[USP_GetPendingCOPOForAppr]";
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
        public DataTable GetPendingRMPOForAppr()
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

                    sqlCommandString = "[USP_GetPendingRMPOForAppr]";
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
        public DataTable GetCurrentCOStockValueList()
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

                    sqlCommandString = "[USP_GetCurrentCOStockValueList]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
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
        public DataTable GetCurrentRMStockValueList()
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

                    sqlCommandString = "[USP_GetCurrentRMStockValueList]";
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
        public DataTable ViewPoDetail(string PONO)
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

                    sqlCommandString = "[USP_ViewPoDetail]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONO", PONO);

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
        public DataTable ClosePO(string PONo, string Reason, int AddedBy)
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


                    sqlCommandString = "USP_UpdateForPurchaseOrderClosed";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", PONo);
                    objCommand.Parameters.AddWithValue("@Reason", Reason);
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);


                    DataTable dtGRNDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtGRNDetails);
                    }
                    connection.Close();
                    return dtGRNDetails;
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
        public DataTable AjaxGetCancelPO(string PONo, string Reason, int AddedBy)
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

                    sqlCommandString = "[USP_GetCancelPurchaseOrder]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", PONo);
                    objCommand.Parameters.AddWithValue("@Remark", Reason);
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
        public DataTable AjaxGetApprovePO(string IndentNo, int AddedBy)
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

                    sqlCommandString = "[USP_GetApprovedPurchaseOrder]";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", IndentNo);
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
        public DataTable SavePOEmailLog(string RecordNo, int RevisionNo, int AddedBY, string PINNo, string msg)
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
                    sqlCommandString = "USP_AddMailPincodeDetailsForPurchaseOrder";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PONo", RecordNo);
                    objCommand.Parameters.AddWithValue("@RevisionNo", RevisionNo);
                    objCommand.Parameters.AddWithValue("@UserID", AddedBY);
                    objCommand.Parameters.AddWithValue("@PINNo", PINNo);
                    objCommand.Parameters.AddWithValue("@IsUsed", 0);
                    objCommand.Parameters.AddWithValue("@Message", msg != null ? msg.ToString() : "");

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
        public DataTable SaveMaintenanceFailureRemark(int MSID, string ScheduleDate, string FailureRemark, int AddedBY, string msg)
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
                    sqlCommandString = "USP_AddMaintenanceFailureRemark";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@MSID", MSID);
                    objCommand.Parameters.AddWithValue("@ScheduleDate", ScheduleDate);
                    objCommand.Parameters.AddWithValue("@FailureRemark", FailureRemark);
                    objCommand.Parameters.AddWithValue("@UserID", AddedBY);
                    //objCommand.Parameters.AddWithValue("@Message", msg != null ? msg.ToString() : "");

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
        public DataTable GetPaymentTermList()
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
        public DataTable GetPODList()
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
                    sqlCommandString = "USP_GetPODList";
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
        public DataTable GetGSTStatusList()
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
                    sqlCommandString = "USP_GetGSTStatusList";
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
        public DataTable GetLicenseNoList()
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
                    sqlCommandString = "USP_GetLicenseNoList";
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
        public DataTable GetShipMentTermList()
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
                    sqlCommandString = "USP_GetShipmentTermsList";
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
        public DataTable GetProjectList()
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
                    sqlCommandString = "USP_GetProjectNameList";
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

        public DataTable GetShipMeList()
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
                    sqlCommandString = "USP_GetShipmentTermsList";
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

        public DataTable GetExportHeadingList()
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
                    sqlCommandString = "USP_GetExportHeadingList";
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
        public DataTable GetTermAndConditionsList()
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
                    sqlCommandString = "USP_GetTermAndConditionsList";
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

        public DataSet SetCustomerData(int VendorID)
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
                    sqlCommandString = "USP_SetExportCustomerData";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CustomerID", VendorID);
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

        ///// 04-09-23
        public DataTable GetFreightListAgainstDCNO(DataTable dtWONO)
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
                    sqlCommandString = "USP_GetFreightListAgainstDCNO";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@PINo", PINo);

                    if (dtWONO != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_DCNOItemListForEXI";
                        param1.Value = dtWONO;
                        param1.TypeName = "PT_DCNOItemListForEXI";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

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

        ///// 27-09-23

        public DataTable updateDCMasterFlagToZero(DataTable dtWONO, int UserID)
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
                    string sqlCommandString = "USP_updateDCMasterFlagToZero";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AddedBy", UserID);

                    if (dtWONO.Rows.Count > 0)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_DCNOItemListForEXI";
                        param1.Value = dtWONO;
                        param1.TypeName = "PT_DCNOItemListForEXI";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }

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


        public DataTable updateDCMasterFlag(String DCNO , int UserID)
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
                    string sqlCommandString = "USP_UpdateDCMasterFlag";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@DCNO", DCNO);
                    objCommand.Parameters.AddWithValue("@AddedBy", UserID);

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

        public DataTable GetPODMasterSummary()
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
                    sqlCommandString = "USP_GetPODMasterSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //objCommand.Parameters.AddWithValue("@FromDate", FromDate);
                    //objCommand.Parameters.AddWithValue("@ToDate", ToDate);
                    //objCommand.Parameters.AddWithValue("@SearchCriteria", SearchCriteria != null ? SearchCriteria.ToString() : "");
                    //objCommand.Parameters.AddWithValue("@Search", Search != null ? Search.ToString() : "");
                    //objCommand.Parameters.AddWithValue("@UserID", UserID);
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

        public DataTable AjaxAddOrEdit( string PODName, int AddedBy)
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
                    sqlCommandString = "USP_AddOrEditPODMaster";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@PODName", PODName);
                    objCommand.Parameters.AddWithValue("@AddedBy", AddedBy);
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

    }
}
