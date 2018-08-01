using Capstone_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Search
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
    }
}