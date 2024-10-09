using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TransportM
    {
        public int AutoID { get; set; }
        public int SrNo { get; set; }
        public int TransID { get; set; }
        public int TransModeID { get; set; }
        public decimal TransDistance { get; set; }
        public string TransporterName { get; set; }
        public string TransporterID { get; set; }
        public string TransDocNo { get; set; }
        public string AddedByName { get; set; }
        public string TransModeName { get; set; }
        public string DisplayTransDocDate { get; set; }
        public string DisplayAddedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime TransDocDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }

    }
}
