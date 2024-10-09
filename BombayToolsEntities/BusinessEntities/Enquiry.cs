using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Enquiry
    {
        public int EnquiryNO { get; set; }
        public int RevisionNo { get; set; }
        public DateTime EnqDate { get; set; }
        public int ContactPersonID { get; set; }
        public string Reference { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public string DisplayDate { get; set; }
        public int SalesPersonID { get; set; }
        public int SalesCoordinatorID { get; set; }
        public int StatusID { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsDeleted { get; set; }

        public string MessageID { get; set; }
        public string ThreadID { get; set; }
        public string Remark { get; set; }
    }
}
