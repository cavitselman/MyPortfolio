using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;

namespace MyP.ViewComponents
{
	public class _PortfolioComponentPartial : ViewComponent
	{
		MyPContext context = new MyPContext();
		public IViewComponentResult Invoke()
		{
			var values = context.Portfolios.ToList();
			return View(values);
		}
	}
}
