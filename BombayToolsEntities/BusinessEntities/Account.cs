using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Account
    {
        public bool IsNew { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string GstNO { get; set; }
        public int PanStatus { get; set; }
        public int GstRegistered { get; set; }
        public string RegisterationDate { get; set; }
        public string PanNO { get; set; }
        public int AddedBY { get; set; }
        public DateTime AddedON { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsCancel { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }
        public bool IsActive { get; set; }
        public int DataAdded { get; set; }
    }
}
