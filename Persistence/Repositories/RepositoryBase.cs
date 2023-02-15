using System.Linq.Expressions;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    public RepositoryBase(DbContext context)
    {
		DatabaseContext = context ?? throw new ArgumentNullException("databaseContext");
        DbSet = DatabaseContext.Set<TEntity>();
    }


    protected DbSet<TEntity> DbSet { get; }

    protected DbContext DatabaseContext { get; }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        await DbSet.AddAsync(entity, cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
        {
            throw new ArgumentNullException("entities");
        }

        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        TEntity entity2 = entity;
        if (entity2 == null)
        {
            throw new ArgumentNullException("entity");
        }

        await Task.Run(delegate
        {
            DbSet.Remove(entity2);
        }, cancellationToken);
    }

    public virtual async Task<bool> RemoveByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        TEntity entity = await FindAsync(id, cancellationToken);
        if (entity == null)
        {
            return false;
        }

        await RemoveAsync(entity, cancellationToken);
        return true;
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
        {
            throw new ArgumentNullException("entities");
        }

        foreach (TEntity entity in entities)
        {
            await RemoveAsync(entity, cancellationToken);
        }
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        TEntity entity2 = entity;
        await Task.Run(delegate
        {
            EntityEntry<TEntity> entityEntry = DatabaseContext.Attach(entity2);
            if (entityEntry.State != EntityState.Modified)
            {
                entityEntry.State = EntityState.Modified;
            }
        }, cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object[1] { id }, cancellationToken);
    }

    public virtual Task<IEnumerable<TEntity>> GetSomeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await FindAsync(id, cancellationToken);
    }

    public virtual async Task SaveChangesAsync()
    {
        await DatabaseContext.SaveChangesAsync();
    }
}

