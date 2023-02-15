namespace ViewModels.Currencies;


	public record CurrencyViewModel(int Id, string Name );

	public record CurrencyCreateViewModel(int Id, string Name) : CurrencyViewModel(Id, Name);

	public record CurrencyUpdateViewModel(string Name);

