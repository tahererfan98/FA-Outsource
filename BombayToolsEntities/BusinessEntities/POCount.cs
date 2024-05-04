using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class POCount
    { 
        public int POID { get; set; }
        public int AllOrders { get; set; } 
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string POYear { get; set; }
        public string Month { get; set; }
        public string WorkYear { get; set; }
        public int MonthNo { get; set; }
        public int Cancelled { get; set; }

    }
}
