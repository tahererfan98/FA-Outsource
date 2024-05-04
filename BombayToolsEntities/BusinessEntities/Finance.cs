using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Finance
    {
        public List<TaxInvoiceMonthly> MonthlyTaxInvoice { get; set; }
        public TurnOver TurnOverDetails { get; set; }
    }
}
