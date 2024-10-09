using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Production_Details
    {
        public int DeptID { get; set; }
        public String DeptName { get; set; }
        public int ProdQTY { get; set; }
        public decimal ProdSQM { get; set; }
        public int RejcQTY { get; set; }
        public decimal RejcSQM { get; set; }
        public decimal TargSQM { get; set; }
        public decimal AchiSQM { get; set; }
        public int UserCheck { get; set; }
        public int QCCheck { get; set; }
        public string ProdQTYTT { get; set; }
        public string ProdSQMTT { get; set; }
        public string RejcQTYTT { get; set; }
        public string RejcSQMTT { get; set; }
        public string TargSQMTT { get; set; }
        public string AchiSQMTT { get; set; }
        public string UserCheckTT { get; set; }
        public string QCCheckTT { get; set; }
        public string BGColor { get; set; }
        public string LastProcessDate { get; set; }
        public string WONO { get; set; }
        public string SRNO { get; set; }
    }
}
