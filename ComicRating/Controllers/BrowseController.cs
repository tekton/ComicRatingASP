using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicRating.Models;

namespace ComicRating.Controllers
{
    public class BrowseController : Controller
    {

        ComicRateEntities db = new ComicRateEntities();

        //
        // GET: /Browse/

        public ActionResult Index()
        {
            //TODO: show basic listing in heirchy: Publishers up top, small table PublisherCount columns wide with series underneath them
            return View();
        }

        //
        //GET: /Browse/All
        public ActionResult All()
        {
            var issues = db.Issues.Include("Series").ToList();
            return View(issues);
        }

        public ActionResult Publishers()
        {
            //TODO just show the list of publishers
            var publishers = db.Publishers.ToList();
            return View(publishers);
        }

        // Right now assumes that there's only one series by that name; doesn't really work once multiple volumes are in
        // Get: /Browse/Series/{series}
        public ActionResult Series(string id)
        {
            //TODO show all issues in series, desc issue number
            ViewBag.title = id;
            var seriesModel = db.Series.Include("Issue").Single(g => g.name == id);
            return View(seriesModel);
        }

        //
        // GET: /Browse/SeriesByPublisher/{publisher}
        public ActionResult SeriesByPublisher(string id)
        {
            //TODO show all of the series that belong to a certain publisher
            //var series = db.Publishers.Single(p => p.name == id);
            ViewBag.message = id;
            var pubModel = db.Publishers.Include("Series").Single(g => g.name == id);

            return View(pubModel);
        }

        //
        // GET: /Browse/Issue/{id?}
        public ActionResult issue(int id)
        {
            ViewBag.message = id;
            var issue = db.Issues.Include("Series").Single(g => g.IssueID == id);
            return View(issue);
        }

    }
}
