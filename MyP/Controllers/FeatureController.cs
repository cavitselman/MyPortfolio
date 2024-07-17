using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public IActionResult UpdateFeature(int id)
		{
			var values = _featureService.TGetByID(1);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateFeature(Feature feature)
		{
			_featureService.TUpdate(feature);
			return RedirectToAction("Index");
		}
	}
}
