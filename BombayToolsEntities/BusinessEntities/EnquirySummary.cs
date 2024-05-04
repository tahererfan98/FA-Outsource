using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquirySummary
    {
        public int SrNo { get; set; }
        public string Date { get; set; }
        public int EnquiryNo { get; set; }
        public int ContactPersonID { get; set; }
        public string CompanyName { get; set; }
        public string Reference { get; set; }
        public string LocationName { get; set; }
        public string PersonName { get; set; }
        public string Assigned { get; set; }
        public string AddedBy { get; set; }
    }
}
