using System;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class UserTweetViewModel
    {
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserFullName { get; set; }

        public string UserAvatarUrl { get; set; }

        public int LikesCount { get; set; }

        public int RetweetsCount { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int FavouritesCount { get; set; }

        public static Expression<Func<Tweet, UserTweetViewModel>> Create
        {
            get
            {
                return tweet => new UserTweetViewModel()
                {
                    Content = tweet.Content,
                    CreatedAt = tweet.CreatedAt,
                    UserFullName = tweet.User.FullName,
                    UserAvatarUrl = tweet.User.AvatarUrl,
                    LikesCount = tweet.Likes.Count,
                    RetweetsCount = tweet.UserRetweets.Count,
                    FollowersCount = tweet.User.FollowersUsers.Count,
                    FollowingCount = tweet.User.FollowingUsers.Count,
                    FavouritesCount = tweet.User.FavouriteTweets.Count
                };
            }
        }
    }
}