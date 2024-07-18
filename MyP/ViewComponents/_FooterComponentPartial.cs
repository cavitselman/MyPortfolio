using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        MyPContext context = new MyPContext();
        public IViewComponentResult Invoke()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
    }
}
