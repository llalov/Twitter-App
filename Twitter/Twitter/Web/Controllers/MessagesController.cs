using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.Data;

namespace Web.Controllers
{
    public class MessagesController : BaseController
    {
        protected MessagesController(ITwitterData data) : base(data)
        {
        }
    }
}