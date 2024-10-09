using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Vertical
    {
        public int SrNo { get; set; }
        public int VerticalID { get; set; }
        public int IsSelected { get; set; }
        public int SalesPersonID { get; set; }
        public int TenderID { get; set; }
        public int SalesCoordinatorID { get; set; }
        public string Name { get; set; } 
        public string Tender { get; set; } 
        public string EmailID { get; set; } 
        public string ContactNo { get; set; } 
        public string SalesCoordinator { get; set; } 
        public string SalesPerson { get; set; } 
        public string VerticalName { get; set; } 
        public decimal BasicTotal { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
