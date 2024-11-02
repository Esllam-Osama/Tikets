using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tikets.Data;
using Tikets.Models;
using Tikets.Repository.IRepository;

namespace Tikets.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        ApplicationDbContext _context;
        DbSet<T> _model;
        public BaseRepo(ApplicationDbContext context)
        {
            _context = context;
            _model = _context.Set<T>();
        }
        public List<T> GetAll(Expression < Func<T, object> >[]? includes)
        {
            var query= _model.AsQueryable();
            if (includes !=null && includes.Length>0) {
            foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList() ;
        }
        public T? GetOne(Expression<Func<T, bool>> expression) {
            return _model.FirstOrDefault(expression);
        }
    }
}
