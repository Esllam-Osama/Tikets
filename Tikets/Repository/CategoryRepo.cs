using Tikets.Data;
using Tikets.Models;
using Tikets.Repository.IRepository;

namespace Tikets.Repository
{
    public class CategoryRepo : BaseRepo<Category> , ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext context):base(context) {}
    }
}
