using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CompanyStatus
    {
        public CompanyStatus()
        {
            EnqCounts = new List<EnquiryCount>();
            SalesCount = new List<SalesPerson>();
        }

        public List<EnquiryCount> EnqCounts { get; set; }
        public List<SalesPerson> SalesCount { get; set; }
    }
}
