using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CompanySearchData
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }


        public int CompanyID { get; set; }
        public int LocationID { get; set; }

        public int ContactPersonID { get; set; }
        //public string Location {get; set;}
        public int PendingCount { get; set; }
        public string Location { get; set; }
        public string SearchText { get; set; }

        public int index { get; set; }
        public int TemplateID { get; set; }
        public int EnqNo { get; set; }
        public int IsCopy { get; set; }
    }
}
