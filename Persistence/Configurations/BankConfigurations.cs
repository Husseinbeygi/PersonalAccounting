using Domain.Banks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BankConfigurations : ConfigurationBase<Bank, int>
{
	public override void Configure(EntityTypeBuilder<Bank> builder)
	{
		base.Configure(builder);


		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);


		builder
		.Property(propertyExpression: x => x.Logo)
		.HasMaxLength(Constants.MaxLength.Icon);

	}
}
