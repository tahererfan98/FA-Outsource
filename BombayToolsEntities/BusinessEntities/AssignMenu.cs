using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AssignMenu
    {
        public AssignMenu()
        {
            user = new User();
            menuList = new List<SubmenuInfo>();
        }
        public User user { get; set; }
        public List<SubmenuInfo> menuList { get; set; }
    }
}
