using AutoMapper;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories;

public class Repository<TEntity,TDto> : IRepository<TEntity,TDto> where TEntity : class, IEntity
{
    protected readonly DbContext DbContext;
    protected readonly IMapper _mapper;

    protected Repository(AppDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        _mapper = mapper;
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

    public void Add(TDto dto)
    {
        DbContext.Set<TEntity>().Add(_mapper.Map<TEntity>(dto));
    }

    public void AddRange(IEnumerable<TDto> dtos)
    {
        DbContext.Set<TEntity>().AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos));
    }

    public void Remove(TDto dto)
    {
        DbContext.Set<TEntity>().Remove(_mapper.Map<TEntity>(dto));
    }

    public void RemoveRange(IEnumerable<TDto> dtos)
    {
        DbContext.Set<TEntity>().RemoveRange(_mapper.Map<IEnumerable<TEntity>>(dtos));
    }

    public void Update(TDto dto)
    {
        DbContext.Set<TEntity>().Update(_mapper.Map<TEntity>(dto));
    }

    public void UpdateRange(IEnumerable<TDto> dtos)
    {
        DbContext.Set<TEntity>().UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dtos));
    }

    #endregion
}