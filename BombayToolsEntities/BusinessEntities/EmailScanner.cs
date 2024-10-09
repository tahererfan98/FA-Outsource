using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EmailScanner
    {
        public string MessageID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int IsRegistered { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int ContactID { get; set; }
        public int AddedBY { get; set; }

        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string PlainText { get; set; }
        public DateTime DateSent { get; set; }
        public string Display { get; set; }
        public string ID { get; set; }
        public string ThreadID { get; set; }
    }
}
