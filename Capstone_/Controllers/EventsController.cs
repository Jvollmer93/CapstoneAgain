//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using GoogleDirections;
//using Geocoder;
//using System.Web.Mvc;
//using Capstone_.Models;
//using Microsoft.AspNet.Identity;

//namespace Capstone_.Controllers
//{
//    public class EventsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Events
//        public ActionResult Index()
//        {
//            return View(db.Events.ToList());
//        }

//        // GET: Events/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Event @event = db.Events.Find(id);
//            if (@event == null)
//            {
//                return HttpNotFound();
//            }
//            return View(@event);
//        }

//        // GET: Events/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Events/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name,Date,Location,StartTime,EndTime,IsPublic")] Event @event)
//        {
//            string currentUserId = User.Identity.GetUserId();
//            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
//            var textController = DependencyResolver.Current.GetService<SMSController>();
//            textController.ControllerContext = new ControllerContext(this.Request.RequestContext, textController);
//            var emailController = DependencyResolver.Current.GetService<EmailController>();
//            textController.ControllerContext = new ControllerContext(this.Request.RequestContext, emailController);

//            if (ModelState.IsValid)
//            {
//                db.Events.Add(@event);
//                db.SaveChanges();
//                if (User.IsInRole("Company"))
//                {
//                    Company CompanyHosting = db.Companies.FirstOrDefault(x => x.Email == currentUser.Email);
//                    var company = from e in db.Companies
//                                 where e.Email == currentUser.Email
//                                 select e;
//                    foreach (var item in company)
//                    //{
//                    //    item.HostedEvents.Add(@event);
//                        if (item.AcceptsTextNotifications)
//                        {
//                            textController.EventSuccesfullyCreatedSMS(item.PhoneNumber);
//                        }
//                        if (item.AcceptsEmailNotifications)
//                        {
//                            emailController.ConfirmEvent(item.Email);
//                        }
//                        db.SaveChanges();
//                    }
//                    //CompanyHosting.HostedEvents.Add(@event);
//                    db.SaveChanges();
//                }
//                else if (User.IsInRole("PersonalUser"))
//                {
//                    //PersonalUser PersonHosting = db.PersonalUsers.FirstOrDefault(x => x.Email == currentUser.Email);
//                    db.PersonalUsers.Where(x => x.Email == currentUser.Email).FirstOrDefault().HostedEvents.Add(@event);
//                    db.SaveChanges();
//                    //var person = from e in db.PersonalUsers
//                    //             where e.Email == currentUser.Email
//                    //             select e;
//                    //foreach (var item in person)
//                    //{
//                    //    db.PersonalUsers.FirstOrDefault(x => x.Email == currentUser.Email).HostedEvents.Add(@event); 
//                    //        //item.HostedEvents.Add(@event);
//                    //    if(item.AcceptsTextNotifications)
//                    //    {
//                    //        textController.EventSuccesfullyCreatedSMS(item.PhoneNumber);
//                    //    }
//                    //    if(item.AcceptsEmailNotifications)
//                    //    {
//                    //        emailController.ConfirmEvent(item.Email);
//                    //    }
//                    //    db.SaveChanges();
//                    //}
//                    //PersonHosting.HostedEvents.Add(@event);
//                    //db.SaveChanges();
//                }
//                return RedirectToAction("Index");
//            }

//            return View(@event);
//        }

//        // GET: Events/Edit/5
//        [Authorize(Roles = "Admin")]
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Event @event = db.Events.Find(id);
//            if (@event == null)
//            {
//                return HttpNotFound();
//            }
//            return View(@event);
//        }

//        // POST: Events/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [Authorize(Roles = "Admin")]
//        public ActionResult Edit([Bind(Include = "Id,Name,Date,Location,StartTime,EndTime,IsPublic")] Event @event)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(@event).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(@event);
//        }

//        // GET: Events/Delete/5
//        [Authorize(Roles = "Admin")]
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Event @event = db.Events.Find(id);
//            if (@event == null)
//            {
//                return HttpNotFound();
//            }
//            return View(@event);
//        }

//        // POST: Events/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        [Authorize(Roles = "Admin")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Event @event = db.Events.Find(id);
//            db.Events.Remove(@event);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public ActionResult Invite()
//        {
//            if(User.IsInRole("PersonalUser"))
//            {
//                return View("Invite", "PersonalUsers");
//            }
//            else if(User.IsInRole("Company"))
//            {
//                return View("Invite", "Company");
//            }
//            return View();
//        }

//        //public double[] GetLatLong(string address)
//        //{
//        //    double[] latLng = new double[2];
//        //    var geocoder = new GoogleDirections.Geocoder("AIzaSyDNRMFv2YIYRFyNP9nWbsz - z6JYYd - oxwo");
//        //    var locations = geocoder.Geocode(address);
//        //    return latLng;
//        //}

//        //public void SetLatLong(double lat, double lng)
//        //{

//        //}

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//    }
//}
