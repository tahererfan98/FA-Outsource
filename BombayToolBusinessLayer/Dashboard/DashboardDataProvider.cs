using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer;
using System.Data;
using BombayToolsEntities.BusinessEntities;

namespace BombayToolBusinessLayer.Dashboard
{
    public class DashboardDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();

        public BO.AdminDashboard GetDashboardData()
        {
            DataSet Stats = new DataSet();
            BO.AdminDashboard ContainerDL = new BO.AdminDashboard();
            List<BO.StreakData> Streak = new List<BO.StreakData>();
            int Pending = 0;
            DataTable dt1 = new DataTable();
            Stats = BTdatamanager.GetDashboardData();
            
            BO.AdminDashboardCount CountBL = new BO.AdminDashboardCount();
            DataTable CountDL = new DataTable();
            DataTable PendingDL = new DataTable();
            DataTable StreakDL = new DataTable();

            CountDL = Stats.Tables[0];
            PendingDL = Stats.Tables[1];
            StreakDL = Stats.Tables[2];

            if (CountDL.Rows.Count != 0)
            {
                foreach (DataRow row in CountDL.Rows)
                {
                    CountBL.Principal = Convert.ToInt32(row["Principal"]);
                    CountBL.Sector = Convert.ToInt32(row["Sector"]);
                    CountBL.Industry = Convert.ToInt32(row["Industry"]);
                    CountBL.Company = Convert.ToInt32(row["Company"]);
                }
            }
            if (PendingDL.Rows.Count != 0)
            {
                foreach (DataRow row in PendingDL.Rows)
                {
                    Pending = Convert.ToInt32(row["PendingApproval"]);
                }
            }
            if (StreakDL.Rows.Count != 0)
            {
                foreach (DataRow row in StreakDL.Rows)
                {
                    BO.StreakData StreakD = new BO.StreakData();
                    StreakD.ID = Convert.ToInt32(row["Count"]);
                    StreakD.Name = Convert.ToString(row["EmpName"]);
                    StreakD.Type = Convert.ToInt32(row["ID"]);
                    Streak.Add(StreakD);
                }
            }
            BO.AdminDashboard Data = new BO.AdminDashboard();
            Data.Count = CountBL;
            Data.PendingApproval = Pending;
            Data.StreakDataList = Streak;
            return Data;
        }

