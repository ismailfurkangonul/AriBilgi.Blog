using AriBilgi.Blog.Shared.Data.Abstract;
using AriBilgi.Blog.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Shared.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public bool AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public int CountAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

        public int CountAsync()
        {
            return _context.Set<T>().Count();
        }

        public void DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public void HardDeleteAsync(T entity)
        {

            _context.Set<T>().Remove(entity);

        }

        public void UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);

        }
    }
}
