using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;//Namespace is used to add propery level attributes
using System.Diagnostics.CodeAnalysis;
namespace ArtistCollection.Models
{
    public class Album_Songs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Set foreign key
        [Required(ErrorMessage = "Artist Id is required.")]
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Song Id is required.")]
        public int SongID { get; set; }
        public string SongName { get; set; }
        public int Track { get; set; }
        public int Minutes { get; set; }

        //Set as foreign key
        public Album Album { get; set; }
    }
}
