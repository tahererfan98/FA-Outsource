using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Attendance
    {
        public int SrNo { get; set; }
        public int ID { get; set; }
        public string Employee_DeviceID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime InTime { get; set; }
        public bool IsSelected { get; set; }
        public DateTime OutTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string AddedOn { get; set; }
        public string InTimeFromExcel { get; set; }
        public string OutTimeFromExcel { get; set; }
        public string DurationTimeFromExcel { get; set; }

        //public string port { get; set; }
    }
}
