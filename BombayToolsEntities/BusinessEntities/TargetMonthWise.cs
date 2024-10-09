using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TargetMonthWise
    {
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        public decimal TargetAmount { get; set; }
        public string Vertical { get; set; }
    }
}
