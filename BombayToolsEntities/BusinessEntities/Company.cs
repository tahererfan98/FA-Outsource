using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Company
    {
        public bool IsNewAdded { get; set; }
        public string DT_RowId { get; set; }
        public int SPID { get; set; }
        public int SrNo { get; set; }
        public int CompanyID { get; set; }
        public int IsSelected { get; set; }
        public bool IsSynchronized { get; set; }
        public string Name { get; set; }
        public string Box { get; set; }
        public string CompanyName { get; set; }
        public int PrincipalID { get; set; }
        public int IndustryID { get; set; }
        public int SectorID { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        //public bool IsCancelled { get; set; }
        //public int CancelledBY { get; set; }
        //public DateTime CancelledON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsActive { get; set; }
        public int index { get; set; }
        public string AddedByName { get; set; }
        public string AddedOnDisplay { get; set; }
        public string Location { get; set; }
        public int LocationID { get; set; }

        //Other Info Details
        public string Address { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string EmailID { get; set; }
        public int ContactNo1 { get; set; }
        public string ContactNo { get; set; }
        public string MobileNO { get; set; }
        public string DesignationID { get; set; }
        public string Principal { get; set; }
        public string DisplayDate { get; set; }
        public string PINo { get; set; }
        public string SectorName { get; set; }
        public string Industry { get; set; }
        public int Type { get; set; }
        public int RevisionNo { get; set; }
        public int QuotID { get; set; }
        public int ContactPersonID { get; set; }
        public string PersonName { get; set; }
        public string ViewName { get; set; }
        public string VerticalName { get; set; }

        public string ProjectName { get; set; }
    }
}
