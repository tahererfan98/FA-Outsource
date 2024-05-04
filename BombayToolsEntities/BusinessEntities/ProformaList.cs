using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ProformaList
    {
        public ProformaList()
        {
            ProformaInvoiceList = new List<ProformaInvoice>();
        }
        public string[] ColumnName { get; set; }
        public List<ProformaInvoice> ProformaInvoiceList { get; set; }
        public decimal TotalPCs { get; set; }
        public decimal TotalSQM { get; set; }
        public decimal TotalAmount { get; set; }
        public int Count { get; set; }


    }
}
