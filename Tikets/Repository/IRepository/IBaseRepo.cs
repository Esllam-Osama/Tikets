
using System.Linq.Expressions;
using Tikets.Models;

namespace Tikets.Repository.IRepository
{
    public interface IBaseRepo<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>>[]? includes);
        T GetOne(Expression<Func<T, bool>> expression);
        //void Update(T entity);
        //void Delete(int id);
    }
}
