using System;

namespace ViewModels.Transactions;

public record TransactionViewModel
{
	public int Id { get; set; }
	public string? AccountSideName { get; set; }
	public int Version { get; set; }
	public int Ordering { get; set; }
	public int InsertedBy { get; set; }
	public int UpdatedBy { get; set; }
	public string? CategoryName { get; set; }
	public string? BankAccountName { get; set; }
	public string? CurrencyName { get; set; }
	public string? Description { get; set; }
	public decimal Amount { get; set; }
	public decimal ExchangeRate { get; set; }
	public bool IsForeignCurrency { get; set; }
	public DateTime InsertDateTime { get; set; }
	public DateTime UpdateDateTime { get; set; }
	public DateTime TransactionDateTime { get; set; }
	public string? ProjectName { get; set; }
	public string? EventName { get; set; }

}
