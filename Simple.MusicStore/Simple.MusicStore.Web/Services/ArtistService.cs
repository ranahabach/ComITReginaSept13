using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    public class ArtistService
    {
        private readonly MusicStoreDbContext _context;

        public ArtistService(MusicStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }
    }
}