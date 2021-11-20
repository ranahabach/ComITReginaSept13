using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simple.MusicStore.Tools.Data;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    public class AlbumService
    {
        private readonly MusicStoreDbContext _context;
        
        public AlbumService(MusicStoreDbContext context)
        {
            _context = context;
        }

        public AlbumPageModel GetPage(int page)
        {
            var albums =  _context
                .Album
                .Skip((page - 1) * Constants.PAGE_SIZE)
                .Take(Constants.PAGE_SIZE)
                .Include(a => a.Track)
                .Select(a => new AlbumModel()
                {
                    Image = a.Image,
                    Artist = a.Artist.Name,
                    Id = a.ArtistId,
                    Title = a.Title,
                    TrackCount = a.Track.Count
                })
                .ToList();

            var pageModel = new AlbumPageModel()
            {
                AlbumCount = 1,
                PageNumber = page,
            };

            pageModel.Albums.AddRange(albums);

            return pageModel;
        }

        public void Add(Album album)
        {
            _context.Album.Add(album);

            _context.SaveChanges();
        }
    }
}