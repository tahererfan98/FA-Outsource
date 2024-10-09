using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaxInvoiceD
    {
        public int SrNo { get; set; }
        public int TaxInvoiceID { get; set; }
        public string TaxInvoiceNo { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string SalesOrderNo { get; set; }
        public int ItemID { get; set; }
        public string DataType { get; set; }
        public string TIItemNote { get; set; }
        public int SetItemID { get; set; }
        public int SetID { get; set; }
        public string ItemDescription { get; set; }
        public string ItemNote { get; set; }
        public string HSNCode { get; set; }
        public string Manufacture { get; set; }
        public string PartNo { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal RevisiedSP { get; set; }
        public decimal QTY { get; set; }
        public decimal BeforeEdit_QTY { get; set; }
        public decimal SO_QTY { get; set; }
        public decimal BAL_QTY { get; set; }
        public decimal BalancedQTY { get; set; }
        public decimal Actual_SO_QTY { get; set; }
        public decimal InStock { get; set; }
        public decimal NetTotal { get; set; }
        public decimal GSTID { get; set; }
        public decimal GST { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal IGST_D { get; set; }
        public decimal CGST_D { get; set; }
        public decimal SGST_D { get; set; } 
        public int OrderNo { get; set; }
        public decimal FinalTotal { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public string SetItemNote { get; set; }
        public string SetPartNo { get; set; }
        public string SetSellingPrice { get; set; }
        public string SetItemName { get; set; }
        public string TallyName { get; set; }
        public string SetUnit { get; set; }
        //For TagID CheckBox
        public string MergeItemListID { get; set; }
        public string TagID { get; set; }
        public string TagName { get; set; }
        public bool isChecked { get; set; }
        public int IsMergedItem { get; set; }
        public string responsemessage { get; set; }
        public string checkedItemMergeID { get; set; }
        public int CancelledBy { get; set; }
        public string CancelledFor { get; set; }

    }
}
