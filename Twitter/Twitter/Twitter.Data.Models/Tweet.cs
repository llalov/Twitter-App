using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Data.Models
{
    public class Tweet
    {

        private ICollection<User> likes;
        private ICollection<User> userRetweets;

        public Tweet()
        {
            this.likes = new HashSet<User>();
            this.userRetweets = new HashSet<User>();
        }

        

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

      
        public string UserId { get; set; }
        public virtual User User { get; set; }  

        public virtual ICollection<User> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<User> UserRetweets
        {
            get { return this.userRetweets; }
            set { this.userRetweets = value; }
        }
         
    }
}
