using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class MentorM
    {
        public int AutoID { get; set; }
        public int SrNo { get; set; }
        public int BoxID { get; set; }
        public int MentorID { get; set; }
        public int SPID { get; set; }
        public int IsSelected { get; set; }
        public string Name { get; set; }
        public string MentorEmailID { get; set; }
        public string MentorName { get; set; } 
        public string MentorMobileNo { get; set; }
        public string ContactNo { get; set; }
        public string Body { get; set; }
        public string EmailID { get; set; }
        public int AddedBy { get; set; } 
        public string AddedByName { get; set; }
        public string DisplayAddedOn { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedOnDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedOnDate { get; set; }
    }
}
