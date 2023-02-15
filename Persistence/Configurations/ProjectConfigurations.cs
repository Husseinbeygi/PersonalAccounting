using Domain.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProjectConfigurations : ConfigurationBase<Project, int>
{
	public override void Configure(EntityTypeBuilder<Project> builder)
	{
		base.Configure(builder);

		builder
		.Property(x => x.Name)
		.HasMaxLength(Constants.MaxLength.Name);

	}
}