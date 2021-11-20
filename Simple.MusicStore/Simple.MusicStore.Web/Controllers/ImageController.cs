using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageService _imageService;

        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Full(string imagePath)
        {
            var image = _imageService.Find(imagePath);
            var imageBytes = Convert.FromBase64String(image.FileContents);
            return File(imageBytes, image.ContentType);
        }

        public IActionResult Thumbnail()
        {
            return NotFound();
        }
    }
}
