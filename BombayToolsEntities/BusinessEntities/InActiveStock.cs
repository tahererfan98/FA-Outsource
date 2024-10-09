using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class InActiveStock
    {
        public int SrNo { get; set; }
        public string Code { get; set; }
        public string ItemDesc { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float InStockSheet { get; set; }
        public float InActiveSheet { get; set; }
        public float InStockSQM { get; set; }
        public float InActiveSQM { get; set; }
        public float PlannedQty { get; set; }
        public float PlannedSQM { get; set; }
        public int IsClear { get; set; }
        public string AddedOn { get; set; }
        public string UserName { get; set; }
    }
}
