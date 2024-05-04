using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DRQuerySortByParameter
    {
        public int ID { get; set; }
        public string columnToSort { get; set; }
        public string sortValue { get; set; }
        public string columnValue { get; set; }
    }
}
