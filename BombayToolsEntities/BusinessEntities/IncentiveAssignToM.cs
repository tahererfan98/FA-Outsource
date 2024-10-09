using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class IncentiveAssignToM
    {
        public IncentiveAssignToM()
        {
            SalesPerson = new List<SalesPerson>();
            SalesCoordinator = new List<SalesCoordinator>();
            Tender = new List<TenderM>();
        }
        public List<SalesPerson> SalesPerson { get; set; }
        public List<SalesCoordinator> SalesCoordinator { get; set; }
        public List<TenderM> Tender { get; set; }
    }
}
