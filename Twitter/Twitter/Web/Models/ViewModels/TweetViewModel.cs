using System.ComponentModel.DataAnnotations;
namespace Web.Models
{
    public class CreateTweetViewModel
    {
        [Required]
        [Display(Name = "Compose new Tweet")]
        [StringLength(140, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Content { get; set; }
    }
}