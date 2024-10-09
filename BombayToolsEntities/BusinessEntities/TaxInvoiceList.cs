using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaxInvoiceList
    {
        public TaxInvoiceList()
        {
            TIList = new List<TaxInvoice>();
        }
        public string[] ColumnName { get; set; }
        public List<TaxInvoice> TIList { get; set; }
        public decimal TotalPCs { get; set; }
        public decimal TotalSQM { get; set; }
        public decimal TotalBalancePCs { get; set; }
        public decimal TotalBalanceSQM { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
