using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SupplierBillM
    {
        public string VendorAddress;

        public int SrNo { get; set; }

        public int TermID { get; set; }
        public string Term { get; set; }
        public int PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }
        public int FreightID { get; set; }
        public string FreightName { get; set; }
        public int MakeID { get; set; }
        public string Make { get; set; }
        public string GRNNo { get; set; }
        public string BillNo { get; set; }
        public string ChallanNo { get; set; }
        public int GRNID { get; set; }
        public int GSTID { get; set; }
        public string GSTNo { get; set; }
        public int State_Code { get; set; }
        public int Con_State_Code { get; set; }
        public int GSTPer { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string ItemCode { get; set; }
        public string HSNCodeName { get; set; }
        public string ExpenseHeadName { get; set; }
        public string ItemId { get; set; }
        public decimal ReceivedQTY { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal AmountAD { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AditionalDiscount { get; set; }
        public decimal AditionalDiscountAmount { get; set; }
        public string RemarkD { get; set; }
        public int RateFlag { get; set; }
        public int AddedBy { get; set; }
        public string SupplierBillNo { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal FreightTotal { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal AmountBeforeAditionalDiscount { get; set; }
        public decimal BeforeRoundGrandTotal { get; set; }
        public decimal RoundDifference { get; set; }
        public string success { get; set; }
        public DateTime SupplierBillDate { get; set; }
        public int SupplierID { get; set; }
        public string Status { get; set; }
        public int BillForID { get; set; }
        public int PayToID { get; set; }
        public DateTime BillDate { get; set; }
        public int PartyGSTID { get; set; }
        public string VendorName { get; set; }
        public string ReferenceNo { get; set; }
        public string SupplierBillDisplayDate { get; set; }
        public int SupplierBillID { get; set; }
        public int GstPercentage { get; set; }
        public string PayToVendorName { get; set; }
        public string CompanyName { get; set; }
        public string BillDisplayDate { get; set; }
        public string GRNDate { get; set; }
        public decimal GSTPercent { get; set; }
        public decimal CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal CGSTRate { get; set; }
        public decimal SGSTRate { get; set; }
        public decimal IGSTRate { get; set; }


        public string TallyLedgerName { get; set; }
        public string ALTERID { get; set; }
        public string GUID { get; set; }
        public string MASTERID { get; set; }
        public string REMOTEID { get; set; }
        public string VCHKEY { get; set; }
        public string VOUCHERKEY { get; set; }
        public string AddedByName { get; set; }
        public string Currency { get; set; }
    }
}
