using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PIMaster
    {
        public int SrNo { get; set; }
        public int RevisionNo { get; set; }
        public int SpecID { get; set; }
        public string PIDate { get; set; }
        public string WorkYear { get; set; }
        public string DocumentDate { get; set; }
        public string Status { get; set; }
        public string PIType { get; set; }
        public string DCDate { get; set; }
        public int IPINO { get; set; }
        public string PINO { get; set; }
        public string DCNO { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string CustName { get; set; }
        public string WONO { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public decimal SQM { get; set; }
        public decimal BalQty { get; set; }
        public decimal BalSQM { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public int TotalPcs { get; set; }
        public decimal TotalSQM { get; set; }

        public List<PIMaster> POBilling { get; set; }

    }
}
