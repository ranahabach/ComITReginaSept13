using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.App;
using MusicStore.Common;
using MusicStore.Db;

namespace MusicStore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MusicStoreDbContext _context;

        public HomeController(ILogger<HomeController> logger, MusicStoreDbContext context)
        {
            AlbumService service = new AlbumService();
            Logger loggerOne = new Logger();

            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var a = _context.Artists.FirstOrDefault(a => a.Name == "Charlie Puth");

            foreach (var album in a.Albums)
            {
                Console.WriteLine(album.Title);
            }

            return View();
        }

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
