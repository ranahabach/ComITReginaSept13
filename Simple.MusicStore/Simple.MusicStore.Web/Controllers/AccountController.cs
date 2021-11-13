using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Simple.MusicStore.Tools.Data;
using Simple.MusicStore.Web.Models;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Web.Controllers
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
            return View(new RegisterModel());
        }

        [HttpPost]
        public IActionResult Register(User userModel)
        {
            if (!_userService.IsValidPassword(userModel.Password))
            {
                var errorModel = new RegisterModel
                {
                    IsError = true,
                    ErrorMessage = "The password is not valid, it must contain a number and capital more than 6 characters",
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    Password = userModel.Password,
                };

                return View(errorModel);
            }

            _userService.Add(userModel);

            return RedirectToAction("Index", "Home");
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
                var errorModel = new LoginModel
                {
                    IsError = true,
                    ErrorMessage = "Could not find the email address in our database",
                    EmailAddress = model.EmailAddress,
                    Password = model.Password
                };

                return View(errorModel);
            }

            // check the password 
            if (model.Password != user.Password)
            {
                var errorModel = new LoginModel
                {
                    IsError = true,
                    ErrorMessage = "The user password is wrong"
                };

                return View(errorModel);
            }

            // Login the user to application 
            var principal = _userService.CreateUserPrincipal(user, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await HttpContext.SignInAsync(principal);
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
