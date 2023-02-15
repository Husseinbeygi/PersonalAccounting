using Domain.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfigurations : ConfigurationBase<Category,int>
{
	public override void Configure(EntityTypeBuilder<Category> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);


		builder
		.Property(propertyExpression: x => x.Description)
		.HasMaxLength(Constants.MaxLength.Description);

	}
}
