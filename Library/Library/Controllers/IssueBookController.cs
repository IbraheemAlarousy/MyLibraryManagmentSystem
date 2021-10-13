using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class IssueBookController : Controller
    {
        LibraryDBEntities db = new LibraryDBEntities();
        // GET: IssueBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Getmid(int mid)
        {
            var memberid = (from s in db.Members where s.ID == mid select s.Name).ToList();
            return Json(memberid, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Getbook()
        {
            var books = db.Books.Select(p => new
            {

                ID = p.ID     , 
                Name = p.Name

            }).ToList();
           
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save (IssueBook issue)
        {
            if (ModelState.IsValid) 
            {
                db.IssueBooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(issue);
        }
    }
}