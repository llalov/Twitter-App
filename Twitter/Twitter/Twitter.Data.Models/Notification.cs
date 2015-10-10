using System;


namespace Twitter.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
