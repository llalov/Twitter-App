using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class EditMyProfileViewModel
    {
        [Display(Name = "Profile picture")]
        [Url(ErrorMessage = "The Url field is not a valid fully-qualified http, https, or ftp URL")]
        public string AvatarUrl { get; set; }

        [Display(Name = "Full name")]
        [StringLength(50, ErrorMessage = "The full name must be between {2} and {1} characters long", MinimumLength = 2)]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [StringLength(55, ErrorMessage = "Biography can be up to {1} characters long", MinimumLength = 0)]
        public string Biography { get; set; }

        [Display(Name = "Location")]
        [StringLength(55, ErrorMessage = "Country names are between {2} and {1} characters long", MinimumLength = 4)]
        public string Location { get; set; }

        
        [Display(Name = "Website")]
        [Url(ErrorMessage = "The Url field is not a valid fully-qualified http, https, or ftp URL")]
        public string Website { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{mm/dd/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime? BirthDay { get; set; }

       
    }
}