using System;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class EditMyProfileViewModel
    {
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}