using System.Collections;
using System.Collections.Generic;

namespace Simple.MusicStore.Web.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
    
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        // public int ArtistId { get; set; }
        // public Artist Artist { get; set; }
    }
}