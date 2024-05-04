using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Dispatches
    {
        public string DispatchesNO { get; set; }
        public string DispatchesDate { get; set; }
        public string TINO { get; set; }
        public string Customer { get; set; }
        public string ProjectName { get; set; }
        public decimal PCS { get; set; }
        public decimal SQM { get; set; }
        public decimal BalancePCS { get; set; }
        public decimal BalanceSQM { get; set; }
        public int CustomerID { get; set; }
        public string PINO { get; set; }
        public string PIDate { get; set; }
        public string PINumber { get; set; }
        public string DCNumber { get; set; }
        public string TINumber { get; set; }
        public string Owner { get; set; }
        public string SalesPerson { get; set; }
        public string ShortDesc { get; set; }
    }
}
