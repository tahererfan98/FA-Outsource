using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CampaignDetails
    {
        public int RecordID { get; set; }
        public string CampaignName { get; set; }
        public string MailID { get; set; }
        public string Status { get; set; }
        public String AddedOn { get; set; }
        public int ReadCount { get; set; }

    }
}