        public List<BO.CompanyDetail> GetCompanyListForSelectedPrincipal(int type, int id)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetCompanyListForSelectedPrincipal(type,id);
            List<BO.CompanyDetail> dataBL = new List<BO.CompanyDetail>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.CompanyDetail data = new BO.CompanyDetail();
                    data.CompanyID = Convert.ToInt32(row["CompanyID"]);
                    data.Company = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.LocationID = Convert.ToInt32(row["LocationId"]);
                    dataBL.Add(data);
                }
            }
            return dataBL;
        }



        public List<BO.Principal> GetPrincipalDetail()
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetPrincipalDetail();
            List<BO.Principal> principalBL = new List<BO.Principal>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.Principal data = new BO.Principal();
                    data.PrincipalID = Convert.ToInt32(row["ID"]);
                    data.PrincipalName = Convert.ToString(row["Name"]);
                    data.PrincipalCount = Convert.ToInt32(row["TotalCount"]);

                    principalBL.Add(data);
                }
            }
            return principalBL;
        }


        public List<BO.Sector> GetSectorDetail()
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetSectorDetail();
            List<BO.Sector> SectorBL = new List<BO.Sector>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.Sector data = new BO.Sector();
                    data.SectorID = Convert.ToInt32(row["ID"]);
                    data.SectorName = Convert.ToString(row["Name"]);
                    data.SectorCount = Convert.ToInt32(row["TotalCount"]);

                    SectorBL.Add(data);
                }
            }
            return SectorBL;
        }

        public List<BO.Industry> GetIndustryDetail()
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetIndustryDetail();
            List<BO.Industry> IndustryBL = new List<BO.Industry>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.Industry data = new BO.Industry();
                    data.IndustryId = Convert.ToInt32(row["ID"]);
                    data.IndustryName = Convert.ToString(row["Name"]);
                    data.IndustryCount = Convert.ToInt32(row["TotalCount"]);

                    IndustryBL.Add(data);
                }
            }
            return IndustryBL;
        }

        public List<BO.StreakData> GetStreakData(int ID)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetStreakData(ID);
            List<BO.StreakData> streakDataBL = new List<BO.StreakData>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.StreakData data = new BO.StreakData();
                    data.ID = Convert.ToInt32(row["ID"]);
                    data.Name = Convert.ToString(row["Name"]);
                    data.Stage = Convert.ToString(row["Stage"]);
                    data.Probabilty = Convert.ToDouble(row["Probabilty"]);
                    data.DealSize = Convert.ToString(row["DealSize"]);
                    data.LeadSource = Convert.ToString(row["LeadSource"]);
                    data.Vertical = Convert.ToString(row["Vertical"]);
                    data.CompanyFromMaster = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.Principal = Convert.ToString(row["Principal"]);
                    data.Sector = Convert.ToString(row["SectorName"]);
                    data.Industry = Convert.ToString(row["Industry"]);
                    data.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                    data.IndustryID = Convert.ToInt32(row["IndustryID"]);
                    data.SectorID = Convert.ToInt32(row["SectorID"]);
                    data.CompanyID = Convert.ToInt32(row["CompanyID"]);
                    streakDataBL.Add(data);
                }
            }
            return streakDataBL;
        }
        public List<BO.StreakData> GetStreakDataStageWise(int ID, string Stage)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetStreakDataStageWise(ID, Stage);
            List<BO.StreakData> streakDataBL = new List<BO.StreakData>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.StreakData data = new BO.StreakData();
                    data.ID = Convert.ToInt32(row["ID"]);
                    data.Name = Convert.ToString(row["Name"]);
                    data.Stage = Convert.ToString(row["Stage"]);
                    data.Probabilty = Convert.ToDouble(row["Probabilty"]);
                    data.DealSize = Convert.ToString(row["DealSize"]);
                    data.LeadSource = Convert.ToString(row["LeadSource"]);
                    data.Vertical = Convert.ToString(row["Vertical"]);
                    data.CompanyFromMaster = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.Principal = Convert.ToString(row["Principal"]);
                    data.Sector = Convert.ToString(row["SectorName"]);
                    data.Industry = Convert.ToString(row["Industry"]);
                    data.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                    data.IndustryID = Convert.ToInt32(row["IndustryID"]);
                    data.SectorID = Convert.ToInt32(row["SectorID"]);
                    data.CompanyID = Convert.ToInt32(row["CompanyID"]);
                    streakDataBL.Add(data);
                }
            }
            return streakDataBL;
        }


        public List<BO.StreakData> GetStreakStages(int ID)
        {
            DataSet dt1 = new DataSet();
            DataTable dt = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetStreakStages(ID);
            List<BO.StreakData> IndustryBL = new List<BO.StreakData>();
            dt = dt1.Tables[1];
            int i = 0;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    i++;
                    BO.StreakData data = new BO.StreakData();
                    data.SrNo = i;
                    data.Stage = Convert.ToString(row["Stage"]);


                    IndustryBL.Add(data);
                }
            }
            return IndustryBL;
        }

        public List<BO.SearchResult> GetSearchResult(string searchText)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetSearchResult(searchText);
            List<BO.SearchResult> logs = new List<BO.SearchResult>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.SearchResult data = new BO.SearchResult();
                    data.Header = Convert.ToString(row["Header"]);
                    data.Body = Convert.ToString(row["Body"]);
                    data.Icon = Convert.ToString(row["ICON"]);
                    data.PrimaryID = Convert.ToInt32(row["PrimaryID"]);
                    data.SecondaryID = Convert.ToInt32(row["SecondayID"]);
                    data.TypeID = Convert.ToInt32(row["Type"]);
                    logs.Add(data);
                }
            }
            return logs;
        }

        public List<BO.ActivityLog> GetUserActivityLog(int userID, DateTime fromDate, DateTime toDate)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetUserActivityLog(userID, fromDate, toDate);
            List<BO.ActivityLog> activityLogs = new List<BO.ActivityLog>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.ActivityLog data = new BO.ActivityLog();
                    data.ActivityDesc = Convert.ToString(row["ACTIVITYDESC"]);
                    data.AddedBy = Convert.ToString(row["Name"]);
                    data.AddedOn = Convert.ToString(row["AddedOn"]);  
                    activityLogs.Add(data);
                }
            }
            return activityLogs;
        }



        public BO.SalesPersonDashboard GetSalaespersonDetail(int id)
        {
            DataSet Stats = new DataSet();
            BO.SalesPersonDashboard ContainerDL = new BO.SalesPersonDashboard();
            DataTable dt1 = new DataTable();
            Stats = BTdatamanager.GetSalaespersonDetail(id);
            List<BO.EnquiryList> enqListBL = new List<BO.EnquiryList>();
            List<BO.QuotationMaster> quotBL = new List<BO.QuotationMaster>();
            List<BO.SalesPersonWeeklyCount> reportBL = new List<BO.SalesPersonWeeklyCount>();
            DataTable enqDL = new DataTable();
            DataTable quotDL = new DataTable();
            DataTable reportDL = new DataTable();
            int i = 0;
            enqDL = Stats.Tables[0];
            quotDL = Stats.Tables[1];
            reportDL = Stats.Tables[2];
            if (enqDL.Rows.Count != 0)
            {
                foreach (DataRow row in enqDL.Rows)
                {
                    BO.EnquiryList data = new BO.EnquiryList();
                    data.EnqNO = Convert.ToString(row["EnquiryNo"]);
                    data.DisplayDate = Convert.ToString(row["DisplayDate"]);
                    data.Company = Convert.ToString(row["CompanyName"]);
                    data.SalesCoordinatorName = Convert.ToString(row["SalesCoordinator"]);
                    data.Status = Convert.ToString(row["Status"]);
                    enqListBL.Add(data);
                }
            }
            if (quotDL.Rows.Count != 0)
            {
                foreach (DataRow row in quotDL.Rows)
                {
                    BO.QuotationMaster data = new BO.QuotationMaster();
                    data.QTNNO = Convert.ToInt32(row["QuotationNo"]);
                    data.Industry = Convert.ToString(row["QuotID"]);
                    data.QuotCreated = Convert.ToString(row["DisplayDate"]);
                    data.Company = Convert.ToString(row["CompanyName"]);
                    data.SalesCoordinatorName = Convert.ToString(row["SalesCoordinator"]);
                    data.Total = Convert.ToInt64(row["Total"]);
                    quotBL.Add(data);
                }
            }
            if (reportDL.Rows.Count != 0)
            {
                foreach (DataRow row in reportDL.Rows)
                {
                    i = i + 1;
                    BO.SalesPersonWeeklyCount data = new BO.SalesPersonWeeklyCount();
                    data.Index = i;
                    data.FromDate = Convert.ToString(row["FromDate"]);
                    data.ToDate = Convert.ToString(row["ToDate"]);
                    data.EnqTotal = Convert.ToInt32(row["EnqCount"]);
                    data.EnqOpen = Convert.ToInt32(row["OpenEnq"]);
                    data.EnqClose = Convert.ToInt32(row["CloseEnq"]);
                    data.QuotTotal = Convert.ToInt32(row["QuotCount"]);
                    data.QuotOpen = Convert.ToInt32(row["OpenQuot"]);
                    data.QuotClose = Convert.ToInt32(row["CloseQuot"]);
                    data.Amount = Convert.ToString(row["Amount"]);
                    reportBL.Add(data);
                }
            }
            BO.SalesPersonDashboard Data = new BO.SalesPersonDashboard();
            Data.EnquiryList = enqListBL;
            //Data.QuotationList = quotBL;
            Data.SaleReport = reportBL;
            return Data;
        }

        public BO.SalesPersonDashboard GetSalaespersonDashboardDetail(int id)
        {
            DataSet Stats = new DataSet();
            BO.SalesPersonDashboard ContainerDL = new BO.SalesPersonDashboard();
            DataTable dt1 = new DataTable();
            Stats = BTdatamanager.GetSalaespersonDashboardDetail(id);
            List<BO.EnquiryList> enqListBL = new List<BO.EnquiryList>();
            List<BO.QuotationMaster> quotBL = new List<BO.QuotationMaster>();
            List<BO.StreakData> Streak = new List<BO.StreakData>();
            DataTable OpenEnq = new DataTable();
            DataTable OpenQuot = new DataTable();
            DataTable enqDL = new DataTable();
            DataTable quotDL = new DataTable();
            DataTable StreakDL = new DataTable();
            //int i = 0;
            OpenEnq = Stats.Tables[0];
            OpenQuot = Stats.Tables[1];
            enqDL = Stats.Tables[2];
            quotDL = Stats.Tables[3];
            StreakDL = Stats.Tables[4];
            if (enqDL.Rows.Count != 0)
            {
                foreach (DataRow row in enqDL.Rows)
                {
                    BO.EnquiryList data = new BO.EnquiryList();
                    data.EnqNO = Convert.ToString(row["EnquiryNo"]);
                    data.DisplayDate = Convert.ToString(row["DisplayDate"]);
                    data.Company = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.SalesCoordinatorName = Convert.ToString(row["SalesCoordinator"]);
                    data.Status = Convert.ToString(row["Status"]);
                    enqListBL.Add(data);
                }
            }
            if (quotDL.Rows.Count != 0)
            {
                foreach (DataRow row in quotDL.Rows)
                {
                    BO.QuotationMaster data = new BO.QuotationMaster();
                    data.QTNNO = Convert.ToInt32(row["QuotationNo"]);
                    data.Industry = Convert.ToString(row["QuotID"]);
                    data.QuotCreated = Convert.ToString(row["DisplayDate"]);
                    data.Company = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.SalesCoordinatorName = Convert.ToString(row["SalesCoordinator"]);
                    data.Total = Convert.ToInt64(row["Total"]);
                    quotBL.Add(data);
                }
            }
            BO.SalesPersonDashboard Data = new BO.SalesPersonDashboard();
            if (OpenEnq.Rows.Count != 0)
            {
                foreach (DataRow row in OpenEnq.Rows)
                {
                    Data.OpenEnquiry = Convert.ToInt32(row["OpenEnquiry"]);
                }
            }
            if (OpenQuot.Rows.Count != 0)
            {
                foreach (DataRow row in OpenQuot.Rows)
                {
                    Data.OpenQuotation = Convert.ToInt32(row["OpenQuotation"]);
                }
            }
            if (StreakDL.Rows.Count != 0)
            {
                foreach (DataRow row in StreakDL.Rows)
                {
                    BO.StreakData StreakD = new BO.StreakData();
                    StreakD.ID = Convert.ToInt32(row["Count"]);
                    StreakD.Name = Convert.ToString(row["EmpName"]);
                    StreakD.Type = Convert.ToInt32(row["ID"]);
                    Streak.Add(StreakD);
                }
            }
            Data.EnquiryList = enqListBL;
            //Data.QuotationList = quotBL;
            Data.StreakDataList = Streak;
            
            return Data;
        }

        public BO.StreakData GetStreakDataForID(int iD)
        {
            BO.StreakData data = new BO.StreakData();
            DataTable dt1 = new DataTable();
            dt1 = BTdatamanager.GetStreakDataForID(iD);
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    data.ID = Convert.ToInt32(row["ID"]);
                    data.Name = Convert.ToString(row["Name"]);
                    data.Stage = Convert.ToString(row["Stage"]);
                    data.Probabilty = Convert.ToDouble(row["Probabilty"]);
                    data.DealSize = Convert.ToString(row["DealSize"]);
                    data.LeadSource = Convert.ToString(row["LeadSource"]);
                    data.Vertical = Convert.ToString(row["Vertical"]);
                    data.CompanyFromMaster = Convert.ToString(row["CompanyName"]);
                    data.Location = Convert.ToString(row["Location"]);
                    data.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                    data.SectorID = Convert.ToInt32(row["SectorID"]);
                    data.IndustryID = Convert.ToInt32(row["IndustryID"]);
                    data.CompanyID = Convert.ToInt32(row["CompanyID"]);
                    data.LocationID = Convert.ToInt32(row["LocationID"]);
                }
            }
            return data;
        }


        public BO.AdminDashboardCount DashboardReport(DateTime from)
        {
            DataSet Stats = new DataSet();
        
            Stats = BTdatamanager.DashboardReport(from);
            List<BO.DailyQuotationCount> QuotBl = new List<BO.DailyQuotationCount>();
            List<BO.DailyQuotationCount> PipeBl = new List<BO.DailyQuotationCount>();
            DataTable QuotDL = new DataTable();
            DataTable PipeDL = new DataTable();

            //int i = 0;
            QuotDL = Stats.Tables[0];
            PipeDL = Stats.Tables[1];
            if (QuotDL.Rows.Count != 0)
            {
                foreach (DataRow row in QuotDL.Rows)
                {
                    BO.DailyQuotationCount data = new BO.DailyQuotationCount();
                    data.EmployeeName = Convert.ToString(row["EmployeeName"]);
                    data.Count = Convert.ToInt32(row["Count"]);
                    data.UserID = Convert.ToInt32(row["UserID"]);
                    QuotBl.Add(data);
                }
            }
            if (PipeDL.Rows.Count != 0)
            {
                foreach (DataRow row in PipeDL.Rows)
                {
                    BO.DailyQuotationCount data = new BO.DailyQuotationCount();
                    data.EmployeeName = Convert.ToString(row["EmployeeName"]);
                    data.Count = Convert.ToInt32(row["Count"]);
                    data.UserID = Convert.ToInt32(row["UserID"]);
                    PipeBl.Add(data);
                }
            }

            BO.AdminDashboardCount Adm = new BO.AdminDashboardCount();
            Adm.DailyQuot = QuotBl;
            Adm.PipelineCount = PipeBl;
            return Adm;
        }

        public BO.SalesDashboard GetSalesDashboardData(int userID, string logType)
        {
            DataSet Stats = new DataSet();

            Stats = BTdatamanager.GetSalesDashboardData(userID, logType);
            BO.SalesDashboard data = new BO.SalesDashboard();
            List<BO.GraphData> ghBL = new List<BO.GraphData>();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            //int i = 0;
            table1 = Stats.Tables[0];
            table2 = Stats.Tables[1];
            if (table1.Rows.Count != 0)
            {
                foreach (DataRow row in table1.Rows)
                {
                    data.QUOTATIONCOUNT = Convert.ToInt32(row["QUOTATIONCOUNT"]);
                    data.QUOTATIONAMOUNT = Convert.ToInt32(row["QUOTATIONAMOUNT"]);
                    data.LEADCOUNT = Convert.ToInt32(row["LEADCOUNT"]);
                    data.LEADAMOUNT = Convert.ToInt32(row["LEADAMOUNT"]);
                    data.OPPORTUNITYCOUNT = Convert.ToInt32(row["OPPORTUNITYCOUNT"]);
                    data.OPPORTUNITYAMOUNT = Convert.ToInt32(row["OPPORTUNITYAMOUNT"]);
                    data.ORDERCLOSEDCOUNT = Convert.ToInt32(row["ORDERCLOSEDCOUNT"]);
                    data.ORDERCLOSEDAMOUNT = Convert.ToInt32(row["ORDERCLOSEDAMOUNT"]);
                }
            }
            if (table2.Rows.Count != 0)
            {
                int i = 0;
                foreach (DataRow row in table2.Rows)
                {
                    BO.GraphData gh = new BO.GraphData();
                    i++;
                    gh.SrNo =i;
                    gh.MonthNo = Convert.ToInt32(row["MonthNo"]);
                    gh.MonthCode = Convert.ToString(row["MonthCode"]);
                    gh.YearNo = Convert.ToInt32(row["YearNo"]);
                    gh.Count = Convert.ToString(row["Count"]);
                    gh.DealSize = Convert.ToInt32(row["DealSize"]);
                    ghBL.Add(gh);
                }
            }

            BO.AdminDashboardCount Adm = new BO.AdminDashboardCount();
            data.Graph = ghBL;
            return data;
        }

        public List<ActivityLog> GetActivityLogSummary(string fromDate, string toDate, int userID, int tl_id, int sessionID, string logType)
        {
            try
            {
                DataTable dt1 = new DataTable();
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                dt1 = BTdatamanager.GetActivityLogSummary(fromDate, toDate, userID, tl_id, sessionID, logType);
                List<BO.ActivityLog> logDataBL = new List<BO.ActivityLog>();
                if (dt1.Rows.Count != 0)
                {
                    int i = 0;
                    foreach (DataRow row in dt1.Rows)
                    {
                        BO.ActivityLog data = new BO.ActivityLog();
                        i++;
                        data.SrNo = i;
                        data.ID = Convert.ToInt32(row["ID"]);
                        data.UserID = Convert.ToInt32(row["UserID"]);
                        data.ActivityName = Convert.ToString(row["ActivityName"]);
                        data.ActivityDate = Convert.ToString(row["ActivityDate"]);
                        data.Date = Convert.ToDateTime(row["Date"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        logDataBL.Add(data);
                    }
                }
                return logDataBL;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
