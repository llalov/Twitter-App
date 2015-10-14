using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Twitter.Data;
using Web.Models.BindingModels;

namespace Web.Controllers
{
    public class HomeController : BaseController

    {
        
        [System.Web.Mvc.Authorize]      
        public ActionResult Index([FromUri] PaginationBindingModel model)
        {
            ViewBag.Title = "Home";
            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreatedAt)
                .Skip(model.StartPage * 10)
                .Take(10);

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