using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Twitter.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(600)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string SenderId { get; set; }

        [JsonIgnore]
        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [JsonIgnore]
        public virtual User Receiver { get; set; }
    }
}
