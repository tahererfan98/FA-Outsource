using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ContactPerson
    {
        public string Location;

        public bool IsNew { get; set; }
        public int index { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int ContactPersonID { get; set; }
        public string ContactPersonName { get; set; }
        public string PersonName { get; set; }
        public int DepartmentID { get; set; }
        public string DesignationID { get; set; }
        public string Salutation { get; set; }
        public string Contact { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string MobileNO { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsCancel { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }
        public string Department { get; set; }
        public string DepartmentName { get; set; }
        public string Designation { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string AddedByName { get; set; }
        public string AddedOnDisplay { get; set; }
        public int StateID { get; set; }
    }
}
