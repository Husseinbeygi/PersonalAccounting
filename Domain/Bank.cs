using Domain.SeedWork;

namespace Domain
{
	public class Bank : IEntity<int>
	{
		public int Id { get; set; }

		public string Logo { get; set; }

		public int Ordering { get; set; }

		public DateTime InsertDateTime { get; set; }
	}
}