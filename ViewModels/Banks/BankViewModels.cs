namespace ViewModels.Banks;

public record BankViewModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Logo { get; set; } = string.Empty;
}

public record BankCreateViewModel
{
	public string Name { get; set; }
	public string Logo { get; set; } = string.Empty;

}

public record BankUpdateViewModel  : BankViewModel { }

