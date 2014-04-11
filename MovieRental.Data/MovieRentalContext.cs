using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MovieRental.Models;

namespace MovieRental.Data
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext()
            : base()
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}