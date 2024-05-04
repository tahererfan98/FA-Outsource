using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ExportInvoiceM
    {
        public ExportInvoiceM()
        {
            POItem = new List<ExportInvoiceD>();
            POBilling = new List<ExportInvoiceM>();
            POCharges = new List<ExportInvoiceCharges>();
            POPacking = new List<ExportInvoicePacking>();
            PackingList = new List<ExportInvoiceD>();
            PackingTotal = new List<ExportInvoiceD>();

        }

        public int POID { get; set; }
        public int No { get; set; }
        public int IsDraft { get; set; }
        public int RevisionNo { get; set; }
        public string WorkYear { get; set; }
        public string POType { get; set; }
        public string CopyFrom { get; set; }
        public string ChallanNo { get; set; }
        public string IndentNo { get; set; }
        public string OtherPTRemark { get; set; }
        public DateTime DOE { get; set; }
        public DateTime CBDate { get; set; }
        public string QuotationNo { get; set; }
        public int VendorID { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal GRNRate { get; set; }
        public int TransporterID { get; set; }
        public int DeliveryAddressID { get; set; }
        public string DeliveryAddress { get; set; }
        public string Vendor_Address { get; set; }
        public string VehicleNo { get; set; }
        public int CurrencyID { get; set; }
        public int AddedBy { get; set; }
        public string AddedName { get; set; }
        public DateTime AddedOn { get; set; }
        public int IsApproved { get; set; }
        public int IsGRNMade { get; set; }
        public int IsGRNPVMade { get; set; }
        public int ApprovedBy { get; set; }
        public int IsForwarding { get; set; }
        public string ApprovedByName { get; set; }
        public string UserType { get; set; }
        public string AddedByName { get; set; }
        public string ApprovedRemarks { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string VendorName { get; set; }
        public string PODisplayDate { get; set; }
        public string DisplayDate { get; set; }
        public string DT_RowClass { get; set; }
        public List<ExportInvoiceCharges> POCharges { get; set; }
        public List<ExportInvoicePacking> POPacking { get; set; }
        public List<ExportInvoiceM> POBilling { get; set; }
        public List<ExportInvoiceD> POItem { get; set; }
        public List<ExportInvoiceD> PackingTotal { get; set; }
        public List<ExportInvoiceD> PackingList { get; set; }
        public List<ExportInvoicePacking> POCondition { get; set; }
        public List<PurchaseOrderPaymentTerm> POPaymentTerm { get; set; }
        public string Symbol { get; set; }
        public string CurrencyCode { get; set; }
        public string Currency_Name { get; set; }
        public string PanNO { get; set; }
        public string GSTNO { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public int State_ID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TallyLedgerName { get; set; }
        public string ALTERID { get; set; }
        public string GUID { get; set; }
        public string MASTERID { get; set; }
        public string REMOTEID { get; set; }
        public string VCHKEY { get; set; }
        public string VOUCHERKEY { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public int SrNo { get; set; }
        public int postatus { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string GRNNo { get; set; }
        public string PendingDay { get; set; }
        public string Received { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal GrnQty { get; set; }

        //07-08-2021
        public string BillToLocation { get; set; }
        public string BillToAddress { get; set; }
        public string ShipToLocation { get; set; }
        public string ShipToAddress { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchCriteria { get; set; }
        public string Search { get; set; }
        public string ItemGroup_Name { get; set; }
        public int ItemGroup_ID { get; set; }
        public int BillingLocationID { get; set; }
        public int ShippingLocationID { get; set; }
        public int BillingStateID { get; set; }
        public int ShippingStateID { get; set; }
        public int GRNID { get; set; }
        public int IsCancel { get; set; }
        public int IsPOClosed { get; set; }
        public int IsClosed { get; set; }
        public string BillingState { get; set; }
        public string ShippingState { get; set; }
        public string ShipToGST { get; set; }
        public string BillToGST { get; set; }
        public string Remarks { get; set; }
        public string GRNRemarks { get; set; }
        public decimal TotalQty { get; set; }
        public string SecondHeading { get; set; }
        public decimal POCount { get; set; }
        public decimal OtherChargeCount { get; set; }
        public decimal POPackingCount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal TotalGSTAmount { get; set; }
        public string DisplayTotalAmt { get; set; }
        public decimal TCSAmount { get; set; }
        public decimal OverallDiscAmt { get; set; }
        public string DisplayBasicAmount { get; set; }
        public string DisplayDiscountAmount { get; set; }
        public string CurSym { get; set; }
        public string DisplayTotAfterDiscAmt { get; set; }
        public string DisplayTCSAmount { get; set; }
        public string DisplayTotalGSTAmount { get; set; }
        public string DisplayTotalCGSTAmount { get; set; }
        public string DisplayTotalOtherChargeAmt { get; set; }
        public string DisplayGrandTotal { get; set; }
        public string AmountInWord { get; set; }
        public decimal CGSTPer { get; set; }
        public decimal SGSTPer { get; set; }
        public decimal IGSTPer { get; set; }
        public decimal TotalSQM { get; set; }
        public decimal FinalTotalBeforeCharges { get; set; }
        public decimal TotalSheetPerCase { get; set; }
        public decimal TotalNoOfCase { get; set; }
        public decimal TotalFreightCharges { get; set; }
        public string PINNo { get; set; }
        public decimal TotalDiscPer { get; set; }
        public decimal TotAfterDiscAmt { get; set; }
        public decimal TotChrgAmt { get; set; }
        public decimal TotChrgAmtPer { get; set; }
        public decimal TotChrgAmtAfterGST { get; set; }
        public decimal TotBeforeTCS { get; set; }
        public decimal TotTCSPer { get; set; }
        public decimal TotAfterTCS { get; set; }
        public decimal GSTAmount { get; set; }
        public string ContPerson { get; set; }
        public string ContactNo { get; set; }
        public string Telephone_1 { get; set; }
        public string Telephone_2 { get; set; }
        public string ReferenceNo { get; set; }
        public string DeliveryDate { get; set; }
        public string GRNType { get; set; }

        //New
        public int EXID { get; set; }
        public string EXINO { get; set; }
        public string EXIDate { get; set; }
        public string DSDate { get; set; }
        public string EXIType { get; set; }
        public string PONO { get; set; }
        public string PODate { get; set; }
        public string LCNO { get; set; }
        public string LCDate { get; set; }
        public string Customer { get; set; }
        public string Cont_Person { get; set; }
        public string Cust_Email { get; set; }
        public string PreCarriageBy { get; set; }
        public string PlaceOfReceipt { get; set; }
        public string VesselNo { get; set; }
        public string ContainerNo { get; set; }
        public string Others { get; set; }
        public string ExportBenefit { get; set; }
        public int ModeOfShipment { get; set; }
        public string Mode { get; set; }
        public int ShipmentTermID { get; set; }
        public string ShipmentTerm { get; set; }
        public string PaymentTerm { get; set; }
        public int CustomerID { get; set; }
        public int PODID { get; set; }
        public string POD { get; set; }
        public int StatusID { get; set; }
        public int LicenseID { get; set; }
        public string LicenseNo { get; set; }
        public string PortOfLoading { get; set; }
        public string CountryOfOrigin { get; set; }
        public string SealNo { get; set; }
        public string CustRefNo { get; set; }
        public string FinalDestination { get; set; }
        public string DCNO { get; set; }
        public string PINO { get; set; }
        public string DNNO { get; set; }
        public string SaleUnit { get; set; }
        public string Project_Name { get; set; }
        public decimal ToatlQTY { get; set; }
        public decimal TotalSQFT { get; set; }
        public int IsINDPresent { get; set; }
        public int IsLC { get; set; }
        public decimal TotNetWeight { get; set; }
        public decimal TotGrossWeight { get; set; }

        public string Shipment { get; set; }
        public int ShipmentID { get; set; }


    }
}
