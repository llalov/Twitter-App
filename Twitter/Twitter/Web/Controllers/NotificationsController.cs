using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class NotificationsController : BaseController
    {

        [HttpGet]
        [Authorize]
        public ActionResult AllNotifications()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = Data.Users.Find(loggedUserId);

            var notifications = user
                .ReceivedNotifications
                .OrderByDescending(n => n.CreatedAt)
                .AsQueryable()
                .Select(NotificationViewModel.Create);

            return View(notifications);
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetUnread()
        {
            var loggedUserId = User.Identity.GetUserId();
            var count = Data.Notifications.All().Count(n => n.ReceiverId == loggedUserId && n.Seen == false && n.SenderId != loggedUserId);
            return PartialView(count);
        }

        public ActionResult MarkAsRead(int notificationId)
        {
            var notification = Data.Notifications.Find(notificationId);
            notification.Seen = true;
            Data.SaveChanges();
            return RedirectToAction("AllNotifications");
        }
    }
}