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
    public class FieldPrevaluesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FieldPrevalues
        public ActionResult Index()
        {
            var fieldPrevalues = db.FieldPrevalues.Include(f => f.FieldType);
            return View(fieldPrevalues.ToList());
        }

        // GET: FieldPrevalues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldPrevalue fieldPrevalue = db.FieldPrevalues.Find(id);
            if (fieldPrevalue == null)
            {
                return HttpNotFound();
            }
            return View(fieldPrevalue);
        }

        // GET: FieldPrevalues/Create
        public ActionResult Create()
        {
            ViewBag.FieldTypeId = new SelectList(db.FormFields, "Id", "Name");
            return View();
        }

        // POST: FieldPrevalues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,String,Int,FieldTypeId")] FieldPrevalue fieldPrevalue)
        {
            if (ModelState.IsValid)
            {
                db.FieldPrevalues.Add(fieldPrevalue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FieldTypeId = new SelectList(db.FormFields, "Id", "Name", fieldPrevalue.FieldTypeId);
            return View(fieldPrevalue);
        }

        // GET: FieldPrevalues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldPrevalue fieldPrevalue = db.FieldPrevalues.Find(id);
            if (fieldPrevalue == null)
            {
                return HttpNotFound();
            }
            ViewBag.FieldTypeId = new SelectList(db.FormFields, "Id", "Name", fieldPrevalue.FieldTypeId);
            return View(fieldPrevalue);
        }

        // POST: FieldPrevalues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,String,Int,FieldTypeId")] FieldPrevalue fieldPrevalue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fieldPrevalue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FieldTypeId = new SelectList(db.FormFields, "Id", "Name", fieldPrevalue.FieldTypeId);
            return View(fieldPrevalue);
        }

        // GET: FieldPrevalues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldPrevalue fieldPrevalue = db.FieldPrevalues.Find(id);
            if (fieldPrevalue == null)
            {
                return HttpNotFound();
            }
            return View(fieldPrevalue);
        }

        // POST: FieldPrevalues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FieldPrevalue fieldPrevalue = db.FieldPrevalues.Find(id);
            db.FieldPrevalues.Remove(fieldPrevalue);
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
