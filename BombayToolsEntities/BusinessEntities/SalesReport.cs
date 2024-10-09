using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesReport
    {
        public int BoxID { get; set; }
        public string BoxName { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        public string SubStage { get; set; }
        public string Vertical { get; set; }
        public string CloseDate { get; set; }
        public string Probabilty { get; set; }
        public string DealSize { get; set; }
        public string AddedOn { get; set; }
        public string FirstDate { get; set; }
        public string LastDate { get; set; }
        public string Total { get; set; }
    }
}
