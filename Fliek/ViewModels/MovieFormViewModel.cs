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
    
        public Movie movie { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public string PageTitle { 
            get
            {
                return movie.Id == 0 ? "New Movie" : "Edit Movie";                 
            }
        
        }
    }
}