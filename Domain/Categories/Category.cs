using Domain.SeedWork;

namespace Domain.Categories
{
	public class Category : IEntity<int>
	{
		public int Id { get; private set; }
		public int Ordering { get; private set; }
		public int Parent { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public DateTime InsertDateTime { get; private set; }
	}
}