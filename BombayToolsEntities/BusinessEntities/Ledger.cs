using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Ledger
    {
        public int SrNo { get; set; }
        public int LedgerID { get; set; }
        public string LedgerSection { get; set; }
        public string LedgerName { get; set; }
        public bool IsSynchronized { get; set; }

    }
}
