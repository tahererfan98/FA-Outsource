using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Country
    {
        public bool IsNew { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int AddedBY { get; set; }
        public DateTime AaddedON { get; set; }
        public bool IsCancel { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }
        public int ModifiedUserID { get; set; }
        public DateTime ModifiedON { get; set; }
        public bool IsActive { get; set; }
    }
}
