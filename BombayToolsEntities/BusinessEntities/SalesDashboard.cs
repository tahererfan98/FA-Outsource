using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesDashboard
    {
        public SalesDashboard()
        {
            Graph = new List<GraphData>();
        }
        public int QUOTATIONCOUNT { get; set; }
        public int LEADCOUNT { get; set; }
        public int OPPORTUNITYCOUNT { get; set; }
        public int ORDERCLOSEDCOUNT { get; set; }
        public int QUOTATIONAMOUNT { get; set; }
        public int LEADAMOUNT { get; set; }
        public int OPPORTUNITYAMOUNT { get; set; }
        public int ORDERCLOSEDAMOUNT { get; set; }
        public List<GraphData> Graph { get; set; }

    }
}
