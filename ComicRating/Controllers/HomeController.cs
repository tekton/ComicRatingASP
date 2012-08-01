using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicRating.Models;

namespace ComicRating.Controllers
{
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
