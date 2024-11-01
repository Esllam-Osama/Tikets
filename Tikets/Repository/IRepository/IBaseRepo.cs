
using Tikets.Models;

namespace Tikets.Repository.IRepository
{
    public interface IBaseRepo<T> where T : class
    {
        List<T> GetAll(string[]? include=null);
        //T? GetOne();
        //void Update(T entity);
        //void Delete(int id);
    }
}
