using Domain.AccountSides;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.AccountSides;

namespace Server.Controllers;

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
