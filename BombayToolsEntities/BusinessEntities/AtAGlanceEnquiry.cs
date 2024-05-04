using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AtAGlanceEnquiry
    {
        public AtAGlanceEnquiry()
        {
            EnquiryCount = new List<EnquiryCount>();
            PrincipalCount = new List<Principal>();
            SectorCount = new List<Sector>();
            IndustryCount = new List<Industry>();
        }

        public List<EnquiryCount> EnquiryCount { get; set; }
        public List<Principal> PrincipalCount { get; set; }
        public List<Sector> SectorCount { get; set; }
        public List<Industry> IndustryCount { get; set; }
    }
}
