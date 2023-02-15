using Domain.Transactions;

namespace Persistence.Repositories;

public class TransactionRepository : RepositoryBase<Transaction, int>, ITransactionRepository
{
	public TransactionRepository(DatabaseContext context) : base(context)
	{
	}
}
