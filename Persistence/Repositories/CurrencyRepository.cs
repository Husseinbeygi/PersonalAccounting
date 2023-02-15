using Domain.Currencies;

namespace Persistence.Repositories;

public class CurrencyRepository : RepositoryBase<Currency, int>, ICurrencyRepository
{
	public CurrencyRepository(DatabaseContext context) : base(context)
	{
	}
}
