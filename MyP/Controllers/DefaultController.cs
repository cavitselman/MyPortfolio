using Microsoft.AspNetCore.Mvc;

namespace MyP.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
