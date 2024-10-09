using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Production_detailed_view
    {
        public string Date { get; set; }
        public string WoNo { get; set; }
        public string PINo { get; set; }
        public string SrNo { get; set; }
        public string Description { get; set; }
        public string Operator { get; set; }
        public string Shift { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double QTY { get; set; }
        public double SQM { get; set; }
        public string NextDepartment { get; set; }
        public string PINumber { get; set; }
        public string WONumber { get; set; }
        public string Customer { get; set; }
        public string Project { get; set; }
    }
}
