using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Entity
{
    public class Population
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int GeneralPopulation { get; set; }
        public int MalePopulation { get; set; }
        public int FemalePopulation { get; set; }
        public string? Name { get; internal set; }
    }
}