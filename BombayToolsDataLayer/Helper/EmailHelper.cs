using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Web;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Mail;
//using System.Net.Mail.MailMessage;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Data;

namespace BombayToolsDataLayer.Helper
{
    public class EmailHelper
    {
        public bool SendEMail(string strToIDs, string strFrom, string strCcIDs, string strBccIDs, string strSubject, string strBodyText)
        {
            string strmaildomain = "";
            int intPortNo;
            //string strFrom = "";
            string strMailPswrd = "";
            bool isMessageSent = false;
            MailMessage MailMessage = new MailMessage();


            strmaildomain = "mail.phoenixkreations.in";
            intPortNo = 25;
            strFrom = "task@phoenixkreations.insd";
            strMailPswrd = "gtgV789&";

            // strToIDs = strMailTo
            // strCcIDs = "hitesh@phoenixkreations.com"
            //MailAddress mailAddress = new MailAddress(strFrom);
            // strSubject = "Test"
            // strBodyText = "Test"
            MailAddress mailAddress = new MailAddress("Do-Not-Reply | Phoenix Kreations <do-not-reply@phoenixkreations.com>");


            MailMessage.From = mailAddress;

            MailMessage.To.Add((strToIDs));
            MailMessage.CC.Add(strCcIDs);
            MailMessage.Bcc.Add(strBccIDs);
            //MailMessage.Attachments.Add(attachByte);
            MailMessage.Subject = strSubject;
            MailMessage.IsBodyHtml = true;
            MailMessage.Body = strBodyText;

            SmtpClient smtpClient = new SmtpClient(strmaildomain, intPortNo);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(strFrom, strMailPswrd);
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = credentials;
            try
            {
                smtpClient.Send(MailMessage);
                isMessageSent = true;
            }
            catch (Exception ex)
            {
                isMessageSent = false;
                throw ex;
            }
            return isMessageSent;

        }
    }
}
