using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryList
    {
        public string EnqNO { get; set; }
        public DateTime EnqDate { get; set; }
        public string Reference { get; set; }
        public string Company { get; set; }

        public string Address { get; set; }
        public string EnqFrom { get; set; }
        public string Description { get; set; }
        public string DisplayDesc { get; set; }
        public string SalesPerson { get; set; }
        public string Status { get; set; }
        public string AttendedBY { get; set; }
        public string Location { get; set; }
        public string DisplayDate { get; set; }
        public string CloseDate { get; set; }
        public string QuotationNo { get; set; }

        public int ContactPersonID { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int SalesPersonID { get; set; }
        public int SalesCoordinator { get; set; }
        public string SalesCoordinatorName { get; set; }
        public int StatusID { get; set; }
        public int AddedBYID { get; set; }
        public DateTime AddedOn { get; set; }
        public string CPEmailID { get; set; }
        public string CPContactNO { get; set; }
        public string CPMobileNO { get; set; }

        public bool IsDeleted { get; set; }
        public string CloseRemark { get; set; }
    }
}
