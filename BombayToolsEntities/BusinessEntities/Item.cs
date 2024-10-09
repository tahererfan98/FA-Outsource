using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Item
    {
        public int SrNo { get; set; }
        public int SetID { get; set; }
        public int CancelledBy { get; set; }
        public int TransID { get; set; }
        public int OpeningStock { get; set; }
        public int OpeningID { get; set; }
        public int YearDate { get; set; }
        public int POID { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public int isCopy { get; set; }
        public int SalesOrderID { get; set; }
        public string ManualPONo { get; set; }
        public string PONo { get; set; }
        public string SalesOrderNo { get; set; }
        public string OpeningNo { get; set; }
        public string ItemDesc { get; set; }
        public string ItemDescription { get; set; }
        public string ItemNote { get; set; }
        public string SOItemNote { get; set; }
        public string DCItemNote { get; set; }
        public string TIItemNote { get; set; }
        public string HSNCode { get; set; }
        public string Unit { get; set; }
        public string Manufacture { get; set; }
        public string PartNo { get; set; }
        public DateTime PODate { get; set; }
        public DateTime SalesOrderDate { get; set; }
        public DateTime OpeningDate { get; set; }
        public string DisplayOpeningDate { get; set; }
        public int CategoryID { get; set; }
        public bool IsSynchronized { get; set; }
        public string CategoryName { get; set; }
        public string TallyName { get; set; }
        public bool IsNew { get; set; }
        public bool IsCancel { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public int QTY { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime CancelledOn { get; set; }
        public bool IsActive { get; set; } 
        public float CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }   // For count
        public int Pieces { get; set; }   // For count
        public int ItemType { get; set; }   // For count
        public int InStock { get; set; }   // For count
        public int PendingPO { get; set; }   // For count
        public int PO_QTY { get; set; }   // For count
        public int Pending { get; set; }   // For count
        public int SO_QTY { get; set; }   // For count
        public int Availability { get; set; }   // For count
        public int PendingSO { get; set; }   // For count
        public int OrderNo { get; set; }   // For count
        public int RunningNo { get; set; }   // For count
        public int VerticalID { get; set; }   // For count
        public int GST { get; set; }   // For count
        public int TotalItem { get; set; }   // For count
        public decimal GSTAmount { get; set; }   // For count
        public decimal Discount { get; set; }   // For count
        public decimal DiscountAmount { get; set; }   // For count
        public decimal AmountAD { get; set; }   // For count
        public decimal NetTotal { get; set; }   // For count
        public decimal FinalTotal { get; set; }   // For count
        public decimal GSTPer { get; set; }   // For count
        public decimal LastPurchase { get; set; }
        public string DT_RowClass { get; set; }

        //For TagID CheckBox
        public string MergeItemListID { get; set; }
        public string TagID { get; set; }
        public string TagName { get; set; }
        public bool isChecked { get; set; }
        public int IsMergedItem { get; set; }
        public string responsemessage { get; set; }
        public string checkedItemMergeID { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string WarehouseName { get; set; }
        /// ////////////////////////  05-03-23
        public decimal Thickness { get; set; }
    }

}
