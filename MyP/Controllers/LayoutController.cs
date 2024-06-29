using Microsoft.AspNetCore.Mvc;

namespace MyP.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
