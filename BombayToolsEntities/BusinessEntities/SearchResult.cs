using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SearchResult
    {
        public string Header {get;set;}
        public string Body {get;set; }
        public string Icon {get;set; }
        public int PrimaryID { get; set; }
        public int SecondaryID { get; set; }
        public int TypeID { get; set; }
        public int AutoID { get; set; }
    }
}
