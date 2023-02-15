using Domain.AccountSides;

namespace Persistence.Repositories;

public class AccountSideRepository : RepositoryBase<AccountSide, int>, IAccountSideRepository
{
	public AccountSideRepository(DatabaseContext context) : base(context)
	{
	}
}
