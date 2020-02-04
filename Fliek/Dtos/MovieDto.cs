using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Fliek.Models;

namespace Fliek.Dtos
{
    public class MovieDto
    {
        private DateTime? _releaseDate;
        private int? _numberInStock;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }
       
        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value.HasValue ? ((DateTime?)value.Value) : null; }
        }

        public DateTime DateAdded { get; set; }

        public string Rating { get; set; }

        [Required]
        [Range(0, 20)]
        public int? NumberInStock
        {
            get { return _numberInStock; }
            set { _numberInStock = value.HasValue ? (int?)value.Value : null; }
        }

        public int GenreId { get; set; }
    }
}