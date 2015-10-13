using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Web.Controllers
{
    using System.Web.Http;
    public abstract class BaseController : Controller

    {
        private ITwitterData data;

        public BaseController()
            : this (new TwitterData(new TwitterDbContext()))
        {            
        }

        protected BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        protected ITwitterData Data {get; private set;}
    }
}