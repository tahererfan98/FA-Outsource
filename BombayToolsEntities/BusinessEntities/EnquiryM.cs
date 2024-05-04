using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EnquiryM
    {
        public EnquiryM()
        {
            ENQItemD = new List<EnquiryD>();
            ENQSizesD = new List<EnquiryD>();
            ENQSentPartnerD = new List<EnquiryD>();
            AttachmentD = new List<AttachmentM>();
            EmailM = new EmailEntity();
        }

        public List<EnquiryD> ENQItemD { get; set; }
        public List<EnquiryD> ENQSizesD { get; set; }
        public List<EnquiryD> ENQSentPartnerD { get; set; }
        public List<AttachmentM> AttachmentD { get; set; }
        public EmailEntity EmailM { get; set; }

        public List<EnquiryD> POBilling { get; set; }


        public int SrNo { get; set; }
        public int ENQID { get; set; }
        public string ENQNO { get; set; }
        public string WONO { get; set; }
        public string ENQDate { get; set; }

        public int RevisionNo { get; set; }
        public string WorkYear { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Remarks { get; set; }
        public string AllWONO { get; set; }
        public string AllPINO { get; set; }
        public int AddedBy { get; set; }
        public string AddedName { get; set; }
        public DateTime AddedOn { get; set; }
        public string Location { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchCriteria { get; set; }
        public string Search { get; set; }
        public string UserName { get; set; }
        public int IsENQSend { get; set; }
        public string ENQStatus { get; set; }
        public string EnqType { get; set; }
        public int IsApproved { get; set; }
        public string ApprovedOn { get; set; }
        public int ApprovedBy { get; set; }
        public int TotalQty { get; set; }


        ///////////////  09-02-24 Send entry

        public int ESID { get; set; }
        public string ESNO { get; set; }
        public string ESDate { get; set; }
        public int PartnerID { get; set; }
        public string PartnerName { get; set; }
        public string PartnerLoc { get; set; }

        /////////////////////// 15-02-24 Approve

        public int EAID { get; set; }
        public string EANO { get; set; }
        public string EADate { get; set; }
        public int NoOfVehicle { get; set; }
        public string Destination { get; set; }
        public string PONO { get; set; }
        public string PINO { get; set; }
        public decimal PIAmount { get; set; }
        public decimal InvAmount { get; set; }
        public decimal TotalVehCost { get; set; }
        public string VehType { get; set; }

        /////////////////////// 21-02-24 Receive

        public int ERID { get; set; }
        public int RecQty { get; set; }
        public decimal RecSQM { get; set; }     
        public int OutQty { get; set; }
        public decimal OutSQM { get; set; }
        public int BQty { get; set; }
        public decimal BSQM { get; set; }
        public string ERNO { get; set; }
        public string ERDate { get; set; }
        public string ChallanNo { get; set; }
        public string VehicleNo { get; set; }

        ///////////// Req Raw Material
        public int RRMID { get; set; }
        public string RRMNO { get; set; }
        public string RRMDate { get; set; }
        public int ItemGroupID { get; set; }
        public int IsCutSize { get; set; }
        public int ReqVehicle { get; set; }
        public decimal Total { get; set; }
        public decimal Qty { get; set; }
        public decimal SQM { get; set; }
        public decimal Weight { get; set; }
        public int RemarkID { get; set; }
        public string RemarkName { get; set; }
        public string ClosingRemark { get; set; }
        public string ItemGroupName { get; set; }

        ///////////////////////////////////////
        public int FGTypeID { get; set; }
        public string FGTypeName { get; set; }      
        public int TransporterID { get; set; }
        public string TransporterName { get; set; }
        public string DriverName { get; set; }
    }
}
