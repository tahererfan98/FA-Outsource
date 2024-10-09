using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class BillingLocation
    {
        public bool IsNew { get; set; }
        public int SrNo { get; set; }
        public string DT_RowId { get; set; }
        public int LocationID { get; set; }
        public int BillingLocationID { get; set; }
        public int CompaID { get; set; }
        public int CompanyID { get; set; }
        public string BillingLocationName { get; set; }
        public string TallyName { get; set; }
        public string BillAddress { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string ContactPerson { get; set; }
        public double ContactNO { get; set; }
        public string EmailID { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public int ModifiedID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsCancel { get; set; }
        public bool IsCheckDelivery { get; set; } 
        public int CanceledID { get; set; }
        public DateTime CanceledON { get; set; }
        public int MasterKey { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string AddedByName { get; set; }
        public string AddedOnDisplay { get; set; }
        public int TyepReg { get; set; }
        public string GSTNo { get; set; }
        public int ShippingLocationID { get; set; }
    }
}
