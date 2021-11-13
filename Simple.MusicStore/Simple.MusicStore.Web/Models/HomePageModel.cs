using System.Collections.Generic;
using Simple.MusicStore.Tools.Data;

namespace Simple.MusicStore.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<Artist> Artists { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public int TotalPages { get; set; }
    }
}