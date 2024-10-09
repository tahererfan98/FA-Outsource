using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class VisitReportM
    {
        public int IsNew { get; set; }
        public int counter { get; set; }
        public int VisitID { get; set; }
        public int RevisionNo { get; set; }
        public string VisitName { get; set; }
        public string DisplayDate { get; set; }
        public string VisitDate { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string ContactPerson { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Remark { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CancelledBy { get; set; }
        public DateTime CancelledOn { get; set; }
        public bool IsActive { get; set; }
        public int SrNo { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int IsCompleted { get; set; }
        public string AddedOn1 { get; set; }
        public string Note { get; set; }
        public string ScheduleDate { get; set; }
        public string ContactNo { get; set; }
        public string BodyText { get; set; }
        public string EmailID { get; set; }
        public string VisitSubject { get; set; }
        public string Success { get; set; }
        public string VisitNo { get; set; }
        public string FromVisitDate { get; set; }
        public string ToVisitDate { get; set; }
        public string UserName { get; set; }
    }
}
