using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryD
    {
        public List<EnquiryD> POBilling { get; set; }

        public int SrNo { get; set; }
        public int IsStepGlass { get; set; }
        public int AutoID { get; set; }
        public string StepSrNo { get; set; }
        public string ItemCode { get; set; }
        public string Status { get; set; }
        public int ItemID { get; set; }
        public int SpecID { get; set; }
        public int ENQID { get; set; }
        public string ENQNO { get; set; }
        public string PINO { get; set; }
        public string WONO { get; set; }
        public string WONumber { get; set; }

        public int RevisionNo { get; set; }
        public string WorkYear { get; set; }
        public string ItemDescription { get; set; }
        public string ProjectName { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public int Qty { get; set; }
        public int Pcs { get; set; }
        public decimal SQM { get; set; }
        public decimal Weight { get; set; }
        public int OutQty { get; set; }
        public decimal OutSQM { get; set; }
        public int RecQty { get; set; }
        public decimal RecSQM { get; set; }
        public int ARQty { get; set; }
        public decimal ARSQM { get; set; }
        public int BQty { get; set; }
        public decimal BSQM { get; set; }
        public string OutType { get; set; }
        public int OutTypeID { get; set; }
        public string WOSpec { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        //////////////////
        public int ReceivedQty { get; set; }
        public int ReceivedSQM { get; set; }
        public string ScheduleDate { get; set; }

        public int PartnerID { get; set; }
        public string PartnerName { get; set; }

        public int NoOfCase { get; set; }   // For count
        public int SheetPerCase { get; set; }   // For count
        public decimal Rate { get; set; }
        public decimal TotalLC { get; set; }
        public decimal ApprovedRate { get; set; }
        public decimal Amount { get; set; }
        public int IsAllSelected { get; set; }

    }
}
