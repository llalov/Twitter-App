using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class ProfileController : BaseController
    {
        [Authorize]
        public ActionResult MyProfile()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);
            var tweets = user.OwnTweets
                .OrderByDescending(t => t.CreatedAt)
                .AsQueryable()
                .Select(UserTweetViewModel.Create);
            return View(tweets);
        }
    }
}