using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using project.Entity;

namespace project.Data.Concrete.EfCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        public DbSet<News> News => Set<News>();
        public DbSet<History> History => Set<History>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Population> Populations => Set<Population>();
        public DbSet<District> Districts => Set<District>();
        public DbSet<SliderImage> SliderImages => Set<SliderImage>();

    }
}