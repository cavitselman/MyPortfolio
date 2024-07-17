using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.ViewComponents.LayoutViewComponents
{
	public class _AdminLayoutNavbarComponentPartial:ViewComponent
	{
		MyPContext context = new MyPContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount = context.ToDoLists.Where(x => x.Status == false).Count();
			var values = context.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
