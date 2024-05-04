using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AdminDashboardCount
    {
        public AdminDashboardCount()
        {
            DailyQuot = new List<DailyQuotationCount>();
            PipelineCount = new List<DailyQuotationCount>();
        }
        public int Principal { get; set; }
        public int Sector { get; set; }
        public int Industry { get; set; }
        public int Company { get; set; }
        public List<DailyQuotationCount> DailyQuot { get; set; }
        public List<DailyQuotationCount> PipelineCount { get; set; }

    }
}
