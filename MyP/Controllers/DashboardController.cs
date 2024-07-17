using Microsoft.AspNetCore.Mvc;

namespace MyP.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
