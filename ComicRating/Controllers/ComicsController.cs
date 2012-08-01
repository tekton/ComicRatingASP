using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicRating.Controllers
{
    public class ComicsController : Controller
    {
        //
        // GET: /Comics/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse() { return View(); }

        public ActionResult All()
        {
            return View();
        }

    }
}
