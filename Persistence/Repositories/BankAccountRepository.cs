using Domain.BankAccounts;

namespace Persistence.Repositories;

public class BankAccountRepository : RepositoryBase<BankAccount, int>, IBankAccountRepository
{
	public BankAccountRepository(DatabaseContext context) : base(context)
	{
	}
}
