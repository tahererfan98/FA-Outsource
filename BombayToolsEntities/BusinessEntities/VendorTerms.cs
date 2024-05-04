using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class VendorTerms
    {
        public int ID { get; set; }
        public string Term { get; set; }
        public int IsActive { get; set; }
        public int Counter { get; set; }
    }
}
