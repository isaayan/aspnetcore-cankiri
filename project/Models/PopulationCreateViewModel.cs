using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using project.Entity;

namespace project.Models
{
    public class PopulationCreateViewModel
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int GeneralPopulation { get; set; }

        public int MalePopulation { get; set; }

        public int FemalePopulation { get; set; }
    }
}