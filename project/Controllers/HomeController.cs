using Microsoft.AspNetCore.Mvc;
using project.Data.Concrete.EfCore;
using project.Entity;
using project.Models;
using System.Diagnostics;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        // Constructor - Dependency Injection ile Logger ve BlogContext alınıyor
        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var sliderImages = _context.SliderImages.Where(x => x.IsActive).ToList();

            if (!sliderImages.Any())
            {
                _logger.LogWarning("SliderImages tablosunda aktif resim bulunamadı.");
            }

            return View(sliderImages);
        }


        public IActionResult Population()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SliderImage()
        {
            var sliderImages = _context.SliderImages.Where(x => x.IsActive).ToList();

            if (!sliderImages.Any())
            {
                _logger.LogWarning("SliderImages tablosunda aktif resim bulunamadı.");
            }

            return View(sliderImages);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
