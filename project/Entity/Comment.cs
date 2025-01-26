using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}