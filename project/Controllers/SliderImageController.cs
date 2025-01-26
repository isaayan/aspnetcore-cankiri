using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data.Concrete.EfCore;
using project.Entity;

namespace project.Controllers
{
    public class SliderImageController : Controller
    {
        private readonly BlogContext _context;

        public SliderImageController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult SliderImage()
        {
            var sliderImages = _context.SliderImages.Where(x => x.IsActive).ToList();
            return View(sliderImages); // Doğru view'e model gönderiyoruz
        }


        [HttpPost]
        public async Task<IActionResult> Add(IFormFile imageFile, string caption)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var sliderImage = new SliderImage
                {
                    ImagePath = $"/images/{fileName}",
                    Caption = caption,
                    IsActive = true
                };

                _context.SliderImages.Add(sliderImage);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _context.SliderImages.FindAsync(id);
            if (image != null)
            {
                _context.SliderImages.Remove(image);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}