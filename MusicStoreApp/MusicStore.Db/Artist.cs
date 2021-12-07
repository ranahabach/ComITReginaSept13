using System.Collections.Generic;

namespace MusicStore.Db
{
    public partial class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }

    public partial class Image
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
}