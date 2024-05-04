using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int CustomerRanking { get; set; }
        public string CustomerName { get; set; }
        public string EmailID { get; set; }
        //public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool Favourite { get; set; }
        public string BackgroundColor { get; set; }
        public string Color { get; set; }
        public int LivePICount { get; set; }
        public int LiveWOCount { get; set; }
        public int LiveTICount { get; set; }
        public string CustomerType { get; set; }
        public string LatestInvoiceDate { get; set; }

    }
}
