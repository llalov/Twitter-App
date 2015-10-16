using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace Twitter.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public NotificationType Type { get; set; }

        [Required]
        public string SenderId { get; set; }

        [JsonIgnore]
        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [JsonIgnore]
        public virtual User Receiver { get; set; }
        
        public DateTime CreatedAt { get; set; }

    }
}
