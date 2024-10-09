using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ImportOIS
    {

        public int SrNo { get; set; }
        public int SetID { get; set; }
        public int TransID { get; set; }
        public int OpeningStock { get; set; }
        public int OpeningID { get; set; }
        public int ItemID { get; set; }
        public int isCopy { get; set; }
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
        public string OpeningDate { get; set; }
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
        public bool IsActive { get; set; }
        public float CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }   // For count
        public int Pieces { get; set; }   // For count
        public int ItemType { get; set; }   // For count
        public int InStock { get; set; }   // For count
        public int PendingPO { get; set; }   // For count
        public int PendingSO { get; set; }   // For count
        public int TotalItem { get; set; }   // For count
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


    }
}
