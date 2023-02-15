using Domain.Currencies;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CurrencyConfigurations : ConfigurationBase<Currency, int>
{
	public override void Configure(EntityTypeBuilder<Currency> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);

	}
}