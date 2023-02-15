using Domain.Projects;

namespace Persistence.Repositories;

public class ProjectRepository : RepositoryBase<Project, int>, IProjectRepository
{
	public ProjectRepository(DatabaseContext context) : base(context)
	{
	}
}
