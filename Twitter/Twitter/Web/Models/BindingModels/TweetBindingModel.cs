
using System.ComponentModel.DataAnnotations;


namespace Web.Models.BindingModels
{
    public class TweetBindingModel
    {
        [Required]
        [Display(Name = "Compose new Tweet")]
        [StringLength(140, ErrorMessage = "The Tweet can be up to {1} characters long.", MinimumLength = 1)]
        public string Content { get; set; }

    }
}
