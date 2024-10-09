using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SOTimeline
    {
        public int SalesOrderID { get; set; }
        public int SalesPipelineID { get; set; }
        public string SalesOrderNo { get; set; }
        public string SONo { get; set; }
        public string DisplayAddedOn { get; set; }
        public string AddedByName { get; set; }
        public string Status { get; set; } 

    }
}
