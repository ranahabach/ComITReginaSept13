using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Simple.MusicStore.Web.Models
{
    public class AddAlbumModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }
        // public IFormFile Image { get; set; }
    }
}