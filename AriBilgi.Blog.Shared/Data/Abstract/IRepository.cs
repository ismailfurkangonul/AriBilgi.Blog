using AriBilgi.Blog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Shared.Data.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T GetAsync(Expression<Func<T, bool>> predicate);
        List<T> GetAllAsync();
        List<T> GetAllAsync(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void HardDeleteAsync(T entity);
        int  CountAsync(Expression<Func<T, bool>> predicate);
        int  CountAsync();
        bool AnyAsync(Expression<Func<T, bool>> predicate);
       

    }
}
