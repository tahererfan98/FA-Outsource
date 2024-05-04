using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class GRNInfo
    {
        public int GRNID { get; set; }
        public string GRNNo { get; set; }
        public string WorkYear { get; set; }
        public string success { get; set; }
        public int SrNo { get; set; }
        public int POID { get; set; }
        public string PONo { get; set; }
        public string ManualPONo { get; set; }
        public string ItemId { get; set; }
        public string ItemCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal BeforeEdit_QTY { get; set; }
        public decimal Qty { get; set; }

        public decimal ReceivedQTY { get; set; }
        public int OfficeID { get; set; }
        public int SupplierID { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyID { get; set; }
        public string ChallanNo { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int PaymentModeID { get; set; }
        public DateTime CBDate { get; set; }
        public int CopyFrom { get; set; }
        public DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public int IsActive { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public DateTime DOE { get; set; }

        public int RevisionNo { get; set; }
        public int ReceivedBy { get; set; }
        public string Remark { get; set; }
        public int ItemGroup { get; set; }

        public decimal Amount { get; set; }
        public int EditMode { get; set; }
        public int GSTPer { get; set; }
        public decimal GSTAmount { get; set; }
        public int GSTID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceQty { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string SearchCriteria { get; set; }
        public string Search { get; set; }

        public int Vendor_ID { get; set; }
        public string Vendor_Name { get; set; }

        public int LocationID { get; set; }
        public decimal AlreadyReceivedQty { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal BasicAmount { get; set; }

        public string Currency_Name { get; set; }

        public string DeliveryLocation { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal GstPercent { get; set; }

        public string GRNDisplayDate { get; set; }

        public string GRNDisplayCBDate { get; set; }



        public decimal DiscountPer { get; set; }
        public decimal DiscountAmount { get; set; }

        public decimal AmountAD { get; set; }
        public string RemarkD { get; set; }


        public string GRNDate { get; set; }

        public string vendorName { get; set; }
        public int MakeID { get; set; }
        public string SerialNo { get; set; }
        public int FreightID { get; set; }
        public string FreightName { get; set; }
        public string Make { get; set; }
        public decimal FreightAmount { get; set; }

        public int CancelledBy { get; set; }
        public string CancelledFor { get; set; }

        public decimal FixedBalanceQty { get; set; }
        public decimal FreightTotal { get; set; }

        public string UserName { get; set; }

        public DateTime SupplierBillDate { get; set; }
        public string SupplierBillNo { get; set; }
        public string SupplierBillDisplayDate { get; set; }

        public string ItemGroupName { get; set; }
        public string RackName { get; set; }

        public string message { get; set; }
        public decimal AditionalDiscount { get; set; }
        public decimal AditionalDiscountAmount { get; set; }
        public string Status { get; set; }
        public decimal AmountBeforeAditionalDiscount { get; set; }
        public int RateFlag { get; set; }
        public string StorePlace { get; set; }
        public string WareHouseName { get; set; }
        public int BillForID { get; set; }
        public int PayToID { get; set; }
        public Boolean Add { get; set; }
        public Boolean Edit { get; set; }
        public Boolean Cancel { get; set; }
        public Boolean View { get; set; }
        public Boolean Print { get; set; }
        public int GRNSrNo { get; set; }
        public string GRNSerialNo { get; set; }
        public string GRNEqType { get; set; }
        public string GRNEqTypeName { get; set; }
        public string GRNMakeID { get; set; }
        public string GRNWarrantyFrom { get; set; }

        public string GRNWarrantyTo { get; set; }

        public int GRNMileage { get; set; }
        public string GRNMakeName { get; set; }
        public string HSNCodeName { get; set; }
        public string ExpenseHeadName { get; set; }
        public string Manufacture { get; set; }
        public string PartNo { get; set; }
    }
}
