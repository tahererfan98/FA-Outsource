using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaxInvoiceData
    {
        public TaxInvoiceData()
        {
            master = new TaxInvoiceM();
            item = new List<TaxInvoiceD>();
            tax = new List<TaxInvoiceTax>();

        }

        public TaxInvoiceM master { get; set; }
        public List<TaxInvoiceD> item { get; set; }
        public List<TaxInvoiceTax> tax { get; set; }


    }
}
