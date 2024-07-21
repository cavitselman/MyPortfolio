using Microsoft.AspNetCore.Mvc;
using MyP.BL.Abstract;
using MyP.DAL.Entities;

namespace MyP.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
		public IActionResult PortfolioList()
		{
			var values = _portfolioService.TGetList();
			return View(values);
		}

		[HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var values = _portfolioService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            _portfolioService.TUpdate(portfolio);
            return Redirect("/Default/Index#works");
        }
    }
}
