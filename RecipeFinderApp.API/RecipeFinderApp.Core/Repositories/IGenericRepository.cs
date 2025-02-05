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
        Task AddAsync(T entity);
        void Delete(T  entity);
        Task DeleteAndSaveAsync(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<U>> GetAllAsync<U>(Expression<Func<T, U>> select,bool getAll = false, bool asNoTrack = true,bool isDeleted = true);
        Task<IEnumerable<U>> GetAllAsync<U>(Expression<Func<T,U>> select, bool isDeleted = true);
        Task<U?> GetByIdAsync<U>(int id, Expression<Func<T, U>> select, bool asNoTrack = true, bool isDeleted = true);
        Task<T?> GetByIdAsync(int id, bool asNoTrack = true, bool isDeleted = true);
        Task<U?> GetFirstAsync<U>(int id, Expression<Func<T, bool>> expression, Expression<Func<T, U>> select, bool asNoTrack = true, bool isDeleted = true);
        Task<IEnumerable<U>> GetWhereAsync<U>(Expression<Func<T, bool>> expression, Expression<Func<T, U>> select, bool asNoTrack = true, bool isDeleted = true);
       
        Task<bool> IsExistAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        void ReverseSoftDelete(T entity);
        Task ReverseSoftDeleteAsync(int id);
        Task<int> SaveAsync();
        void SoftDelete(T entity);
        Task SoftDeleteAsync(int id);
        
    }
}
