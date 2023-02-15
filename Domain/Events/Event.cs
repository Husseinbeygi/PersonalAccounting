using Domain.SeedWork;

namespace Domain.Events
{
	public class Event : IEntity<int>
	{
		public int Id { get; private set; }
		public int Ordering { get; private set; }
		public string Name { get; private set; }
		public DateTime InsertDateTime { get; private set; }
	}
}