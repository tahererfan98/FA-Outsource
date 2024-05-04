using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Zone
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public bool IsNew { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public bool IsCancelled { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public int IsActive { get; set; }

        public string State { get; set; }
        public int ZoneCount { get; set; }
        //public string Company { get; set; }
        public int SrNo { get; set; }
    }
}
