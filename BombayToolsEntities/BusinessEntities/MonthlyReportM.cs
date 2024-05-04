using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class MonthlyReportM
    {
        public MonthlyReportM()
        {
            Slide1 = new List<MonthlyReportM>();
            Slide2 = new List<MonthlyReportM>();
            Slide3 = new List<MonthlyReportM>();
            Slide4 = new List<MonthlyReportM>();
            Slide5 = new List<MonthlyReportM>();
            Slide6A = new List<MonthlyReportM>();
            Slide6B = new List<MonthlyReportM>();
            Slide7 = new List<MonthlyReportM>();
            Slide8 = new List<MonthlyReportM>();
            Slide9 = new List<MonthlyReportM>();
            Slide10 = new List<MonthlyReportM>();
            Slide11 = new List<MonthlyReportM>();
            Slide12 = new List<MonthlyReportM>();
            Slide13 = new List<MonthlyReportM>();

            MonthlyGraph = new List<MonthlyReportM>();
            QuaterlyGraph = new List<MonthlyReportM>();
            ContributionGraph = new List<MonthlyReportM>();
        }
        public List<MonthlyReportM> Slide1 { get; set; }
        public List<MonthlyReportM> Slide2 { get; set; }
        public List<MonthlyReportM> Slide3 { get; set; }
        public List<MonthlyReportM> Slide4 { get; set; }
        public List<MonthlyReportM> Slide5 { get; set; }
        public List<MonthlyReportM> Slide6A { get; set; }
        public List<MonthlyReportM> Slide6B { get; set; }
        public List<MonthlyReportM> Slide7 { get; set; }
        public List<MonthlyReportM> Slide8 { get; set; }
        public List<MonthlyReportM> Slide9 { get; set; }
        public List<MonthlyReportM> Slide10 { get; set; }
        public List<MonthlyReportM> Slide11 { get; set; }
        public List<MonthlyReportM> Slide12 { get; set; }
        public List<MonthlyReportM> Slide13 { get; set; }

        public MonthlyReportM Slide8B { get; set; }
        public List<MonthlyReportM> MonthlyGraph { get; set; }
        public List<MonthlyReportM> QuaterlyGraph { get; set; }
        public List<MonthlyReportM> ContributionGraph { get; set; }


        public int POID { get; set; }
        public int UserID { get; set; }
        public int No { get; set; }
        public int IsDraft { get; set; }
        public int RevisionNo { get; set; }
        public int AddedBy { get; set; }
        public int MRID { get; set; }
        public int MRNO { get; set; }
        public int MonthID { get; set; }
        public int HYMonthID { get; set; }
        public int SlideID { get; set; }
        public string WorkYear { get; set; }
        public string MRDate { get; set; }
        public string SalesPerson_Name { get; set; }

        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public int SrNo { get; set; }
        public string Point { get; set; }
        public string ProjName { get; set; }
        public decimal ProjAmount { get; set; }
        public string DisProjAmount { get; set; }
        public decimal SQM { get; set; }
        public int ProbabiltyID { get; set; }
        public string Probabilty { get; set; }
        public string ExpVal { get; set; }
        public string GlazierBidding { get; set; }
        public string Competitor { get; set; }
        public string Reason { get; set; }
        public string DisExpVal { get; set; }
        public string KeyAccName { get; set; }
        public string ExpSales { get; set; }
        public string Q1ExpSales { get; set; }
        public string Q2ExpSales { get; set; }
        public string Q3ExpSales { get; set; }
        public string Q4ExpSales { get; set; }
        public string DisExpSales { get; set; }
        public string CustRelationship { get; set; }
        public string ProjWorkingOn { get; set; }
        public string Strategies { get; set; }
        public string Activity { get; set; }
        public string ActivityDesc { get; set; }

        ////// Image
        public int AutoID { get; set; }
        public int DocID { get; set; }
        public int runningno { get; set; }
        public string DocumentName { get; set; }
        public string DocName { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public string SaveFilePath { get; set; }
        public string ContentType { get; set; }
        public string PreviewFilePath { get; set; }
        public string UploadFor { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SearchCriteria { get; set; }
        public string Search { get; set; }
        public string Month { get; set; }
        public string NextMonth { get; set; }
        public string NextMonth1 { get; set; }
        public string Year { get; set; }
        public string AddedByName { get; set; }
        public string ChallengesFaced { get; set; }
        public string PotentialSol { get; set; }

        ////  3-10-23
        public decimal Target { get; set; }
        public decimal Achive { get; set; }
        public decimal OnGoingBal { get; set; }
        public decimal OrderInProd { get; set; }
        public decimal Percentage { get; set; }
        public decimal OpenPIAMount { get; set; }
        public decimal MonthlyTarget { get; set; }
        public decimal SalePer { get; set; }
        public decimal MarginPer { get; set; }
        public decimal StandMarginPer { get; set; }
        public int MonthNo { get; set; }
        public string Monthcode { get; set; }
        public string MonthName { get; set; }

        public string DisTarget { get; set; }
        public string DisAchive { get; set; }
        public string DisOnGoingBal { get; set; }
        public string DisOrderInProd { get; set; }
        public string QuaterName { get; set; }
        public decimal QuoaterlyTarget { get; set; }
        public int IsAchived { get; set; }
        public decimal QuaterlyPer { get; set; }
        public int FINANCIAL_QUARTER { get; set; }
        public string ProdName { get; set; }
        public string KeyPerson { get; set; }

        public string ExpClose { get; set; }
        public string Support { get; set; }
        public string NMonth { get; set; }
        public string NextYear { get; set; }
        public int HalfYNo { get; set; }
        public string HalfYcode { get; set; }
        public string HalfYName { get; set; }
        public int IsCurrentMonth { get; set; }

    }
}

