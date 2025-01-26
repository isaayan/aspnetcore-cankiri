using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Hosting;
using project.Data.Abstract;
using project.Data.Concrete.EfCore;
using project.Entity;
using project.Models;

namespace project.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;
        private ICommentRepository _commentRepository;

        public async Task<IActionResult> News()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();
            var userId = int.Parse(userIdClaim);

            var role = User.FindFirstValue(ClaimTypes.Role);

            var news = await _newsRepository.News.ToListAsync(); // Get all news asynchronously

            var newsViewModel = new NewsViewModel(); // Create an empty NewsViewModel

            newsViewModel.News = news; // Assign all news if no role filter

            return View(newsViewModel);
        }

        public NewsController(INewsRepository newsRepository, ICommentRepository commentRepository)
        {
            _newsRepository = newsRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _newsRepository
                        .News
                        .Include(x => x.User)
                        .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                        .FirstOrDefaultAsync(p => p.NewsId == id));
        }

        [HttpPost]
        public JsonResult AddComment(int NewsId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                NewsId = NewsId,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);

            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(NewsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _newsRepository.CreatePost(
                    new News
                    {
                        Title = model.Title,
                        Content = model.Content,
                        Description = model.Description,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        IsActive = false
                    }
                );
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

            var news = _newsRepository.News.FirstOrDefault(i => i.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(new NewsCreateViewModel
            {
                NewsId = news.NewsId,
                Title = news.Title,
                Description = news.Description,
                Content = news.Content,
                IsActive = news.IsActive,
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(NewsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = _newsRepository.News.FirstOrDefault(i => i.NewsId == model.NewsId);

                if (news == null)
                {
                    return NotFound();
                }

                news.Title = model.Title;
                news.Description = model.Description;
                news.Content = model.Content;
                news.IsActive = model.IsActive;

                _newsRepository.EditPost(news);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var news = _newsRepository.News.FirstOrDefault(n => n.NewsId == id);
            if (news == null)
            {
                return Json(new { success = false, message = "News not found." });
            }

            _newsRepository.Delete(news);
            return Json(new { success = true, message = "News deleted successfully." });
        }

    }
}