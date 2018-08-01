using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Capstone_.Models;
using System.Net;
using System.Net.Mail;

namespace Capstone_.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //GET /home/index
        public ActionResult Home()
        {
            return View("Index");
        }

        public ActionResult Index(string option, string searchString)
        {
            List<PersonalUser> personalUsers = new List<PersonalUser>();
            List<Company> companies = new List<Company>();

            if (option == "PersonalUsers")
            {
                foreach (var user in db.PersonalUsers)
                {
                    if (user.Name.Contains(searchString))
                    {
                        personalUsers.Add(user);
                    }
                    else if (user.Email.Contains(searchString))
                    {
                        personalUsers.Add(user);
                    }
                    else if (user.PhoneNumber.Contains(searchString))
                    {
                        personalUsers.Add(user);
                    }
                }
                return View(personalUsers.ToList());
            }
            else if (option == "Companies")
            {
                foreach (var company in db.Companies)
                {
                    if (company.Name.Contains(searchString))
                    {
                        companies.Add(company);
                    }
                    else if (company.Email.Contains(searchString))
                    {
                        companies.Add(company);
                    }
                    else if (company.PhoneNumber.Contains(searchString))
                    {
                        companies.Add(company);
                    }
                    else if (company.Address.Contains(searchString))
                    {
                        companies.Add(company);
                    }
                }
                return View(companies.ToList());
            }
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        //GET /home/about
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}