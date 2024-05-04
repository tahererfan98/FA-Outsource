using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class LoginEntites
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int CompanyID { get; set; }

        public int VesselID { get; set; }

        public string UserType { get; set; }

        public DateTime AddedDATE { get; set; }

        public DateTime UpdatedDATE { get; set; }

        public int AddedBy { get; set; }

        public int ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public string LoginErrorMessage { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserImage { get; set; }
        public string Designation { get; set; }

        public bool rememberme { get; set; }

        public int VendorID { get; set; }

        public int AdminID { get; set; }

        public string CompanyName { get; set; }

        public string VesselName { get; set; }

    }
}
