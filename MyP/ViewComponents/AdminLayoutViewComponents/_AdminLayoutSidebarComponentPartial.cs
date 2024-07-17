using Microsoft.AspNetCore.Mvc;

namespace MyP.ViewComponents.LayoutViewComponents
{
	public class _AdminLayoutSidebarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
