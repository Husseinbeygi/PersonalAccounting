using Domain.BankAccounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BankAccountConfigurations : ConfigurationBase<BankAccount, int>
{

	public override void Configure(EntityTypeBuilder<BankAccount> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);

		builder
		.Property(x => x.Sheba)
		.HasMaxLength(Constants.FixedLength.Sheba);

		builder
		.Property(x => x.AccountNumber)
		.HasMaxLength(Constants.FixedLength.AccountNumber);

		builder
		.Property(x => x.CardNumber)
		.HasMaxLength(Constants.FixedLength.CardNumber);


	}
}
