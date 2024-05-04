using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ItemList
    {
        public string Remark { get; set; }
        public int SrNo { get; set; }
        public int index { get; set; }
        public int SetID { get; set; }
        public int Pieces { get; set; }
        public int QuotationID { get; set; }
        public int RevNO { get; set; }
        public int ItemID { get; set; }
        public int QTY { get; set; }
        public int UnitID { get; set; }
        public decimal SetPrice { get; set; }
        public decimal Rate { get; set; }
        public decimal RevisiedSP { get; set; }
        public decimal Amount { get; set; }

        // get
        public string Symbol { get; set; }
        public string SetUnit { get; set; } //Item Notes
        public string ItemNote { get; set; } //Item Notes
        public string ItemDesc { get; set; } //Item Name
        public string SetName { get; set; } //Item Name
        public string Unit { get; set; }
        public string Manufacture { get; set; }
        public string HSNCode { get; set; }
        public string OtherChargeDesc { get; set; }
        public decimal Discount { get; set; }
        public string PartNo { get; set; }
        public int CategoryID { get; set; }
        public string CategoryDesc { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FreightPercent { get; set; }
        public decimal PackingPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal PackingAmount { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal OtherCharges { get; set; }
        public string SetItemNote { get; set; }
        public string SetPartNo { get; set; }
        public string SetSellingPrice { get; set; }
        public string SetItemName { get; set; }

        public double Total { get; set; }


        //Display data
        public string DisplayRateAmount { get; set; }
        public string DisplayAmount { get; set; }
        public string DisplayDiscountAmount { get; set; }
        public string DisplayFreightAmount { get; set; }
        public string DisplayPackingAmount { get; set; }
        public string DisplayGSTAmount { get; set; }
        public string DisplayOtherChargesAmount { get; set; }
        public string DisplayTotalAmount { get; set; }

        //temp
        public string ExGodown { get; set; }
        public string Freight { get; set; }
        public string Packing { get; set; }
        
        public string Payment { get; set; }
        public string Taxes { get; set; }
        public string Warranty { get; set; }
        public string Delivery { get; set; }
        public string ItemRemark { get; set; }
        public string TallyName { get; set; }
        public float CostPrice { get; set; }
        public float SellingPrice { get; set; }

        //For TagID CheckBox
        public string MergeItemListID { get; set; }
        public string TagID { get; set; }
        public string TagName { get; set; }
        public bool isChecked { get; set; }
        public int IsMergedItem { get; set; }
        public string responsemessage { get; set; }
        public string checkedItemMergeID { get; set; }

        //Export Invoice
        public string GRNNo { get; set; }
        public string PONo { get; set; }
        public string ItemDescription { get; set; }
        public string PurchaseDate { get; set; }
        public string VendorName { get; set; }
        public string ItemCode { get; set; }
        public string ItemQty { get; set; }
        public string NetAmount { get; set; }
        public string GrandTotal { get; set; }
    }
}
