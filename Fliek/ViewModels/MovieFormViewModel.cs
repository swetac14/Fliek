using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Fliek.Models;

 

namespace Fliek.ViewModels
{
    public class MovieFormViewModel
    {
    
        //public Movie movieDB { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie")]
        public string MovieName { get; set; }


        [Display(Name = "Release Date")]
        //[DataType(DataType.DateTime)]
        // [DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
        public DateTime? ReleaseDate
       
            { get; set; }
       
        public string Rating { get; set; }


        [Display(Name = "Number in Stock")]
        [Required]
        [Range(0, 20)]
        public int? NumberInStock
        { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }


        public string PageTitle { 
            get
            {
                // return movieDB.Id != 0 ? "Edit Movie" : "New Movie"; 
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        
        }

        public MovieFormViewModel()
        {
            Id = 0;

        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            MovieName = movie.MovieName;
            ReleaseDate = movie.ReleaseDate;
            Rating = movie.Rating;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}