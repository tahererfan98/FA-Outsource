using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesPerson
    {
        public int SalesPersonID { get; set; }
        public string SalesPersonName  {get; set;}
        public string EmailID  {get; set;}
        public int TotalCount { get; set; }
        public int OpenCount { get; set; }
        public int CloseCount { get; set; }

        //New
        public int TL_ID { get; set; }
        public int CancelledCount { get; set; }
        public decimal ClosedPIPercent { get; set; }
        public decimal OpenPIPercent { get; set; }
        public decimal SalesAchievedPercent { get; set; }
        public decimal CancelledPIPercent { get; set; }
        public string SalesTarget { get; set; }
        public string SalesAmount { get; set; }
    }
}
