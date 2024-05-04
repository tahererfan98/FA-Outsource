using System;
using System.Collections.Generic;
using System.Web;
using DBView = BombayToolBusinessLayer.EmailManager;
using BO = BombayToolsEntities.BusinessEntities;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using DBViewE = BombayToolBusinessLayer.Enquiry;

using System.Linq;
using System.Threading;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

using BombayTools.Service;
using BombayTools.Filters;



namespace BombayTools.Controllers.EmailManager
{
    [UserAuthenticationFilter]
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
        {
            get { return new GmailApiFilter(); }
        }
    }
    [UserAuthenticationFilter]

    public class EmailManagerController : Controller
    {
         
        public  ActionResult InsertNewEvent(CancellationToken cancellationToken)
        {
            var result =  new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
                AuthorizeAsync(cancellationToken).Result;

            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

                // YOUR CODE SHOULD BE HERE..
                List<Message> messages = new List<Message>();
                UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
                request.MaxResults = 30;
                do
                {
                    try
                    {
                        ListMessagesResponse response = request.Execute();
                        messages.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;
                        if (messages.Count > 49)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                } while (!String.IsNullOrEmpty(request.PageToken));
                ViewBag.message = messages;
                List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();

                List<Message> list = new List<Message>();
                foreach (Message email in messages)
                {
                    var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                    var emailInfoResponse = emailInfoReq.Execute();

                    if (emailInfoResponse != null)
                    {
                        string from = "";
                        string date = "";
                        string subject = "";
                        string body = "";
                        var id = emailInfoResponse.Id;
                        var ThreadID = emailInfoResponse.ThreadId;

                        //loop through the headers and get the fields we need...
                        foreach (var mParts in emailInfoResponse.Payload.Headers)
                        {
                            if (mParts.Name == "Date")
                            {
                                date = mParts.Value;
                                int index = date.IndexOf("+");
                                if (index > 0)
                                    date = date.Substring(0, index);
                                int index1 = date.IndexOf("-");
                                if (index1 > 0)
                                    date = date.Substring(0, index1);
                            }
                            else if (mParts.Name == "From")
                            {
                                from = mParts.Value;
                                int index = from.IndexOf("<");
                                if (index > 0)
                                    from = from.Substring(0, index);
                            }
                            else if (mParts.Name == "Subject")
                            {
                                subject = mParts.Value;
                            }
                        }


                        BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                        eachData.Display = date;
                        eachData.FromName = from;
                        eachData.Subject = subject;
                        eachData.Body = body;
                        eachData.ID = id;
                        eachData.ThreadID = ThreadID;
                        emails.Add(eachData);
                    }



                }
                return View(emails.ToList());

            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
        {
            protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
            {
                get { return new GmailApiFilter(); }
            }
        }

        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        DBView.EmailDataProvider dashboardBussinesManager = new DBView.EmailDataProvider();

        public  UserCredential SetTokenFolderPath()
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            string tokenPath = "~/Uploads/token" + UserID + ".json";
            UserCredential credential;
            var cleantSecretPath = Server.MapPath("~/Uploads/credentials.json");
            var rootPath = Server.MapPath("~/");

            if (rootPath != null)
            {
                var credentialPath = Path.Combine(rootPath, "Credentials");
                var directoryInfo = Directory.CreateDirectory(credentialPath);
            }

            using (var stream =
                new FileStream(cleantSecretPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = Server.MapPath(tokenPath);
                credential =  GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                    int i = dashboardBussinesManager.SaveTokenPathForUser(UserID, tokenPath);
            }
            return (credential);
        }

        public UserCredential GetCredetional(string tokenPath)
        {
            UserCredential credential;
            var cleantSecretPath = Server.MapPath("~/Uploads/credentials.json");
            var rootPath = Server.MapPath("~/");

            if (rootPath != null)
            {
                var credentialPath = Path.Combine(rootPath, "Credentials");
                var directoryInfo = Directory.CreateDirectory(credentialPath);
            }

            using (var stream =
                new FileStream(cleantSecretPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = Server.MapPath(tokenPath);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            return (credential);
        }

        public List<BO.Recieved_Emails> GetMailHeader(List<Message> result)
        {
            string TokenPath = Convert.ToString(Session["tokenpath"]);
            UserCredential credential;
            if (TokenPath == null || TokenPath == "")
            {
                credential = SetTokenFolderPath();
            }
            else
            {
                credential = GetCredetional(TokenPath);
            }
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });
            List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();
            List<Message> list = new List<Message>();
            foreach (Message email in result)
            {
                var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                var emailInfoResponse = emailInfoReq.Execute();

                if (emailInfoResponse != null)
                {
                    string from = "";
                    string date = "";
                    string subject = "";
                    string body = "";
                    var id = emailInfoResponse.Id;
                    var ThreadID = emailInfoResponse.ThreadId;

                    //loop through the headers and get the fields we need...
                    foreach (var mParts in emailInfoResponse.Payload.Headers)
                    {
                        if (mParts.Name == "Date")
                        {
                            date = mParts.Value;
                            int index = date.IndexOf("+");
                            if (index > 0)
                                date = date.Substring(0, index);
                            int index1 = date.IndexOf("-");
                            if (index1 > 0)
                                date = date.Substring(0, index1);
                        }
                        else if (mParts.Name == "From")
                        {
                            from = mParts.Value;
                            int index = from.IndexOf("<");
                            if (index > 0)
                                from = from.Substring(0, index);
                        }
                        else if (mParts.Name == "Subject")
                        {
                            subject = mParts.Value;
                        }
                    }


                    BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                    eachData.Display = date;
                    eachData.FromName = from;
                    eachData.Subject = subject;
                    eachData.Body = body;
                    eachData.ID = id;
                    eachData.ThreadID = ThreadID;
                    emails.Add(eachData);
                }



            }
            return emails;
        }

        public List<BO.EmailScanner> GetScanMailResult(List<Message> result)
        {
            string TokenPath = Convert.ToString(Session["tokenpath"]);
            UserCredential credential;
            if (TokenPath == null || TokenPath == "")
            {
                credential = SetTokenFolderPath();
            }
            else
            {
                credential = GetCredetional(TokenPath);
            }
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });
            List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();
            List<Message> list = new List<Message>();
            foreach (Message email in result)
            {
                var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                var emailInfoResponse = emailInfoReq.Execute();

                if (emailInfoResponse != null)
                {
                    string from = "";
                    string date = "";
                    string subject = "";
                    string body = "";
                    var id = emailInfoResponse.Id;
                    var ThreadID = emailInfoResponse.ThreadId;

                    //loop through the headers and get the fields we need...
                    foreach (var mParts in emailInfoResponse.Payload.Headers)
                    {
                        if (mParts.Name == "Date")
                        {
                            date = mParts.Value;
                            int index = date.IndexOf("+");
                            if (index > 0)
                                date = date.Substring(0, index);
                            int index1 = date.IndexOf("-");
                            if (index1 > 0)
                                date = date.Substring(0, index1);
                        }
                        else if (mParts.Name == "From")
                        {
                            from = mParts.Value;
                            int index = from.IndexOf("<");
                            if (index > 0)
                                from = from.Substring(0, index);
                        }
                        else if (mParts.Name == "Subject")
                        {
                            subject = mParts.Value;
                        }
                        if (date != "" && from != "")
                        {
                            if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                                body = DecodeBase64String(emailInfoResponse.Payload.Body.Data);
                            else
                                body = GetNestedBodyParts(emailInfoResponse.Payload.Parts, "");

                            //now you have the data you want....

                        }
                    }
                    int index0 = body.IndexOf("<!DOCTYPE");
                    if (index0 > 0)
                    {
                        body = body.Remove(0, index0);
                    }
                    if (index0 < 0)
                    {
                        int index1 = body.IndexOf("<html");
                        if (index1 > 0)
                        {
                            body = body.Remove(0, index1);
                        }
                        else
                        {
                            int index2 = body.IndexOf("<div");
                            if (index2 > 0)
                            {
                                body = body.Remove(0, index2);
                            }
                        }

                    }

                    BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                    eachData.Display = date;
                    eachData.FromName = from;
                    eachData.Subject = subject;
                    eachData.Body = body;
                    eachData.ID = id;
                    eachData.ThreadID = ThreadID;
                    eachData.PlainText = StripHTML(body);
                    emails.Add(eachData);
                }



            }
            List<BO.EmailScanner> ScanItemList = new List<BO.EmailScanner>();
            foreach (BO.Recieved_Emails item in emails)
            {
                BO.EmailScanner ScanItem = new BO.EmailScanner();
                ScanItem.AddedBY = Convert.ToInt16(Session["userid"]);
                string ScanMessageID = item.ID;
                string ScanEmail = "";
                string ScanContact = "";
                string PlainText1 = item.PlainText;
                PlainText1 = PlainText1.Replace("\n", String.Empty);
                PlainText1 = PlainText1.Replace("\r", String.Empty);
                PlainText1 = PlainText1.Replace("\t", String.Empty);
                int si = PlainText1.IndexOf("Email:");
                //si = si + 12;
                int sj = PlainText1.IndexOf("Mobile:");
                if(si > 0 && sj > 0)
                {
                    ScanEmail = PlainText1.Remove(0, si + 7);
                    sj = ScanEmail.IndexOf("Mobile:");
                    if(sj == -1)
                    {
                        sj = ScanEmail.IndexOf("Note:");
                        if (sj == -1)
                        {
                            ScanEmail = "NA";
                        }
                        else
                        {
                            ScanEmail = ScanEmail.Substring(0, sj);
                            ScanEmail=ScanEmail.Trim();
                        }
                    }
                    else
                    {
                        ScanEmail = ScanEmail.Substring(0, sj);
                        ScanEmail=ScanEmail.Trim();
                    }


                    if (ScanEmail.ToLower().Contains('@')) {
                        //do nothing
                    }
                    else
                    {
                        ScanEmail = "NA";
                    }
                }
                else
                {
                    ScanEmail = "NA";
                }
                string PlainText2 = item.PlainText;
                PlainText2 = PlainText2.Replace("\n", String.Empty);
                PlainText2 = PlainText2.Replace("\r", String.Empty);
                PlainText2 = PlainText2.Replace("\t", String.Empty);
                int sk = PlainText2.IndexOf("Mobile:");
                int sl = PlainText2.IndexOf("Note");
                if(sk > 0 && sl > 0)
                {
                    ScanContact = PlainText2.Remove(0, sk+8);
                    int sm = ScanContact.IndexOf("Note");

                    ScanContact = ScanContact.Substring(0, sm);
                    ScanContact = ScanContact.Trim();

                    si = ScanContact.IndexOf("Email:");
                    if(si != -1)
                    {
                        sj = ScanContact.IndexOf(ScanEmail);
                        if(sj != -1)
                        {
                            ScanContact = PlainText2.Remove(si, sj);
                        }
                    }
                    ScanContact =ScanContact.Trim();
                }
                else
                {
                    ScanContact = "NA";
                }
                ScanItem.Email = ScanEmail;
                ScanItem.MessageID = ScanMessageID;
                ScanItem.ContactNo = ScanContact;
                ScanItemList.Add(ScanItem);
            }
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("MessageID");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("ContactNo");
            dataTable.Columns.Add("AddedBY");
            dataTable.TableName = "PT_ScanVerification";
            foreach (BO.EmailScanner item in ScanItemList)
            {
                DataRow row = dataTable.NewRow();

                row["MessageID"] = item.MessageID;
                row["Email"] = item.Email;
                row["ContactNo"] = item.ContactNo;
                row["AddedBY"] = item.AddedBY;
                dataTable.Rows.Add(row);
            }
            List<BO.EmailScanner> VerfiedList = dashboardBussinesManager.GetEmailVerfied(dataTable, emails);

            return VerfiedList;
        }

        public BO.Recieved_Emails GetEmailInfo(Message emailInfoResponse)
        {
            BO.Recieved_Emails eachData = new BO.Recieved_Emails();

            string from = "";
            string date = "";
            string subject = "";
            string body = "";
            var id = emailInfoResponse.Id;

            //loop through the headers and get the fields we need...
            foreach (var mParts in emailInfoResponse.Payload.Headers)
            {
                if (mParts.Name == "Date")
                {
                    date = mParts.Value;
                }
                else if (mParts.Name == "From")
                {
                    from = mParts.Value;
                }
                else if (mParts.Name == "Subject")
                {
                    subject = mParts.Value;
                }

                if (date != "" && from != "")
                {
                    if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                        body = DecodeBase64String(emailInfoResponse.Payload.Body.Data);
                    else
                        body = GetNestedBodyParts(emailInfoResponse.Payload.Parts, "");

                    //now you have the data you want....

                }
            }
            int index = body.IndexOf("<!DOCTYPE");
            if (index > 0)
            {
                body = body.Remove(0, index);
            }
            if (index < 0)
            {
                int index1 = body.IndexOf("<html");
                if (index1 > 0)
                {
                    body = body.Remove(0, index1);
                }
                else
                {
                    int index2 = body.IndexOf("<div");
                    if (index2 > 0)
                    {
                        body = body.Remove(0, index2);
                    }
                }

            }
            eachData.Display = date;
            eachData.FromName = from;
            eachData.Subject = subject;
            eachData.Body = body;
            eachData.PlainText = StripHTML(body);
            eachData.ID = id;

            return eachData;
        }

        public static byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        static String DecodeBase64String(string s)
        {
            var ts = s.Replace("-", "+");
            ts = ts.Replace("_", "/");
            var bc = Convert.FromBase64String(ts);
            var tts = Encoding.UTF8.GetString(bc);

            return tts;
        }

        static String GetNestedBodyParts(IList<MessagePart> part, string curr)
        {
            string str = curr;
            if (part == null)
            {
                return str;
            }
            else
            {
                foreach (var parts in part)
                {
                    if (parts.Parts == null)
                    {
                        if (parts.Body != null && parts.Body.Data != null)
                        {
                            var ts = DecodeBase64String(parts.Body.Data);
                            str += ts;
                        }
                    }
                    else
                    {
                        return GetNestedBodyParts(parts.Parts, str);
                    }
                }

                return str;
            }
        }

        private string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                //MessageBox.Show("Error");
                return source;
            }
        }

        //public ActionResult EmailInbox(CancellationToken cancellationToken)
        //{
        //    Session["GmailID"] = Convert.ToInt32(Session["userid"]);
        //    var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
        //    AuthorizeAsync(cancellationToken).Result;
        //    if (result.Credential != null)
        //    {
        //        var service = new GmailService(new BaseClientService.Initializer
        //        {
        //            HttpClientInitializer = result.Credential,
        //            ApplicationName = "ASP.NET MVC Sample"
        //        });
        //        DBViewE.EnquiryDataProvider dashboardBussinesManager1 = new DBViewE.EnquiryDataProvider();
        //        List<BO.SalesPerson> SalesPersonList = new List<BO.SalesPerson>();
        //        SalesPersonList = dashboardBussinesManager1.GetSalesPersonList();
        //        ViewBag.SalesPersonList = new SelectList(SalesPersonList, "SalesPersonID", "SalesPersonName");
        //        List<BO.SalesCoordinator> SalesCoordinatorList = new List<BO.SalesCoordinator>();
        //        SalesCoordinatorList = dashboardBussinesManager1.GetSalesCoordinatorList();
        //        ViewBag.SalesCoordinatorList = new SelectList(SalesCoordinatorList, "SalesCoordinatorID", "SalesCoordinatorName");
        //        ViewBag.SalesPersonListM = JsonConvert.SerializeObject(SalesPersonList);
        //        ViewBag.SalesCoordinatorListM = JsonConvert.SerializeObject(SalesCoordinatorList);
        //        DBViewC.ManageContactDataProvider dashboardBussinesManager2 = new DBViewC.ManageContactDataProvider();
        //        //For State List
        //        List<BO.State> StateList = new List<BO.State>();
        //        StateList = dashboardBussinesManager2.GetStateList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.StateDropdown = new SelectList(StateList, "StateID", "StateName");
        //        //For Country List
        //        List<BO.Country> CountryList = new List<BO.Country>();
        //        CountryList = dashboardBussinesManager2.GetCountryList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.CountryDropdown = new SelectList(CountryList, "CountryID", "CountryName");
        //        List<BO.Principal> principalList = new List<BO.Principal>();
        //        principalList = dashboardBussinesManager2.GetPrincipalList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.PrincipalDropdown = new SelectList(principalList, "PrincipalID", "PrincipalName");
        //        //For Sector List
        //        List<BO.Sector> sectorList = new List<BO.Sector>();
        //        sectorList = dashboardBussinesManager2.GetSectorList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.SectorDropdown = new SelectList(sectorList, "SectorID", "SectorName");
        //        //For Industry List
        //        List<BO.Industry> IndustryList = new List<BO.Industry>();
        //        IndustryList = dashboardBussinesManager2.GetIndustryList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.IndustryDropdown = new SelectList(IndustryList, "IndustryID", "IndustryName");
        //        return View();
        //    }
        //    else
        //    {
        //        return new RedirectResult(result.RedirectUri);
        //    }
            
        //}

        [HttpPost]
        public ActionResult GetEMailBody(string ID, CancellationToken cancellationToken)
        {
            if(Convert.ToInt32(Session["GmailID"]) == 0)
            {
                Session["GmailID"] = Convert.ToInt32(Session["userid"]);
            }
            var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
            AuthorizeAsync(cancellationToken).Result;

            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

            BO.Recieved_Emails eachData = new BO.Recieved_Emails();
            var emailInfoReq = service.Users.Messages.Get("me", ID);
            var emailInfoResponse = emailInfoReq.Execute();

                //var c = ForwardEmail1(cancellationToken, ID);
            if (emailInfoResponse != null)
            {
                eachData = GetEmailInfo(emailInfoResponse);
            }
           
                List<String> labelsToRemove = new List<string>();
              
                labelsToRemove.Add("UNREAD");
                ModifyMessageRequest mods = new ModifyMessageRequest();
                mods.RemoveLabelIds = labelsToRemove;
                var labelupdate = service.Users.Messages.Modify(mods, "me", ID);
                var temp = labelupdate.Execute();
            return Json(eachData);
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public ActionResult SearchEmailList(string SearchText, CancellationToken cancellationToken)
        {
            Session["GmailID"] = Convert.ToInt32(Session["userid"]);
            var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
            AuthorizeAsync(cancellationToken).Result;
            List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();

            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });
                List<Message> messages = new List<Message>();
                    UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
                request.Q = SearchText;
                request.MaxResults = 50;
                    try
                    {
                        ListMessagesResponse response = request.Execute();
                        messages.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                if (messages != null)
                {
                    foreach (Message email in messages)
                    {
                        var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                        var emailInfoResponse = emailInfoReq.Execute();

                        if (emailInfoResponse != null)
                        {
                            string from = "";
                            string date = "";
                            string subject = "";
                            string body = "";
                            var id = emailInfoResponse.Id;
                            var ThreadID = emailInfoResponse.ThreadId;

                            //loop through the headers and get the fields we need...
                            foreach (var mParts in emailInfoResponse.Payload.Headers)
                            {
                                if (mParts.Name == "Date")
                                {
                                    date = mParts.Value;
                                    int index = date.IndexOf("+");
                                    if (index > 0)
                                        date = date.Substring(0, index);
                                    int index1 = date.IndexOf("-");
                                    if (index1 > 0)
                                        date = date.Substring(0, index1);
                                }
                                else if (mParts.Name == "From")
                                {
                                    from = mParts.Value;
                                    int index = from.IndexOf("<");
                                    if (index > 0)
                                        from = from.Substring(0, index);
                                }
                                else if (mParts.Name == "Subject")
                                {
                                    subject = mParts.Value;
                                }
                            }
                            BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                            eachData.Display = date;
                            eachData.FromName = from;
                            eachData.Subject = subject;
                            eachData.Body = body;
                            eachData.ID = id;
                            eachData.ThreadID = ThreadID;
                            emails.Add(eachData);
                        }
                        ViewBag.MailDetails = JsonConvert.SerializeObject(emails);
                    }
                }
                return PartialView(emails.ToList());

            }       
            else
            {
                return new RedirectResult(result.RedirectUri);
            }

            
        }

        [HttpPost]
        public ActionResult SaveEMailAganistQuotation(BO.QuotationAganistEmail data)
        {
            data.AddedBy = Convert.ToInt16(Session["userid"]);
            data.ModifiedBy = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveEMailAganistQuotation(data);
            return Json(message);
        }

        [HttpPost]
        public ActionResult SaveEMailAganistBox(BO.QuotationAganistEmail data)
        {
            data.AddedBy = Convert.ToInt16(Session["userid"]);
            data.ModifiedBy = Convert.ToInt16(Session["userid"]);
            string message = dashboardBussinesManager.SaveEMailAganistBox(data);
            return Json(message);
        }

        public ActionResult QuotationEmail(int ID, CancellationToken cancellationToken)
        {
            List<BO.QuotationAganistEmail> List = new List<BO.QuotationAganistEmail>();
            List = dashboardBussinesManager.GetEMailListForQuotation(ID);
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.Recieved_Emails> emailList = new List<BO.Recieved_Emails>();
            BO.Recieved_Emails emails = new BO.Recieved_Emails();
            //foreach (BO.QuotationAganistEmail data in List)
            //{

            //    if(data.AddedBy == UserID)
            //    {
            //        string TokenPath = Convert.ToString(Session["tokenpath"]);
            //        credential = GetCredetional(TokenPath);
            //    } else
            //    {
            //        string TokenPath = data.TokenPath;
            //        credential = GetCredetional(TokenPath);
            //    }
            //    var service = new GmailService(new BaseClientService.Initializer()
            //    {
            //        HttpClientInitializer = credential,
            //    });
            //    var emailInfoReq = service.Users.Messages.Get("me", data.MessageID);
            //    var emailInfoResponse = emailInfoReq.Execute();

            //    if (emailInfoResponse != null)
            //    {
            //        emails = GetEmailInfo(emailInfoResponse);
            //        emails.Addedby = data.AddedBy;
            //        emails.TokenPath = data.TokenPath;
            //    }
            //    emailList.Add(emails);
            //}
            return PartialView(emailList.ToList());
        }

        [HttpPost]
        public ActionResult GetSelectedEmailForQuotation(BO.Recieved_Emails data)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            UserCredential credential;
            BO.Recieved_Emails emails = new BO.Recieved_Emails();
            emails.Addedby = data.Addedby;
            emails.TokenPath = data.TokenPath;
            if (data.Addedby == UserID)
            {
                string TokenPath = Convert.ToString(Session["tokenpath"]);
                credential = GetCredetional(TokenPath);
            }
            else
            {
                string TokenPath = data.TokenPath;
                credential = GetCredetional(TokenPath);
            }
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });
            var emailInfoReq = service.Users.Messages.Get("me", data.ID);
            var emailInfoResponse = emailInfoReq.Execute();

            if (emailInfoResponse != null)
            {
                emails = GetEmailInfo(emailInfoResponse);
            }
            return Json(emails);
        }

        public ActionResult ScanEmailForDetails(string value)
        {
            string TokenPath = Convert.ToString(Session["tokenpath"]);
            UserCredential credential;
            if (TokenPath == null || TokenPath == "")
            {
                credential = SetTokenFolderPath();
            }
            else
            {
                credential = GetCredetional(TokenPath);
            }
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
            //Custom filter get last 3 days email
            string filter = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            filter = "after:" + filter;
            string query = filter.Replace('-', '/');
            value = value + "(" +query + ")";
            request.Q = value;
            request.MaxResults = 50;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                    if (result.Count < 75)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            } while (!String.IsNullOrEmpty(request.PageToken));
            List<BO.EmailScanner> emails = new List<BO.EmailScanner>();
            if (result != null)
            {
                emails = GetScanMailResult(result);
            }
            ViewBag.Count = emails.Count;
            return PartialView(emails.ToList());
        }

        //View
        //public ActionResult Inbox(CancellationToken cancellationToken)
        //{
        //    Session["GmailID"] = Convert.ToInt32(Session["userid"]);
        //    var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
        //    AuthorizeAsync(cancellationToken).Result;
        //    List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();


        //    if (result.Credential != null)
        //    {
        //        if (HttpContext.Cache["SavedEmailLog"] == null)
        //        {
        //            var service = new GmailService(new BaseClientService.Initializer
        //            {
        //                HttpClientInitializer = result.Credential,
        //                ApplicationName = "ASP.NET MVC Sample"
        //            });
        //            List<Message> messages = new List<Message>();
        //            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
        //            //request.MaxResults = 40;

        //            do
        //            {
        //                try
        //                {
        //                    ListMessagesResponse response = request.Execute();
        //                    messages.AddRange(response.Messages);
        //                    request.PageToken = response.NextPageToken;
        //                    if (messages.Count > 49)
        //                    {
        //                        break;
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    throw e;
        //                }
        //            } while (!String.IsNullOrEmpty(request.PageToken));
        //            ViewBag.message = messages;
        //            List<Message> list = new List<Message>();
        //            foreach (Message email in messages)
        //            {
        //                var emailInfoReq = service.Users.Messages.Get("me", email.Id);
        //                var emailInfoResponse = emailInfoReq.Execute();

        //                if (emailInfoResponse != null)
        //                {
        //                    string from = "";
        //                    string date = "";
        //                    string subject = "";
        //                    string body = "";
        //                    var id = emailInfoResponse.Id;
        //                    var ThreadID = emailInfoResponse.ThreadId;

        //                    //loop through the headers and get the fields we need...
        //                    foreach (var mParts in emailInfoResponse.Payload.Headers)
        //                    {
        //                        if (mParts.Name == "Date")
        //                        {
        //                            date = mParts.Value;
        //                            int index = date.IndexOf("+");
        //                            if (index > 0)
        //                                date = date.Substring(0, index);
        //                            int index1 = date.IndexOf("-");
        //                            if (index1 > 0)
        //                                date = date.Substring(0, index1);
        //                        }
        //                        else if (mParts.Name == "From")
        //                        {
        //                            from = mParts.Value;
        //                            int index = from.IndexOf("<");
        //                            if (index > 0)
        //                                from = from.Substring(0, index);
        //                        }
        //                        else if (mParts.Name == "Subject")
        //                        {
        //                            subject = mParts.Value;
        //                        }
        //                    }
        //                    BO.Recieved_Emails eachData = new BO.Recieved_Emails();
        //                    eachData.Display = date;
        //                    eachData.FromName = from;
        //                    eachData.Subject = subject;
        //                    eachData.Body = body;
        //                    eachData.ID = id;
        //                    eachData.ThreadID = ThreadID;
        //                    emails.Add(eachData);
        //                }
        //            }

        //        }

        //        if (HttpContext.Cache["SavedEmailLog"] == null)
        //        {
        //            HttpContext.Cache["SavedEmailLog"] = JsonConvert.SerializeObject(emails);
        //        }
        //        ViewBag.MailDetails = HttpContext.Cache["SavedEmailLog"];
        //        emails = JsonConvert.DeserializeObject<List<BO.Recieved_Emails>>(ViewBag.MailDetails);
        //        DBViewE.EnquiryDataProvider dashboardBussinesManager1 = new DBViewE.EnquiryDataProvider();
        //        List<BO.SalesPerson> SalesPersonList = new List<BO.SalesPerson>();
        //        SalesPersonList = dashboardBussinesManager1.GetSalesPersonList();
        //        ViewBag.SalesPersonList = new SelectList(SalesPersonList, "SalesPersonID", "SalesPersonName");
        //        List<BO.SalesCoordinator> SalesCoordinatorList = new List<BO.SalesCoordinator>();
        //        SalesCoordinatorList = dashboardBussinesManager1.GetSalesCoordinatorList();
        //        ViewBag.SalesCoordinatorList = new SelectList(SalesCoordinatorList, "SalesCoordinatorID", "SalesCoordinatorName");
        //        DBViewC.ManageContactDataProvider dashboardBussinesManager2 = new DBViewC.ManageContactDataProvider();
        //        //For State List
        //        List<BO.State> StateList = new List<BO.State>();
        //        StateList = dashboardBussinesManager2.GetStateList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.StateDropdown = new SelectList(StateList, "StateID", "StateName");
        //        //For Country List
        //        List<BO.Country> CountryList = new List<BO.Country>();
        //        CountryList = dashboardBussinesManager2.GetCountryList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.CountryDropdown = new SelectList(CountryList, "CountryID", "CountryName");
        //        List<BO.Principal> principalList = new List<BO.Principal>();
        //        principalList = dashboardBussinesManager2.GetPrincipalList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.PrincipalDropdown = new SelectList(principalList, "PrincipalID", "PrincipalName");
        //        //For Sector List
        //        List<BO.Sector> sectorList = new List<BO.Sector>();
        //        sectorList = dashboardBussinesManager2.GetSectorList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.SectorDropdown = new SelectList(sectorList, "SectorID", "SectorName");
        //        //For Industry List
        //        List<BO.Industry> IndustryList = new List<BO.Industry>();
        //        IndustryList = dashboardBussinesManager2.GetIndustryList(Convert.ToString(Session["LoginType"]));
        //        ViewBag.IndustryDropdown = new SelectList(IndustryList, "IndustryID", "IndustryName");
        //        return View(emails.ToList());
        //    }
        //    else
        //    {
        //        return new RedirectResult(result.RedirectUri);
        //    }

        //}


        [HttpPost]
        public ActionResult GetLinkedMailDetail(int ID,string Type, CancellationToken cancellationToken)
        {
            BO.QuotationAganistEmail mailData = new BO.QuotationAganistEmail();
            if (Type == "QTN")
            {
                mailData = dashboardBussinesManager.GetLinkedMailDetail(ID);
            }
            else
            {
                mailData = dashboardBussinesManager.GetLinkedPipelineMail(ID);
            }
            Session["GmailID"] = mailData.AddedBy;
            var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
                        AuthorizeAsync(cancellationToken).Result;

            if (result.Credential != null)
            {
                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

                BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                List<BO.Recieved_Emails> mailList = new List<BO.Recieved_Emails>();
                //var emailInfoReq = service.Users.Messages.Get("me", mailData.MessageID);
                //var emailInfoResponse = emailInfoReq.Execute();

                var check = service.Users.Threads.Get("me", mailData.ThreadID);
                var check2 = check.Execute();
                if (check2 != null)
                {
                    //eachData = GetEmailInfo(emailInfoResponse);
                    mailList = ParseEMailThread(check2);

                }

                return Json(mailList);
            }
            else
            {
                return  Json("Token has expired...try again later!");
            }
        }

        public List<BO.Recieved_Emails> ParseEMailThread(Google.Apis.Gmail.v1.Data.Thread thread)
        {
            List<BO.Recieved_Emails> mailList = new List<BO.Recieved_Emails>();
            foreach(Message mail in thread.Messages)
            {
                BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                eachData = GetEmailInfo(mail);
                mailList.Add(eachData);
            }

            return mailList;
        }
        [HttpPost]
        public ActionResult RefreshMailList()
        {
            int i = 0;
            //HttpContext.Cache["SavedEmailLog"] = "-";
            HttpContext.Cache.Remove("SavedEmailLog");
            return Json(i);
        }

        public ActionResult MailListForUser(CancellationToken cancellationToken, string PageToken)
        {
            int isRead = 0;
            Session["GmailID"] = Convert.ToInt32(Session["userid"]);
            var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
            AuthorizeAsync(cancellationToken).Result;
            List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();
            string NextPageToken ="";
            Boolean GetDeafult = false;
            if(PageToken == "NA")
            {
                PageToken = "";
                GetDeafult = true;
                HttpContext.Cache.Remove("SavedEmailLog");
            }

            if (result.Credential != null)
            {
                //if (GetDeafult || HttpContext.Cache["SavedEmailLog"] == null)
                //{
                    var service = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });
                    List<Message> messages = new List<Message>();
                    UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
                    request.PageToken = PageToken;
                    request.MaxResults = 15;
                    request.LabelIds = "INBOX";
                    //request.IncludeSpamTrash = false;
                    try
                    {
                        ListMessagesResponse response = request.Execute();
                        messages.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;
                        NextPageToken = request.PageToken;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    ViewBag.message = messages;
                    List<Message> list = new List<Message>();
                    foreach (Message email in messages)
                    {
                        var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                        var emailInfoResponse = emailInfoReq.Execute();
                        if(emailInfoResponse.LabelIds.Count != 0)
                    {
                        foreach (var d in emailInfoResponse.LabelIds)
                        {
                            if(d == "UNREAD"){
                                isRead = 1;
                                break;
                            }
                        }
                    }
                   
                        if (emailInfoResponse != null)
                        {
                            string from = "";
                            string date = "";
                            string subject = "";
                            string body = "";
                            var id = emailInfoResponse.Id;
                            var ThreadID = emailInfoResponse.ThreadId;
                        var snippet = emailInfoResponse.Snippet;
                            //loop through the headers and get the fields we need...
                            foreach (var mParts in emailInfoResponse.Payload.Headers)
                            {
                            if(date == "" || subject == "" || from == "")
                            {
                                if (mParts.Name == "Date")
                                {
                                    date = mParts.Value;
                                    int index = date.IndexOf("+");
                                    if (index > 0)
                                        date = date.Substring(0, index);
                                    int index1 = date.IndexOf("-");
                                    if (index1 > 0)
                                        date = date.Substring(0, index1);
                                }
                                else if (mParts.Name == "From")
                                {
                                    from = mParts.Value;
                                    int index = from.IndexOf("<");
                                    if (index > 0)
                                        from = from.Substring(0, index);
                                }
                                else if (mParts.Name == "Subject")
                                {
                                    subject = mParts.Value;
                                }
                            }

                            }
                            BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                            eachData.Display = date;
                            eachData.FromName = from;
                            eachData.Subject = subject;
                            eachData.Body = body;
                            eachData.ID = id;
                            eachData.IsRead = isRead;
                            eachData.ThreadID = ThreadID;
                            eachData.Snippets = snippet;
                            emails.Add(eachData);
                        isRead = 0;
                        }
                    }
                //}
                if (HttpContext.Cache["SavedEmailLog"] == null)
                {
                    HttpContext.Cache["SavedEmailLog"] = JsonConvert.SerializeObject(emails);
                }
                if (GetDeafult)
                {
                    ViewBag.MailDetails = HttpContext.Cache["SavedEmailLog"];
                }
                else
                {
                    ViewBag.MailDetails = JsonConvert.SerializeObject(emails);
                }
                emails = JsonConvert.DeserializeObject<List<BO.Recieved_Emails>>(ViewBag.MailDetails);
                ViewBag.NextPageToken = NextPageToken;
                return PartialView(emails.ToList());
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }

        public ActionResult SendEMailTOAthread(CancellationToken cancellationToken, Message message)
        {
            try
            {
                message.Id = "";
                message.ThreadId = "";
                //message.Payload.Headers
                Session["GmailID"] = Convert.ToInt32(Session["userid"]);
                var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
                AuthorizeAsync(cancellationToken).Result;
                if (result.Credential != null)
                {
                    var service = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });
                    UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send(message,"me");
                    message = request.Execute();
                }
                return Json("Mail Sent");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ForwardEmail(CancellationToken cancellationToken,string ID)
        {
            try
            {
                int i = 0;
                //tempcheck.ResentFrom.Add(new MimeKit.MailboxAddress("", "hubsbot@bombaytools.in"));

                Session["GmailID"] = Convert.ToInt32(Session["userid"]);
                var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
                AuthorizeAsync(cancellationToken).Result;

                if (result.Credential != null)
                {
                    var service = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });

                    var emailInfoReq = service.Users.Messages.Get("me", ID);
                    emailInfoReq.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw; 
                    var emailInfoResponse = emailInfoReq.Execute();
                    using (MemoryStream rawInStream = new MemoryStream(Base64FUrlDecode(emailInfoResponse.Raw)))
                    using (MemoryStream rawOutStream = new MemoryStream())
                    {
                        var tempcheck = MimeKit.MimeMessage.Load(rawInStream);
                        var me = tempcheck.To;
                        tempcheck.ResentFrom.Add(new MimeKit.MailboxAddress("",""));
                        tempcheck.ResentTo.Add(new MimeKit.MailboxAddress("", "phoenixtechnosoftkreation@gmail.com"));
                        tempcheck.ResentDate = DateTime.Now;
                        tempcheck.ResentMessageId = tempcheck.MessageId;
                        //tempcheck.From.Add(new MimeKit.MailboxAddress("", "phoenixtechnosoftkreation@gmail.com"));
                        //tempcheck.To.Clear();
                        //tempcheck.To.Add(new MimeKit.MailboxAddress("", "fimog54326@4tmail.com"));
                        //tempcheck.References.Add(tempcheck.MessageId);
                        //tempcheck.InReplyTo = tempcheck.MessageId;
                        //tempcheck.Cc.Add(new MimeKit.MailboxAddress("", "p.sanmesh@gmail.com"));
                        tempcheck.WriteTo(rawOutStream);
                        emailInfoResponse.Raw = Base64UrlEncode(rawOutStream.ToArray());
                    }

                    var tempq = service.Users.Messages.Send(emailInfoResponse,"me");
                    var temp = tempq.Execute();
                    return Json(temp);
                }
                else
                {
                    return new RedirectResult(result.RedirectUri);
                }
              
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult ForwardEmail1(CancellationToken cancellationToken,string SalesPersonEmail,string SalesCoordinatorEmail  , string ID)
        {
            try
            {
                Session["GmailID"] = Convert.ToInt32(Session["userid"]);

                var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
                AuthorizeAsync(cancellationToken).Result;

                if (result.Credential != null)
                {
                    var service = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });

                    var emailInfoReq = service.Users.Messages.Get("me", ID);
                    emailInfoReq.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw;
                    var emailInfoResponse = emailInfoReq.Execute();

                    var tempcheck = new MimeKit.MimeMessage();
                    var message = new MimeKit.MimeMessage();
                    using (MemoryStream rawInStream = new MemoryStream(Base64FUrlDecode(emailInfoResponse.Raw)))
                    {
                         tempcheck = MimeKit.MimeMessage.Load(rawInStream);

                        message.From.Add(tempcheck.From[0]);
                        if (SalesPersonEmail !="")
                        {
                            message.To.Add(new MimeKit.MailboxAddress("", SalesPersonEmail));
                        }
                        if (SalesCoordinatorEmail != "")
                        {
                            message.To.Add(new MimeKit.MailboxAddress("", SalesCoordinatorEmail));
                        }
                        // set the forwarded subject
                        if (!tempcheck.Subject.StartsWith("FW:", StringComparison.OrdinalIgnoreCase))
                            message.Subject = "FW: " + tempcheck.Subject;
                        else
                            message.Subject = tempcheck.Subject;

                        // create the main textual body of the message
                        var text = new MimeKit.TextPart("plain") { Text = "Enquiry Assigned:" };

                        // create the message/rfc822 attachment for the original message
                        var rfc822 = new MimeKit.MessagePart { Message = tempcheck };

                        // create a multipart/mixed container for the text body and the forwarded message
                        var multipart = new MimeKit.Multipart("mixed");
                        multipart.Add(text);
                        multipart.Add(rfc822);

                        // set the multipart as the body of the message
                        message.Body = multipart;


                    }
                    using (MemoryStream rawOutStream = new MemoryStream())
                    {
                        message.WriteTo(rawOutStream);
                        emailInfoResponse.Raw = Base64UrlEncode(rawOutStream.ToArray());
                    }

                       
                    var tempq = service.Users.Messages.Send(emailInfoResponse, "me");
                    var temp = tempq.Execute();
                    return Json(temp);
                }
                else
                {
                    return new RedirectResult(result.RedirectUri);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private static byte[] Base64FUrlDecode(string input)
        {
            int padChars = (input.Length % 4) == 0 ? 0 : (4 - (input.Length % 4));
            StringBuilder result = new StringBuilder(input, input.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        private static string Base64UrlEncode(byte[] input)
        {
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(input)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }


        ///For Pipeline
        public ActionResult _ViewEmailMiniInbox(string SearchText,string flagForMail, CancellationToken cancellationToken)
        {
            HttpCookie reqCookies = HttpContext.Request.Cookies["BombayTool_userCookies"];
            if(flagForMail == "0")
            {
                Session["GmailID"] = Convert.ToInt32(Session["userid"]);
                if (Convert.ToInt32(Session["isFromInfo"]) == 1)
                {
                    Session["miniMail"] = null;
                }
            }
            else
            {
                Session["GmailID"] = 2028;
                Session["isFromInfo"] = 1;
                Session["miniMail"] = null;
            }
            ViewBag.setFlagForMail = flagForMail;
            var result = new AuthorizationCodeMvcApp(this, new GmailApiFilter()).
            AuthorizeAsync(cancellationToken).Result;
            List<BO.Recieved_Emails> emails = new List<BO.Recieved_Emails>();
            if(SearchText != "")
            {
                Session["miniMail"] = null;
            }
            ViewBag.SearchEmail = SearchText;
            if (result.Credential != null)
            {
                if (Session["miniMail"] == null || Convert.ToString(Session["miniMail"]) == "" )
                {
                    var service = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });
                    List<Message> messages = new List<Message>();
                    UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("me");
                    if (SearchText != "")
                    {
                        request.Q = SearchText;
                    }
                    request.MaxResults = 50;
                    try
                    {
                        ListMessagesResponse response = request.Execute();
                        messages.AddRange(response.Messages);
                        request.PageToken = response.NextPageToken;

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    if (messages != null)
                    {
                        foreach (Message email in messages)
                        {
                            var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                            var emailInfoResponse = emailInfoReq.Execute();

                            if (emailInfoResponse != null)
                            {
                                string from = "";
                                string date = "";
                                string subject = "";
                                string body = "";
                                var id = emailInfoResponse.Id;
                                var ThreadID = emailInfoResponse.ThreadId;
                                
                                //loop through the headers and get the fields we need...
                                foreach (var mParts in emailInfoResponse.Payload.Headers)
                                {
                                    if (mParts.Name == "Date")
                                    {
                                        date = mParts.Value;
                                        int index = date.IndexOf("+");
                                        if (index > 0)
                                            date = date.Substring(0, index);
                                        int index1 = date.IndexOf("-");
                                        if (index1 > 0)
                                            date = date.Substring(0, index1);
                                    }
                                    else if (mParts.Name == "From")
                                    {
                                        from = mParts.Value;
                                        int index = from.IndexOf("<");
                                        if (index > 0)
                                            from = from.Substring(0, index);
                                    }
                                    else if (mParts.Name == "Subject")
                                    {
                                        subject = mParts.Value;
                                    }
                                }
                                BO.Recieved_Emails eachData = new BO.Recieved_Emails();
                                eachData.Display = date;
                                eachData.FromName = from;
                                eachData.Subject = subject;
                                eachData.Body = body;
                                eachData.ID = id;
                                eachData.ThreadID = ThreadID;
                                eachData.Snippets = emailInfoResponse.Snippet; 
                                emails.Add(eachData);
                            }
                            ViewBag.MailDetails = JsonConvert.SerializeObject(emails);
                        }
                    }
                }
                else
                {
                    emails = (List<BO.Recieved_Emails>)Session["miniMail"];
                }
                Session["miniMail"] = (emails);
                return PartialView(emails.ToList());

            }       
            else
            {
                return RedirectToAction("EmailBox");
                //return new RedirectResult(result.RedirectUri);
            }

        }

    }
}