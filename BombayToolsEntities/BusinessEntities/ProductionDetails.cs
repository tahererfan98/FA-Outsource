using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ProductionDetails
    {
        public int TotalPCs { get; set; }
        public int ProductionPCs { get; set; }
        public int PendingPCs { get; set; }
        public int StageNo { get; set; }
        //public int RejectedPCs { get; set; } 
    }
}
