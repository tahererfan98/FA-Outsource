using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Principal
    {
        public int PrincipalID { get; set; }
        public string PrincipalName { get; set; }

        public bool IsNew { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public bool IsCancelled { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsActive { get; set; }

        public int PrincipalCount { get; set; }
        public string Company { get; set; }
        public int SrNo { get; set; }
    }
}
