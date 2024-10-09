using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesOrderTax
    {
        public int SrNo { get; set; }
        public int SalesOrderID { get; set; }
        public int FreightID { get; set; }
        public string SalesOrderNo { get; set; }
        public string GstPercent { get; set; }
        public string TaxName { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public decimal GST { get; set; }
        public decimal GSTID { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal FinalTotal { get; set; }
    }
}
