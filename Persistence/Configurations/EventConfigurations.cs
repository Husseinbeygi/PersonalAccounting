using Domain.Events;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class EventConfigurations : ConfigurationBase<Event, int>
{
	public override void Configure(EntityTypeBuilder<Event> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);

	}
}