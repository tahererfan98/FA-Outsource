using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class IndentD
    {

        public int SrNo { get; set; }
        public int IndentID { get; set; }
        public string IndentNo { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public string PartNo { get; set; }
        public string Manufacture { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public int IndentQTY { get; set; }
        public decimal AlreadyReceivedQty { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal FixedBalanceQty { get; set; }
        public decimal Discount { get; set; }
        public decimal SQM { get; set; }
        public decimal GST { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public int InStock { get; set; }   // For count
        public string Unit { get; set; }
        public string RequiredDate { get; set; }
        public string ItemCode { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Type { get; set; }
        public string WarehouseName { get; set; }
        public string Remarks { get; set; }
        public string ProjectName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string IndentDate { get; set; }
        public int ProjectID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int SheetPerCase { get; set; }
        public int NoOfCase { get; set; }
    }
}
