using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class NotificationData
    {
        public int SrNo { get; set; }
        public string NoticiationData { get; set; }
        public int DependentID { get; set; }
        public string Datetime { get; set; }
        public int NotificationID { get; set; }
        public string URL { get; set; }
        public string NoticiationTitle { get; set; }
    }
}
