using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicRating.Models;

namespace ComicRating.Controllers
{
    /**
     * Basic startign point, until more is done with user ratings it will remain a blank link site
     * 
     * Eventually "Browse" will be the home of most interactions with the site
     * 
     * Most comments will be in controllers while model and view code is sparse and self commenting for the most part
     * 
     * @Author Tyler Agee
     */
    public class HomeController : Controller
    {

        ComicRateEntities db = new ComicRateEntities(); 

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ComicRatings!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult PublisherRightList()
        { 
            var publishers = db.Publishers.ToList();
            return PartialView(publishers); 
        }

    }
}
