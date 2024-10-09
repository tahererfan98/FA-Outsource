using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Users
    {
        public Users()
        {
            MenuList = new List<Users>();
            SubMenuList = new List<Users>();
        }
        public List<Users> MenuList { get; set; }
        public List<Users> SubMenuList { get; set; }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string EmpID { get; set; }
        public string ContactNo { get; set; }
        public int MenuID { get; set; }
        public int SubMenuID { get; set; }
        public string SubMenu { get; set; }
        public string MenuName { get; set; }
        public int IsAccess { get; set; }
        public int Count { get; set; }
        public int AddedBy { get; set; }
        public string AddedOn { get; set; }
        public bool Status { get; set; }
    }
}
