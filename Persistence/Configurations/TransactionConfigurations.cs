using Domain.Transactions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class TransactionConfigurations : ConfigurationBase<Transaction,int>
{
	public override void Configure(EntityTypeBuilder<Transaction> builder)
	{
		base.Configure(builder);


		builder
		.Property(propertyExpression: x => x.Description)
		.HasMaxLength(Constants.MaxLength.Description);

	}
}
