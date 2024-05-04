using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesPersonDashboard
    {
        public SalesPersonDashboard()
        {
            EnquiryList = new List<EnquiryList>();
            SaleReport = new List<SalesPersonWeeklyCount>();
            StreakDataList = new List<StreakData>();
        }
        public List<EnquiryList> EnquiryList { get; set; }
        public List<SalesPersonWeeklyCount> SaleReport { get; set; }
        public int OpenEnquiry { get; set; }
        public int OpenQuotation { get; set; }
        public List<StreakData> StreakDataList { get; set; }
    }
}
