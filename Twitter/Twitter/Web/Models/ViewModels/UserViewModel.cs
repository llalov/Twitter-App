using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return user => new UserViewModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    AvatarUrl = user.AvatarUrl
                };
            }
        }
    }
}