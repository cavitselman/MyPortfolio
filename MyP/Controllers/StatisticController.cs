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
			return View();
		}
	}
}
