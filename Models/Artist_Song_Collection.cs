using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;//Namespace is used to add propery level attributes
using System.Diagnostics.CodeAnalysis;

namespace ArtistCollection.Models
{
    public class Artist_Song_Collection
    {
        
        [Required(ErrorMessage = "Artist Id is required.")]
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Album Id is required.")]
        public int AlbumID { get; set; }

        public Album Album { get; set; }
        public Artist Artist { get; set; }

    }
}
