using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PurchaseOrderDXML
    {
        public PurchaseOrderDXML()
        {
            POD = new List<PurchaseOrderD>();
            TaxData = new List<PurchaseOrderD>();
        }
        public List<PurchaseOrderD> POD { get; set; }
        public List<PurchaseOrderD> TaxData { get; set; }
    }
}
