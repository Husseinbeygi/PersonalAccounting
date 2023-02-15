using Domain.AccountSides;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AccountSideConfigurations : ConfigurationBase<AccountSide,int>
{

	public override void Configure(EntityTypeBuilder<AccountSide> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Address)
		.HasMaxLength(Constants.FixedLength.Address);

		builder
		.Property(x => x.Sheba)
		.HasMaxLength(Constants.FixedLength.Sheba);

		builder
		.Property(x => x.Mobile)
		.HasMaxLength(Constants.FixedLength.Mobile);

		builder
		.Property(x => x.AccountNumber)
		.HasMaxLength(Constants.FixedLength.AccountNumber);

		builder
		.Property(x => x.CardNumber)
		.HasMaxLength(Constants.FixedLength.CardNumber);

	}
}
