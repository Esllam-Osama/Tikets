using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tikets.Models;
using Tikets.Repository;
using Tikets.Fetaures;
using Tikets.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Tikets.Utility;
using Microsoft.EntityFrameworkCore;

namespace Tikets.Controllers
{
    [Authorize(Roles =$"{StaticData.Admin},{StaticData.User}")]
    public class HomeController : Controller
    {
        IMovieRepo movies;
        public HomeController(IMovieRepo movies)
        {
            this.movies = movies;
        }

        public IActionResult Index(int pageNum = 1)
        {
            var items = movies.GetAll(includes: [e => e.Category, e => e.Cinema],
                additionalIncludes:e=>e.Include(e=>e.ActorMovies).ThenInclude(am=>am.Actor));
            var totalPage = (int)Math.Ceiling(items.Count() / (double)12);
            if (pageNum <= 0 || pageNum > totalPage)
            {
                ViewBag.error = $"Page Number Must be Bigger Than Zero and smaller than {totalPage+1}";
                pageNum = 1;
            }
            return View(new PaginationResult<Movie>(items.Skip((pageNum - 1) * 12).Take(12).ToList(), pageNum, totalPage));
        }
        public IActionResult Details(int id)
        {
            var movie = movies.GetOne(e => e.Id == id, includes: [e=>e.Category , e=>e.Cinema], additionalIncludes: e => e.Include(e => e.ActorMovies).ThenInclude(am => am.Actor));
            if (movie != null)
            {
                return View(movie);
            }
            TempData["errors"] = "Movie Not Found";
            return RedirectToAction("Index");
        }
        public IActionResult GetMoviesInCategory(int categoryId, int pageNum=1) {
            var items = movies.GetAll([e => e.Cinema, e=>e.Category],e=>e.CategoryId==categoryId);
            var totalPage = (int)Math.Ceiling(items.Count() / (double)12);
            if (pageNum <= 0 || pageNum > totalPage)
            {
                ViewBag.error = $"Page Number Must be Bigger Than Zero and smaller than {totalPage + 1}";
                pageNum = 1;
            }
            if (items.Count() < 1) {
                TempData["errors"] = $"Not Found movies";
                return Redirect("/Category/Index");
            }
            return View(new PaginationResult<Movie>(items.Skip((pageNum - 1) * 12).Take(12).ToList(), pageNum, totalPage));
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
