using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicRating.Models;

namespace ComicRating.Controllers
{ 
    /***
     * Partial scaffold, partial custom code for multi layers of db management
     * */
    [Authorize(Roles = "Admin")]
    public class IssuesManagerController : Controller
    {
        private ComicRateEntities db = new ComicRateEntities();

        //
        // GET: /IssuesManager/

        public ViewResult Index()
        {
            var issues = db.Issues.Include(i => i.series).Include(r => r.ratings);
            return View(issues.ToList());
        }

        //
        // GET: /IssuesManager/Details/5

        public ViewResult Details(int id)
        {
            Issue issue = db.Issues.Find(id);
            return View(issue);
        }

        //
        // GET: /IssuesManager/Create

        public ActionResult Create()
        {
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "name");
            return View();
        } 

        //
        // POST: /IssuesManager/Create

        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "name", issue.SeriesID);
            return View(issue);
        }
        
        //
        // GET: /IssuesManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Issue issue = db.Issues.Find(id);
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "name", issue.SeriesID);
            return View(issue);
        }

        //
        // POST: /IssuesManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "name", issue.SeriesID);
            return View(issue);
        }

        //
        // GET: /IssuesManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Issue issue = db.Issues.Find(id);
            return View(issue);
        }

        //
        // POST: /IssuesManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}