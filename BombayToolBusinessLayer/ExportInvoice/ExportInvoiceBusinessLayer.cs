using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer.ExportInvoice;
using DBM = BombayToolsDataLayer;

namespace BombayToolBusinessLayer.ExportInvoice
{
    public class ExportInvoiceBusinessLayer
    {
        DB.ExportInvoiceDataLayer DBManager = new DB.ExportInvoiceDataLayer();
        DBM.BombayToolsDBManager BTdatamanager = new DBM.BombayToolsDBManager();
        public DataTable GetBillingAddress(int CustID)
        {
            try
            {
                DataTable ItemDL = new DataTable();
                ItemDL = DBManager.GetBillingAddress(CustID);
                return ItemDL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetShippingAddress(int CustID)
        {
            try
            {
                DataTable ItemDL = new DataTable();
                ItemDL = DBManager.GetShippingAddress(CustID);
                return ItemDL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VendorD> GetVendorDetails(int vendorID)
        {
            try
            {
                List<VendorD> list = new List<VendorD>();
                DataTable dt = new DataTable();
                dt = DBManager.GetVendorDetails(vendorID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        VendorD enq = new VendorD();
                        enq.AutoID = Convert.ToInt32(row["AutoID"]);
                        enq.Location = Convert.ToString(row["LocationName"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ExportInvoiceM> GetExportInvoiceSummary(ExportInvoiceM data1, int UserID)
        {
            try
            {
                List<ExportInvoiceM> list = new List<ExportInvoiceM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetExportInvoiceSummary(data1.FromDate, data1.ToDate, data1.SearchCriteria, data1.Search, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ExportInvoiceM data = new ExportInvoiceM();
                        data.EXID = Convert.ToInt32(row["EXIID"]);
                        data.EXINO = Convert.ToString(row["EXINO"]);
                        data.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        data.EXIDate = Convert.ToString(row["EXIDate"]);
                        data.Customer = Convert.ToString(row["Customer"]);
                        data.FinalTotal = Convert.ToDecimal(row["BasicAmount"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);
                        data.AddedByName = Convert.ToString(row["AddedByName"]);
                        //data.IsForwarding = Convert.ToInt32(row["IsForwarding"]);
                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ResponseMessage DirectApprovePO(string PONo, int AddedBy)
        {
            try
            {
                //    // HC.DBOperationForTrackerPurchase db = new HC.DBOperationForTrackerPurchase();

                ResponseMessage success = new ResponseMessage();

                DataTable itemD = new DataTable();

                itemD = DBManager.DirectApprovePO(PONo, AddedBy);

                if (itemD != null)
                {
                    success.Message = Convert.ToString(itemD.Rows[0][0]);
                    success.Status = Convert.ToInt32(itemD.Rows[0][1]);
                }

                return success;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ExportInvoiceM GetExportInvoiceDetail(string pONo)
        {
            try
            {
                ExportInvoiceM purchases = new ExportInvoiceM();
                List<ExportInvoiceD> POD = new List<ExportInvoiceD>();
                List<ExportInvoiceCharges> POCHRG = new List<ExportInvoiceCharges>();
                List<ExportInvoicePacking> POC = new List<ExportInvoicePacking>();
                List<PurchaseOrderPaymentTerm> POPaymentTerm = new List<PurchaseOrderPaymentTerm>();

                DataSet set = new DataSet();
                set = DBManager.GetExportInvoiceDetail(pONo);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];
                dt4 = set.Tables[3];
                dt5 = set.Tables[4];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.EXID = Convert.ToInt32(row["EXIID"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.EXINO = Convert.ToString(row["EXINO"]);
                        purchases.EXIDate = Convert.ToString(row["EXIDate"]);
                        purchases.PONO = Convert.ToString(row["PONO"]);
                        purchases.PODate = Convert.ToString(row["PODate"]);
                        purchases.LCNO = Convert.ToString(row["LOCNO"]);
                        purchases.LCDate = Convert.ToString(row["LOCDate"]);
                        purchases.EXIType = Convert.ToString(row["EXIType"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustID"]);
                        purchases.Customer = Convert.ToString(row["CustomerName"]);
                        purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);
                        purchases.CurSym = Convert.ToString(row["Symbol"]);
                        purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);
                        purchases.Symbol = Convert.ToString(row["Symbol"]);
                        purchases.CurrencyCode = Convert.ToString(row["CurrencyCode"]);
                        purchases.BillingLocationID = Convert.ToInt32(row["BillToID"]);
                        purchases.ShippingLocationID = Convert.ToInt32(row["ShipToID"]);
                        purchases.BillToLocation = Convert.ToString(row["BillToLocation"]);
                        purchases.BillToAddress = Convert.ToString(row["BillingAddress"]);
                        purchases.ShipToLocation = Convert.ToString(row["ShipToLocation"]);
                        purchases.ShipToAddress = Convert.ToString(row["SHIPPINGAddress"]);
                        purchases.PortOfLoading = Convert.ToString(row["PortOfLoading"]);
                        purchases.CountryOfOrigin = Convert.ToString(row["CountryOfOrigin"]);
                        purchases.SealNo = Convert.ToString(row["SealNo"]);
                        purchases.VesselNo = Convert.ToString(row["VesselNo"]);
                        purchases.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        purchases.CustRefNo = Convert.ToString(row["CustRefNo"]);
                        purchases.FinalDestination = Convert.ToString(row["FinalDestination"]);
                        purchases.ModeOfShipment = Convert.ToInt32(row["ShipmentID"]);
                        purchases.ShipmentTermID = Convert.ToInt32(row["ShipmentTermID"]);
                        purchases.PODID = Convert.ToInt32(row["PODID"]);
                        //purchases.StatusID = Convert.ToInt32(row["GSTStatusID"]);
                        //purchases.LicenseID = Convert.ToInt32(row["LicenseID"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.Others = Convert.ToString(row["Others"]);
                        purchases.ExportBenefit = Convert.ToString(row["ExportBenefit"]);
                        purchases.TotalQty = Convert.ToDecimal(row["TotalQty"]);
                        purchases.TotalNoOfCase = Convert.ToDecimal(row["TotalNoOfCase"]);
                        purchases.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                        purchases.NetTotal = Convert.ToDecimal(row["BasicAmount"]);
                        purchases.TotChrgAmt = Convert.ToDecimal(row["TotalOtherChargeAmt"]);
                        purchases.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);
                        purchases.DisplayBasicAmount = Convert.ToString(row["DisplayBasicAmount"]);
                        purchases.DisplayTotalOtherChargeAmt = Convert.ToString(row["DisplayTotalOtherChargeAmt"]);
                        purchases.DisplayGrandTotal = Convert.ToString(row["DisplayGrandTotal"]);
                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        ExportInvoiceD orderD = new ExportInvoiceD();
                        orderD.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderD.GLNO = Convert.ToString(row["GLNO"]);
                        orderD.ItemDescription = Convert.ToString(row["ItemDesc"]);
                        orderD.Project_Name = Convert.ToString(row["Project_Name"]);
                        //orderD.HeadingID = Convert.ToInt32(row["HeadingID"]);
                        orderD.Unit = Convert.ToString(row["Unit"]);
                        orderD.SaleUnit = Convert.ToString(row["SaleUnit"]);
                        orderD.HSNCode = Convert.ToString(row["HSNCode"]);
                        orderD.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderD.Rate = Convert.ToDecimal(row["Rate"]);
                        orderD.Qty = Convert.ToDecimal(row["QTY"]);
                        orderD.SQM = Convert.ToDecimal(row["SQM"]);
                        orderD.SQFT = Convert.ToDecimal(row["SQFT"]);
                        orderD.NoOfCase = Convert.ToInt32(row["NoOfCases"]);
                        orderD.NetTotal = Convert.ToDecimal(row["Amount"]);
                        //orderD.NetWeight = Convert.ToInt32(row["NetWeight"]);
                        //orderD.GrossWeight = Convert.ToInt32(row["GrossWeight"]);
                        orderD.WONO = Convert.ToString(row["WONO"]);
                        orderD.PINO = Convert.ToString(row["PINO"]);
                        orderD.DCNO = Convert.ToString(row["DCNO"]);
                        orderD.SpecID = Convert.ToInt32(row["SpecID"]);

                        POD.Add(orderD);

                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        ExportInvoiceCharges orderC = new ExportInvoiceCharges();
                        orderC.ChargeID = Convert.ToInt32(row["ChargeID"]);
                        orderC.ChargeName = Convert.ToString(row["ChargeName"]);
                        orderC.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                        orderC.DisplayChargeAmount = Convert.ToString(row["DisplayChargeAmount"]);
                        POCHRG.Add(orderC);
                    }
                }
                if (dt4 != null)
                {
                    foreach (DataRow row in dt4.Rows)
                    {
                        ExportInvoicePacking orderC = new ExportInvoicePacking();
                        orderC.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderC.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderC.PackingMarks = Convert.ToString(row["PackingMarks"]);
                        orderC.PackageName = Convert.ToString(row["PackageName"]);
                        orderC.NoOfPackages = Convert.ToString(row["NoOfPackages"]);
                        orderC.TotalPackages = Convert.ToInt32(row["TotalPackages"]);
                        orderC.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                        orderC.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                        POC.Add(orderC);
                    }
                }
                if (dt5 != null)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        PurchaseOrderPaymentTerm orderP = new PurchaseOrderPaymentTerm();
                        orderP.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        orderP.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        orderP.IsDefault = Convert.ToBoolean(row["IsDefault"]);
                        POPaymentTerm.Add(orderP);
                    }
                }

                purchases.POItem = POD;
                purchases.POCharges = POCHRG;
                purchases.POPaymentTerm = POPaymentTerm;
                purchases.POPacking = POC;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExportInvoiceM GetExportInvoiceDetailPrint(string pONo)
        {
            try
            {
                ExportInvoiceM purchases = new ExportInvoiceM();
                List<ExportInvoiceD> POD = new List<ExportInvoiceD>();
                List<ExportInvoiceCharges> POCHRG = new List<ExportInvoiceCharges>();
                List<ExportInvoicePacking> POC = new List<ExportInvoicePacking>();
                List<PurchaseOrderPaymentTerm> POPaymentTerm = new List<PurchaseOrderPaymentTerm>();
                ExportInvoiceM SpecTotal = new ExportInvoiceM();
                List<ExportInvoiceD> PackingList = new List<ExportInvoiceD>();

                DataSet set = new DataSet();
                set = DBManager.GetExportInvoiceDetailPrint(pONo);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];
                dt4 = set.Tables[3];
                dt5 = set.Tables[4];
                dt6 = set.Tables[5];
                dt7 = set.Tables[6];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.EXID = Convert.ToInt32(row["EXIID"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.EXINO = Convert.ToString(row["EXINO"]);
                        purchases.EXIDate = Convert.ToString(row["EXIDate"]);
                        purchases.PONO = Convert.ToString(row["PONO"]);
                        purchases.PODate = Convert.ToString(row["PODate"]);
                        purchases.LCNO = Convert.ToString(row["LOCNO"]);
                        purchases.LCDate = Convert.ToString(row["LOCDate"]);
                        purchases.EXIType = "D";
                        purchases.CustomerID = Convert.ToInt32(row["CustID"]);
                        purchases.Customer = Convert.ToString(row["CustomerName"]);
                        purchases.Cont_Person = Convert.ToString(row["Cont_Person"]);
                        purchases.Cust_Email = Convert.ToString(row["Cust_Email"]);
                        purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);
                        purchases.CurSym = Convert.ToString(row["Symbol"]);
                        purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);
                        purchases.Symbol = Convert.ToString(row["Symbol"]);
                        purchases.CurrencyCode = Convert.ToString(row["CurrencyCode"]);
                        purchases.BillingLocationID = Convert.ToInt32(row["BillToID"]);
                        purchases.ShippingLocationID = Convert.ToInt32(row["ShipToID"]);
                        purchases.BillToLocation = Convert.ToString(row["BillToLocation"]);
                        purchases.BillToAddress = Convert.ToString(row["BillingAddress"]);
                        purchases.ShipToLocation = Convert.ToString(row["ShipToLocation"]);
                        purchases.ShipToAddress = Convert.ToString(row["SHIPPINGAddress"]);
                        //purchases.PreCarriageBy = Convert.ToString(row["PreCarriageBy"]);
                        //purchases.PlaceOfReceipt = Convert.ToString(row["PlaceOfReceipt"]);
                        purchases.PortOfLoading = Convert.ToString(row["PortOfLoading"]);
                        purchases.CountryOfOrigin = Convert.ToString(row["CountryOfOrigin"]);
                        purchases.FinalDestination = Convert.ToString(row["FinalDestination"]);
                        purchases.VesselNo = Convert.ToString(row["VesselNo"]);
                        purchases.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        purchases.SealNo = Convert.ToString(row["SealNo"]);
                        purchases.Mode = Convert.ToString(row["Shipment"]);
                        purchases.ShipmentTerm = Convert.ToString(row["ShipmentTerm"]);
                        purchases.POD = Convert.ToString(row["POD"]);
                        purchases.DCNO = Convert.ToString(row["DCNO"]);
                        purchases.PINO = Convert.ToString(row["PINO"]);
                        purchases.Project_Name = Convert.ToString(row["Project_Name"]);
                        //purchases.Status = Convert.ToString(row["GSTStatus"]);
                        //purchases.LicenseNo = Convert.ToString(row["License"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.Others = Convert.ToString(row["Others"]);
                        purchases.ExportBenefit = Convert.ToString(row["ExportBenefit"]);
                        purchases.TotalQty = Convert.ToDecimal(row["TotalQty"]);
                        purchases.TotalSQFT = Convert.ToDecimal(row["TotalSQFT"]);
                        purchases.TotalNoOfCase = Convert.ToDecimal(row["TotalNoOfCase"]);
                        purchases.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                        purchases.NetTotal = Convert.ToDecimal(row["BasicAmount"]);
                        purchases.TotChrgAmt = Convert.ToDecimal(row["TotalOtherChargeAmt"]);
                        purchases.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);
                        purchases.DisplayBasicAmount = Convert.ToString(row["DisplayBasicAmount"]);
                        purchases.DisplayTotalOtherChargeAmt = Convert.ToString(row["DisplayTotalOtherChargeAmt"]);
                        purchases.DisplayGrandTotal = Convert.ToString(row["DisplayGrandTotal"]);
                        purchases.AmountInWord = Convert.ToString(row["AmountInWord"]);
                        purchases.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        purchases.DSDate = Convert.ToString(row["DSDate"]);
                        purchases.Currency_Name = Convert.ToString(row["Currency_Name"]);
                        purchases.SaleUnit = Convert.ToString(row["SaleUnit"]);
                        purchases.IsINDPresent = Convert.ToInt32(row["IsINDPresent"]);
                        purchases.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        purchases.IsLC = Convert.ToInt32(row["IsLC"]);
                        purchases.TotNetWeight = Convert.ToDecimal(row["TotNetWeight"]);
                        purchases.TotGrossWeight = Convert.ToDecimal(row["TotGrossWeight"]);
                        purchases.GSTNO = Convert.ToString(row["GSTNO"]);
                        purchases.Others = Convert.ToString(row["Others"]);
                        purchases.Shipment = Convert.ToString(row["Shipment"]);
                        purchases.ShipmentID = Convert.ToInt32(row["ShipmentID"]);
                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        ExportInvoiceD orderD = new ExportInvoiceD();
                        orderD.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderD.GLNO = Convert.ToString(row["GLNO"]);
                        orderD.ItemDescription = Convert.ToString(row["ItemDesc"]);
                        orderD.DCNO = Convert.ToString(row["DCNO"]);
                        //orderD.Heading = Convert.ToString(row["Heading"]);
                        //if (orderD.SrNo == 2)
                        //{
                        //    purchases.SecondHeading = orderD.Heading;
                        //}
                        //orderD.HeadingID = Convert.ToInt32(row["HeadingID"]);
                        orderD.Unit = Convert.ToString(row["Unit"]);
                        orderD.HSNCode = Convert.ToString(row["HSNCode"]);
                        orderD.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderD.Rate = Convert.ToDecimal(row["Rate"]);
                        orderD.Qty = Convert.ToDecimal(row["QTY"]);
                        orderD.SQM = Convert.ToDecimal(row["SQM"]);
                        orderD.SQFT = Convert.ToDecimal(row["SQFT"]);
                        orderD.NoOfCase = Convert.ToInt32(row["NoOfCases"]);
                        orderD.NetTotal = Convert.ToDecimal(row["Amount"]);
                        orderD.DisplayNetTotal = Convert.ToString(row["DisplayNetTotal"]);

                        POD.Add(orderD);

                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        ExportInvoiceCharges orderC = new ExportInvoiceCharges();
                        orderC.ChargeID = Convert.ToInt32(row["ChargeID"]);
                        orderC.ChargeName = Convert.ToString(row["ChargeName"]);
                        orderC.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                        orderC.DisplayChargeAmount = Convert.ToString(row["DisplayChargeAmount"]);
                        POCHRG.Add(orderC);
                    }
                }
                if (dt4 != null)
                {
                    foreach (DataRow row in dt4.Rows)
                    {
                        ExportInvoicePacking orderC = new ExportInvoicePacking();
                        orderC.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderC.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderC.PackingMarks = Convert.ToString(row["PackingMarks"]);
                        orderC.PackageName = Convert.ToString(row["PackageName"]);
                        orderC.NoOfPackages = Convert.ToString(row["NoOfPackages"]);
                        orderC.TotalPackages = Convert.ToInt32(row["TotalPackages"]);
                        orderC.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                        orderC.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                        POC.Add(orderC);
                    }
                }
                if (dt5 != null)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        PurchaseOrderPaymentTerm orderP = new PurchaseOrderPaymentTerm();
                        orderP.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        orderP.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        POPaymentTerm.Add(orderP);
                    }
                }
                if (dt6 != null)
                {
                    foreach (DataRow row in dt6.Rows)
                    {
                        SpecTotal.ToatlQTY = Convert.ToDecimal(row["TotalQty"]);
                        SpecTotal.TotalSQFT = Convert.ToDecimal(row["TotalSQFT"]);
                        
                    }
                }
                //// Packing list
                if (dt7 != null)
                {
                    foreach (DataRow row in dt7.Rows)
                    {
                        ExportInvoiceD PckList = new ExportInvoiceD();
                        //PckList.SrNo = Convert.ToInt32(row["SrNo"]);
                        PckList.SpecID = Convert.ToInt32(row["SpecID"]);
                        PckList.BatchNo = Convert.ToInt32(row["BatchNo"]);

                        PckList.DCNO = Convert.ToString(row["DCNO"]);
                        PckList.Qty = Convert.ToDecimal(row["Pcs"]);
                        PckList.AHeight = Convert.ToDecimal(row["AHeight"]);
                        PckList.AWidth = Convert.ToDecimal(row["AWidth"]);
                        PckList.Inch_Height = Convert.ToDecimal(row["Inch_Height"]);
                        PckList.Inch_Width = Convert.ToDecimal(row["Inch_Width"]);
                        PckList.Qty_SQFT = Convert.ToDecimal(row["Qty_SQFT"]);
               
                        PckList.Remark = Convert.ToString(row["Remark"]);
                        PackingList.Add(PckList);

                    }
                }


                purchases.POItem = POD;
                purchases.POCount = POD.Count();
                purchases.POCharges = POCHRG;
                purchases.POPaymentTerm = POPaymentTerm;
                purchases.POPacking = POC;
                purchases.POPackingCount = POC.Count;
                purchases.OtherChargeCount = POCHRG.Count();
                purchases.PackingList = PackingList;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExportInvoiceM GetExportInvoicePackingPrint(string pONo)
        {
            try
            {
                ExportInvoiceM purchases = new ExportInvoiceM();
                List<ExportInvoiceD> POD = new List<ExportInvoiceD>();
                List<ExportInvoiceCharges> POCHRG = new List<ExportInvoiceCharges>();
                List<ExportInvoicePacking> POC = new List<ExportInvoicePacking>();
                List<PurchaseOrderPaymentTerm> POPaymentTerm = new List<PurchaseOrderPaymentTerm>();
                ExportInvoiceM SpecTotal = new ExportInvoiceM();
                List<ExportInvoiceD> PackingList = new List<ExportInvoiceD>();
                List<ExportInvoiceD> PackingListT = new List<ExportInvoiceD>();

                DataSet set = new DataSet();
                set = DBManager.GetExportInvoicePackingPrint(pONo);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];
                dt4 = set.Tables[3];
                dt5 = set.Tables[4];
                dt6 = set.Tables[5];
                dt7 = set.Tables[6];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.EXID = Convert.ToInt32(row["EXIID"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.EXINO = Convert.ToString(row["EXINO"]);
                        purchases.EXIDate = Convert.ToString(row["EXIDate"]);
                        purchases.PONO = Convert.ToString(row["PONO"]);
                        purchases.PODate = Convert.ToString(row["PODate"]);
                        purchases.LCNO = Convert.ToString(row["LOCNO"]);
                        purchases.LCDate = Convert.ToString(row["LOCDate"]);
                        purchases.EXIType = "D";
                        purchases.CustomerID = Convert.ToInt32(row["CustID"]);
                        purchases.Customer = Convert.ToString(row["CustomerName"]);
                        purchases.Cont_Person = Convert.ToString(row["Cont_Person"]);
                        purchases.Cust_Email = Convert.ToString(row["Cust_Email"]);
                        purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);
                        purchases.CurSym = Convert.ToString(row["Symbol"]);
                        purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);
                        purchases.Symbol = Convert.ToString(row["Symbol"]);
                        purchases.CurrencyCode = Convert.ToString(row["CurrencyCode"]);
                        purchases.BillingLocationID = Convert.ToInt32(row["BillToID"]);
                        purchases.ShippingLocationID = Convert.ToInt32(row["ShipToID"]);
                        purchases.BillToLocation = Convert.ToString(row["BillToLocation"]);
                        purchases.BillToAddress = Convert.ToString(row["BillingAddress"]);
                        purchases.ShipToLocation = Convert.ToString(row["ShipToLocation"]);
                        purchases.ShipToAddress = Convert.ToString(row["SHIPPINGAddress"]);
                        //purchases.PreCarriageBy = Convert.ToString(row["PreCarriageBy"]);
                        //purchases.PlaceOfReceipt = Convert.ToString(row["PlaceOfReceipt"]);
                        purchases.PortOfLoading = Convert.ToString(row["PortOfLoading"]);
                        purchases.CountryOfOrigin = Convert.ToString(row["CountryOfOrigin"]);
                        purchases.FinalDestination = Convert.ToString(row["FinalDestination"]);
                        purchases.VesselNo = Convert.ToString(row["VesselNo"]);
                        purchases.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        purchases.SealNo = Convert.ToString(row["SealNo"]);
                        purchases.Mode = Convert.ToString(row["Shipment"]);
                        purchases.ShipmentTerm = Convert.ToString(row["ShipmentTerm"]);
                        purchases.POD = Convert.ToString(row["POD"]);
                        purchases.DCNO = Convert.ToString(row["DCNO"]);
                        purchases.PINO = Convert.ToString(row["PINO"]);
                        purchases.Project_Name = Convert.ToString(row["Project_Name"]);
                        //purchases.Status = Convert.ToString(row["GSTStatus"]);
                        //purchases.LicenseNo = Convert.ToString(row["License"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.Others = Convert.ToString(row["Others"]);
                        purchases.ExportBenefit = Convert.ToString(row["ExportBenefit"]);
                        purchases.TotalQty = Convert.ToDecimal(row["TotalQty"]);
                        purchases.TotalSQFT = Convert.ToDecimal(row["TotalSQFT"]);
                        purchases.TotalNoOfCase = Convert.ToDecimal(row["TotalNoOfCase"]);
                        purchases.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                        purchases.NetTotal = Convert.ToDecimal(row["BasicAmount"]);
                        purchases.TotChrgAmt = Convert.ToDecimal(row["TotalOtherChargeAmt"]);
                        purchases.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);
                        purchases.DisplayBasicAmount = Convert.ToString(row["DisplayBasicAmount"]);
                        purchases.DisplayTotalOtherChargeAmt = Convert.ToString(row["DisplayTotalOtherChargeAmt"]);
                        purchases.DisplayGrandTotal = Convert.ToString(row["DisplayGrandTotal"]);
                        purchases.AmountInWord = Convert.ToString(row["AmountInWord"]);
                        purchases.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        purchases.DSDate = Convert.ToString(row["DSDate"]);
                        purchases.Currency_Name = Convert.ToString(row["Currency_Name"]);
                        purchases.SaleUnit = Convert.ToString(row["SaleUnit"]);
                        purchases.IsINDPresent = Convert.ToInt32(row["IsINDPresent"]);
                        purchases.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        purchases.IsLC = Convert.ToInt32(row["IsLC"]);
                        purchases.TotNetWeight = Convert.ToDecimal(row["TotNetWeight"]);
                        purchases.TotGrossWeight = Convert.ToDecimal(row["TotGrossWeight"]);
                        //purchases.TotalSQFT = Convert.ToDecimal(row["TotalSQFT"]);
                        purchases.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                        purchases.GSTNO = Convert.ToString(row["GSTNO"]);
                        purchases.Shipment = Convert.ToString(row["Shipment"]);
                        purchases.ShipmentID = Convert.ToInt32(row["ShipmentID"]);
                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        ExportInvoiceD orderD = new ExportInvoiceD();
                        orderD.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderD.GLNO = Convert.ToString(row["GLNO"]);
                        orderD.ItemDescription = Convert.ToString(row["ItemDesc"]);
                        orderD.DCNO = Convert.ToString(row["DCNO"]);
                        //orderD.Heading = Convert.ToString(row["Heading"]);
                        //if (orderD.SrNo == 2)
                        //{
                        //    purchases.SecondHeading = orderD.Heading;
                        //}
                        //orderD.HeadingID = Convert.ToInt32(row["HeadingID"]);
                        orderD.Unit = Convert.ToString(row["Unit"]);
                        orderD.SaleUnit = Convert.ToString(row["SaleUnit"]);
                        orderD.HSNCode = Convert.ToString(row["HSNCode"]);
                        orderD.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderD.Rate = Convert.ToDecimal(row["Rate"]);
                        orderD.Qty = Convert.ToDecimal(row["QTY"]);
                        orderD.SQM = Convert.ToDecimal(row["SQM"]);
                        orderD.SQFT = Convert.ToDecimal(row["SQFT"]);
                        orderD.NoOfCase = Convert.ToInt32(row["NoOfCases"]);
                        orderD.NetTotal = Convert.ToDecimal(row["Amount"]);
                        orderD.DisplayNetTotal = Convert.ToString(row["DisplayNetTotal"]);

                        POD.Add(orderD);

                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        ExportInvoiceCharges orderC = new ExportInvoiceCharges();
                        orderC.ChargeID = Convert.ToInt32(row["ChargeID"]);
                        orderC.ChargeName = Convert.ToString(row["ChargeName"]);
                        orderC.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                        orderC.DisplayChargeAmount = Convert.ToString(row["DisplayChargeAmount"]);
                        POCHRG.Add(orderC);
                    }
                }
                if (dt4 != null)
                {
                    foreach (DataRow row in dt4.Rows)
                    {
                        ExportInvoicePacking orderC = new ExportInvoicePacking();
                        orderC.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderC.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderC.PackingMarks = Convert.ToString(row["PackingMarks"]);
                        orderC.PackageName = Convert.ToString(row["PackageName"]);
                        orderC.NoOfPackages = Convert.ToString(row["NoOfPackages"]);
                        orderC.TotalPackages = Convert.ToInt32(row["TotalPackages"]);
                        orderC.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                        orderC.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                        POC.Add(orderC);
                    }
                }
                if (dt5 != null)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        PurchaseOrderPaymentTerm orderP = new PurchaseOrderPaymentTerm();
                        orderP.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        orderP.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        POPaymentTerm.Add(orderP);
                    }
                }
                if (dt6 != null)
                {
                    foreach (DataRow row in dt6.Rows)
                    {
                        ExportInvoiceD PckTotalD = new ExportInvoiceD();
                        PckTotalD.ToatlQTY = Convert.ToDecimal(row["TotalQty"]);
                        PckTotalD.TotalSQFT = Convert.ToDecimal(row["TotalSQFT"]);
                        PckTotalD.TotASQM = Convert.ToDecimal(row["TotASQM"]);
                        PckTotalD.DCNO = Convert.ToString(row["DCNO"]);
                        PackingListT.Add(PckTotalD);

                    }
                }
                //// Packing list
                if (dt7 != null)
                {
                    foreach (DataRow row in dt7.Rows)
                    {
                        ExportInvoiceD PckList = new ExportInvoiceD();
                        //PckList.SrNo = Convert.ToInt32(row["SrNo"]);
                        PckList.SpecID = Convert.ToInt32(row["SpecID"]);
                        PckList.BatchNo = Convert.ToInt32(row["BatchNo"]);

                        PckList.DCNO = Convert.ToString(row["DCNO"]);
                        PckList.Qty = Convert.ToDecimal(row["Pcs"]);
                        PckList.AHeight = Convert.ToDecimal(row["AHeight"]);
                        PckList.AWidth = Convert.ToDecimal(row["AWidth"]);
                        PckList.Inch_Height = Convert.ToDecimal(row["Inch_Height"]);
                        PckList.Inch_Width = Convert.ToDecimal(row["Inch_Width"]);
                        PckList.Qty_SQFT = Convert.ToDecimal(row["Qty_SQFT"]);
                        PckList.ASQM = Convert.ToDecimal(row["ASQM"]);
                        PckList.SaleUnit = Convert.ToString(row["SaleUnit"]);
                        PckList.Remark = Convert.ToString(row["Remark"]);
                        PackingList.Add(PckList);

                    }
                }


                purchases.POItem = POD;
                purchases.POCount = POD.Count();
                purchases.POCharges = POCHRG;
                purchases.POPaymentTerm = POPaymentTerm;
                purchases.POPacking = POC;
                purchases.POPackingCount = POC.Count;
                purchases.OtherChargeCount = POCHRG.Count();
                purchases.PackingList = PackingList;
                purchases.PackingTotal = PackingListT;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ExportInvoiceM GetPackingListDetailPrint(string pONo)
        {
            try
            {
                ExportInvoiceM purchases = new ExportInvoiceM();
                List<ExportInvoiceD> POD = new List<ExportInvoiceD>();
                List<ExportInvoiceCharges> POCHRG = new List<ExportInvoiceCharges>();
                List<ExportInvoicePacking> POC = new List<ExportInvoicePacking>();
                List<PurchaseOrderPaymentTerm> POPaymentTerm = new List<PurchaseOrderPaymentTerm>();

                DataSet set = new DataSet();
                set = DBManager.GetPackingListDetailPrint(pONo);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];
                dt4 = set.Tables[3];
                dt5 = set.Tables[4];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.EXID = Convert.ToInt32(row["PackingID"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.EXINO = Convert.ToString(row["PackingNo"]);
                        purchases.EXIDate = Convert.ToString(row["PackingDate"]);
                        purchases.PONO = Convert.ToString(row["PONO"]);
                        purchases.PODate = Convert.ToString(row["PODate"]);
                        purchases.LCNO = Convert.ToString(row["LOCNO"]);
                        purchases.LCDate = Convert.ToString(row["LOCDate"]);
                        purchases.EXIType = "D";
                        purchases.CustomerID = Convert.ToInt32(row["CustID"]);
                        purchases.Customer = Convert.ToString(row["CustomerName"]);
                        purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);
                        purchases.CurSym = Convert.ToString(row["Symbol"]);
                        purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);
                        purchases.Symbol = Convert.ToString(row["Symbol"]);
                        purchases.CurrencyCode = Convert.ToString(row["CurrencyCode"]);
                        purchases.BillingLocationID = Convert.ToInt32(row["BillToID"]);
                        purchases.ShippingLocationID = Convert.ToInt32(row["ShipToID"]);
                        purchases.BillToLocation = Convert.ToString(row["BillToLocation"]);
                        purchases.BillToAddress = Convert.ToString(row["BillingAddress"]);
                        purchases.ShipToLocation = Convert.ToString(row["ShipToLocation"]);
                        purchases.ShipToAddress = Convert.ToString(row["SHIPPINGAddress"]);
                        purchases.PreCarriageBy = Convert.ToString(row["PreCarriageBy"]);
                        purchases.PlaceOfReceipt = Convert.ToString(row["PlaceOfReceipt"]);
                        purchases.VesselNo = Convert.ToString(row["VesselNo"]);
                        purchases.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        purchases.Mode = Convert.ToString(row["Shipment"]);
                        purchases.ShipmentTerm = Convert.ToString(row["ShipmentTerm"]);
                        purchases.POD = Convert.ToString(row["POD"]);
                        purchases.Status = Convert.ToString(row["GSTStatus"]);
                        purchases.LicenseNo = Convert.ToString(row["License"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.Others = Convert.ToString(row["Others"]);
                        purchases.ExportBenefit = Convert.ToString(row["ExportBenefit"]);
                        purchases.TotalQty = Convert.ToDecimal(row["TotalQty"]);
                        purchases.TotalNoOfCase = Convert.ToDecimal(row["TotalNoOfCase"]);
                        purchases.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                        purchases.NetTotal = Convert.ToDecimal(row["BasicAmount"]);
                        purchases.TotChrgAmt = Convert.ToDecimal(row["TotalOtherChargeAmt"]);
                        purchases.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);
                        purchases.DisplayBasicAmount = Convert.ToString(row["DisplayBasicAmount"]);
                        purchases.DisplayTotalOtherChargeAmt = Convert.ToString(row["DisplayTotalOtherChargeAmt"]);
                        purchases.DisplayGrandTotal = Convert.ToString(row["DisplayGrandTotal"]);
                        purchases.AmountInWord = Convert.ToString(row["AmountInWord"]);
                        purchases.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        purchases.DSDate = Convert.ToString(row["DSDate"]);
                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        ExportInvoiceD orderD = new ExportInvoiceD();
                        orderD.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderD.ItemDescription = Convert.ToString(row["ItemDesc"]);
                        orderD.Heading = Convert.ToString(row["Heading"]);
                        if (orderD.SrNo == 2)
                        {
                            purchases.SecondHeading = orderD.Heading;
                        }
                        orderD.HeadingID = Convert.ToInt32(row["HeadingID"]);
                        orderD.Unit = Convert.ToString(row["Unit"]);
                        orderD.HSNCode = Convert.ToString(row["HSNCode"]);
                        orderD.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderD.Rate = Convert.ToDecimal(row["Rate"]);
                        orderD.Qty = Convert.ToDecimal(row["QTY"]);
                        orderD.SQM = Convert.ToDecimal(row["SQM"]);
                        orderD.SQFT = Convert.ToDecimal(row["SQFT"]);
                        orderD.NoOfCase = Convert.ToInt32(row["NoOfCases"]);
                        orderD.NetTotal = Convert.ToDecimal(row["Amount"]);
                        orderD.DisplayNetTotal = Convert.ToString(row["DisplayNetTotal"]);

                        POD.Add(orderD);

                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        ExportInvoiceCharges orderC = new ExportInvoiceCharges();
                        orderC.ChargeID = Convert.ToInt32(row["ChargeID"]);
                        orderC.ChargeName = Convert.ToString(row["ChargeName"]);
                        orderC.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                        orderC.DisplayChargeAmount = Convert.ToString(row["DisplayChargeAmount"]);
                        POCHRG.Add(orderC);
                    }
                }
                if (dt4 != null)
                {
                    foreach (DataRow row in dt4.Rows)
                    {
                        ExportInvoicePacking orderC = new ExportInvoicePacking();
                        orderC.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderC.ContainerNo = Convert.ToString(row["ContainerNo"]);
                        orderC.PackingMarks = Convert.ToString(row["PackingMarks"]);
                        orderC.PackageName = Convert.ToString(row["PackageName"]);
                        orderC.NoOfPackages = Convert.ToString(row["NoOfPackages"]);
                        orderC.TotalPackages = Convert.ToInt32(row["TotalPackages"]);
                        orderC.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                        orderC.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                        POC.Add(orderC);
                    }
                }
                if (dt5 != null)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        PurchaseOrderPaymentTerm orderP = new PurchaseOrderPaymentTerm();
                        orderP.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        orderP.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        POPaymentTerm.Add(orderP);
                    }
                }

                purchases.POItem = POD;
                purchases.POCount = POD.Count();
                purchases.POCharges = POCHRG;
                purchases.POPaymentTerm = POPaymentTerm;
                purchases.POPacking = POC;
                purchases.POPackingCount = POC.Count;
                purchases.OtherChargeCount = POCHRG.Count();

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseOrderD> GetChrgesList(string EXINO)
        {
            try
            {
                List<PurchaseOrderD> list = new List<PurchaseOrderD>();
                DataTable dt = new DataTable();
                dt = DBManager.GetChrgesList();
                if (dt != null)
                {
                    var i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        PurchaseOrderD enq = new PurchaseOrderD();
                        enq.ChargeID = Convert.ToInt32(row["ChargeID"]);
                        enq.ChargeName = Convert.ToString(row["Name"]);
                        enq.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerM> GetCustomerMasterList()
        {
            try
            {
                List<CustomerM> list = new List<CustomerM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetCustomerMasterList();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CustomerM enq = new CustomerM();
                        enq.CustomerID = Convert.ToInt32(row["Cust_ID"]);
                        enq.CustomerName = Convert.ToString(row["Cust_Name"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //New For Email Table
        public List<ItemList> POItemsDetails(string PONo)
        {
            try
            {
                List<ItemList> list = new List<ItemList>();
                DataTable dt = new DataTable();
                dt = DBManager.POItemsDetails(PONo);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ItemList enq = new ItemList();
                        enq.SrNo = Convert.ToInt32(row["SrNo"]);
                        enq.ItemCode = Convert.ToString(row["ItemCode"]);
                        enq.ItemDesc = Convert.ToString(row["ItemDesc"]);
                        enq.ItemQty = Convert.ToString(row["Qty"]);
                        enq.NetAmount = Convert.ToString(row["Amount"]);
                        enq.GrandTotal = Convert.ToString(row["GrandTotal"]);
                        enq.VendorName = Convert.ToString(row["VendorName"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //End New For Email Table
        public List<DeliveryInfo> GetDeliveryAddressList()
        {
            try
            {
                List<DeliveryInfo> list = new List<DeliveryInfo>();
                DataTable dt = new DataTable();
                dt = DBManager.GetDeliveryAddressList();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DeliveryInfo enq = new DeliveryInfo();
                        enq.DeliveryAddressID = Convert.ToInt32(row["DeliveryAddressID"]);
                        enq.DeliveryAddress = Convert.ToString(row["DeliveryAddress"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage AddOrEditExportInvoice(ExportInvoiceM POM, int AddedBy, DataTable dataTable, DataTable dataTableF2, DataTable dataTableP3, DataTable dataTableT4)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DBManager.AddOrEditExportInvoice(POM.EXID, POM.EXINO, POM.EXIDate, POM.PONO, POM.PODate, POM.LCNO, POM.LCDate, POM.EXIType,  POM.CustomerID, POM.FinalTotal,
                     POM.AddedOn, POM.CurrencyID, POM.ExchangeRate, POM.BillingLocationID, POM.ShippingLocationID, POM.BillToAddress, POM.ShipToAddress, POM.TotChrgAmt, POM.GrandTotal, POM.Remarks,
                     POM.VesselNo, POM.ContainerNo, POM.ModeOfShipment, POM.ShipmentTermID, POM.PODID,  POM.Others, POM.ExportBenefit, POM.PortOfLoading , POM.CountryOfOrigin , POM.SealNo, POM.FinalDestination , POM.CustRefNo ,
                    AddedBy ,dataTable, dataTableF2, dataTableP3, dataTableT4 );

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.EXINO = Convert.ToString(row["EXINO"]);
                  
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

        public ResponseMessage AjaxAddOrEditPackingList(ExportInvoiceM POM, DataTable dataTable, DataTable dataTableF2, DataTable dataTableP3, DataTable dataTableT4)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DBManager.AjaxAddOrEditPackingList(POM.EXID, POM.EXINO, POM.EXIDate, POM.PONO, POM.PODate, POM.LCNO, POM.LCDate, POM.EXIType, POM.PINNo, POM.CustomerID, POM.FinalTotal, POM.AddedBy, POM.AddedOn, POM.CurrencyID, POM.ExchangeRate, POM.BillingLocationID, POM.ShippingLocationID, POM.BillToAddress, POM.ShipToAddress, POM.TotChrgAmt, POM.GrandTotal, POM.Remarks,
                    POM.PreCarriageBy, POM.PlaceOfReceipt, POM.VesselNo, POM.ContainerNo, POM.ModeOfShipment, POM.ShipmentTermID, POM.PODID, POM.StatusID, POM.LicenseID, POM.Others, POM.ExportBenefit,
                    dataTable, dataTableF2, dataTableP3, dataTableT4);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        //message.Vendor = Convert.ToString(row["VendorName"]);
                        //message.Amount = Convert.ToInt32(row["GrandTotal"]);
                        //message.PODate = Convert.ToString(row["PODate"]);
                        //message.PONO = Convert.ToString(row["PONO"]);
                        //message.UserName = Convert.ToString(row["UserName"]);
                        //message.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
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
        public List<PurchaseOrderM> GetPurchaseOrderMDataForXML()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPurchaseOrderMDataForXML();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PurchaseOrderM data = new PurchaseOrderM();
                        data.POID = Convert.ToInt32(row["POID"]);
                        data.PONO = Convert.ToString(row["PONO"]);
                        data.PODisplayDate = Convert.ToString(row["PODate"]);
                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.NetTotal = Convert.ToDecimal(row["BasicAmount"]);
                        data.FinalTotal = Convert.ToDecimal(row["GrandTotal"]);
                        data.ApprovedByName = Convert.ToString(row["AddedByName"]);
                        data.PanNO = Convert.ToString(row["PANNo"]);
                        data.GSTNO = Convert.ToString(row["GSTNo"]);
                        data.State = Convert.ToString(row["State"]);
                        data.Address1 = Convert.ToString(row["Vendor_Address"]);
                        data.Address2 = Convert.ToString(row["address2"]);
                        data.TallyLedgerName = Convert.ToString(row["TallyLedgerName"]);
                        data.DisplayDate = Convert.ToString(row["DisplayPODate"]);
                        data.ALTERID = Convert.ToString(row["ALTERID"]);
                        data.GUID = Convert.ToString(row["GUID"]);
                        data.MASTERID = Convert.ToString(row["MASTERID"]);
                        data.REMOTEID = Convert.ToString(row["REMOTEID"]);
                        data.VCHKEY = Convert.ToString(row["VCHKEY"]);
                        data.VOUCHERKEY = Convert.ToString(row["VOUCHERKEY"]);
                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<PIMaster> GetDNNOListAgainstCustomer(int CustomerID)
        {
            List<PIMaster> OpenGRNList = new List<PIMaster>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DBManager.GetDNNOListAgainstCustomer(CustomerID);
            if (OpenGRNDL != null)
            {
                int i = 0;
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    PIMaster OpenGRNData = new PIMaster();

                    OpenGRNData.DCNO = Convert.ToString(row["DCNo"]);
                    OpenGRNData.DCDate = Convert.ToString(row["DCDate"]);
                    OpenGRNData.ProjectName = Convert.ToString(row["Project_Name"]);
                    //OpenGRNData.CustName = Convert.ToString(row["Cust_Name"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                    OpenGRNData.Description = Convert.ToString(row["Description"]);
                    OpenGRNData.Qty = Convert.ToDecimal(row["Qty"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                    //OpenGRNData.BalQty = Convert.ToDecimal(row["BalQty"]);
                    //OpenGRNData.BalSQM = Convert.ToDecimal(row["BalSQM"]);
                    //OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.SrNo = i++;

                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }
        public List<PIDetails> GetItemListAgainstPINo(string PINo)
        {
            List<PIDetails> OpenGRNList = new List<PIDetails>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DBManager.GetItemListAgainstPINo(PINo);
            List<PIDetails> enqBL = new List<PIDetails>();
            if (OpenGRNDL != null)
            {
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    PIDetails OpenGRNData = new PIDetails();
                    OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.ItemCode = Convert.ToString(row["ItemCode"]);
                    OpenGRNData.HeadingID = Convert.ToInt32(row["HeadingID"]);
                    OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                    OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                    OpenGRNData.HSNCode = Convert.ToString(row["HSNCode"]);
                    OpenGRNData.Qty = Convert.ToDecimal(row["TotPcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.Rate = Convert.ToDecimal(row["Rate"]);
                    OpenGRNData.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                    OpenGRNData.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                    OpenGRNData.NoOfCases = Convert.ToDecimal(row["NoOfCases"]);
                    OpenGRNData.ContainerNo = Convert.ToString(row["ContainerNo"]);
                    OpenGRNData.NetTotal = Convert.ToDecimal(row["TotalLC"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }
        public PIDetails GetItemListAgainstDCNO(DataTable dtWONO)
        {
            PIDetails purchases = new PIDetails();
            List<PIDetails> OpenGRNList = new List<PIDetails>();

            DataSet set = new DataSet();
            set = DBManager.GetItemListAgainstDCNO(dtWONO);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            dt1 = set.Tables[0];
            dt2 = set.Tables[1];
            dt3 = set.Tables[2];

            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {

                    purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);

                }
            }
            if (dt2 != null)
            {
                foreach (DataRow row in dt2.Rows)
                {

                    purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);

                }
            }
            if (dt3 != null)
            {
                foreach (DataRow row in dt3.Rows)
                {
                    PIDetails OpenGRNData = new PIDetails();
                    OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    //OpenGRNData.ItemCode = Convert.ToString(row["ItemCode"]);
                    OpenGRNData.HeadingID = Convert.ToInt32(row["HeadingID"]);
                    OpenGRNData.Heading = Convert.ToString(row["Heading"]);
                    OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                    OpenGRNData.Project_Name = Convert.ToString(row["Project_Name"]);
                    OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                    OpenGRNData.HSNCode = Convert.ToString(row["HSNCode"]);
                    OpenGRNData.SaleUnit = Convert.ToString(row["SaleUnit"]);
                    OpenGRNData.Qty = Convert.ToDecimal(row["TotPcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.SQFT = Convert.ToDecimal(row["SQFT"]);
                    OpenGRNData.Rate = Convert.ToDecimal(row["Rate"]);
                    //OpenGRNData.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                    //OpenGRNData.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                    //OpenGRNData.NoOfCases = Convert.ToDecimal(row["NoOfCases"]);
                    //OpenGRNData.ContainerNo = Convert.ToString(row["ContainerNo"]);
                    OpenGRNData.NetTotal = Convert.ToDecimal(row["TotalLC"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                    OpenGRNData.DCNO = Convert.ToString(row["DCNo"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                    OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            purchases.POBilling = OpenGRNList;
            return purchases;
        }
        //Last Purchase History
        public List<ItemList> ViewLastPurchaseHistoryCO(int ItemID, int IsLastMonth)
        {
            List<ItemList> OpenGRNList = new List<ItemList>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DBManager.ViewLastPurchaseHistoryCO(ItemID, IsLastMonth);
            List<ItemList> enqBL = new List<ItemList>();
            if (OpenGRNDL != null)
            {
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    ItemList OpenGRNData = new ItemList();
                    //OpenGRNData.ItemID = Convert.ToInt32(row["ItemID"]);
                    OpenGRNData.GRNNo = Convert.ToString(row["GRNNo"]);
                    OpenGRNData.PONo = Convert.ToString(row["PONo"]);
                    OpenGRNData.PartNo = Convert.ToString(row["PartNo"]);
                    OpenGRNData.ItemDescription = Convert.ToString(row["ItemDesc"]);
                    OpenGRNData.PurchaseDate = Convert.ToString(row["PurchaseDate"]);
                    OpenGRNData.Rate = Convert.ToInt32(row["Rate"]);
                    OpenGRNData.QTY = Convert.ToInt32(row["Qty"]);
                    OpenGRNData.VendorName = Convert.ToString(row["VendorName"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }
        public List<ItemList> ViewLastPurchaseHistoryRM(int ItemID, int IsLastMonth)
        {
            List<ItemList> OpenGRNList = new List<ItemList>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DBManager.ViewLastPurchaseHistoryRM(ItemID, IsLastMonth);
            List<ItemList> enqBL = new List<ItemList>();
            if (OpenGRNDL != null)
            {
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    ItemList OpenGRNData = new ItemList();
                    //OpenGRNData.ItemID = Convert.ToInt32(row["ItemID"]);
                    OpenGRNData.GRNNo = Convert.ToString(row["GRNNo"]);
                    OpenGRNData.PONo = Convert.ToString(row["PONo"]);
                    OpenGRNData.PartNo = Convert.ToString(row["PartNo"]);
                    OpenGRNData.ItemDescription = Convert.ToString(row["ItemDesc"]);
                    OpenGRNData.PurchaseDate = Convert.ToString(row["PurchaseDate"]);
                    OpenGRNData.Rate = Convert.ToInt32(row["Rate"]);
                    OpenGRNData.QTY = Convert.ToInt32(row["Qty"]);
                    OpenGRNData.VendorName = Convert.ToString(row["VendorName"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }
        //End Last Purchase History
        public string POApproval(PurchaseOrderM data)
        {
            try
            {
                //    // HC.DBOperationForTrackerPurchase db = new HC.DBOperationForTrackerPurchase();

                string success = "";

                DataTable itemD = new DataTable();

                itemD = DBManager.POApproval(data.PONO, data.ApprovedBy, data.ApprovedRemarks, data.postatus);

                if (itemD != null)
                {
                    success = Convert.ToString(itemD.Rows[0][0]);
                }

                return success;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPurchaseStatus()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPurchaseStatus();
                if (dt != null)
                {
                    int a = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        a++;
                        PurchaseOrderM data = new PurchaseOrderM();
                        data.SrNo = a;
                        data.StatusID = Convert.ToInt32(row["AutoID"]);
                        data.Status = Convert.ToString(row["Status"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseOrderM> GetPendingPurchaseOrderSummary()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingPurchaseOrderSummary();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);

                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        data.Received = Convert.ToString(row["Partially Received/Fully Received"]);


                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPendingCOPOList()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingCOPOList();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);

                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        data.Received = Convert.ToString(row["Partially Received/Fully Received"]);


                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPendingRMPOList()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingRMPOList();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);

                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        data.Received = Convert.ToString(row["Partially Received/Fully Received"]);


                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPendingPurchaseOrderForAppr()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingPurchaseOrderForAppr();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);
                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPendingCOPOForAppr()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingCOPOForAppr();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);
                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> GetPendingRMPOForAppr()
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPendingRMPOForAppr();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        //if (Convert.ToString(row["Partially Received/Fully Received"]) != "")
                        //{
                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.SrNo = i;
                        data.PODisplayDate = Convert.ToString(row["Date"]);
                        data.VendorName = Convert.ToString(row["VendorName"]);
                        data.PendingDay = Convert.ToString(row["PendingDays"]);
                        data.GrandTotal = Convert.ToDecimal(row["GrandTotal"]);

                        list.Add(data);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderD> GetCurrentCOStockValueList()
        {
            try
            {
                List<PurchaseOrderD> list = new List<PurchaseOrderD>();
                DataTable dt = new DataTable();
                dt = DBManager.GetCurrentCOStockValueList();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        i++;

                        PurchaseOrderD data = new PurchaseOrderD();

                        data.SrNo = i;
                        data.ItemCode = Convert.ToString(row["Code"]);
                        data.PartNo = Convert.ToString(row["PartNo"]);
                        data.ItemDescription = Convert.ToString(row["Name"]);
                        data.InStock = Convert.ToInt32(row["In Stock"]);
                        //data.WareHouse = Convert.ToString(row["WareHouse"]);
                        data.Rate = Convert.ToDecimal(row["Rate"]);
                        data.FinalTotal = Convert.ToDecimal(row["Total Amount"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderD> GetCurrentRMStockValueList()
        {
            try
            {
                List<PurchaseOrderD> list = new List<PurchaseOrderD>();
                DataTable dt = new DataTable();
                dt = DBManager.GetCurrentRMStockValueList();
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        i++;

                        PurchaseOrderD data = new PurchaseOrderD();

                        data.SrNo = i;
                        data.ItemCode = Convert.ToString(row["Code"]);
                        data.PartNo = Convert.ToString(row["PartNo"]);
                        data.ItemDescription = Convert.ToString(row["Name"]);
                        data.Height = Convert.ToString(row["Height"]);
                        data.Width = Convert.ToString(row["Width"]);
                        data.InStock = Convert.ToInt32(row["In Stock"]);
                        //data.WareHouse = Convert.ToString(row["WareHouse"]);
                        data.Rate = Convert.ToDecimal(row["Rate"]);
                        data.FinalTotal = Convert.ToDecimal(row["Total Amount"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PurchaseOrderM> ViewPoDetail(string PONO)
        {
            try
            {
                List<PurchaseOrderM> list = new List<PurchaseOrderM>();
                DataTable dt = new DataTable();
                dt = DBManager.ViewPoDetail(PONO);
                if (dt != null)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {

                        i++;

                        PurchaseOrderM data = new PurchaseOrderM();

                        data.PONO = Convert.ToString(row["PO NO"]);
                        data.GRNNo = Convert.ToString(row["GRNNo"]);
                        data.ItemName = Convert.ToString(row["ItemDescription"]);
                        data.Qty = Convert.ToDecimal(row["purchaseqty"]);
                        data.GrnQty = Convert.ToDecimal(row["grnQty"]);



                        list.Add(data);

                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ClosePO(string PONo, string Reason, int AddedBy)
        {
            try
            {
                //    // HC.DBOperationForTrackerPurchase db = new HC.DBOperationForTrackerPurchase();

                string success = "";

                DataTable itemD = new DataTable();

                itemD = DBManager.ClosePO(PONo, Reason, AddedBy);

                if (itemD != null)
                {
                    success = Convert.ToString(itemD.Rows[0][0]);
                }

                return success;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage AjaxGetCancelPO(string PONo, string Reason, int AddedBy)
        {
            try
            {
                DataTable itemD = new DataTable();
                ResponseMessage response = new ResponseMessage();
                itemD = DBManager.AjaxGetCancelPO(PONo, Reason, AddedBy);

                if (itemD != null)
                {
                    foreach (DataRow row in itemD.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                    }

                }

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage AjaxGetApprovePO(string IndentNo, int AddedBy)
        {
            try
            {
                DataTable itemD = new DataTable();
                ResponseMessage response = new ResponseMessage();
                itemD = DBManager.AjaxGetApprovePO(IndentNo, AddedBy);

                if (itemD != null)
                {
                    foreach (DataRow row in itemD.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                    }

                }

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Add Payment term
        public List<PurchaseOrderPaymentTerm> GetPaymentTermList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetPaymentTermList();
                List<PurchaseOrderPaymentTerm> enqBL = new List<PurchaseOrderPaymentTerm>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        PurchaseOrderPaymentTerm enq = new PurchaseOrderPaymentTerm();
                        i++;
                        //enq.SN = i;
                        enq.IsDefault = Convert.ToBoolean(row["IsDefault"]);
                        enq.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        enq.PaymentTerm = Convert.ToString(row["PaymentTerms"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //POD Master
        public List<ModeOfShipment> GetPODList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetPODList();
                List<ModeOfShipment> enqBL = new List<ModeOfShipment>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        ModeOfShipment enq = new ModeOfShipment();
                        i++;
                        //enq.SN = i;
                        enq.PODID = Convert.ToInt32(row["PODID"]);
                        enq.PODName = Convert.ToString(row["PODName"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GST Status Master
        public List<ModeOfShipment> GetGSTStatusList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetGSTStatusList();
                List<ModeOfShipment> enqBL = new List<ModeOfShipment>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        ModeOfShipment enq = new ModeOfShipment();
                        i++;
                        //enq.SN = i;
                        enq.StausID = Convert.ToInt32(row["ID"]);
                        enq.StatusName = Convert.ToString(row["Status"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //License No Master
        public List<ModeOfShipment> GetLicenseNoList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetLicenseNoList();
                List<ModeOfShipment> enqBL = new List<ModeOfShipment>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        ModeOfShipment enq = new ModeOfShipment();
                        i++;
                        //enq.SN = i;
                        enq.LicenseID = Convert.ToInt32(row["ID"]);
                        enq.LicenseNo = Convert.ToString(row["LicenseNO"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ShipMent Term Master
        public List<ModeOfShipment> GetShipMentTermList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetShipMentTermList();
                List<ModeOfShipment> enqBL = new List<ModeOfShipment>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        ModeOfShipment enq = new ModeOfShipment();
                        i++;
                        //enq.SN = i;
                        enq.TermID = Convert.ToInt32(row["TermID"]);
                        enq.Term = Convert.ToString(row["Term"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Export Heading List
        public List<ModeOfShipment> GetExportHeadingList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetExportHeadingList();
                List<ModeOfShipment> enqBL = new List<ModeOfShipment>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        ModeOfShipment enq = new ModeOfShipment();
                        i++;
                        //enq.SN = i;
                        enq.HeadingID = Convert.ToInt32(row["HeadingID"]);
                        enq.Heading = Convert.ToString(row["Heading"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseOrderConditions> GetTermAndConditionsList()
        {
            try
            {

                DataTable list = new DataTable();
                list = DBManager.GetTermAndConditionsList();
                List<PurchaseOrderConditions> enqBL = new List<PurchaseOrderConditions>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        PurchaseOrderConditions enq = new PurchaseOrderConditions();
                        i++;
                        //enq.SN = i;
                        enq.IsDefault = Convert.ToBoolean(row["IsDefault"]);
                        enq.TermID = Convert.ToInt32(row["TermID"]);
                        enq.Term = Convert.ToString(row["Term"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public PurchaseOrderM SetCustomerData(int VendorID)
        {
            try
            {
                PurchaseOrderM purchases = new PurchaseOrderM();
                List<PurchaseOrderM> POD = new List<PurchaseOrderM>();
                List<PurchaseOrderM> STL = new List<PurchaseOrderM>();
                List<PurchaseOrderPaymentTerm> POC = new List<PurchaseOrderPaymentTerm>();

                DataSet set = new DataSet();
                set = DBManager.SetCustomerData(VendorID);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];
                dt4 = set.Tables[3];
                dt5 = set.Tables[4];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {

                        purchases.CurrencyID = Convert.ToInt32(row["CurrencyID"]);

                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {

                        purchases.ExchangeRate = Convert.ToDecimal(row["ExchangeRate"]);

                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        PurchaseOrderM orderD = new PurchaseOrderM();
                        orderD.No = Convert.ToInt32(row["No"]);
                        orderD.State = Convert.ToString(row["State"]);
                        orderD.State_ID = Convert.ToInt32(row["State_ID"]);
                        orderD.Location = Convert.ToString(row["Location"]);
                        orderD.GSTNO = Convert.ToString(row["GSTNO"]);
                        orderD.Address = Convert.ToString(row["Address"]);


                        POD.Add(orderD);

                    }
                }
                if (dt4 != null)
                {
                    foreach (DataRow row in dt4.Rows)
                    {
                        PurchaseOrderPaymentTerm orderC = new PurchaseOrderPaymentTerm();
                        orderC.PaymentTermID = Convert.ToInt32(row["PaymentTermID"]);
                        orderC.PaymentTerm = Convert.ToString(row["PaymentTerm"]);
                        orderC.IsDefault = Convert.ToBoolean(row["IsDefault"]);
                        POC.Add(orderC);
                    }
                }
                if (dt5 != null)
                {
                    foreach (DataRow row in dt5.Rows)
                    {
                        PurchaseOrderM orderD = new PurchaseOrderM();
                        orderD.No = Convert.ToInt32(row["No"]);
                        orderD.State = Convert.ToString(row["State"]);
                        orderD.State_ID = Convert.ToInt32(row["State_ID"]);
                        orderD.Location = Convert.ToString(row["Location"]);
                        orderD.GSTNO = Convert.ToString(row["GSTNO"]);
                        orderD.Address = Convert.ToString(row["Address"]);


                        STL.Add(orderD);

                    }
                }
                purchases.POBilling = POD;
                purchases.POShipping = STL;
                purchases.POPaymentTerm = POC;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IndentInfo> GetProjectList()
        {
            List<IndentInfo> EmployeeDL = new List<IndentInfo>();
            DataTable EmployeeDT = new DataTable();
            string Table = "ProjectMaster";
            string Column = "ProjectID,Project_Name";
            string Condition = " ISACTIVE=1";
            string OrderBy = "Project_Name";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    IndentInfo CustomerList = new IndentInfo();
                    CustomerList.ProjectID = Convert.ToInt32(row["ProjectID"]);
                    CustomerList.ProjectName = Convert.ToString(row["Project_Name"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }

        public List<IndentInfo> GetItemGroupList()
        {
            List<IndentInfo> EmployeeDL = new List<IndentInfo>();
            DataTable EmployeeDT = new DataTable();
            string Table = "ItemGroupM";
            string Column = "ItemGroup_ID,ItemGroup_Name";
            string Condition = " ItemGroup_ID IN (1,5)";
            string OrderBy = "ItemGroup_Code";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    IndentInfo CustomerList = new IndentInfo();
                    CustomerList.ItemGroup_ID = Convert.ToInt32(row["ItemGroup_ID"]);
                    CustomerList.ItemGroup_Name = Convert.ToString(row["ItemGroup_Name"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }
        public List<CurrencyCodeInfo> GetCurrencyList()
        {
            List<CurrencyCodeInfo> CurrencyList = new List<CurrencyCodeInfo>();
            DataTable CurrencyDL = new DataTable();

            CurrencyDL = BTdatamanager.CurrencyCodeList();

            if (CurrencyDL != null)
            {
                foreach (DataRow row in CurrencyDL.Rows)
                {
                    CurrencyCodeInfo CurrencyDataList = new CurrencyCodeInfo();

                    CurrencyDataList.ID = Convert.ToInt32(row["currency_ID"]);
                    CurrencyDataList.CurrencyCode = Convert.ToString(row["currencycode"]);

                    CurrencyList.Add(CurrencyDataList);
                }

            }
            return CurrencyList;
        }

        public List<ModeOfShipment> GetModeOfShipment()
        {
            List<ModeOfShipment> CurrencyList = new List<ModeOfShipment>();
            DataTable CurrencyDL = new DataTable();

            CurrencyDL = BTdatamanager.GetModeOfShipment();

            if (CurrencyDL != null)
            {
                foreach (DataRow row in CurrencyDL.Rows)
                {
                    ModeOfShipment CurrencyDataList = new ModeOfShipment();

                    CurrencyDataList.ModeID = Convert.ToInt32(row["ModeID"]);
                    CurrencyDataList.ModeName = Convert.ToString(row["ModeName"]);

                    CurrencyList.Add(CurrencyDataList);
                }

            }
            return CurrencyList;
        }
        public List<IndentInfo> GetCategoryMasterList()
        {
            List<IndentInfo> EmployeeDL = new List<IndentInfo>();
            DataTable EmployeeDT = new DataTable();
            string Table = "SubCategory1M";
            string Column = "EntryID as [SubCategoryID1], RTRIM(Code) + SPACE(8-(LEN(Code))) + ''-'' + SPACE(5) + LTRIM(Name) AS [SubCategory1]";
            string Condition = "";
            string OrderBy = " name";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    IndentInfo CustomerList = new IndentInfo();
                    CustomerList.SubCategoryID = Convert.ToInt32(row["SubCategoryID1"]);
                    CustomerList.SubCategoryName = Convert.ToString(row["SubCategory1"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }
        public List<IndentInfo> GetSubCategoryMasterList()
        {
            List<IndentInfo> EmployeeDL = new List<IndentInfo>();
            DataTable EmployeeDT = new DataTable();
            string Table = "SubCategory2M";
            string Column = "EntryID as [SubCategoryID1], RTRIM(Code) + SPACE(8-(LEN(Code))) + ''-'' + SPACE(5) + LTRIM(Name) AS [SubCategory1]";
            string Condition = "";
            string OrderBy = " name";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    IndentInfo CustomerList = new IndentInfo();
                    CustomerList.SubCategoryID = Convert.ToInt32(row["SubCategoryID1"]);
                    CustomerList.SubCategoryName = Convert.ToString(row["SubCategory1"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }

        //// 04-09-23
        public List<PurchaseOrderD> GetFreightListAgainstDCNO(DataTable dtWONO)
        {
            List<PurchaseOrderD> OpenGRNList = new List<PurchaseOrderD>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DBManager.GetFreightListAgainstDCNO(dtWONO);
            List<PurchaseOrderD> enqBL = new List<PurchaseOrderD>();
            if (OpenGRNDL != null)
            {
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    PurchaseOrderD OpenGRNData = new PurchaseOrderD();
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    //OpenGRNData.ItemCode = Convert.ToString(row["ItemCode"]);
                    OpenGRNData.ChargeID = Convert.ToInt32(row["ChargeID"]);
                    OpenGRNData.ChargeName = Convert.ToString(row["ChargeName"]);
                    OpenGRNData.ChargeAmount = Convert.ToDecimal(row["ChargeAmount"]);
                    
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }


        //// 27-09-23

        public ResponseMessage updateDCMasterFlagToZero(DataTable dtWONO , int UserID)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                DataTable dt = new DataTable();
                dt = DBManager.updateDCMasterFlagToZero(dtWONO, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        public ResponseMessage updateDCMasterFlag(string DCNO , int UserID)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                DataTable dt = new DataTable();
                dt = DBManager.updateDCMasterFlag(DCNO, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public List<ModeOfShipment> GetPODMasterSummary()
        {
            try
            {
                List<ModeOfShipment> list = new List<ModeOfShipment>();
                DataTable dt = new DataTable();
                dt = DBManager.GetPODMasterSummary();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeOfShipment data = new ModeOfShipment();
                        data.PODID = Convert.ToInt32(row["PODID"]);
                        data.PODName = Convert.ToString(row["PODName"]);
                       
                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage AjaxAddOrEdit(string PODName, int AddedBy)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DBManager.AjaxAddOrEdit(PODName,  AddedBy);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
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
