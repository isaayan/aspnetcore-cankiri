using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using project.Data.Abstract;
using project.Data.Concrete.EfCore;
using project.Entity;

namespace project.Data.Concrete.EfCore
{
    public class EfPopulationRepository : IPopulationRepository
    {
        private BlogContext _context;
        public EfPopulationRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Population> Population => _context.Populations;


        public void Add(Population populations)
        {
            _context.Populations.Add(populations);
            _context.SaveChanges();
        }

        public void Update(Population populations)
        {
            var entity = _context.Populations.FirstOrDefault(i => i.Id == populations.Id);

            if (entity != null)
            {
                entity.Year = populations.Year;
                entity.GeneralPopulation = populations.GeneralPopulation;
                entity.MalePopulation = populations.MalePopulation;
                entity.FemalePopulation = populations.FemalePopulation;

                _context.SaveChanges();
            }
        }

        public void Delete(Population populations)
        {
            _context.Populations.Remove(populations);
            _context.SaveChanges();
        }

    }
}