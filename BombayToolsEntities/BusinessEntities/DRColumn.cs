using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DRColumn
    {
        public int AutoID { get; set; }
        public string QueryName { get; set; }
        public string ColumnDisplayName { get; set; }
        public string OperatorID { get; set; }
        public string SortID { get; set; }
        public string GroupID { get; set; }
    }
}
