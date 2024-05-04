using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class User
    {
        public int ID { get; set; }
        public int index { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public Boolean Status { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string DisplayDateofJoining { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public int AddedBy { get; set; }
        public string AddedByName { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedOnDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }

        public string EmployeeName { get; set; }
        public string Body { get; set; }
        public string LastLogin { get; set; }
    }
}
