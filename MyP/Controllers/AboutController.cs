using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{	
    public class AboutController : Controller
    {
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult UpdateAbout(int id)
		{
			var values = _aboutService.TGetByID(1);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateAbout(About about)
		{
			_aboutService.TUpdate(about);
			return RedirectToAction("Index");
		}
	}
}
