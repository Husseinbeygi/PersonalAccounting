using System.Linq.Expressions;

namespace Domain.SeedWork;

public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
{
	Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

	Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

	Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

	Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

	Task<bool> RemoveByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));

	Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IEnumerable<TEntity>> GetSomeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

	Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
}
