using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DynamicReportM
    {
        public int AutoID { get; set; }
        public int ReportFor { get; set; }
        public string MasterString { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string AddedByName { get; set; }
        public string AddedOnDate { get; set; }
    }
}
