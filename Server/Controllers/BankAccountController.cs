using Domain.BankAccounts;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.BankAccount;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankAccountController : BaseController
	<BankAccount
	, int
	, BankAccountViewModel
	, BankAccountCreateViewModel
	, BankAccountUpdateViewModel>

{
	public BankAccountController(ILogger<BankAccount> logger, IBankAccountRepository repository) : base(logger, repository)
	{
	}
}
