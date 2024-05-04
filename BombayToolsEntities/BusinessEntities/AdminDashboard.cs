using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AdminDashboard
    {
        public AdminDashboard()
        {
            Count = new AdminDashboardCount();
            StreakDataList =new List<StreakData>();
        }
        public AdminDashboardCount Count { get; set; }
        public int PendingApproval { get; set; }
        public List<StreakData> StreakDataList { get; set; }
    }
}
