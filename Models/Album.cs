using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Namespace is used to add propery level attributes
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArtistCollection.Models
{
    public class Album
    {
        [Display(Name = "Album ID")]
        [Required(ErrorMessage = "Album Id is required.")]
        public int AlbumID { get; set; }

        [Display(Name = "Album Name")]
        [Required(ErrorMessage = "Album Name is required.")]
        public string AlbumName { get; set; }

        [Required(ErrorMessage ="Year is required.")]
        public int Year { get; set; }

        //[Required(ErrorMessage="Genre is required.")]
        [AllowNull]
        public string Genre { get; set; }


       // public ICollection<Album_Songs>  Album_Songs { get; set; }
        //public ICollection<Artist_Song_Collection> Artist_Song_Collections { get; set; }





    }
}
