using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class LoggedDetails
    {
        public LoggedDetails()
        {
            Customer = new List<UserDetail>();
            CSE = new List<UserDetail>();
        }
        public List<UserDetail> Customer { get; set; }
        public List<UserDetail> CSE { get; set; }
        public UserDetail User { get; set; }
    }
}
