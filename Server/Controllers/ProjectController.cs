using Domain.Projects;
using Domain.SeedWork;
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
	public ProjectController(ILogger<Project> logger, IRepository<Project, int> repository) : base(logger, repository)
	{
	}
}
