using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WcfChatService1
{
    public class TextMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime SentTime { get; set; }
        [Required]
        public string Sender { get; set; }

    }
}