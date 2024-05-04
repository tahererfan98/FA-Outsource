using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class FullQuotation
    {
        public FullQuotation()
        {
            ItemList = new List<ItemList>();
        }
        public SalesPipeline pipeline { get; set; }
        public List<ItemList> ItemList { get; set; }
        public SalesCoordinator Sales { get; set; }
    }
}
