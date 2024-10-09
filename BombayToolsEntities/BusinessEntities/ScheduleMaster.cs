using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ScheduleMaster
    {
        public int SrNo { get; set; }
        public int ScheduleID { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDays { get; set; }
        public string ManualScheduleDate { get; set; }
    }
}
