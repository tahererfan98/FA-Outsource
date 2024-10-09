using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class MailCampaign
    {
        public MailCampaign()
        {
            Attachments = new List<EmployeeAttachments>();
        }
        public int RecordID { get; set; }
        public string TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string CampaignName { get; set; }
        public string EmailID { get; set; }
        public string CampaignPassword { get; set; }
        public string Body { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public List<EmployeeAttachments> Attachments { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }
}
