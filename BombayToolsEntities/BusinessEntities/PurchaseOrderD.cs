using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PurchaseOrderD
    {
        public int POID { get; set; }
        public string PONO { get; set; }
        public int ItemID { get; set; }
        public int OrderNo { get; set; }
        public int RunningNo { get; set; }
        public int SrNo { get; set; }
        public int index { get; set; }
        public string ItemDescription { get; set; }
        public string PartNo { get; set; }
        public string Manufacture { get; set; }
        public decimal Rate { get; set; }
        public decimal LastPurchase { get; set; }
        public int QTY { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public int InStock { get; set; }   // For count
        public int PendingPO { get; set; }   // For count
        public int PendingSO { get; set; }   // For count
        public int TotalItem { get; set; }   // For count
        public string Unit { get; set; }
        public string Status { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string IGST { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public int PrintQTY { get; set; }  // for Print
        public string CurrencyCode { get; set; }  // for Print
        public decimal ExchangeRate { get; set; }  // for Print

        //For Export Invoice
        public int ChargeID { get; set; }
        public string ChargeName { get; set; }
        public decimal ChargeAmount { get; set; }
        public string ItemCode { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
    }
}
