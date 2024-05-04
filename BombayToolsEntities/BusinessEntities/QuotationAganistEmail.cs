using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class QuotationAganistEmail
    {
            public int QuotID {get;set;}
            public int AutoID {get;set; }
            public string TokenPath {get;set;}
            public string MessageID {get;set;}
            public string ThreadID {get;set;}
            public string Snippet {get;set;}
            public int AddedBy {get;set;}
            public int ModifiedBy {get;set;}
            public int IsActive {get;set;}
    }
}
