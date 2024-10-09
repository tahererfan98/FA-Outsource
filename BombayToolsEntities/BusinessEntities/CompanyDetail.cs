using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CompanyDetail
    {
        public CompanyDetail()
        {
            ContactPersonD = new List<ContactPerson>();
        }
        public int CompanyID { get; set; }
        public string Company { get; set; }
        public string Principal { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public int LocationID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
        public int PanStatus { get; set; }
        public int GSTRegistered { get; set; }
        public string PanNo { get; set; }
        public string GSTNo { get; set; }
        public string RegisterDate { get; set; }
        public List<ContactPerson> ContactPersonD { get; set; }












    }
}
