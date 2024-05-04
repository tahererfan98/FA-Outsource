using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CustomerQuickAdd
    {

            public string Company { get; set; }
            public string Location { get; set; }
            public int CompanyID { get; set; }
            public int LocationID { get; set; }
            public string ContactPersonName { get; set; }
            public string ContactNo { get; set; }
            public string ContactEmail { get; set; }
            public int StateID { get; set; }
            public int CountryID { get; set; }
            public DateTime AddedOn { get; set; }
            public int AddedBy { get; set; }
            public int PrincipalID { get; set; }
            public int SectorID { get; set; }
            public int IndustryID { get; set; }

    }
}
