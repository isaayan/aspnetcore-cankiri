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
    public class EfHistoryRepository : IHistoryRepository
    {
        private BlogContext _context;
        public EfHistoryRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<History> History => _context.History;

        public void CreatePost(History history)
        {
            _context.History.Add(history);
            _context.SaveChanges();
        }

        public void EditPost(History history)
        {
            var entity = _context.History.FirstOrDefault(i => i.HistoryId == history.HistoryId);

            if (entity != null)
            {
                entity.Title = history.Title;
                entity.Description = history.Description;
                entity.Content = history.Content;
                entity.IsActive = history.IsActive;

                _context.SaveChanges();
            }
        }

        public void EditPost(History history, int[] historyId)
        {
            var entity = _context.History.Include(i => i.HistoryId).FirstOrDefault(i => i.HistoryId == history.HistoryId);

            if (entity != null)
            {
                entity.Title = history.Title;
                entity.Description = history.Description;
                entity.Content = history.Content;
                entity.IsActive = history.IsActive;

                _context.SaveChanges();
            }
        }

        public void Delete(History history)
        {
            _context.History.Remove(history);
            _context.SaveChanges();
        }

    }
}