using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Simple.MusicStore.Tools.Data;
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
            var all = _context.Artist.Include(a => a.Album).ToList();
            return all;
        }

        /*

         public string GetArtist(Artist a)
         {
            return new { a.Name, a.ArtistId };
         }
         
         */

        private Dictionary<int, string> _artists = new Dictionary<int, string>();

        public IEnumerable<ArtistInfoModel> GetArtistNames()
        {

            return _context
                .Artist
                .Select(a => new ArtistInfoModel() { Id = a.ArtistId, Name = a.Name })
                .ToList();
        }

        public IEnumerable<dynamic> GetArtistNamesDynamic()
        {
            return _context
                .Artist
                .ToList()
                .Select(a =>
                {
                    dynamic e = new ExpandoObject();
                    e.Id = a.ArtistId;
                    e.Name = a.Name;
                    return e;
                });
        }

        public async Task<IEnumerable<Artist>> GetAllMatching(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context
                    .Artist
                    .Take(PAGE_SIZE)
                    .Include(a => a.Album)
                    .Where(a => a.Name == "Carlos")
                    .ToListAsync();
            }

            var all = await _context
                .Artist
                .Where(a => a.Name.Contains(searchTerm))
                .Include(a => a.Album)
                .ToListAsync();

            return all;
        }

        public IEnumerable<Artist> GetPage(int page)
        {
            if (page < 1)
            {
                page = 1;
            }

            return _context
                .Artist
                .Skip((page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .Include(a => a.Album)
                .ToList();
        }
    }
}