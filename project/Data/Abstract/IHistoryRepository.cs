using Microsoft.Extensions.Hosting;
using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data.Abstract
{
    public interface IHistoryRepository
    {
        IQueryable<History> History { get; }
        void CreatePost(History history);
        void EditPost(History history);
        void EditPost(History history, int[] historyId);
        void Delete(History history);
    }
}