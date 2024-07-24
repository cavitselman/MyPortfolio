using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.Controllers
{
    public class DashboardController : Controller
    {
        MyPContext context = new MyPContext();
        public IActionResult Index()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Messages.Count();
            ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();
            var values = context.ToDoLists.OrderBy(x => x.Date).ToList();
            return View(values);
        }
    }
}
