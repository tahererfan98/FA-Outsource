using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class YearDataList
    {

        public YearDataList()
        {
            POYearList = new List<YearList>();
            SOYearList = new List<YearList>();

        }
        public List<YearList> SOYearList { get; set; }
        public List<YearList> POYearList { get; set; }

    }
}
