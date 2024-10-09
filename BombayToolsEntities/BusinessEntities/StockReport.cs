using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class StockReport
    {
        public int SrNo { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string PartNo { get; set; }
        public string CategoryName { get; set; }
        public string VerticalName { get; set; }
        public string Vertical { get; set; }
        public int VerticalID { get; set; }
        public int CategoryID { get; set; }
        public int OpeningBalance { get; set; }
        public int Instock { get; set; }
        public int PendingPO { get; set; }
        public int SODue { get; set; }
        public int NetAvailable { get; set; }
        public int StockInwards { get; set; }
        public int StockOutwards { get; set; }
        public int StockAvailable { get; set; }
        public int ClosingBalance { get; set; }
        public int OUT_QTY { get; set; }
        public int Opening_QTY { get; set; }
        public int IN_QTY { get; set; }
        public int ReorderLevel { get; set; }
        public int MinReorder { get; set; }
        public int ShortFall { get; set; }
        public int Closing_QTY { get; set; }
        public decimal Opening_Rate { get; set; }
        public decimal Opening_Amount { get; set; }
        public decimal IN_RATE { get; set; }
        public decimal IN_Amount { get; set; }
        public decimal OUT_RATE { get; set; }
        public decimal OUT_Amount { get; set; }
        public decimal Closing_Rate { get; set; }
        public decimal Closing_Amount { get; set; }
        public int Consumption { get; set; }
        public decimal GrossProfit { get; set; }
        public int ProfitPercent { get; set; } 

    }
}
