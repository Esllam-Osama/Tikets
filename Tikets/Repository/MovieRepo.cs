using Tikets.Data;
using Tikets.Models;
using Tikets.Repository.IRepository;
using Tikets.Fetaures;

namespace Tikets.Repository
{
    public class MovieRepo :BaseRepo<Movie> , IMovieRepo
    {
        public MovieRepo(ApplicationDbContext context) : base(context) { }
    public PaginationResult<Movie> GetAllWithPagination(int pageNumber)
    {
            var items = GetAll(pageNumber);
            int pages= items.Count / 12;
            return new PaginationResult<Movie>(items, pages, pageNumber);
    }
    }
    
}
