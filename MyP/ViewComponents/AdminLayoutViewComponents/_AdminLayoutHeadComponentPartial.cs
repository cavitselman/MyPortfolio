using Microsoft.AspNetCore.Mvc;

namespace MyP.ViewComponents.LayoutViewComponents
{
	public class _AdminLayoutHeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
