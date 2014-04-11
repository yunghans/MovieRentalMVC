using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieRental.Models
{
    public class Movie
    {
        [Key][Required]
        public string MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string FilmRating { get; set; }
        public string Language { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        private List<Genre> genres = new List<Genre>();
        public virtual List<Genre> Genres
        {
            get
            {
                return genres;
            }
            set
            {
                genres = value;
            }
        }
        [Required]
        public int NoInStock { get; set; }
        [Required]
        public double RentalRate { get; set; }
        public string ImdbRating { get; set; }
    }

    public class Genre
    {
        public Genre() { }
        public Genre(string genre)
        {
            Description = genre;
        }
        [Key]
        public string Description { get; set; }
        private List<Movie> movies = new List<Movie>();
        public virtual List<Movie> Movies
        {
            get
            {
                return movies;
            }
        }
    }
}