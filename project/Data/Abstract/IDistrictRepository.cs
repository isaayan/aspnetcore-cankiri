using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data.Abstract
{
    public interface IDistrictRepository
    {
        IQueryable<District> District { get; }
        void Add(District district);
        void Update(District district);
        void Delete(District district);
    }
}