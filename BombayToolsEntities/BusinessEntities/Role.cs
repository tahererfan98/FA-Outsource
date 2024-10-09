using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int AddedBy { get; set; }
        public int SrNo { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
