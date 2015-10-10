namespace Twitter.Data
{
    using System.Data.Entity;

    using Twitter.Data.Models;

    public interface ITwitterDbContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Message> Messages { get; set; }

        int SaveChanges();
    }
}