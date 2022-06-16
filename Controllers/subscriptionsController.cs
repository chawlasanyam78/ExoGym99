using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoGym.Models;

namespace ExoGym.Controllers
{
    public class subscriptionsController : Controller
    {
        private subscriptionEntities db = new subscriptionEntities();

        // GET: subscriptions
        public ActionResult Index()
        {
            return View(db.subscriptions.ToList());
        }

        // GET: subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: subscriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(subscription subscription)
        {
            if (ModelState.IsValid)
            {
                subscription.MembersId = Convert.ToInt32(Session["id"].ToString());
                subscription.startdate = DateTime.Now;
                subscription.enddate = DateTime.Now;

                db.subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("PaymentSuccessful");
            }

            return View(subscription);
        }

        // GET: subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,startdate,enddate,MembersId,packagename")] subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        // GET: subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subscription subscription = db.subscriptions.Find(id);
            db.subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
