using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simple.MusicStore.Web.Models;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        private readonly ArtistService _artistService;

        public HomeController(
            ILogger<HomeController> logger, 
            UserService userService,
            ArtistService artistService)
        {
            _logger = logger;
            _userService = userService;
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            var artist = _artistService.GetAll();
            this.ViewData["Title"] = "This my title";
            this.ViewData["IsLoggedIn"] = true;
            return View(artist);
        }
        
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
