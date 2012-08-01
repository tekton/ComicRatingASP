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
    public class RatingsController : Controller
    {
        private ComicRateEntities db = new ComicRateEntities();

        //
        // GET: /Ratings/

        public ViewResult Index()
        {
            var ratings = db.Ratings.Include(r => r.issue).Include(s => s.issue.series);
            return View(ratings.ToList());
        }

        //
        // GET: /Ratings/Details/5

        public ViewResult Details(int id)
        {
            Rating rating = db.Ratings.Find(id);
            return View(rating);
        }

        //
        // GET: /Ratings/Create

        public ActionResult Create(int id)
        {
            
            Issue issue = db.Issues.Include("Series").Single(i => i.IssueID==id);
            ViewBag.IssueTitle = issue.series.name + " " + issue.number; //new SelectList(db.Issues.Include("Series"), "IssueID", "series.name number");
            ViewBag.IssueID = id;
            return View();
        } 

        //
        // POST: /Ratings/Create

        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "title", rating.IssueID);
            return View(rating);
        }
        
        //
        // GET: /Ratings/Edit/5
 
        public ActionResult Edit(int id)
        {
            Rating rating = db.Ratings.Find(id);
            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "title", rating.IssueID);
            return View(rating);
        }

        //
        // POST: /Ratings/Edit/5

        [HttpPost]
        public ActionResult Edit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssueID = new SelectList(db.Issues, "IssueID", "title", rating.IssueID);
            return View(rating);
        }

        //
        // GET: /Ratings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Rating rating = db.Ratings.Find(id);
            return View(rating);
        }

        //
        // POST: /Ratings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
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