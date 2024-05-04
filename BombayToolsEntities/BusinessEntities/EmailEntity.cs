using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EmailEntity
    {

        public int QuotationNo { get; set; }
        public int RevisionNo { get; set; }
        public string RecordNo { get; set; }
        public string ENQNO { get; set; }
        public string PINNO { get; set; }
        public string QuotID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string message { get; set; }
        public string Path { get; set; }
        public byte[] Attachment { get; set; }
        public string MailID { get; set; }
        public string ContentType { get; set; }
        public string Dear { get; set; }
        public string DocFileName { get; set; }
        public string FilePath { get; set; }
        public string MailDomain { get; set; }
        public string MailID_From { get; set; }
        public string Pswrd { get; set; }
        public int PortNo { get; set; }
        public Boolean MailSent { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
