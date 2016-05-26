using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleForms.Models;

namespace SimpleForms.Controllers
{
    public class UserFieldValuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserFieldValues
        public ActionResult Index()
        {
            return View(db.UserFieldValues.ToList());
        }

        // GET: UserFieldValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFieldValue userFieldValue = db.UserFieldValues.Find(id);
            if (userFieldValue == null)
            {
                return HttpNotFound();
            }
            return View(userFieldValue);
        }

        // GET: UserFieldValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserFieldValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,String,Numeric")] UserFieldValue userFieldValue)
        {
            if (ModelState.IsValid)
            {
                db.UserFieldValues.Add(userFieldValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userFieldValue);
        }

        // GET: UserFieldValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFieldValue userFieldValue = db.UserFieldValues.Find(id);
            if (userFieldValue == null)
            {
                return HttpNotFound();
            }
            return View(userFieldValue);
        }

        // POST: UserFieldValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,String,Numeric")] UserFieldValue userFieldValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFieldValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFieldValue);
        }

        // GET: UserFieldValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFieldValue userFieldValue = db.UserFieldValues.Find(id);
            if (userFieldValue == null)
            {
                return HttpNotFound();
            }
            return View(userFieldValue);
        }

        // POST: UserFieldValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFieldValue userFieldValue = db.UserFieldValues.Find(id);
            db.UserFieldValues.Remove(userFieldValue);
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
