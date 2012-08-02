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

        [ChildActionOnly]
        public ActionResult browserInfoRightList()
        {
            return PartialView();
        }

        public ActionResult BrowserAndSettings()
        {
            //Request.Headers.Keys;
            //get all the information possible about the browser, system, etc...

            //System.Web.HttpBrowserCapabilitiesBase browser = Request.Browser;

            Dictionary<string, string> browserInfo = new Dictionary<string, string>();
            Dictionary<string, string> request = new Dictionary<string, string>();

            foreach (string x in Request.ServerVariables)
            {
                browserInfo.Add(x, Request.ServerVariables[x]);
            }

            //browser doesn't have an enumerator...doh
            //TODO find a way to do something similar...
            //foreach (var y in Request.Browser)
            //{
            //    request.Add(y, Request.Browser.y);
            //}

            //foreach(string y in Session)
            //{
            //    browserInfo.Add(y, Session[y]);
            //}

            ViewBag.s = browserInfo;
            ViewBag.ip = this.ip();

            //if (Session("quad") == null)
            //{
            //    Session.Add("quad") = DateTime.Now.ToShortTimeString;
            //}
            //...and then figure out how to change things in the returned view for it!
            return View();
        }

        public string ip()
        {
            string ipaddy = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddy == null || ipaddy == "")
            {
                ipaddy = Request.ServerVariables["REMOTE_ADDR"];
            }
            return ipaddy;
        }

    }
}
