using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone_.Models;
using Microsoft.AspNet.Identity;

namespace Capstone_.Controllers
{
    public class PersonalUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalUsers
        public ActionResult Index()
        {
            return View(db.PersonalUsers.ToList());
        }

        // GET: PersonalUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalUser personalUser = db.PersonalUsers.Find(id);
            if (personalUser == null)
            {
                return HttpNotFound();
            }
            return View(personalUser);
        }

        // GET: PersonalUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,AcceptsTextNotifications,AcceptsEmailNotifications")] PersonalUser personalUser)
        {
            if (ModelState.IsValid)
            {
                db.PersonalUsers.Add(personalUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalUser);
        }

        // GET: PersonalUsers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalUser personalUser = db.PersonalUsers.Find(id);
            if (personalUser == null)
            {
                return HttpNotFound();
            }
            return View(personalUser);
        }

        // POST: PersonalUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password,AcceptsTextNotifications,AcceptsEmailNotifications")] PersonalUser personalUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalUser);
        }

        // GET: PersonalUsers/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalUser personalUser = db.PersonalUsers.Find(id);
            if (personalUser == null)
            {
                return HttpNotFound();
            }
            return View(personalUser);
        }

        // POST: PersonalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalUser personalUser = db.PersonalUsers.Find(id);
            db.PersonalUsers.Remove(personalUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Company, PersonalUser")]
        //public ActionResult FollowCompany(Company companyToFollow)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

        //    foreach (var following in currentUser.CompaniesIFollow)
        //    {
        //        if (following.Id == companyToFollow.Id)
        //            return View("Index");
        //    }

        //    currentUser.CompaniesIFollow.Add(companyToFollow);
        //    return View("Index");
        //}
        //[Authorize(Roles = "Company, PersonalUser")]
        //public ActionResult FollowPerson(PersonalUser personToFollow)
        //{
        //    string currentUserId = User.Identity.GetUserId();
        //    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

        //    foreach (var following in currentUser.CompaniesIFollow)
        //    {
        //        if (following.Id == personToFollow.Id)
        //            return View("Index");
        //    }

        //    currentUser.PersonsIFollow.Add(personToFollow);
        //    return View("Index");
        //}
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
