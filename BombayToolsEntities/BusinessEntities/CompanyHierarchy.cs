using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CompanyHierarchy
    {
        public CompanyHierarchy()
        {
            Companies = new List<Company>();
            Locations = new List<Company>();
            Persons = new List<Company>();
        }
        public List<Company> Companies { get; set; }
        public List<Company> Locations { get; set; }
        public List<Company> Persons { get; set; }
    }
}
