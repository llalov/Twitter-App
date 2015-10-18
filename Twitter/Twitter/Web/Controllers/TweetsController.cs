using System;
using System.Threading.Tasks;
using System.Web.Http;
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

        [System.Web.Mvc.Authorize]
        public ActionResult CreateTweet ()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize]
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

        [System.Web.Mvc.Authorize]
        public ActionResult AddTweetToFavourites([FromUri] int tweetId)
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = Data.Users.Find(loggedUserId);
            var favoutireTweet = Data.Tweets.Find(tweetId);
            var notification = new Notification()
            {
                Type = NotificationType.Like,
                CreatedAt = DateTime.Now,
                SenderId = loggedUserId,
                ReceiverId = favoutireTweet.UserId
            };

            user.ReceivedNotifications.Add(notification);
            user.FavouriteTweets.Add(favoutireTweet);
            Data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}