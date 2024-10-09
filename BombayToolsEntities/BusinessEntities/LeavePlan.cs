using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class LeavePlan
    {
        public int Srno { get; set; }
        public int IsNew { get; set; }
        public string LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public int LeaveTypeCount { get; set; }
        public int LeaveID { get; set; }
        public int RevisionNo { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public int Days { get; set; }
        public string LeaveReason { get; set; }
        public int AddedBy { get; set; }
        public string AddedOn { get; set; }
        public int IsApproved { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedOn { get; set; }
        public string Status { get; set; }
        public string AddedByName { get; set; }
        public string EmailID { get; set; }
        public string UserType { get; set; }
    }
}
