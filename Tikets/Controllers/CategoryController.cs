using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tikets.Repository.IRepository;
using Tikets.Utility;

namespace Tikets.Controllers
{
    [Authorize(Roles = $"{StaticData.Admin},{StaticData.User}")]
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
        [Authorize(Roles =$"{StaticData.Admin}")]
        public IActionResult GetAllCategoriesForDashbord()
        {
            var categories = Categories.GetAll(includes: [e=>e.Movies]).ToList();
            return View(categories);
        }
    }
}
