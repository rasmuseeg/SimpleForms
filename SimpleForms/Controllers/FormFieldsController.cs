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
    public class FormFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormFields
        public ActionResult Index()
        {
            var formFields = db.FormFields.Include(f => f.Form);
            return View(formFields.ToList());
        }

        // GET: FormFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormField formField = db.FormFields.Find(id);
            if (formField == null)
            {
                return HttpNotFound();
            }
            return View(formField);
        }

        // GET: FormFields/Create
        public ActionResult Create()
        {
            ViewBag.FormId = new SelectList(db.Forms, "Id", "Name");
            return View();
        }

        // POST: FormFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FormId,DataType,Mandatory")] FormField formField)
        {
            if (ModelState.IsValid)
            {
                db.FormFields.Add(formField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormId = new SelectList(db.Forms, "Id", "Name", formField.FormId);
            return View(formField);
        }

        // GET: FormFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormField formField = db.FormFields.Find(id);
            if (formField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormId = new SelectList(db.Forms, "Id", "Name", formField.FormId);
            return View(formField);
        }

        // POST: FormFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FormId,DataType,Mandatory")] FormField formField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormId = new SelectList(db.Forms, "Id", "Name", formField.FormId);
            return View(formField);
        }

        // GET: FormFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormField formField = db.FormFields.Find(id);
            if (formField == null)
            {
                return HttpNotFound();
            }
            return View(formField);
        }

        // POST: FormFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormField formField = db.FormFields.Find(id);
            db.FormFields.Remove(formField);
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
