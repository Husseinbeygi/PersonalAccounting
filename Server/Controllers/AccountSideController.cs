using Domain.AccountSides;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.AccountSides;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSideController : BaseController
	<AccountSide
	, int
	, AccountSideViewModel
	, AccountSideCreateViewModel
	, AccountSideUpdateViewModel>

{
	public AccountSideController(ILogger<AccountSide> logger, IAccountSideRepository repository) : base(logger, repository)
	{
	}
}
