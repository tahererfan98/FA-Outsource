using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class LinkingEnquiry
    {
        public int EnquiryNo { get; set; }
        public int QuotationNo { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int IsActive { get; set; }

    }
}
