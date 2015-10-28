using System;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Twitter.Data.Models;
using Web.Hubs;
using Web.Models.BindingModels;
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
        public ActionResult CreateTweet(TweetBindingModel model)
        {
            //Adding the new tweet in db
            var loggedUserId = User.Identity.GetUserId();
            var tweet = new Tweet
            {
                CreatedAt = DateTime.Now,
                Content = model.Content,
                UserId = loggedUserId
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            //collecting Data for new Tweets hub
            var user = Data.Users.Find(loggedUserId);
            var userFullName = user.FullName;
            var userAvatarUrl = user.AvatarUrl;
            var tweetId = tweet.Id;
            var likesCount = tweet.Likes.Count;
            var retweetsCount = tweet.Retweets.Count;
            var createdAt = DateTime.Now.ToString("MMM d yyyy HH:mm");
            string content = model.Content;

            //creating new tweet hub
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();
            hubContext.Clients.All.newTweet(content, userAvatarUrl, userFullName, createdAt, tweetId, likesCount, retweetsCount);

            //...
            if (ModelState.IsValid)
            {
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
            var notification = new Twitter.Data.Models.Notification()
            {
                CreatedAt = DateTime.Now,
                ReceiverId = favoutireTweet.UserId,
                SenderId = loggedUserId,
                Type = NotificationType.Like,
                Seen = false
            };
           
            Data.Notifications.Add(notification);
            user.FavouriteTweets.Add(favoutireTweet);
            Data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}