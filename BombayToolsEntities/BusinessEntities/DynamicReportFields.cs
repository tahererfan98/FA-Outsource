using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DynamicReportFields
    {
        public int FieldID { get; set; } 
        public string FieldDisplayName { get; set; } 
        public string FieldTableName { get; set; }
        public int FromTable { get; set; }
        public string DepandsOn { get; set; }
        public string FieldNameinDB { get; set; }
        public int Operator { get; set; }


    }
}
