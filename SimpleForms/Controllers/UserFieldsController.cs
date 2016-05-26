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
    public class UserFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserFields
        public ActionResult Index()
        {
            var userFields = db.UserFields.Include(u => u.Field);
            return View(userFields.ToList());
        }

        // GET: UserFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserField userField = db.UserFields.Find(id);
            if (userField == null)
            {
                return HttpNotFound();
            }
            return View(userField);
        }

        // GET: UserFields/Create
        public ActionResult Create()
        {
            ViewBag.FieldId = new SelectList(db.FormFields, "Id", "Name");
            return View();
        }

        // POST: UserFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,FieldId")] UserField userField)
        {
            if (ModelState.IsValid)
            {
                db.UserFields.Add(userField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FieldId = new SelectList(db.FormFields, "Id", "Name", userField.FieldId);
            return View(userField);
        }

        // GET: UserFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserField userField = db.UserFields.Find(id);
            if (userField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldId = new SelectList(db.FormFields, "Id", "Name", userField.FieldId);
            return View(userField);
        }

        // POST: UserFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,FieldId")] UserField userField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FieldId = new SelectList(db.FormFields, "Id", "Name", userField.FieldId);
            return View(userField);
        }

        // GET: UserFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserField userField = db.UserFields.Find(id);
            if (userField == null)
            {
                return HttpNotFound();
            }
            return View(userField);
        }

        // POST: UserFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserField userField = db.UserFields.Find(id);
            db.UserFields.Remove(userField);
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
