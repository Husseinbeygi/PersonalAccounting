namespace ViewModels.AccountSides;

public record AccountSideUpdateViewModel : AccountSideViewModel
{
	public AccountSideUpdateViewModel(int Id,
								   string Name,
								   string? Mobile,
								   string? Type,
								   string? Address,
								   string? AccountNumber,
								   string? Sheba,
								   string? CardNumber) : base(Id, Name, Mobile, Type, Address, AccountNumber, Sheba, CardNumber)
	{
	}
}
