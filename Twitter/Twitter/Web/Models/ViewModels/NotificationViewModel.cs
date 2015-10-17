using System;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class NotificationViewModel
    {
        public NotificationType Type { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string SenderFullName { get; set; }

        public string SenderAvatarUrl { get; set; }

        public static Expression<Func<Notification, NotificationViewModel>> Create
        {
            get
            {
                return notification => new NotificationViewModel()
                {
                    Type = notification.Type,
                    SenderId = notification.SenderId,
                    ReceiverId = notification.ReceiverId,
                    CreatedAt = notification.CreatedAt,
                    SenderFullName = notification.Sender.FullName,
                    SenderAvatarUrl = notification.Sender.AvatarUrl
                };
            }
        }
    }
}