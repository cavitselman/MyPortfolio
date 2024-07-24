using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.Controllers
{
	public class StatisticController : Controller
	{
		MyPContext context = new MyPContext();
		public IActionResult Index()
		{
			ViewBag.v1 = context.Skills.Count();
			ViewBag.v2 = context.Messages.Count();
			ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();
			ViewBag.v5 = context.Portfolios.Count();
			ViewBag.v6 = context.ToDoLists.Count();
			ViewBag.v7 = context.ToDoLists.Where(x => x.Status == true).Count();
			ViewBag.v8 = context.ToDoLists.Where(x => x.Status == false).Count();
			ViewBag.v9 = context.Testimonials.Count();
			ViewBag.v10 = context.SocialMedias.Count();
			ViewBag.v11 = context.Experiences.Count();
			ViewBag.v12 = context.AdminReplys.Count();
			return View();
		}
	}
}
