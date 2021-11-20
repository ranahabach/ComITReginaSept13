using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Simple.MusicStore.Web.Models
{
    public class AlbumPageModel
    {
        public List<AlbumModel> Albums { get; set; }
        public int AlbumCount { get; set; }
        public int PageNumber { get; set; }

        public AlbumPageModel()
        {
            Albums = new List<AlbumModel>();
        }
    }

    public class AlbumModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Image { get; set; }
        public int TrackCount { get; set; }
    }
}