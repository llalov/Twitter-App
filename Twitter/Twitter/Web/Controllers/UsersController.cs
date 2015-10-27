using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            var users = this.Data.Users.All();
            return View(users);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        public ActionResult Search([FromUri]string query)
        {
            var resutlWords = Data.Users
                .All()
                .Where(u => u.FullName.StartsWith(query))
                .Select(UserViewModel.Create)
                .ToList();
            return this.Json(resutlWords, JsonRequestBehavior.AllowGet);
        }
    }
}