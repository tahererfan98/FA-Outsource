using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class FreightMaster
    {

        public int AutoID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddedBy { get; set; }
        public  DateTime AddedOn { get; set; }
    }
}
