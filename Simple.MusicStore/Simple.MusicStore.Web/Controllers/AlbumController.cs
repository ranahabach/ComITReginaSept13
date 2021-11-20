using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS.Core;
using Simple.MusicStore.Tools.Data;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Models;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumService _albumService;
        private readonly ImageService _imageService;
        private readonly ArtistService _artistService;

        public AlbumController(
            AlbumService albumService, 
            ImageService imageService,
            ArtistService artistService)
        {
            _albumService = albumService;
            _imageService = imageService;
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            var model = _albumService.GetPage(1);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddAlbumModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddAlbumModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    var imageFile = new AppFile()
                    {
                        ContentType = image.ContentType,
                        Path = $"/albums/{image.FileName}",
                        FileContents = Convert.ToBase64String(imageBytes)
                    };
                    _imageService.Add(imageFile);

                    var artist = _artistService.GetAllMatching(model.Artist).First();

                    var album = new Album()
                    {
                        ArtistId = artist.ArtistId,
                        Title = model.Title,
                        Image = imageFile.Path,
                    };

                    _albumService.Add(album);
                }

                RedirectToAction("Index");
            }

            return View();
        }
    }
}
