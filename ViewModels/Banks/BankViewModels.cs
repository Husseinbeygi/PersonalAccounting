namespace ViewModels.Banks;

public record BankViewModel(int Id, string Name, string Logo);

public record BankCreateViewModel(int Id, string Name, string Logo) : BankViewModel(Id, Name, Logo);

public record BankUpdateViewModel(string Name, string Logo);
