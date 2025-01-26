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
    public class EfDistrictRepository : IDistrictRepository
    {
        private BlogContext _context;
        public EfDistrictRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<District> District => _context.Districts;

        public void Add(District districts)
        {
            _context.Districts.Add(districts);
            _context.SaveChanges();
        }

        public void Update(District districts)
        {
            var entity = _context.Districts.FirstOrDefault(i => i.Id == districts.Id);

            if (entity != null)
            {
                entity.Name = districts.Name;

                _context.SaveChanges();
            }
        }

        public void Delete(District districts)
        {
            _context.Districts.Remove(districts);
            _context.SaveChanges();
        }

    }
}