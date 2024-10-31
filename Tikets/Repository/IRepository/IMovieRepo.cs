using Tikets.Fetaures;
using Tikets.Models;

namespace Tikets.Repository.IRepository
{
    public interface IMovieRepo : IBaseRepo<Movie>
    {
        public PaginationResult<Movie> GetAllWithPagination(int pageNumber);
    }
}
