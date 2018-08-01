using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace Capstone_.Controllers
{
    public class SMSController : TwilioController
    {
        // GET: SMS
        public ActionResult SendSms(string phoneNumber)
        {
            var accountSid = "ACcbb564436b31339fd12a788f659515f1";
            var authToken = "9be9a5f9206f985072fb88231b43ad7d";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+" + phoneNumber);
            var from = new PhoneNumber("+14142690237");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Message");
            return Content(message.Sid);
        }
        public ActionResult DayOfEvent(string phoneNumber)
        {
            var accountSid = "ACcbb564436b31339fd12a788f659515f1";
            var authToken = "9be9a5f9206f985072fb88231b43ad7d";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+" + phoneNumber);
            var from = new PhoneNumber("+14142690237");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Event is today");
            return Content(message.Sid);
        }

        public ActionResult TwoHourNotification(string phoneNumber)
        {
            var accountSid = "ACcbb564436b31339fd12a788f659515f1";
            var authToken = "9be9a5f9206f985072fb88231b43ad7d";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+" + phoneNumber);
            var from = new PhoneNumber("+14142690237");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Event in 2 hours.");
            return Content(message.Sid);
        }
    }
}