using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DRQueryConditionParameter
    {
        public int ID { get; set; }
        public int columnID { get; set; }
        public string operatorID { get; set; }
        public string value { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
