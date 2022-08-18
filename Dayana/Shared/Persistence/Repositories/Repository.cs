using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dayana.Shared.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DbContext DbContext;

    protected Repository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #region Queries

    public async Task<bool> ExistsAsync(int id)
    {
        return await DbContext.Set<TEntity>().AnyAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().AnyAsync(predicate);
    }

    #endregion

    #region Commands

    public void Add(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbContext.Set<TEntity>().UpdateRange(entities);
    }

    #endregion
}