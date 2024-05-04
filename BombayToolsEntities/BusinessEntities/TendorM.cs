using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TenderM
    {
        public int TenderID { get; set; }
        public string TenderName { get; set; } 
        public string EmailID { get; set; }
        public int TotalCount { get; set; }
        public int OpenCount { get; set; }
        public int CloseCount { get; set; }
    }
}
