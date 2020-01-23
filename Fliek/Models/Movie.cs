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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }

        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value.HasValue ? (DateTime?)value.Value : null; }
        }
        public DateTime DateAdded { get; set; }
        public string Rating { get; set; }
        public int NumberInStock { get; set; }
        public GenreType GenreType { get; set; }
    }
}