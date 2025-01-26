using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data.Abstract;

namespace project.ViewComponents
{
    public class NewNews : ViewComponent
    {
        private INewsRepository _newsRepository;
        public NewNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _newsRepository
                .News
                .OrderByDescending(p => p.PublishedOn)
                .Take(5)
                .ToListAsync()
            );
        }
    }
}