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
        //GET: Email
        //public static IRestResponse EmailNotification()
        //{
        //    RestClient client = new RestClient();
        //    client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        //    client.Authenticator =
        //        new HttpBasicAuthenticator("api",
        //                                    "key-a5d1a068-f46988d9");
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("domain", "samples.mailgun.org", ParameterType.UrlSegment);
        //    request.Resource = "{domain}/messages";
        //    request.AddParameter("from", "CapstoneName <capstone@samples.mailgun.org>");//mailgun@sandboxfe46c92add184634b58c92d1aecfd9ce.mailgun.org>");
        //    request.AddParameter("to", "vollme22@uwm.edu");
        //    request.AddParameter("to", "samples.mailgun.org");
        //    request.AddParameter("subject", "Test");
        //    request.AddParameter("text", "This is a test Email");
        //    request.Method = Method.POST;
        //    return client.Execute(request);
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(EmailNotification().Content.ToString());
        //}

        //private static void Main()
        //{
        //    EmailNotification().Wait();
        //}

        //static async Task EmailNotification()
        //{
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("Jvollmer122793@gmail.com");
        //    var subject = "Test email send";
        //    var to = new EmailAddress("vollme22@uwm.edu", "This me");
        //    var plainTextContent = "This is a test email";
        //    var htmlContent = "<strong>still testing</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //}

        public ActionResult SendEmail()
        {
            ZenderMessage message = new ZenderMessage("27a1f808-107b-4a30-aa30-356fe72ab083");
            MailAddress from = new MailAddress("Jvollmer122793@gmail.com");
            MailAddress to = new MailAddress("vollme22@uwm.edu");
            message.From = from;
            message.To.Add(to);
            message.Subject = "Welcome!";
            message.Body = "<p><b>Lorem ipsum</b> dolor sit amet, consectetur adipiscing elit.</p>";
            message.IsBodyHtml = true;
            message.SendMailAsync();
            return View("~/Views/Home/Index.cshtml");
        }

    }
}