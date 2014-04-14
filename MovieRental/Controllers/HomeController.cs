using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10)]
        public ActionResult Index(string genre, string search)
        {
            MovieRepository rep = new MovieRepository();
            IEnumerable<Genre> genres = rep.GetAllGenres();

            IEnumerable<Movie> movies;

            if (!string.IsNullOrEmpty(search))
            {
                movies = rep.FindMoviesByTitle(search);
            }
            else if (!string.IsNullOrEmpty(genre))
            {
                Genre selectedGenre = genres.SingleOrDefault(g => g.Description == genre);
                if (selectedGenre == null)
                {
                    movies = rep.GetAllMovies();
                }
                else
                {
                    movies = selectedGenre.Movies;
                }
            }
            else
            {
                movies = rep.GetAllMovies();
            } 
            
            ViewBag.Genres = genres;

            if (Request.IsAjaxRequest()){
                return PartialView(movies);
            } else {
               return View(movies);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
