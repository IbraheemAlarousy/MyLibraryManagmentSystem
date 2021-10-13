using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class PuplishersController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: Puplishers
        public ActionResult Index()
        {
            return View(db.Puplishers.ToList());
        }

        // GET: Puplishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puplisher puplisher = db.Puplishers.Find(id);
            if (puplisher == null)
            {
                return HttpNotFound();
            }
            return View(puplisher);
        }

        // GET: Puplishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puplishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Phone")] Puplisher puplisher)
        {
            if (ModelState.IsValid)
            {
                db.Puplishers.Add(puplisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puplisher);
        }

        // GET: Puplishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puplisher puplisher = db.Puplishers.Find(id);
            if (puplisher == null)
            {
                return HttpNotFound();
            }
            return View(puplisher);
        }

        // POST: Puplishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Phone")] Puplisher puplisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puplisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puplisher);
        }

        // GET: Puplishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puplisher puplisher = db.Puplishers.Find(id);
            if (puplisher == null)
            {
                return HttpNotFound();
            }
            return View(puplisher);
        }

        // POST: Puplishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puplisher puplisher = db.Puplishers.Find(id);
            db.Puplishers.Remove(puplisher);
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
