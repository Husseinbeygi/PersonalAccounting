using Domain.Projects;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.Projects;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : BaseController
		<Project
		, int
		, ProjectViewModel
		, ProjectCreateViewModel
		, ProjectUpdateViewModel>
{
	public ProjectController(ILogger<Project> logger, IProjectRepository repository) : base(logger, repository)
	{
	}
}
