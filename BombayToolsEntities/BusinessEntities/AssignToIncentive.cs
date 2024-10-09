using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AssignToIncentive
    {
        public int SrNo { get; set; }
        public int VerticalID { get; set; }
        public int TenderID { get; set; }
        public int SalesPersonID { get; set; }
        public int SalesCoordinatorID { get; set; }
        public string SalesCoordinator { get; set; }
        public string SalesPerson { get; set; }
        public string Tender { get; set; }
        public string TenderName { get; set; }
        public string SalesCoordinatorName { get; set; }
        public string SalesPersonName { get; set; } 
        public string VerticalName { get; set; }
        public decimal BasicTotal { get; set; }
        public int BoxID { get; set; }
        public int AutID { get; set; }
        public int AddedBy { get; set; }
        public bool IsActive { get; set; }
        public string AddedByName { get; set; }
        public DateTime AddedOn { get; set; }
        public string DisplayAddedOn { get; set; }
    }
}
