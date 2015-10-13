using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.BindingModels
{
    public class TweetBindingModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int UserId { get; set; }
    }
}
