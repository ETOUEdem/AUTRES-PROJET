using System;
using System.Collections.Generic;
using System.Text;

namespace FeedBackService.Core.Models
{
    public class Feedback
    {

        // public int Id { get; set; }      
        // public Guid IUserId { get; set; }      
        public string Subject { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
