using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyEshopp.Models
{
	public class RegisterViewModels
	{
		
		[MaxLength(300)]
		[EmailAddress]
		[Display(Name = "Email")]
        [Required(ErrorMessage = "please {0} fill it. ")]
		[Remote("VerifyEmali","Account")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please {0} fill it. ")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

        [Required(ErrorMessage = "please {0} fill it. ")]
		[MaxLength(50)]
		[DataType(DataType.Password)]
		[Compare("Password")]
		[Display(Name = "Password")]
		public string RePassword { get; set; }
	}
	public class LoginViewModel
	{
		[MaxLength(300)]
		[EmailAddress]
		[Display(Name = "Email")]
		[Required(ErrorMessage = "please {0} fill it. ")]

		public string Email { get; set; }

		public string Password { get; set; }

		[Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

    }

}
