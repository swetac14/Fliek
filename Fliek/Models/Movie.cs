using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fliek.Models
{
    public class Movie
    {
        private DateTime? _releaseDate;
        private int? _numberInStock;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie")]
        public string MovieName { get; set; }


        [Display(Name = "Release Date")]
        //[DataType(DataType.DateTime)]
       // [DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value.HasValue ? ((DateTime?)value.Value) : null; }
        }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Rating { get; set; }


        [Display(Name = "Number in Stock")]
        [Required]
        [Range(0, 20)]
        public int? NumberInStock
        {
            get { return _numberInStock; }
            set { _numberInStock = value.HasValue ? (int?)value.Value : null; }
        }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public GenreType GenreType { get; set; }
    }
}