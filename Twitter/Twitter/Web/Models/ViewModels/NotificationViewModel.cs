using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Twitter.Data.Models;

namespace Web.Models.ViewModels
{
    public class NotificationViewModel
    {
        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string SenderFullName { get; set; }

        [Required]
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