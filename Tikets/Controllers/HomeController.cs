using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tikets.Models;
using Tikets.Repository;
using Tikets.Repository.IRepository;

namespace Tikets.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepo movies;
        public HomeController(IMovieRepo movies)
        {
            this.movies = movies;
        }

        public IActionResult Index(int pageNumer=1)
        {
            if (pageNumer <=0) {
                ViewBag.error = "Page Number Must be Bigger Than Zero";
                pageNumer = 1;
            }
            return View(movies.GetAllWithPagination(pageNumer));
        }

        
        public IActionResult Error()
        {
            return View();
        }

    }
}
