namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Data.Migrations;
    using Twitter.Data.Models;

    public class TwitterDbContext : IdentityDbContext<User>, ITwitterDbContext
    {
        public TwitterDbContext()
            : base("TwitterDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Notification> Notifications { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions 
               .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
            .HasMany(u=>u.FollowersUsers)
            .WithMany()
            .Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("FollowerId");
                m.ToTable("UserFollowers");
            });

            modelBuilder.Entity<User>()
               .HasMany(u => u.FollowingUsers)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("UserId");
                   m.MapRightKey("FollowedUserId");
                   m.ToTable("FollowedUsers");
               });

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(u => u.InvolvedNotifications)
               .WithRequired(m => m.Sender)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedNotifications)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.User)
                .WithMany(t => t.OwnTweets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.OwnTweets);

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Likes)
                .WithMany(t => t.FavouriteTweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("FavouriteTweets");
                });

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Retweets)
                .WithMany(t => t.Retweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("Retweets");
                });

            base.OnModelCreating(modelBuilder);
        }      
    }
}