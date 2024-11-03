
using System.Linq.Expressions;
using Tikets.Models;

namespace Tikets.Repository.IRepository
{
    public interface IBaseRepo<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, object>>[]? includes = null);
        T? GetOne(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[]? includes = null);
    }
}
