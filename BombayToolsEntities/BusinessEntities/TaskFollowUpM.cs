using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class TaskFollowUpM
    {
        public int SrNo { get; set; }
        public int TaskID { get; set; }
        public int IsCompleted { get; set; }
        public int LocationID { get; set; }
        public int TID { get; set; }
        public int AddedBy { get; set; }
        public int Title { get; set; }
        public int TotalFollowUp { get; set; }
        public string TNo { get; set; }
        public string TaskType { get; set; }
        public string LocationName { get; set; }
        public string TaskName { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string PersonName { get; set; }
        public string SalesPersonName { get; set; }
        public decimal Amount { get; set; }
        public string ScheduleType { get; set; }
        public string Description { get; set; }
        public string BackgroundColor { get; set; }
        public string Editable { get; set; }
        public string TextColor { get; set; }
        public string order { get; set; }
        public string Firstdate { get; set; }
        public string IsVisited { get; set; }
        public string Remarks { get; set; }
        public string CustomerName { get; set; }
        public string DisplayTaskDate { get; set; }
        public string TaskDate { get; set; }
        public string Start { get; set; }
        public DateTime tod { get; set; }
        public DateTime fromd { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
