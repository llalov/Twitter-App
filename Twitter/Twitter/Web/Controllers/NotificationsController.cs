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
        public ActionResult AllNotfications()
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

        /*[HttpGet]
        [Authorize]
        public ActionResult UnreadNotifications()
        {
            // TO DO (first a column wiht name "seen" needs to be added in the notifications table so 
            that and depending on if the notification is not seen it will render 
            in the view for this action)    
        }*/
    }
}