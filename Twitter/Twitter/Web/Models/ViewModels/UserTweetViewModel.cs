using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class UserTweetViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(140, ErrorMessage = "The Tweet can be up to {1} characters long.", MinimumLength = 1)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public string UserFullName { get; set; }

        public string UserAvatarUrl { get; set; }

        public int? LikesCount { get; set; }

        public int? RetweetsCount { get; set; }

        public int? FollowersCount { get; set; }

        public int? FollowingCount { get; set; }

        public int? FavouritesCount { get; set; }

        public static Expression<Func<Tweet, UserTweetViewModel>> Create
        {
            get
            {
                return tweet => new UserTweetViewModel()
                {
                    Id = tweet.Id,
                    Content = tweet.Content,
                    CreatedAt = tweet.CreatedAt,
                    UserFullName = tweet.User.FullName,
                    UserAvatarUrl = tweet.User.AvatarUrl,
                    LikesCount = tweet.Likes.Count,
                    RetweetsCount = tweet.Retweets.Count,
                    FollowersCount = tweet.User.FollowersUsers.Count,
                    FollowingCount = tweet.User.FollowingUsers.Count,
                    FavouritesCount = tweet.User.FavouriteTweets.Count
                };
            }
        }
    }
}