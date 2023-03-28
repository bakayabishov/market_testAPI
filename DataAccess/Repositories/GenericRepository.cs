using System.Linq.Expressions;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly ApplicationDbContext _applicationDbContext;
    public GenericRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await _applicationDbContext.AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddRange(List<TEntity> entity)
    {
        await _applicationDbContext.AddRangeAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> Delete(TEntity entity)
    {
        _ = _applicationDbContext.Remove(entity);
        return await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
    {
        return await _applicationDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        return await (filter == null ? _applicationDbContext.Set<TEntity>().ToListAsync() : _applicationDbContext.Set<TEntity>().Where(filter).ToListAsync());
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _ = _applicationDbContext.Update(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
    {
        _applicationDbContext.UpdateRange(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }
}
