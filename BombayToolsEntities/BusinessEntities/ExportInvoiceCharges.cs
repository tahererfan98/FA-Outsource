using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ExportInvoiceCharges
    {
        public int ChargeID { get; set; }
        public string ChargeName { get; set; }
        public decimal ChargeAmount { get; set; }
        public string DisplayChargeAmount { get; set; }
    }
}
