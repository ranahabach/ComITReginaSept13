using System.Collections.Generic;

namespace Simple.MusicStore.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<Artist> Artists { get; set; }
        public int PageNumber { get; set; }
    }
}