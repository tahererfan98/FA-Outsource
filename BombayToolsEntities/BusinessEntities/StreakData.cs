using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class StreakData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public double Probabilty { get; set; }
        public string DealSize { get; set; }
        public string LeadSource { get; set; }
        public string CompanyName { get; set; }
        public string Vertical { get; set; }
        public string CompanyFromMaster { get; set; }
        public string Location { get; set; }
        public int LocationID { get; set; }
        public int CompanyID { get; set; }
        public int Type { get; set; }
        public int IsUpdate { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }

        public int PrincipalID { get; set; }
        public int IndustryID { get; set; }
        public int SectorID { get; set; }
        public string Principal { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public int SrNo { get; set; }
        public int TypeOfData { get; set; }
        
    }
}
