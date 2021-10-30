using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MusicStore2.Web.Models;
using Simple.MusicStore.Web.Models;
using Simple.MusicStore.Web.Services;

namespace MusicStore2.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel userModel)
        {
            _userService.Add(userModel);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return  View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userService.Find(model.EmailAddress);

            if (user == null)
            {
                var errorModel = new LoginModel();
                errorModel.IsError = true;
                errorModel.ErrorMessage = "Could not find the email address in our database";
                return View(errorModel);
            }

            // check the password 
            if (model.Password != user.Password)
            {
                var errorModel = new LoginModel();
                errorModel.IsError = true;
                errorModel.ErrorMessage = "The user password is wrong";
                return View(errorModel);
            }

            // Login the user to application 
            var claims = new List<Claim>();  
            claims.Add(new Claim("FirstName","Lolo"));
            claims.Add(new Claim("LastName","Perez"));
            claims.Add(new Claim("EmailAddress", "admin@musicstore.com"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "admin@musicstore.com"));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
