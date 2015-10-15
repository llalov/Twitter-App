using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        [Authorize]
        [HttpGet]
        public ActionResult AllUsers()
        {
            var users = this.Data.Users.All();
            return View(users);
        }
    }
}