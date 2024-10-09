using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SOPipelineM
    {
        public SOPipelineM()
        {
            master = new SalesOrderM();
            SalesPipeline = new SalesPipeline();
            SOTimeline = new List<SOTimeline>();

        }
        public SalesOrderM master { get; set; }
        public SalesPipeline SalesPipeline { get; set; }
        public List<SOTimeline> SOTimeline { get; set; }

    }
}
