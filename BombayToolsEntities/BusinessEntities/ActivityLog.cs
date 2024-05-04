using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ActivityLog
    {
        public int SrNo { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ActivityName { get; set; }
        public string Activity { get; set; }
        public string UserName { get; set; }
        public string ActivityDate { get; set; }
        public DateTime Date { get; set; }
        public string ActivityDesc { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
    }
}
