using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Data.Abstract;
using project.Data.Concrete.EfCore;
using project.Entity;
using project.Models;

namespace project.Controllers
{
    public class DistrictController : Controller
    {
        private IDistrictRepository _districtRepository;

        public DistrictController(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        [Authorize]
        public IActionResult District()
        {
            var districts = _districtRepository.District.ToList();
            return View(districts);
        }


        [HttpPost]
        public IActionResult Update(int id, District model)
        {
            var district = _districtRepository.District.FirstOrDefault(i => i.Id == id);
            if (district == null)
            {
                return Json(new { success = false, message = "District not found." });
            }

            if (ModelState.IsValid)
            {
                _districtRepository.Update(
                    new District
                    {
                        Id = model.Id,
                        Name = model.Name,
                    }
                );
                return Json(new { success = true, message = "District updated successfully." });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var district = _districtRepository.District.FirstOrDefault(n => n.Id == id);
            if (district == null)
            {
                return Json(new { success = false, message = "District not found." });
            }

            _districtRepository.Delete(district);
            return Json(new { success = true, message = "District deleted successfully." });
        }

        [HttpPost]
        public IActionResult Add(District model)
        {
            if (ModelState.IsValid)
            {
                _districtRepository.Add(
                    new District
                    {
                        Id = model.Id,
                        Name = model.Name,
                    }
                );
                return Json(new { success = true, message = "District deleted successfully." });
            }
            return View(model);
        }


    }
}
