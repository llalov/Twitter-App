using System;


namespace Twitter.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }


        public string SenderId { get; set; }
        public virtual User Sender { get; set; }
        public string ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
    }
}
