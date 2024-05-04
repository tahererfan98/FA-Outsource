using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CalendarEvent
    {
        public int ID { get; set; }
        public string CalendarID { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime DateM { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Attendees { get; set; }
        public int Pending { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
