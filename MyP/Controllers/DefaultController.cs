using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyP.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public DefaultController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadPdf()
        {
            // PDF dosyasının adı
            string fileName = "cv.pdf";

            // PDF dosyasının yolu (wwwroot klasörü içinde)
            string filePath = Path.Combine(_env.WebRootPath, fileName);

            // Dosya var mı kontrol et
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Eğer dosya bulunamazsa 404 hatası döndür
            }

            // PDF dosyasını byte dizisi olarak oku
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // PDF dosyasını response olarak döndür
            return File(fileBytes, "application/pdf", fileName);
        }
    }
}
