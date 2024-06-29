using Microsoft.AspNetCore.Mvc;

namespace MyP.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
