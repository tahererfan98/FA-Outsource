using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DispatchesList
    {
        public DispatchesList()
        {
            DispatchList = new List<Dispatches>();
        }
        public string[] ColumnName { get; set; }
        public List<Dispatches> DispatchList { get; set; }
        public decimal TotalPCs { get; set; }
        public decimal TotalSQM { get; set; }
        public decimal TotalBalancePCs { get; set; }
        public decimal TotalBalanceSQM { get; set; }
    }
}
