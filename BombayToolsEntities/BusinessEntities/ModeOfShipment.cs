using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ModeOfShipment
    {
        public int ModeID { get; set; }
        public string ModeName { get; set; }
        public int HeadingID { get; set; }
        public string Heading { get; set; }
        public int PODID { get; set; }
        public string PODName { get; set; }
        public int TermID { get; set; }
        public string Term { get; set; }
        public int StausID { get; set; }
        public string StatusName { get; set; }
        public int LicenseID { get; set; }
        public string LicenseNo { get; set; }

        public int ProjectID { get; set; }
        public string Project_Name { get; set; }
    }
}
