using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data.Abstract;
using project.Entity;
using project.Models;

namespace project.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<IActionResult> History()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var history = await _historyRepository.History.ToListAsync();

            var historyViewModel = new HistoryViewModel();

            if (string.IsNullOrEmpty(role))
            {
                historyViewModel.History = history.Where(x => x.UserId == userId).ToList();
            }
            else
            {
                historyViewModel.History = history;
            }

            return View(historyViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var history = await _historyRepository
                .History
                .Include(x => x.User) // Ensure 'User' is a navigation property
                .FirstOrDefaultAsync(p => p.HistoryId == id);

            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(HistoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _historyRepository.CreatePost(new History
                {
                    Title = model.Title,
                    Content = model.Content,
                    Description = model.Description,
                    UserId = int.Parse(userId ?? "0"),
                    PublishedOn = DateTime.Now,
                    IsActive = false
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = _historyRepository.History.FirstOrDefault(i => i.HistoryId == id);

            if (history == null)
            {
                return NotFound();
            }

            return View(new HistoryCreateViewModel
            {
                HistoryId = history.HistoryId,
                Title = history.Title,
                Description = history.Description,
                Content = history.Content,
                IsActive = history.IsActive,
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(HistoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var history = _historyRepository.History.FirstOrDefault(i => i.HistoryId == model.HistoryId);

                if (history == null)
                {
                    return NotFound();
                }

                history.Title = model.Title;
                history.Description = model.Description;
                history.Content = model.Content;
                history.IsActive = model.IsActive;

                _historyRepository.EditPost(history);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var history = _historyRepository.History.FirstOrDefault(n => n.HistoryId == id);

            if (history == null)
            {
                return Json(new { success = false, message = "History not found." });
            }

            _historyRepository.Delete(history);

            return Json(new { success = true, message = "History deleted successfully." });
        }
    }
}
