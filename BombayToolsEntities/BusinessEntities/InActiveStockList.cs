using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class InActiveStockList
    {
        public InActiveStockList()
        {
            InActiveStock_List = new List<InActiveStock>();
        }
        public string[] ColumnName { get; set; }
        public List<InActiveStock> InActiveStock_List { get; set; }
        public decimal TotalPCs { get; set; }
        public decimal TotalSQM { get; set; }
        public decimal TotalAmount { get; set; }
        public int Count { get; set; }


    }
}
