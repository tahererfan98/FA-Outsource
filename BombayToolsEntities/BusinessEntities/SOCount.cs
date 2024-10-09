using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SOCount
    {
        public int SOID { get; set; }
        public int POID { get; set; }
        public int AllOrders { get; set; }
        public string SOYear { get; set; }
        public string POYear { get; set; }
        public string Month { get; set; }
        public string WorkYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Cancelled { get; set; }
        public int MonthNo { get; set; }
    }
}
