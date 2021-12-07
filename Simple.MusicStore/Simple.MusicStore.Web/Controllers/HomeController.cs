using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            ArtistService artistService
            )
        {
            _logger = logger;
            _userService = userService;
            _artistService = artistService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            // this.ViewData["Title"] = "This my title";
            // this.ViewData["IsLoggedIn"] = true;
            // var users = _userService.GetAll();
            if (page < 1) page = 1;
            
            var artists = _artistService.GetPage(page).ToList();
            var total = artists.Count();
            var model = new HomePageModel()
            {
                Artists = artists, 
                CurrentPage = page,
                NextPage = total == 10 ? page + 1 : page,
                PreviousPage = page - 1 == 0 ? 1 : page - 1,
                TotalPages = 25
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string search, int page)
        {
            var artists = (await _artistService.GetAllMatching(search)).ToList();
            var model = new HomePageModel()
            {
                Artists = artists,
                CurrentPage = 1,
                NextPage = 2,
                PreviousPage = 1,
                TotalPages = 25
            };

            return View(model);
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
