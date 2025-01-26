using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Entity
{
    public class SliderImage
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string? Caption { get; set; }
        public bool IsActive { get; set; }
    }
}