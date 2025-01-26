using project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User User);
        Task UpdateUser(User user);
    }
}