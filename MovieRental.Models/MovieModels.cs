using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieRental.Models
{
    [MetadataType(typeof(MovieMetadata))]
    public class Movie
    {
        [Key]
        [Required]
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

    public class MovieMetadata
    {
        [Required(ErrorMessage = "Movie ID is required")]
        [DisplayName("ID")]
        [RegularExpression(@"[a-z]{2}\d{7}$",
            ErrorMessage = "The format should be 2 lowercase letter followed with 7 digits")]
        public string MovieId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [DisplayName("Year")]
        [RegularExpression(@"\d{4}$",
            ErrorMessage = "The format should be 4 digits")]
        public string ReleaseYear { get; set; }
        [DisplayName("Classification")]
        public string FilmRating { get; set; }
        public string Language { get; set; }
        [DisplayName("Poster URL")]
        [Required]
        public string Poster { get; set; }
        [DataType(DataType.MultilineText)]
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

}