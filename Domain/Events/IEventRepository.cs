using Domain.SeedWork;

namespace Domain.Events;

public interface IEventRepository : IRepository<Event,int>
{
}
