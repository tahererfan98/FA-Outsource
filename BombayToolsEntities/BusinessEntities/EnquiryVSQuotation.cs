using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryVSQuotation
    {
        public int EnquiryTotal { get; set; }
        public int QuotationTotal { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
