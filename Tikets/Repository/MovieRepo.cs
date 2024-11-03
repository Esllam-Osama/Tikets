using Tikets.Data;
using Tikets.Models;
using Tikets.Repository.IRepository;
using Tikets.Fetaures;

namespace Tikets.Repository
{
    public class MovieRepo : BaseRepo<Movie>, IMovieRepo
    {
        ApplicationDbContext _context;
        public MovieRepo(ApplicationDbContext context) : base(context) {
        this._context = context;
        }
    }
}
