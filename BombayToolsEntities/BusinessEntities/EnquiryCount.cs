using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryCount
    {
        public int Count { get; set; }
        public string Name { get; set; }
        

        //At a glance screen
        public int OpenCount { get; set; }
        public int CloseCount { get; set; }
        public int TotalCount { get; set; }
        public decimal Value { get; set; }

    }
}
