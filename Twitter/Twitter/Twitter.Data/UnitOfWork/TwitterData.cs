using System;
using System.Collections.Generic;
using Twitter.Data.Models;
using Twitter.Data.Repositories;

namespace Twitter.Data
{
    public class TwitterData : ITwitterData
    {
        private ITwitterDbContext context;
        private IDictionary<Type, object> repositories;

        public TwitterData(ITwitterDbContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
            
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
            
        }

        public IRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); } 
            
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
              
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
