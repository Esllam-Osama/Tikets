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
            var allItems = GetAll(); 
            var totalItems = allItems.Count();
            var items = allItems.Skip((pageNumber - 1) * 12).Take(12).ToList();

            int pages = (int)Math.Ceiling(totalItems / 12.0);
            return new PaginationResult<Movie>(items, pageNumber , pages);
        }

    }

}
