using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }

		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateTestimonial(Testimonial testimonial)
		{
			_testimonialService.TAdd(testimonial);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteTestimonial(int id)
		{
			var values = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var values = _testimonialService.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial testimonial)
		{
			_testimonialService.TUpdate(testimonial);
			return RedirectToAction("Index");
		}
	}
}
