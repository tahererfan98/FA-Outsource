using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CustomerDeskM
    {
        public int AutoID { get; set; }
        public int SrNo { get; set; }
        public int ID { get; set; }
        public int MasterID { get; set; }
        public int CallID { get; set; }
        public int IssueID { get; set; }
        public int CustomerID { get; set; }
        public int ProjectID { get; set; }
        public string MasterNo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Issues { get; set; }
        public string EmailID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string PINo { get; set; }
        public string WONo { get; set; }
        public string Remarks { get; set; }
        public string Reason { get; set; }
        public string IssueName { get; set; }
        public string AddedByName { get; set; }
        public string DisplayAddedOn { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int CancelledBy { get; set; }
        public DateTime CancelledOn { get; set; }
        public Boolean IsIssueClosed { get; set; }
        public Boolean IsActive { get; set; }
        public int IssueCloededBy { get; set; }
        public DateTime IssueCloededOn { get; set; }
         
    }
}
