using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<List<U>> GetAllAsync<U>(Expression<Func<T, U>> select);
        Task<List<T>> GetAllAsync(Expression<Func<T,T>> select);
        Task<List<U>> GetWhereAsync<U>(Expression<Func<T, bool>> expression, Expression<Func<T, U>> select);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression, Expression<Func<T, T>> select);
        Task<U?> GetByIdAsync<U>(int id, Expression<Func<T, U>> select);
        Task<T?> GetByIdAsync(int id, Expression<Func<T, T>> select);
        Task<U?> GetByExpressionAsync<U>(Expression<Func<T, bool>> expression, Expression<Func<T, U>> select);
        Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, T>> select);
        Task<bool> IsExistAsync(Guid id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T model);
        Task RemoveAsync(Guid id);
        void Remove(T  model);
        Task<int> GetAllCountAsync();
        Task SaveAsync();
    }
}
