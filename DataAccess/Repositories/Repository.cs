using System.Linq.Expressions;
using System.Reflection;
using DataAccess.Exceptions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private DbContext DbContext { get; }
    private DbSet<TEntity> DbSet { get; }
    
    public Repository(DbContext context)
    {
        DbContext = context;
        DbSet = DbContext.Set<TEntity>();
    }
    
    public TEntity Find(object id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return DbSet.Find(id);
    }
    
     public async Task<TEntity> FindAsync(object id, CancellationToken cancellation = default)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await DbSet.FindAsync(new[] { id }, cancellation);
    }
    
    public IQueryable<TEntity> Query()
    {
        return DbSet;
    }
    
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentException(null, nameof(predicate));
        }

        return DbSet.Where(predicate);
    }
    
    public Task<IReadOnlyCollection<TProjection>> QueryAsync<TProjection>(
        Func<IQueryable<TEntity>, Task<IReadOnlyCollection<TProjection>>> selector,
        CancellationToken cancellation = new CancellationToken())
    {
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        return selector(DbSet);
    }
    
    public int Count(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return DbSet.Count(predicate);
    }
    
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellation = default)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return await DbSet.CountAsync(predicate, cancellation);
    }
    
    public bool Exists(object key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var parameter = Expression.Parameter(typeof(TEntity), "arg");
        var predicate = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Constant(key, key.GetType()),
                Expression.Property(parameter, GetPrimaryKeyProperty())), parameter);

        return DbSet.Any(predicate);
    }
    
    public async Task<bool> ExistsAsync(object key, CancellationToken cancellation = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var parameter = Expression.Parameter(typeof(TEntity), "arg");
        var predicate = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Constant(key, key.GetType()),
                Expression.Property(parameter, GetPrimaryKeyProperty())), parameter);

        return await DbSet.AnyAsync(predicate, cancellation);
    }
    
    public bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.Any(predicate);
    }
    
    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default)
    {
        return DbSet.AnyAsync(predicate, cancellation);
    }
    
    public void SaveChanges()
    {
        DbContext.SaveChanges();
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellation = default)
    {
        await DbContext.SaveChangesAsync(cancellation);
    }
    
    public void Add(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.ModifyDate = DateTime.UtcNow;
        DbContext.Add(entity);
        SaveChanges();
    }
    
    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellation = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity)); 
        
        entity.ModifyDate = DateTime.UtcNow;
        var entityEntry = await DbContext.AddAsync(entity, cancellation);
        
        await SaveChangesAsync(cancellation);
        
        return entityEntry.Entity.Id;
    }
    
    public void Update(TEntity entity)
    {
        UpdateEntity(entity);

        SaveChanges();
    }
    
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        UpdateEntity(entity);

        await SaveChangesAsync(cancellation);
    }
    
    public void Delete(object key, bool throwIfNotFound)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var entry = Find(key);
        switch (entry)
        {
            case null when throwIfNotFound:
                throw new EntityNotFoundException(
                    $"Не удалось удалить сущность '{typeof(TEntity).Name}' с идентификатором '{key}', т.к. она не была найдена в базе");
            case null:
                return;
            default:
                DbSet.Remove(entry);
                SaveChanges();
                break;
        }
    }
    
    public async Task DeleteAsync(object key, bool throwIfNotFound, CancellationToken cancellation = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var entry = await FindAsync(key, cancellation);

        if (entry == null && throwIfNotFound)
            throw new EntityNotFoundException(
                $"Не удалось удалить сущность '{typeof(TEntity).Name}' с идентификатором '{key}', т.к. она не была найдена в базе");

        if (entry != null)
        {
            DbSet.Remove(entry);
            await SaveChangesAsync(cancellation);
        }
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        var enumerable = entities.ToList();
        if (entities == null || !enumerable.Any())
            throw new ArgumentException(null, nameof(entities));

        foreach (var entity in entities)
        {
            entity.ModifyDate = DateTime.UtcNow;
        }
        
        DbContext.AddRange(enumerable);
        SaveChanges();
    }
    
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
    {
        var enumerable = entities.ToList();
        if (entities == null || !enumerable.Any())
            throw new ArgumentException(null, nameof(entities));

        foreach (var entity in entities)
        {
            entity.ModifyDate = DateTime.UtcNow;
        }
        
        await DbContext.AddRangeAsync(entities, cancellation);

        await SaveChangesAsync(cancellation);
    }
    
    public PropertyInfo GetPrimaryKeyProperty()
    {
        var keyProperties = DbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
            .Select(s => s.PropertyInfo).ToList();

        if (keyProperties.Count < 1 || keyProperties.Count > 1)
            throw new InvalidOperationException("Получение идентификатора поддерживается только для сущностей с простым первичным ключом");

        return keyProperties.Single();
    }
    
    private void UpdateEntity(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.ModifyDate = DateTime.UtcNow;
        var state = DbContext.Entry(entity).State;
        if (state == EntityState.Detached)
            DbContext.Attach(entity);

        DbContext.Update(entity);
    }
}