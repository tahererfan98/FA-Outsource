using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesOrderForm
    {
        public SalesOrderForm() {
            SalesOrderList = new List<SalesOrderM>();
            SOItemTagIDList = new List<SalesOrderD>();
        }
        public List<SalesOrderM> SalesOrderList { get; set; }
        public List<SalesOrderD> SOItemTagIDList { get; set; }
    }
}
