using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Data.Abstract;
using project.Data.Concrete.EfCore;
using project.Entity;
using project.Models;

namespace project.Controllers
{
    public class PopulationController : Controller
    {
        private IPopulationRepository _populationRepository;

        public PopulationController(IPopulationRepository populationRepository)
        {
            _populationRepository = populationRepository;
        }

        [Authorize]
        public IActionResult Population()
        {
            var populations = _populationRepository.Population.ToList();
            return View(populations);
        }


        [HttpPost]
        public IActionResult Update(int id, Population model)
        {
            var populations = _populationRepository.Population.FirstOrDefault(i => i.Id == id);
            if (populations == null)
            {
                return Json(new { success = false, message = "Population not found." });
            }

            if (ModelState.IsValid)
            {
                _populationRepository.Update(
                    new Population
                    {
                        Id = model.Id,
                        Year = model.Year,
                        GeneralPopulation = model.GeneralPopulation,
                        MalePopulation = model.MalePopulation,
                        FemalePopulation = model.FemalePopulation
                    }
                );
                return Json(new { success = true, message = "Population updated successfully." });
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var population = _populationRepository.Population.FirstOrDefault(n => n.Id == id);
            if (population == null)
            {
                return Json(new { success = false, message = "Population not found." });
            }

            _populationRepository.Delete(population);
            return Json(new { success = true, message = "Population deleted successfully." });
        }

        [HttpPost]
        public IActionResult Add(Population model)
        {
            if (ModelState.IsValid)
            {
                _populationRepository.Add(
                    new Population
                    {
                        Id = model.Id,
                        Year = model.Year,
                        GeneralPopulation = model.GeneralPopulation,
                        MalePopulation = model.MalePopulation,
                        FemalePopulation = model.FemalePopulation
                    }
                );
                return Json(new { success = true, message = "Population deleted successfully." });
            }
            return View(model);
        }


    }
}
