using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesOrderM
    {
        public int SrNo { get; set; }
        public int AutoID { get; set; }
        public int SalesOrderID { get; set; }
        public int SalesPipelineID { get; set; }
        public int IsSOLinked { get; set; }
        public int IsLinkedToSP { get; set; }
        public int IsQuotAgainst { get; set; }
        public int IsLinked { get; set; }
        public string LinkedType { get; set; }
        public string ReqName { get; set; }
        public string SalesOrderNo { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string SONo { get; set; }
        public string DCNo { get; set; }
        public int CancelledBy { get; set; }
        public string CancelledFor { get; set; }
        public string LastSONo { get; set; }
        public int LedgerID { get; set; }
        public string LedgerName { get; set; }
        public string LedgerSection { get; set; }
        public int ContactPersonID { get; set; }
        public int CompanyID { get; set; }
        public string VendorCode { get; set; }
        public string Vertical { get; set; }
        public string ContactPersonName { get; set; }
        public string BillingStateName { get; set; }
        public string BillingAddress { get; set; } 
        public string BillingLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public string ShippingLocation { get; set; }
        public int DeliveryLocationID { get; set; }
        public int BillingLocationID { get; set; }
        public int ShippingLocationID { get; set; }
        public string ContactNo { get; set; }
        public string ContactNo2 { get; set; } 
        public string DelCompanyName { get; set; }
        public string EmailID { get; set; }
        public string DLEmailID { get; set; }
        public string PinCodeBill { get; set; } 
        public string PinCodeDelivery { get; set; }
        public string ConsigneeAddress { get; set; }
        public int DeliveryStateID { get; set; }
        public string DeliveryStateName { get; set; }
        public string ContactDelivery1 { get; set; }
        public string ContactDelivery2 { get; set; }

        public int BillingStateID { get; set; }
        public string Salutation { get; set; }

        public string GSTNO { get; set; }
        public DateTime SalesOrderDate { get; set; }
        public string DisplaySalesOrderDate { get; set; }
        public int BillForID { get; set; }
        public int CategoryID { get; set; }
        public int BoxID { get; set; }
        public int Qty { get; set; }
        public int VerticalID { get; set; }
        public string BillFor { get; set; }
        public string SOStatus { get; set; }
        public string PONO { get; set; }
        public DateTime PODate { get; set; }
        public string DisplayPODate { get; set; }
        public string PaymentType { get; set; }
        public string AdvanceDetails { get; set; }
        public string CreditDays { get; set; }
        public string INCOTerm { get; set; }
        public string DeliveryPeriod { get; set; }
        public string DeliveryInstruction { get; set; }
        public string Requirement { get; set; }
        public string QuotationNo { get; set; }
        public string Remarks { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal IGST_M { get; set; }
        public decimal CGST_M  { get; set; }
        public decimal SGST_M { get; set; }
        public decimal DealSize { get; set; }
        public decimal NetTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public int QuotID { get; set; }
        public int RevisionNo { get; set; } 
        public int SOQty { get; set; }
        public int DCQty { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string Status { get; set; }
        public string VerticalName { get; set; }
        public string CategoryName { get; set; }
        public string LinkToSP { get; set; }
        public string Type { get; set; }
        public string DT_RowClass { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string AddedByName { get; set; }
        public string DisplayAddedOn { get; set; }
    }
}
