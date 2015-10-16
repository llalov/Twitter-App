using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Data;
using Twitter.Data.Models;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class TweetsController :BaseController
    {

        [Authorize]
        public ActionResult CreateTweet ()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(CreateTweetViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var loggedUserId = User.Identity.GetUserId();

                var tweet = new Tweet
                {
                    CreatedAt = DateTime.Now,
                    Content = model.Content,
                    UserId = loggedUserId
                };

                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}