using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
	public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

		public ExperienceController(IExperienceService experienceService)
		{
			_experienceService = experienceService;
		}

		public IActionResult ExperienceList()
        {
            var values = _experienceService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _experienceService.TAdd(experience);
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _experienceService.TGetByID(id);
            _experienceService.TDelete(value);            
            return RedirectToAction("ExperienceList");
		}

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _experienceService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _experienceService.TUpdate(experience);
            return Redirect("/Default/Index#about");
        }
    }
}
