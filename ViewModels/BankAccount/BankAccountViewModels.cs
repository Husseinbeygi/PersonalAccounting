using System;

namespace ViewModels.BankAccount;

public record BankAccountViewModel
{



	public int Id { get; set; }
	public string Name { get; set; }
	public string? AccountNumber { get; set; }
	public string? Sheba { get; set; }
	public string? CardNumber { get; set; }
	public int BankId { get; set; }
	public string BankName { get; set; }

}

public record BankAccountCreateViewModel
{
	public string Name { get; set; }
	public string? AccountNumber { get; set; }
	public string? Sheba { get; set; }
	public string? CardNumber { get; set; }
	public int BankId { get; set; }
	public string BankName { get; set; }

}


public record BankAccountUpdateViewModel  : BankAccountViewModel
{

}