using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaxInvoiceM
    {
        public int SrNo { get; set; }
        public int TaxInvoiceID { get; set; }
        public string LastTINo { get; set; }
        public string TaxInvoiceNo { get; set; }
        public string TINo { get; set; }
        public DateTime TaxInvoiceDate { get; set; }
        public string DisplayTaxInvoiceDate { get; set; }
        public int DeliveryChallanID { get; set; }
        public string DCNo { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime SalesOrderDate { get; set; }
        public string DisplaySalesOrderDate { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public string DisplayDeliveryChallanDate { get; set; }
        public string SONo { get; set; }
        public string SalesOrderNo { get; set; }
        public int ContactPersonID { get; set; }
        public int CompanyID { get; set; }
        public string VendorCode { get; set; }
        public string Vertical { get; set; }
        public string ContactPersonName { get; set; }
        public string BillingStateName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingLocation { get; set; }
        public string ShippingLocation { get; set; }
        public int BillingLocationID { get; set; }
        public int ShippingLocationID { get; set; }
        public string ContactNo { get; set; }
        public string ContactNo2 { get; set; }
        public string DLEmailID { get; set; }
        public string EmailID { get; set; }
        public string PinCodeBill { get; set; }
        public string PinCodeDelivery { get; set; }
        public string ConsigneeAddress { get; set; }
        public int DeliveryStateID { get; set; }
        public string DelCompanyName { get; set; }
        public string DeliveryStateName { get; set; }
        public string GSTNO { get; set; }
        public string ContactDelivery1 { get; set; }
        public string ContactDelivery2 { get; set; }
        public int BillingStateID { get; set; }
        public int BillForID { get; set; }
        public string BillFor { get; set; }
        public string PaymentType { get; set; }
        public string AdvanceDetails { get; set; }
        public string CreditDays { get; set; }
        public string Remarks { get; set; }
        public string DeliveryPeriod { get; set; }
        public string DeliveryInstructions { get; set; }
        public string INCOTerms { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal NetTotal { get; set; }
        public decimal IGST_M { get; set; }
        public decimal CGST_M { get; set; }
        public decimal SGST_M { get; set; }
        public int IsEwayBillGenerate { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
        public string AddedByName { get; set; }
        public string DisplayAddedOn { get; set; }
        public int CancelledBy { get; set; }
        public string CancelledFor { get; set; }


    }
}
