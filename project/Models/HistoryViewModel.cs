using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class HistoryViewModel
    {
        public List<History> History { get; set; } = new();
    }
}