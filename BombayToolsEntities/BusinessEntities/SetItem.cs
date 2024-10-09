using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SetItem
    {
        public int SetID { get; set; }
        public int ItemID { get; set; }
        public int QTY { get; set; }
        public float Rate { get; set; }
        public int RunningNo { get; set; }
    }
}
