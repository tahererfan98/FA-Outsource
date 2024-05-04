using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class VisitReportData
    {
        public VisitReportData()
        {
            VisitData = new VisitReport();
            VisitItemList = new List<VisitReport>();
            Attachment = new List<SupplierInfoAttach>();
        }
        public VisitReport VisitData { get; set; }
        public List<VisitReport> VisitItemList { get; set; }
        public List<SupplierInfoAttach> Attachment { get; set; }
    }
}
