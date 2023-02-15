using System;

namespace ViewModels.Transactions;

public record TransactionCreateViewModel 
{
	public int Id { get; private set; }
	public int AccountSideId { get; private set; }
	public int Version { get; private set; }
	public int Ordering { get; private set; }
	public int InsertedBy { get; private set; }
	public int UpdatedBy { get; private set; }
	public int CategoryId { get; private set; }
	public int BankAccountId { get; private set; }
	public int CurrencyId { get; private set; }
	public bool IsUpdatable { get; private set; }
	public bool IsUndeletable { get; private set; }
	public string? Description { get; private set; }
	public decimal Amount { get; private set; }
	public decimal ExchangeRate { get; private set; }
	public bool IsForeignCurrency { get; private set; }
	public DateTime TransactionDateTime { get; private set; }
	public int ProjectId { get; private set; }
	public int EventId { get; private set; }

}