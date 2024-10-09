using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PIStages
    {
        public PIStages()
        {
            WODetails = new List<WO>();
        }
        public string StageName { get; set; }
        public string PINO { get; set; }
        public DateTime PIDate { get; set; }
        public string DisplayPIDate { get; set; }
        public string PIDate1 { get; set; }
        public bool isPIStageApproved { get; set; }
        public DateTime CustomerApprovedDate { get; set; }
        public string CustomerApprovedDate1 { get; set; }
        public string CustomerName { get; set; }
        public bool isCustomerStageApproved { get; set; }
        public DateTime ApprovalDateByAccountDept { get; set; }
        public string ApprovalDateByAccountDept1 { get; set; }
        public string ApproversName { get; set; }
        public bool isAccountStageApproved { get; set; }
        public int WOCount { get; set; }
        public DateTime LatestWODate { get; set; }
        public string LatestWODate1 { get; set; }
        public bool isWOStageApproved { get; set; }
        public int RevisionNo { get; set; }
        public int DCCount { get; set; }
        public bool isDCStageApproved { get; set; }
        public int TICount { get; set; }
        public bool isTIStageApproved { get; set; }
        public List<WO> WODetails { get; set; }
        public bool isPIApprovalNeeded { get; set; }
        public bool isPIRevised { get; set; }
        public string Message { get; set; }
        public int AutoID { get; set; }
    }
}
