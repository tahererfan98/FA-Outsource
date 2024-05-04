using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CurrencyCodeInfo
    {

        public int ID { get; set; }
        public int CurrencyID { get; set; }

        public int SrNo { get; set; }

        public string CountryName { get; set; }

        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }

        public string Symbol { get; set; }
    }
}
