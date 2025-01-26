using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using project.Entity;

namespace project.Models
{
    public class DistrictCreateViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

    }
}