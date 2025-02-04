using Microsoft.EntityFrameworkCore;
using RecipeFinderApp.Core.Entities.Common;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL.Repositories;

public class GenericRepository<T>(RecipeFinderDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
{
    protected DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T model)
        => await Table.AddAsync(model);

    public async Task<List<U>> GetAllAsync<U>(Expression<Func<T, U>> select)
    {
        var models = await Table.Select(select).ToListAsync();
        return models;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, T>> select)
    {
        var models = await Table.Select(select).ToListAsync();
        return models;
    }

    public async Task<int> GetAllCountAsync()
        => await Table.CountAsync();

    public async Task<U?> GetByExpressionAsync<U>(Expression<Func<T, bool>> expression, Expression<Func<T, U>> select)
    {
        var query = Table.Where(expression).Select(select);
        var model = await query.FirstOrDefaultAsync();
        return model;
    }

    public async Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression, Expression<Func<T, T>> select)
    {
        var query = Table.Where(expression).Select(select);
        var model = await query.FirstOrDefaultAsync();
        return model;
    }

    public async Task<U?> GetByIdAsync<U>(int id, Expression<Func<T, U>> select)
        => await GetByExpressionAsync(x => x.Id == id, select);

    public async Task<T?> GetByIdAsync(int id, Expression<Func<T, T>> select)
        => await GetByExpressionAsync(x => x.Id == id, select);
    public async Task<List<U>> GetWhereAsync<U>(Expression<Func<T, bool>> expression, Expression<Func<T, U>> select)
    {
        var query = Table.Where(expression).Select(select);
        var models = await query.ToListAsync();
        return models;
    }

    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression, Expression<Func<T, T>> select)
    {
        var query = Table.Where(expression).Select(select);
        var models = await query.ToListAsync();
        return models;
    }

    public async Task<bool> IsExistAsync(Guid id)
    {
        var model = await Table.FindAsync(id);
        if(model == null) return false;
        return true;
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        var model = await Table.FirstOrDefaultAsync(expression);
        if (model == null) return false;
        return true;
    }

    public void Remove(T model)
        => Table.Remove(model);

    public async Task RemoveAsync(Guid id)
    {
        var model = await Table.FindAsync(id);
        Table.Remove(model!);
    }

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}
