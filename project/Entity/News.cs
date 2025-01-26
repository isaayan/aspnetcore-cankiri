using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Entity
{
    public class News
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();



    }
}