using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Prod_Details
    {
        public Prod_Details()
        {
            WONOList = new List<WO>();
            OperatorName = new List<UserDetails>();
            ProductionList = new List<Production_detailed_view>();
        }
        public List<WO> WONOList { get; set; }
        public List<UserDetails> OperatorName { get; set; }
        public List<Production_detailed_view> ProductionList { get; set; }
        public bool isReauthorized { get; set; }
    }
}
