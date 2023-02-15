using Domain.Events;

namespace Persistence.Repositories;

public class EventRepository : RepositoryBase<Event, int>, IEventRepository
{
	public EventRepository(DatabaseContext context) : base(context)
	{
	}
}
