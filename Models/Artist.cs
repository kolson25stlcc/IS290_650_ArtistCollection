using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Namespace is used to add propery level attributes
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArtistCollection.Models
{
    public class Artist
    {
        [Required(ErrorMessage = "Artist Id is required.")]
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Artist's first name is required.")]
        public string ArtistFirstName { get; set; }

        [Required(ErrorMessage = "Artist's last name is required.")]
        public string ArtistLastName { get; set; }

        [Required(ErrorMessage = "The year the artist was born is required.")]
        public int YearBorn { get; set; }

        public int? YearDied { get; set; }

        public int? YearsActive { get; set; }

        [AllowNull]
        public string Occupation { get; set; }

        public decimal? NetWorth { get; set; }

        [AllowNull]
        public string Hometown { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
        [AllowNull]
        public string Awards { get; set; }
        [AllowNull]
        public string Instruments { get; set; }
        [AllowNull]
        public string Label { get; set; }
        [AllowNull]
        public string Photo { get; set; }


        public ICollection<Artist_Song_Collection> Artist_Song_Collections { get; set; }


    }
}
