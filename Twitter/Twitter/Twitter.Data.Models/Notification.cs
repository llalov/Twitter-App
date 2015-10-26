using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace Twitter.Data.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public string SenderId { get; set; }

        
        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

         
        public virtual User Receiver { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Seen { get; set; }

    }
}
