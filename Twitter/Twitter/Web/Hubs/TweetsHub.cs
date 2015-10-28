using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Web.Hubs
{
    [HubName("tweets")]
    public class TweetsHub : Hub
    {
        public void SendTweet(string content, string avatarUrl, string userFullName, string createdAt, int tweetId, int likesCount, int retweetsCount)
        {      
            this.Clients.All.newTweet(content, avatarUrl, userFullName, createdAt, tweetId, likesCount, retweetsCount);
        }
    }
}