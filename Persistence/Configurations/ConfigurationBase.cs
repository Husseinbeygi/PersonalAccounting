using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Persistence.Configurations;

public class ConfigurationBase<TEntity,TKey> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity<TKey>
{
	public virtual void Configure(EntityTypeBuilder<TEntity> builder)
	{
		builder.ToTable(typeof(TEntity).Name);
		builder.HasKey(t => t.Id);


		builder
		.Property(x => x.InsertDateTime)
		.HasDefaultValue(DateTime.UtcNow);

		builder.Property(x => x.Ordering)
		.HasDefaultValue(10_000);

	}
}
