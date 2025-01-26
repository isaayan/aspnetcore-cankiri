using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data.Abstract
{
    public interface INewsRepository
    {
        IQueryable<News> News { get; }
        void CreatePost(News news);
        void EditPost(News news);
        void EditPost(News news, int[] newsId);
        void Delete(News news);

    }
}