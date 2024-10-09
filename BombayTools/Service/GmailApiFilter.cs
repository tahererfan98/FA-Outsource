using System;
using System.Web.Hosting;
using System.Web.Mvc;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace BombayTools.Service
{
    public class GmailApiFilter : FlowMetadata
    {

        public static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "177529392004-2j6fmdqkc5mptou7ijvl5qurjaes0r19.apps.googleusercontent.com",
                    //ClientId = "563957882834-15u92tvh461rc8fhdj92nqkv2f4tpadh.apps.googleusercontent.com",
                    ClientSecret = "K6sNNeFfOc58JiPSIWVWGsr9"
                    //ClientSecret = "yOykp2lOFs_83oSaQjNliyMZ"
                },
                Scopes = new[] { GmailService.Scope.GmailReadonly,
                                 GmailService.Scope.GmailSend,
                                 GmailService.Scope.GmailModify,
                                GmailService.Scope.GmailCompose,
                                GmailService.Scope.MailGoogleCom,
                                  GmailService.Scope.GmailInsert,
                                  CalendarService.Scope.Calendar,
                                  CalendarService.Scope.CalendarEvents
                },
                DataStore = new FileDataStore(HostingEnvironment.MapPath("/Uploads/token"))
                //DataStore = new FileDataStore(IObserver.MapPath("~/App_Data"), true)
            });

        public override string GetUserId(Controller controller)
        {
            var user = controller.Session["GmailID"];
            if (user == null)
            {
                //user = Guid.NewGuid();
                controller.Session["GmailID"] = user;
            }
            return user.ToString();

        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }

    }
}