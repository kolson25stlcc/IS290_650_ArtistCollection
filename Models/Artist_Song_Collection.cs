using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistCollection.Models
{
    public class Artist_Song_Collection
    {
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }

        public Album Album { get; set; }
        public Artist Artist { get; set; }

    }
}
