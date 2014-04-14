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
        public ActionResult Index()
        {
            MovieRepository rep = new MovieRepository();
            IEnumerable<Movie> movies = rep.GetAllMovies();

            return View(movies);
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
