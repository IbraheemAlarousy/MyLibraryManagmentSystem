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
    public class IssueBook2Controller : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: IssueBook2
        public ActionResult Index()
        {
            return View(db.IssueBooks.ToList());
        }

        // GET: IssueBook2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // GET: IssueBook2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssueBook2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MemberID,BookName,IssueDate,ReturnDate")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.IssueBooks.Add(issueBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(issueBook);
        }

        // GET: IssueBook2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // POST: IssueBook2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MemberID,BookName,IssueDate,ReturnDate")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issueBook);
        }

        // GET: IssueBook2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // POST: IssueBook2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssueBook issueBook = db.IssueBooks.Find(id);
            db.IssueBooks.Remove(issueBook);
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
