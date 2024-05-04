using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryFollowUp
    {
        public int LogNo { get; set; }
        public int FollowUpID { get; set; }
        public string FollowUpName { get; set; }
        public int EnquiryNo { get; set; }
        public string FollowUpNote { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string DisplayDate { get; set; }
    }
}
