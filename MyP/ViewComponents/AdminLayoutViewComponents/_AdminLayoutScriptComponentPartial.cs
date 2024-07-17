using Microsoft.AspNetCore.Mvc;

namespace MyP.ViewComponents.LayoutViewComponents
{
	public class _AdminLayoutScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
