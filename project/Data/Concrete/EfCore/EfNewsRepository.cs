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
    public class EfNewsRepository : INewsRepository
    {
        private BlogContext _context;
        public EfNewsRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<News> News => _context.News;

        public void CreatePost(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void EditPost(News news)
        {
            var entity = _context.News.FirstOrDefault(i => i.NewsId == news.NewsId);

            if (entity != null)
            {
                entity.Title = news.Title;
                entity.Description = news.Description;
                entity.Content = news.Content;
                entity.IsActive = news.IsActive;

                _context.SaveChanges();
            }
        }

        public void EditPost(News news, int[] newsId)
        {
            var entity = _context.News.Include(i => i.NewsId).FirstOrDefault(i => i.NewsId == news.NewsId);

            if (entity != null)
            {
                entity.Title = news.Title;
                entity.Description = news.Description;
                entity.Content = news.Content;
                entity.IsActive = news.IsActive;

                _context.SaveChanges();
            }
        }

        public void Delete(News news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }


    }
}