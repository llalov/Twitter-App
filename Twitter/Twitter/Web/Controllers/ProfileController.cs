using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models.BindingModels;
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
                .Select(TweetViewModel.Create);
            return View(tweets);
        }

        [Authorize]
        public ActionResult EditMyProfile()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditMyProfile(ProfileBindingModel model)
        {
            var loggedUserId = User.Identity.GetUserId();
            var profile = Data.Users.Find(loggedUserId);

            if (model.FullName != null)
            {
                profile.FullName = model.FullName;
            }

            if (model.AvatarUrl != null)
            {
                profile.AvatarUrl = model.AvatarUrl;
            }

            if (model.Biography != null)
            {
                profile.Biography = model.Biography;
            }

            if (model.BirthDay != null)
            {
                profile.BirthDay = model.BirthDay;
            }

            if (model.Website != null)
            {
                profile.Website = model.Website;
            }            

            this.Data.SaveChanges();

            return RedirectToAction("MyProfile", "Profile");
        }
    }
}