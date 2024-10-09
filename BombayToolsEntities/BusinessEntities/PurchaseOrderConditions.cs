using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PurchaseOrderConditions
    {
        public int POID { get; set; }
        public int Counter { get; set; }
        public string Condition { get; set; }
        public bool IsDefault { get; set; }
        public int TermID { get; set; }
        public string Term { get; set; }
    }
}
