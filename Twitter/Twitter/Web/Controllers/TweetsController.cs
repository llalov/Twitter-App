using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.Data;

namespace Web.Controllers
{
    public class TweetsController :BaseController
    {
        protected TweetsController(ITwitterData data) : base(data)
        {
        }
    }
}