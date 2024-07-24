using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyP.DAL.Entities;
using MyP.Models;
using System.ComponentModel.DataAnnotations;

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
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (p.Picture != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(p.Picture.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userimage/" + imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await p.Picture.CopyToAsync(stream);
				user.ImageUrl = imagename;
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
				return RedirectToAction("Index", "Login");
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
