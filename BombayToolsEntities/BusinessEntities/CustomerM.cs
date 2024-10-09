using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CustomerM
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public int PartnerID { get; set; }

        public string PartnerName { get; set; }
        public string ESNO { get; set; }
        public int StateCode { get; set; }
        public int PrincipleID { get; set; }
        public int SectorID { get; set; }
        public int BrandID { get; set; }
    }
}
