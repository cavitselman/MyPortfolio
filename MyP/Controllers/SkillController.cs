using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.BL.Concrete;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
	public class SkillController : Controller
	{
		private readonly ISkillService _skillService;

		public SkillController(ISkillService skillService)
		{
			_skillService = skillService;
		}

		public IActionResult SkillList()
		{
			var values = _skillService.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSkill()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateSkill(Skill skill)
		{
			_skillService.TAdd(skill);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteSkill(int id)
		{
			var values = _skillService.TGetByID(id);
			_skillService.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateSkill(int id)
		{
			var values = _skillService.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateSkill(Skill skill)
		{
			_skillService.TUpdate(skill);
            return Redirect("/Default/Index#about");
        }
	}
}
