using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Db
{
    public partial class Album
    {
        public Album()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
