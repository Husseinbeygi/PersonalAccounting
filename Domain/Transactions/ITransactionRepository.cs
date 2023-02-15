using Domain.SeedWork;

namespace Domain.Transactions;

public interface ITransactionRepository : IRepository<Transaction, int>
{
}
