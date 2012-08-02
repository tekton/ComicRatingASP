using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicRating.Models;

namespace ComicRating.Controllers
{
    /**
     * 
     * The eventual central hub for all workings
     * 
     * TODO: add ajax/dynamic linking for ratings while browsing on an issue or series
     * 
     * Sparse code to allow for self commenting; todo and comments added as needed
     * @Author Tyler Agee 
     */
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
            var issue = db.Issues.Include("Series").Include("Ratings").Single(g => g.IssueID == id);

            var ratings = issue.ratings.ToArray();
            var art = 0;
            var overall = 0;
            var story = 0;
            foreach (var rate in ratings)
            {
                art += rate.art;
                overall += rate.overall;
                story += rate.story;
            }

            if (ratings.Count() > 0)// || ratings.Count().Equals(0) == false)
            {
                ViewBag.art_avg = art / ratings.Count();
                ViewBag.overall_avg = overall / ratings.Count();
                ViewBag.story_avg = story / ratings.Count();
            }
            else
            {
                ViewBag.art_avg = "No ratings to base calculations one...";
                ViewBag.overall_avg = "No ratings to base calculations one...";
                ViewBag.story_avg = "No ratings to base calculations one...";
            }
            return View(issue);
        }

    }
}
