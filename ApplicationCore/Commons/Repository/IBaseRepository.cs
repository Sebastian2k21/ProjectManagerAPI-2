using ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commons.Repository
{
    public interface IBaseRepository<T, TKey> where T : class where TKey : struct
    {
        Task<T> Get(TKey id);
        Task<List<T>> GetAll();
        Task<List<T>> FindAll(Expression<Func<T, bool>> expression);
        Task<T> FindFirst(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(TKey id);

 
    }
}
