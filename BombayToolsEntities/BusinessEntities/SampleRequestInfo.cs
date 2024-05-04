using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SampleRequestInfo
    {
        public SampleRequestInfo()
        {
            SRDetails = new List<SampleRequestDetails>();
        }
        public int AddedBy { get; set; }
        public int SID { get; set; }
        public string WorkYear { get; set; }
        public string SMPNo { get; set; }
        public string SMPDate { get; set; }
        public string Customer { get; set; }
        public string Project { get; set; }
        public string SampleType { get; set; }
        public string MockupType { get; set; }
        public string RequiredLocation { get; set; }
        public string RequiredDate { get; set; }
        public int ModeOfTransport { get; set; }
        public string ModeName { get; set; }
        public string Remarks { get; set; }
        public string PINo { get; set; }
        public string DoneRemarks { get; set; }
        public string UserName { get; set; }
        public string MailID { get; set; }
        public string PSize { get; set; }
        public string Weight { get; set; }
        public string DoneBy { get; set; }
        public int IsCancel { get; set; }
        public int IsDone { get; set; }
        public int IsClose { get; set; }
        public int IsCosting { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal PackingCost { get; set; }
        public decimal CurrierCost { get; set; }
        public decimal OtherExps { get; set; }
        public List<SampleRequestDetails> SRDetails { get; set; }
        public int TotalQty { get; set; }
    }
}
