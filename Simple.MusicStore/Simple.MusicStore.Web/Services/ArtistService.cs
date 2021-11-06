using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    public class ArtistService
    {
        private readonly MusicStoreDbContext _context;
        private int PAGE_SIZE = 10;
    
        public ArtistService(MusicStoreDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Artist> GetAll()
        { 
            var all = _context.Artists.Include(a => a.Albums).ToList();
            return all;
        }

        public IEnumerable<Artist> GetAllMatching(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _context
                    .Artists
                    .Take(PAGE_SIZE)
                    .Include(a => a.Albums)
                    .ToList();
            }

            var all = _context
                .Artists
                .Where(a => a.Name.Contains(searchTerm))
                .Include(a => a.Albums)
                .ToList();

            return all;
        }
    }
}