using System.Linq.Expressions;
using System.Reflection;

namespace DataAccess.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellation = default);
    void Add(TEntity entity);
    Task<int> AddAsync(TEntity entity, CancellationToken cancellation = default);
    void Update(TEntity entity);
    Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);
    void Delete(object key, bool throwIfNotFound = true);
    Task DeleteAsync(object key, bool throwIfNotFound = true, CancellationToken cancellation = default);
    void AddRange(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default);
    TEntity Find(object id);
    Task<TEntity> FindAsync(object id, CancellationToken cancellation = default);
    Task<IReadOnlyCollection<TProjection>> QueryAsync<TProjection>(
        Func<IQueryable<TEntity>, Task<IReadOnlyCollection<TProjection>>> selector,
        CancellationToken cancellation = default);
    int Count(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
    bool Exists(object key);
    Task<bool> ExistsAsync(object key, CancellationToken cancellation = default);
    bool Exists(Expression<Func<TEntity, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
    IQueryable<TEntity> Query();
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    PropertyInfo GetPrimaryKeyProperty();
}
