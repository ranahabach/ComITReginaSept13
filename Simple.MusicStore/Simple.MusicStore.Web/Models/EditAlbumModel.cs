using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Simple.MusicStore.Tools.Data;

namespace Simple.MusicStore.Web.Models
{
    public class EditAlbumModel
    {
        [Required]
        public int  Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public static class EditAlbumModelExtensions
    {
        public static EditAlbumModel ToModel(this Album album)
        {
            return new EditAlbumModel()
            {
                Id = album.AlbumId,
                Title = album.Title,
                Image = album.Image,
                Artist = album.Artist.Name
            };
        }
    }

    /*
     public EditAlbumModel ToModel()
        {
            return new EditAlbumModel()
            {
                Id = AlbumId,
                Title = Title,
                Image = Image,
                Artist = Artist.Name
            };
        }

        public AddAlbumModel ToModel()
        {

        }
     
     */
}
