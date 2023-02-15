using Domain.Banks;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.Banks;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankController : BaseController
	<Bank
	, int
	, BankViewModel
	, BankCreateViewModel
	, BankUpdateViewModel>

{
	public BankController(ILogger<Bank> logger, IBankRepository repository) : base(logger, repository)
	{
	}
}
