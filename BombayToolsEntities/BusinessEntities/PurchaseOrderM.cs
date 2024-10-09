using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PurchaseOrderM
    {
        public PurchaseOrderM()
        {
            POItem = new List<PurchaseOrderD>();
            POCondition = new List<PurchaseOrderConditions>();
        }
        public int POID { get; set; }
        public int IsDraft { get; set; }
        public int VerticalID { get; set; }
        public int CategoryID { get; set; }
        public decimal Qty { get; set; }
        public string PONO { get; set; }
        public string VerticalName { get; set; } 
        public string CategoryName { get; set; }
        public string ManualPONo { get; set; } 
        public DateTime PODate { get; set; } 
        public string Vertical { get; set; } 
        public string Company { get; set; }
        public string AddedByName { get; set; }
        public string Status { get; set; }
        public string DisplayPODate { get; set; }
        public string QuotationNo { get; set; }
        public int VendorID { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal ExchangeRate { get; set; }
        public int CurrencyID { get; set; }
        public int AddedBy { get; set; }
        public string AddedName { get; set; }
        public DateTime AddedOn { get; set; }
        public int IsGRNMade { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string VendorName { get; set; }
        public string PODisplayDate { get; set; }
        public string DisplayDate { get; set; }
        public string DT_RowClass { get; set; }
        public List<PurchaseOrderD> POItem { get; set; }
        public List<PurchaseOrderConditions> POCondition { get; set; }
        public string Symbol { get; set; }
        public string CurrencyCode { get; set; }
        public string PanNO { get; set; }
        public string GSTNO { get; set; }
        public string State { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TallyLedgerName { get; set; }
        public string ALTERID { get; set; }
        public string GUID { get; set; }
        public string MASTERID { get; set; }
        public string REMOTEID { get; set; }
        public string VCHKEY { get; set; }
        public string VOUCHERKEY { get; set; }

        //Added For ExportInvoice
        public string UserName { get; set; }
        public int DeliveryAddressID { get; set; }
        public string DeliveryAddress { get; set; }
        public string Vendor_Address { get; set; }
        public string ApprovedRemarks { get; set; }
        public int postatus { get; set; }
        public int SrNo { get; set; }
        public int StatusID { get; set; }
        public string PendingDay { get; set; }
        public string Received { get; set; }
        public string GRNNo { get; set; }
        public string ItemName { get; set; }
        public decimal GrnQty { get; set; }
        public int No { get; set; }
        public int State_ID { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public List<PurchaseOrderM> POBilling { get; set; }
        public List<PurchaseOrderM> POShipping { get; set; }
        public List<PurchaseOrderPaymentTerm> POPaymentTerm { get; set; }
        public string POType { get; set; }
    }
}
