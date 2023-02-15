using Domain.Banks;

namespace Persistence.Repositories;

public class BankRepository : RepositoryBase<Bank, int>, IBankRepository
{
	public BankRepository(DatabaseContext context) : base(context)
	{
	}
}
