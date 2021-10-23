using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore2.Web.Models;
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
        public IActionResult Register(User user)
        {
            _userService.Add(user);

            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            return  View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
