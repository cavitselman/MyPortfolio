using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Context;
using MyP.DAL.Entities;
using MyP.Models;

namespace MyP.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel model = new UserEditViewModel();
			model.Name = values.Name;
			model.Surname = values.Surname;
			model.PictureUrl = values.ImageUrl;
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel p)
		{
			MyPContext context = new MyPContext();
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			if (user == null)
			{
				return NotFound("Kullanıcı bulunamadı.");
			}

			if (p.Picture != null)
			{
				var extension = Path.GetExtension(p.Picture.FileName);
				var imagename = Guid.NewGuid().ToString() + extension;
				var relativePath = "/userimage/" + imagename; // Resmin relative yolu

				var savelocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userimage", imagename);

				using (var stream = new FileStream(savelocation, FileMode.Create))
				{
					await p.Picture.CopyToAsync(stream);
				}

				// Kullanıcının profil resim yolunu güncelle
				user.ImageUrl = relativePath;

				// Kullanıcıyı güncelleme
				var result = await _userManager.UpdateAsync(user);
				if (!result.Succeeded)
				{
					ModelState.AddModelError(string.Empty, "Profil resmi güncellenirken bir hata oluştu.");
					// Hata durumunda gerekli işlemleri yapabilirsiniz.
				}

				// Veritabanındaki değişiklikleri kaydet
				await context.SaveChangesAsync();
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Lütfen bir resim seçin.");
			}

			return View();
		}


		[HttpGet]
		public IActionResult PasswordEdit()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> PasswordEdit(UserPasswordEditViewModel p)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View();
		}
	}
}
