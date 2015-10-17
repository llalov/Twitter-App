using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Data.Models
{
    public class Tweet
    {

        private ICollection<User> likes;
        private ICollection<User> retweets;

        public Tweet()
        {
            this.likes = new HashSet<User>();
            this.retweets = new HashSet<User>();
        }

        

        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(140)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }  

        public virtual ICollection<User> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<User> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }
         
    }
}
