using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class ReturnBookController : Controller
    {
        LibraryDBEntities db = new LibraryDBEntities();

        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ReturnBook returns)
        {
            if (ModelState.IsValid)
            {
                db.ReturnBooks.Add(returns);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(returns);
        }
        [HttpPost]
        public ActionResult Getmid(int mid)
        {
            var memberid = (from s in db.IssueBooks
                            where s.MemberID == mid
                            select new
                            {

                                IssueDate = s.IssueDate,
                                ReturnDate = s.ReturnDate,
                                Memberid = s.MemberID,
                                BookName = s.BookName,
                                elapsedDays = SqlFunctions.DateDiff("day", s.ReturnDate, DateTime.Now)
                            }).ToArray();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }

    }


}