using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
     public class MailCampaignTemplate
    {
        public MailCampaignTemplate()
        {
            Attachments = new List<EmployeeAttachments>();
        }
        public int SrNo { get; set; }
        public int AutoID { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string DocHTML { get; set; }
        public int AddedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }
        public string DisplayAddedOn { get; set; }
        public string DisplayModifiedOn { get; set; }
        public string DisplayAddedOnName { get; set; }
        public string DisplayModifiedOnName { get; set; }
        public string Remark { get; set; }
        public List<EmployeeAttachments> Attachments { get; set; }
        public int RecordID { get; set; }
        public string CampaignName { get; set; }
    }
}
