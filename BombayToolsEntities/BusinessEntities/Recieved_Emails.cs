using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Recieved_Emails
    {
        public Recieved_Emails()
        {
            this.Attachments = new List<Email_Attachment>();
        }
        public int MessageNumber { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string PlainText { get; set; }
        public DateTime DateSent { get; set; }
        public string Display { get; set; }
        public string ID { get; set; }
        public string ThreadID { get; set; }

        public int IsRead { get; set; }
        public int Addedby { get; set; }
        public string TokenPath { get; set; }
        public string Snippets { get; set; }
        public List<Email_Attachment> Attachments { get; set; }
    }
}
