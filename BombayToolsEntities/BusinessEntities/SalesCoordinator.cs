using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesCoordinator
    {
        public int SalesCoordinatorID { get; set; }
        public int HasDiscount { get; set; }
        public string SalesCoordinatorName { get; set; }
        public string EmailID { get; set; }
        public string SalesEmail { get; set; }
        public string SaleContact { get; set; }
    }
}
