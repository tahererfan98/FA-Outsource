using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Vendor
    {

        public string VendorName { get; set; }
        public int VendorID { get; set; }
        public string Vendor_Name { get; set; }
        public int Vendor_ID { get; set; }
        public string Vendor_Code { get; set; }
        public string Vendor_Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string CustomerStatus { get; set; }
        public string VendorStatus { get; set; }
        public string ContactNo_1 { get; set; }
        public string ContactNo_2 { get; set; }
        public string FaxNumber { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string WebSite { get; set; }
        public string GSTNo { get; set; }
        public string PANNo { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public int VendorLocationID { get; set; }
        public string DeliveryAddress { get; set; }
        public bool IsVendor { get; set; }
        public bool IsCustomer { get; set; }
        public string Flag { get; set; }
        public string VendorLocationName { get; set; }
        public int IsEdit { get; set; }
        public string Btype { get; set; }
        public int ShippingLocationID { get; set; }
        public string DeliveryLocation { get; set; }
        public int StateID { get; set; }
        public int StateCode { get; set; }
        public string StateName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingLocation { get; set; }
        public int BillingLocationID { get; set; }
        public int DeliveryLocationID { get; set; }
        public int ConID { get; set; }
        public string ConName { get; set; }
        public int PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }




        //addedby Prashant Solapure

        public int RegisterTypeID { get; set; }
        public string RegisterType { get; set; }
        public string GSTRegistrationDate { get; set; }
        public string GSTLocation { get; set; }
        public string GSTAddress { get; set; }
        public string GSTContactNo { get; set; }
        public string GSTRegistrationTypeName { get; set; }
        public string TallyName { get; set; }
        public string address2 { get; set; }
        public string Discountable { get; set; }
        public string Creditores { get; set; }
        public string relatedPerson { get; set; }
        public string Gstscheme { get; set; }
        public string status { get; set; }
        public string registration { get; set; }
        public string DocumenttypeID { get; set; }
        public string MSNoFile { get; set; }
        public int AddedBy { get; set; }

        public Vendor()
        {
            Locationmaster = new List<Locationmaster>();
            StateMaster = new List<StateMaster>();
            GSTRegistrationType = new List<GSTRegistrationType>();
            Vendor_Docs = new List<Vendor_Docs>();
            Item = new List<Item>();
            BankList = new List<BankList>();
            VendorContactDetails = new List<VendorContactDetails>();
            VendorAccountDetails = new List<VendorAccountDetails>();
            VendorPaymentDetails = new List<VendorPaymentDetails>();
            Products = new List<Products>();
            VendorDiscountDetails = new List<VendorDiscountDetails>();
            Terms = new List<VendorTerms>();
            VendorDoc = new List<VendorDocs>();
        }

        public List<Locationmaster> Locationmaster = new List<Locationmaster>();
        public List<StateMaster> StateMaster = new List<StateMaster>();
        public List<GSTRegistrationType> GSTRegistrationType = new List<GSTRegistrationType>();
        public List<Vendor_Docs> Vendor_Docs = new List<Vendor_Docs>();
        public List<VendorDocs> VendorDoc = new List<VendorDocs>();
        public List<Item> Item = new List<Item>();
        public List<BankList> BankList = new List<BankList>();
        public List<VendorContactDetails> VendorContactDetails = new List<VendorContactDetails>();
        public List<VendorAccountDetails> VendorAccountDetails = new List<VendorAccountDetails>();
        public List<VendorPaymentDetails> VendorPaymentDetails = new List<VendorPaymentDetails>();
        public List<Products> Products = new List<Products>();
        public List<VendorDiscountDetails> VendorDiscountDetails = new List<VendorDiscountDetails>();
        public List<VendorTerms> Terms = new List<VendorTerms>();


    }

    public class VendorContactDetails
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
        public int ID { get; set; }
        public int IsCancel { get; set; }
        public string SRNO { get; set; }
        public int counter { get; set; }
    }

    public class Locationmaster
    {

        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }

    public class StateMaster
    {

        public int StateID { get; set; }
        public string StateName { get; set; }
    }

    public class GSTRegistrationType
    {

        public int RGID { get; set; }
        public string RGType { get; set; }
    }

    public class Vendor_Docs
    {

        public int Docid { get; set; }
        public string DocType { get; set; }
    }
    public class BankList
    {

        public string BankID { get; set; }
        public string BankName { get; set; }
    }

    public class VendorAccountDetails
    {
        public string BankID { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public string AccountName { get; set; }
        public string BranchName { get; set; }
        public int AutoID { get; set; }
        public int IsActive { get; set; }
        public int Counter { get; set; }
    }

    public class VendorPaymentDetails
    {
        public string PriceList { get; set; }
        public string Totaldiscount { get; set; }
        public string Poc { get; set; }
        public string NET { get; set; }
        public string CreditLimit { get; set; }
        public string AccountDiscount { get; set; }
        public string LC { get; set; }
        public string PaymentTerm { get; set; }
        public string LocNo { get; set; }
        public string Others { get; set; }
        public int TempID { get; set; }
    }

    public class Products
    {
        public string ProductName { get; set; }
        public int TempID { get; set; }

    }
    public class VendorDiscountDetails
    {
        public string Items { get; set; }
        public string Discounts { get; set; }
        public int TempID { get; set; }
        public int itemID { get; set; }

    }

    public class VendorDocs
    {
        public int SrNo { get; set; }
        public int DocID { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int IsActive { get; set; }
        public int Counter { get; set; }
    }
}
