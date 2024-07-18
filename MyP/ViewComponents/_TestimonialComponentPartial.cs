using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.ViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        MyPContext context = new MyPContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
    }
}
