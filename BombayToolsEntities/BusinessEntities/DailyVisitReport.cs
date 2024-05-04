using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DailyVisitReport
    {
        public string Discussion { get; set; }
        public int VisitID { get; set; }
        public int IsEditable { get; set; }
        public int IsSameUser { get; set; }
        public int DailyVisitID { get; set; }
        public string DailyVisitNo { get; set; }
        public string AddedByName { get; set; }
        public string NextAction { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public int SrNo { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string DisplayNextActionDate { get; set; }
        public string DisplayAddedOn { get; set; }
        public string Tags { get; set; }
        public int VerticalID { get; set; }
        public string Vertical { get; set; }
        public DateTime NextActionDate { get; set; }
        public DateTime DailyVisitDate { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime AddedOn { get; set; }
        public string DisplayDailyVisitDate { get; set; }
        public int AddedBy { get; set; }
        public Boolean IsCancel { get; set; }
        public int CancelledBy { get; set; }
        public DateTime CancelledOn { get; set; }
        public int AutoID { get; set; }
        public int TagCount { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EMPID { get; set; }
    }
}
