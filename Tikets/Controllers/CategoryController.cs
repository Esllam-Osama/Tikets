using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tikets.Repository.IRepository;

namespace Tikets.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepo Categories;
        public CategoryController(ICategoryRepo Categories)
        {
            this.Categories = Categories;
        }
        //GET: CategoryController
        public ActionResult Index()
        {
            return View(Categories.GetAll([e=>e.Movies]));
        }
    }
}
