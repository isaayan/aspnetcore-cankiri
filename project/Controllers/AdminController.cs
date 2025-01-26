using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data.Abstract;

namespace project.Controllers
{

    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userRepository.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteToAdmin(int userId)
        {
            var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                user.Role = "admin"; // Admin yap
                await _userRepository.UpdateUser(user);
            }
            return RedirectToAction("UserList");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteToUser(int userId)
        {
            var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                user.Role = "user"; // User yap
                await _userRepository.UpdateUser(user);
            }
            return RedirectToAction("UserList");
        }

    }

}

