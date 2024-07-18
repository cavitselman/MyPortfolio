using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
		public IActionResult SocialMediaList()
		{
			var values = _socialMediaService.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateSocialMedia(SocialMedia socialMedia)
		{
			_socialMediaService.TAdd(socialMedia);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteSocialMedia(int id)
		{
			var values = _socialMediaService.TGetByID(id);
			_socialMediaService.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
