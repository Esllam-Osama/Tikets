using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tikets.Models;
using Tikets.Repository;
using Tikets.Repository.IRepository;

namespace Tikets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMovieRepo movies;


        public HomeController(ILogger<HomeController> logger ,IMovieRepo movies)
        {
            _logger = logger;
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
