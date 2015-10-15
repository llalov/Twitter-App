using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        [Authorize]
        public ActionResult AllUsers()
        {
            var users = this.Data.Users.All();
            return View(users);
        }
    }
}