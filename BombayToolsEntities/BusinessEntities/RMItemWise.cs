using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class RMItemWise
    {
        public int SrNo { get; set; }
        public string RMCode { get; set; }
        public string RMItemDesc { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double InStockQty { get; set; }
        public double InStockSQM { get; set; }
        public double AvailableQty { get; set; }
        public double AvailableSQM { get; set; }
        public double PlannedQty { get; set; }
        public double PlannedSQM { get; set; }
        public string ThicknessName { get; set; }
        public string SubCode { get; set; }
        public bool IsClearGlass { get; set; }
    }
}
