using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fliek.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
    }
}