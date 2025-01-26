using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data.Abstract
{
    public interface IPopulationRepository
    {
        IQueryable<Population> Population { get; }
        void Add(Population population);
        void Update(Population population);
        void Delete(Population population);
    }
}