using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class PopulationViewModel
    {
        public List<Population> Populations { get; set; } = new();
    }
}