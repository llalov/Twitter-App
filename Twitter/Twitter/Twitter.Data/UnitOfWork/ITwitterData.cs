using Twitter.Data.Models;
using Twitter.Data.Repositories;

namespace Twitter.Data
{
    public interface ITwitterData
    {
        IRepository<User> Users { get; }
        
        IRepository<Tweet> Tweets { get;}
        
        IRepository<Message> Messages { get;}
        
        IRepository<Notification> Notifications { get;}

        int SaveChanges();
    }
}
