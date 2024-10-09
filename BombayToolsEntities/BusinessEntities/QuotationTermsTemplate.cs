using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class QuotationTermsTemplate
    {
        public bool IsNew { get; set; }
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string Packing { get; set; }
        public string Freight { get; set; }
        public string Exgodown { get; set; }
        public string Tax { get; set; }
        public string Warranty { get; set; }
        public string Payment { get; set; }
        public string Delivery { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsActive { get; set; }
        public int TemplateCount { get; set; }
        public int SrNo { get; set; }
    }
}
