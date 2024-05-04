using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class MapRequirementSalesOrder
    {
        public int AutoID { get; set; }
        public int RequirmentID { get; set; }
        public decimal Amount { get; set; }
        public string SalesOrderNo { get; set; }
        public string Remark { get; set; }
        public int AddedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }
    }
}
