using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesPersonWeeklyCount
    {
        public int Index { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int EnqTotal { get; set; }
        public int EnqOpen { get; set; }
        public int EnqClose { get; set; }
        public int QuotTotal { get; set; }
        public int QuotOpen { get; set; }
        public int QuotClose { get; set; }
        public string Amount { get; set; }
    }
}
