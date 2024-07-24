using System.ComponentModel.DataAnnotations;

namespace MyP.Models
{
	public class UserEditViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PictureUrl { get; set; }
		public IFormFile Picture { get; set; }
	}
	public class UserPasswordEditViewModel
	{
		[Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
		[DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
		public string PasswordConfirm { get; set; }
	}
}
