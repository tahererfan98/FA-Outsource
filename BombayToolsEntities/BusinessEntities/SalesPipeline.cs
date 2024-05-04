using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SalesPipeline
    {
        public int AutoID { get; set; }
        public int CountryID { get; set; }
        public int BoxID { get; set; }
        public int QuotID { get; set; }
        public int DirectID { get; set; }
        public int SalesOrderID { get; set; }
        public int ReqLinkedForSO { get; set; }
        public string ShortDesc { get; set; }
        public string AccessibleForName { get; set; }
        public string PINo { get; set; }
        public string SONo { get; set; }
        public string Requirement { get; set; }
        public string SalesOrderNo { get; set; }
        public string QuotationID { get; set; }
        public string QuotationNo { get; set; } 
        public string ProjectName { get; set; }
        public string DirectRequirementName { get; set; }
        public string VerticalName { get; set; }
        public int VerticalID { get; set; }
        public int MainSubStageID { get; set; }
        public int StageID { get; set; }
        public string Status { get; set; }
        public string Vertical { get; set; }
        public string StageName { get; set; }
        public DateTime CloseDate { get; set; }
        public string DisplayCloseDate { get; set; }
        public DateTime NextFollowUp { get; set; }
        public string DisplayNextFollowUp { get; set; }
        public decimal Probability { get; set; }
        public decimal ProjectSize { get; set; }
        public decimal Probabilty { get; set; }
        public decimal DealSizeINR { get; set; }
        public int CurrencyID { get; set; }
        public decimal DealSizeUSD { get; set; }
        public decimal ExchangeRate { get; set; }
        public string DealSizeUSDValue { get; set; }
        public string DealSizeValue { get; set; }
        public decimal DealSize { get; set; }
        public int LeadSourceID { get; set; }
        public string LeadSource { get; set; }
        public string VerticalIDNames { get; set; }
        public string Remark { get; set; }
        public int AddedBy { get; set; }
        public string SalesPerson { get; set; }
        public string AddedByName { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public string ContactPerson { get; set; }
        public string DisplayAddedOn { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedOnDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedOnDate{ get; set; }
        public int SrNo { get; set; }
        public int CommentID { get; set; }
        public int IsActive{ get; set; }
        public string CompanyName { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string PersonName { get; set; }
        public string EmailID { get; set; }
        public string Contact { get; set; }
        public string Total { get; set; }
        public int IsDirect { get; set; }
        public int ContactPersonID { get; set; }
        public int SubStageID { get; set; }
        public string SubStageName { get; set; }
        public int AssignTo { get; set; }

        ////28-07-23
        public string DealSizeWithComma { get; set; }
        public string DealSizeUSDWithComma { get; set; }
        public string ProjectSizeWithComma { get; set; }
        public string CurrencyName { get; set; }
        public string AssignToName { get; set; }
        public string ProbabilityName { get; set; }

        public string Developer { get; set; }
        public string Fabricator { get; set; }
        public string Architect { get; set; }
        public string Consultant { get; set; }
    }
}
