using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class LiveProjectOrCustomerDetails
    {
        public LiveProjectOrCustomerDetails()
        {
            LivePIForProject = new List<ProformaInvoice>();
            LiveWOForProject = new List<WorkOrder>();
            LiveTIForProject = new List<TaxInvoice>();
        }
        public int LivePICount { get; set; }
        public List<ProformaInvoice> LivePIForProject { get; set; }
        public string PIBGColor { get; set; }
        public int LiveWOCount { get; set; }
        public List<WorkOrder> LiveWOForProject { get; set; }
        public string WOBGColor { get; set; }
        public int LiveTICount { get; set; }
        public List<TaxInvoice> LiveTIForProject { get; set; }
        public string TIBGColor { get; set; }

        public decimal PITotalPCs { get; set; }
        public decimal PITotalSQM { get; set; }
        public decimal PITotalAmount { get; set; }
        public decimal WOTotalPCs { get; set; }
        public decimal WOTotalSQM { get; set; }
        public decimal WOTotalBalancePCs { get; set; }
        public decimal WOTotalBalanceSqm { get; set; }

        public decimal TITotalPCs { get; set; }
        public decimal TITotalSQM { get; set; }
        public decimal TITotalBalancePCs { get; set; }
        public decimal TITotalBalanceSqm { get; set; }
        public decimal TITotalAmount { get; set; }

    }
}
