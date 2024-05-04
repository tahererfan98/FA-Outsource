using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ImportDVReport
    {

        public string Discussion { get; set; }
        public int DailyVisitID { get; set; }
        public string DailyVisitNo { get; set; }
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
        public int VerticalID { get; set; }
        public string Vertical { get; set; }
        public string NextActionDate { get; set; }
        public string DailyVisitDate { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime AddedOn { get; set; }
        public string DisplayDailyVisitDate { get; set; }
        public int AddedBy { get; set; }
        public Boolean IsCancel { get; set; }
        public int CancelledBy { get; set; }
        public DateTime CancelledOn { get; set; }

    }
}
