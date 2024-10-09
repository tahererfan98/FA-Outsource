using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AtAGlanceLocationBussiness
    {
        public AtAGlanceLocationBussiness()
            {
            //EnqCounts = new List<EnquiryCount>();
            //QuotCounts = new List<QuotationCount>();
            //SalesCount = new List<SalesPerson>();
            CompanyNotes = new List<CompanyNotes>();
            Item = new List<Item>();
            EnquiryVSQuotations = new List<EnquiryVSQuotation>();
        }

        public EnquiryCount EnqCounts { get; set; }
        public SalesPerson SalesCount { get; set; }
        public List<CompanyNotes> CompanyNotes { get; set; }
        public List<Item> Item { get; set; }
        public List<EnquiryVSQuotation> EnquiryVSQuotations { get; set; }
    }
}
