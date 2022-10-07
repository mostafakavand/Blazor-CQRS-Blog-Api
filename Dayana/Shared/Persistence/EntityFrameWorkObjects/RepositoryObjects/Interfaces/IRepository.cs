using Dayana.Shared.Basic.MethodsAndObjects.Models;
using System.Linq.Expressions;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces;

public interface IRepository<TEntity,TDto> where TEntity : class, IEntity
{
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    void Add(TDto dto);
    void AddRange(IEnumerable<TDto> dtos);
    void Remove(TDto dto);
    void RemoveRange(IEnumerable<TDto> dtos);
    void Update(TDto dto);
    void UpdateRange(IEnumerable<TDto> dtos);
}