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
    public class SeriesManagerController : Controller
    {
        private ComicRateEntities db = new ComicRateEntities();

        //
        // GET: /SeriesManager/

        public ViewResult Index()
        {
            var series = db.Series.Include(s => s.publisher);
            return View(series.ToList());
        }

        //
        // GET: /SeriesManager/Details/5

        public ViewResult Details(int id)
        {
            Series series = db.Series.Find(id);
            return View(series);
        }

        //
        // GET: /SeriesManager/Create

        public ActionResult Create()
        {
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name");
            return View();
        } 

        //
        // POST: /SeriesManager/Create

        [HttpPost]
        public ActionResult Create(Series series)
        {
            if (ModelState.IsValid)
            {
                db.Series.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name", series.PublisherID);
            return View(series);
        }
        
        //
        // GET: /SeriesManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Series series = db.Series.Find(id);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name", series.PublisherID);
            return View(series);
        }

        //
        // POST: /SeriesManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Series series)
        {
            if (ModelState.IsValid)
            {
                db.Entry(series).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "name", series.PublisherID);
            return View(series);
        }

        //
        // GET: /SeriesManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Series series = db.Series.Find(id);
            return View(series);
        }

        //
        // POST: /SeriesManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Series series = db.Series.Find(id);
            db.Series.Remove(series);
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