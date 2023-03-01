using Domain.SeedWork;
using Domain.Transactions;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.Transactions;

namespace Server.Controllers;

public class TransactionController : BaseController
<Transaction
, int
, TransactionViewModel
, TransactionCreateViewModel
, TransactionUpdateViewModel>
{
	public TransactionController(ILogger<Transaction> logger, ITransactionRepository repository) : base(logger, repository)
	{
	}
}
