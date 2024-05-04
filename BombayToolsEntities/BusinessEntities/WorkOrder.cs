using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class WorkOrder
    {
        public string WONO { get; set; }
        public string WODate { get; set; }
        public string PINO { get; set; }
        public string Customer { get; set; }
        public string ProjectName { get; set; }
        public decimal PCS { get; set; }
        public decimal SQM { get; set; }
        public string Owner { get; set; }
        public string SalesPerson { get; set; }
        public string WOID { get; set; }
        public int CustomerID { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string ShortDescription { get; set; }
        public string PIDate { get; set; }
        public decimal BalancePcs { get; set; }
        public decimal BalanceSQM { get; set; }
        public string WONumber { get; set; }
        public string PINumber { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
    }
}
