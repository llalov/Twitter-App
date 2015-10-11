using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.Data;

namespace Web.Controllers
{
    public class NotificationsController : BaseController
    {
        protected NotificationsController(ITwitterData data) : base(data)
        {
        }
    }
}