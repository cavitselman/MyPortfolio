using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        MyPContext context = new MyPContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription = context.Abouts.Select(x=>x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail=context.Abouts.Select(x=>x.Details).FirstOrDefault();
            return View();
        }
    }
}
