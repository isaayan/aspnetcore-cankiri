using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using project.Entity;

namespace project.Models
{
    public class NewsCreateViewModel
    {
        public int NewsId { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string? Content { get; set; }

        public bool IsActive { get; set; }
    }
}