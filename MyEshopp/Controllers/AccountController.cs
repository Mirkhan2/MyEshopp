using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyEshopp.Data.Repositories;
using MyEshopp.Models;

namespace MyEshopp.Controllers
{
	public class AccountController : Controller
	{
		private IUserRepository _userRepository;
		public AccountController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}


		#region Register
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModels register)
		{
			if (!ModelState.IsValid)
			{
				return View(register);
			}

			if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
			{
				ModelState.AddModelError("Email", "Email is Wrong");
				return View(register);
			}
			Users user = new Users()
			{
				Email = register.Email.ToLower(),
				Password = register.Password,
				IsAdmin = false,
				Registerdate = DateTime.Now

			};
			_userRepository.AddUser(user);

			return View("SuccessRegister", register);
		}
		#endregion

		#region Login
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public  IActionResult login(LoginViewModel login)
		{
			if (!ModelState.IsValid)
			{
				return View(login);
			}
			var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
			if (user == null)
			{
				ModelState.AddModelError("Email", "information is wrong");
				return View(login);
			}
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier , user.UserId.ToString()),
				new Claim(ClaimTypes.Name, user.Email),
			//	new Claim{"UserId", user.Email),
		    };
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var principal = new ClaimsPrincipal(identity);

			var properties = new AuthenticationProperties
			{
				IsPersistent = login.RememberMe
			};

			 HttpContext.SignInAsync(principal, properties);

			return Redirect("/");
		}

		#endregion
		public IActionResult Logout()	
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("/Account/Login");
		}
	}
}
