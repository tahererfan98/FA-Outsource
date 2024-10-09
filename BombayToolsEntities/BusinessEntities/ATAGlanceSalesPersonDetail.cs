using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
   public class ATAGlanceSalesPersonDetail
    {
        public int Today { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int LastMonth { get; set; }
        public int Total { get; set; }
        public int OpenCount { get; set; }
        public int CloseCount { get; set; }
    }
}
