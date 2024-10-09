using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Pop3;
using OpenPop.Mime;
using BombayToolsEntities.BusinessEntities;

namespace BombayToolBusinessLayer.Email
{
    [Serializable]
    public class Email
    {
        public Email()
        {
            this.Attachments = new List<Attachment>();
        }
        public int MessageNumber { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateSent { get; set; }
        public List<Attachment> Attachments { get; set; }

    }

    [Serializable]
    public class Attachment
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }


    public class ReadEmail
    {
        public List<Email> Read_Emails(string popConnect, string userEmailID, string password)
        {
            Pop3Client pop3Client;

            pop3Client = new Pop3Client();
            pop3Client.Connect(popConnect, 995, true); //pop.gmail.com "pop-mail.outlook.com"
            pop3Client.Authenticate(userEmailID, password);

            int count = pop3Client.GetMessageCount();
            List<Email> emails = new List<Email>();
            //int counter = 0;
            for (int i = count; i > 0; i--)
            {

                Message message = pop3Client.GetMessage(i);

                Email email = new Email()
                {
                    MessageNumber = i,
                    Subject = message.Headers.Subject,
                    DateSent = message.Headers.DateSent,
                    FromEmail = string.Format(message.Headers.From.Address),
                    FromName = string.Format(message.Headers.From.DisplayName),
                };
                MessagePart body = message.FindFirstPlainTextVersion();
                if (body != null)
                {
                    email.Body = body.GetBodyAsText();
                }
                else
                {
                    body = message.FindFirstPlainTextVersion();
                    if (body != null)
                    {
                        email.Body = body.GetBodyAsText();
                    }
                }
                List<MessagePart> attachments = message.FindAllAttachments();

                foreach (MessagePart attachment in attachments)
                {
                    email.Attachments.Add(new Attachment
                    {
                        FileName = attachment.FileName,
                        ContentType = attachment.ContentType.MediaType,
                        Content = attachment.Body
                    });
                }
                emails.Add(email);
                //counter++;
                //if (counter > 2)
                //{
                //    break;
                //}
            }

            return emails;
        }
    }
}

