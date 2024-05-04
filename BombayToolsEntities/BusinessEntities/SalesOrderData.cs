using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesOrderData
    {
        public SalesOrderData()
        {
            master = new SalesOrderM();
            item = new List<SalesOrderD>();
            tax = new List<SalesOrderTax>();

        }
        public SalesOrderM master { get; set; }
        public List<SalesOrderD> item { get; set; }
        public List<SalesOrderTax> tax { get; set; }
    }
}
