using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class IndentInfo
    {

        public IndentInfo()
        {
            IndentItem = new List<IndentD>();

        }
        public int SrNo { get; set; }
        public int RevisionNo { get; set; }
        public string WorkYear { get; set; }
        public string ReqDates { get; set; }
        public int IndentID { get; set; }
        public int IsDraft { get; set; }
        public string IndentNo { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
        public string ReqNo { get; set; }
        public int IsPOMade { get; set; }
        public int IsPOCount { get; set; }
        public DateTime IndentDate { get; set; }
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string QuotationNo { get; set; }
        public int VendorID { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal ExchangeRate { get; set; }
        public int CurrencyID { get; set; }
        public int AddedBy { get; set; }
        public string AddedName { get; set; }
        public DateTime AddedOn { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string VendorName { get; set; }
        public string IndentDisplayDate { get; set; }
        public string DisplayDate { get; set; }
        public string DT_RowClass { get; set; }
        public List<IndentD> IndentItem { get; set; }

        public string Symbol { get; set; }
        public string CurrencyCode { get; set; }
        public string PanNO { get; set; }
        public string GSTNO { get; set; }
        public string State { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TallyLedgerName { get; set; }
        public string ALTERID { get; set; }
        public string GUID { get; set; }
        public string MASTERID { get; set; }
        public string REMOTEID { get; set; }
        public string VCHKEY { get; set; }
        public string VOUCHERKEY { get; set; }
        public string Remarks { get; set; }
        public string ProjectName { get; set; }

        //12/07/2021
        public string UserName { get; set; }
        public int IndentClosed { get; set; }
        public int IssueID { get; set; }

        //08-08-2021
        //07-08-2021
        public string IssueNo { get; set; }
        public string IssueDate1 { get; set; }
        public string ReceiverName { get; set; }
        public string Description { get; set; }
        public DateTime IssueDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchCriteria { get; set; }
        public string Search { get; set; }
        public string PINo { get; set; }
        public string ItemGroup_Name { get; set; }
        public int ItemGroup_ID { get; set; }
        public int ProjectID { get; set; }
        public int IsCancel { get; set; }
        public int UserID { get; set; }
        public int IsSelected { get; set; }
        public int IsApprove { get; set; }
        public string PINNo { get; set; }
        public string USERS { get; set; }
        public string EmailID { get; set; }

        //08-08-2021
        public string StatusRemarks { get; set; }
        public int IsIndentClosed { get; set; }
        public int IsGRNPVMade { get; set; }

        public string PODate { get; set; }
        public string GRNNo { get; set; }
        public string GRNDate { get; set; }
        public string ItemName { get; set; }
        public string ItemQty { get; set; }
        public int IsTop { get; set; }
        public decimal SQM { get; set; }
        public decimal Rate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Cases { get; set; }
        public int Sheets { get; set; }
        public int Qty { get; set; }
    }
}
