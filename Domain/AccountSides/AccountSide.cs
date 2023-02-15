using Domain.SeedWork;

namespace Domain.AccountSides
{
	public class AccountSide : IEntity<int>
	{
		public int Id { get; private set; }
		public int Ordering { get; private set; }
		public string Name { get; private set; }
		public string? Mobile { get; private set; }
		public string? Type { get; private set; }
		public string? Address { get; private set; }
		public string? AccountNumber { get; private set; }
		public string? Sheba { get; private set; }
		public string? CardNumber { get; private set; }
		public DateTime InsertDateTime { get; private set; }
	}
}