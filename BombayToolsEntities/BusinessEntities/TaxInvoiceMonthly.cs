using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaxInvoiceMonthly
    {
        public int GrandTotal { get; set; }
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        public string Year { get; set; }
    }
}
