using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistCollection.Models
{
    public class Album_Songs
    {
        //Set foreign key
        public int AlbumID { get; set; }
        public int SongID { get; set; }
        public string SongName { get; set; }
        public int Track { get; set; }
        public int Minutes { get; set; }

        //Set as foreign key
        public Album Album { get; set; }
    }
}
