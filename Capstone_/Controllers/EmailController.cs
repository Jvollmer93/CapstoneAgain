using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Zender.Mail;
using System.Net.Mail;
using Capstone_.Models;

namespace Capstone_.Controllers
{
    public class EmailController : Controller
    {
        public IRestResponse ConfirmEvent(string emailAddress)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "a5d1a068-f46988d9");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "brominecapstone.pro", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun <mailgun@brominecapstone.pro>");
            request.AddParameter("to", emailAddress);
            request.AddParameter("to", "Jvollmer93@brominecapstone.pro");
            request.AddParameter("subject", "Event Confirmation");
            request.AddParameter("text", "Event creation was successfull.");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}