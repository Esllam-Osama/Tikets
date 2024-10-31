using Tikets.Data;
using Tikets.Models;
using Tikets.Repository.IRepository;

namespace Tikets.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        ApplicationDbContext _context;
        public BaseRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            int pageSize = 12;
            var items = _context.Set<T>()
                .ToList();
            return items;
        }
    }
}
