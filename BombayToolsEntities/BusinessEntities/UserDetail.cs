using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class UserDetail
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int SalesPersonID { get; set; }
        public string MailID { get; set; }
        public int SrNo { get; set; }
        public int TL_ID { get; set; }
        public string EMPID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string LoginType { get; set; }
        public string DepType { get; set; }
        public string EmailID { get; set; }
        public string Token { get; set; }
        public bool rememberme { get; set; }

        public string LoginErrorMessage { get; set; }


    }
}
