using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {      
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            var tweets = this.Data.Tweets.All()
                .OrderBy(t => t.CreatedAt);

  
            return View(tweets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}