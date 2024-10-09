using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class OutsourcePartner
    {
        public int SrNo { get; set; }
        public int PartnerID { get; set; }
        public int EntryID { get; set; }
        public string PartnerName { get; set; }
        public string PartnerLoc { get; set; }
        public string VendorCode { get; set; }
        public string Address { get; set; }
        public string VendorType { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string VatNo { get; set; }

        public int PaymentTermID { get; set; }
        public string PaymentTerm { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public int AddedBy { get; set; }
        public string Status { get; set; }


        public OutsourcePartner()
        {
            POBilling = new List<OutsourcePartner>();

        }
        public List<OutsourcePartner> POBilling { get; set; }

    }
}
