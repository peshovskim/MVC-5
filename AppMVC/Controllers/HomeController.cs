using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var movies = db.TimeTables.Include(m => m.Movie);
            //var max = db.Movies.Select(x => x.Rating).Max();
           // ViewBag.MaxRatingMovie = db.Movies.Where(x => x.Rating == max).Select(x => x.ImgUrl);
           

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = " ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}