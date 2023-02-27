using System;
using System.ComponentModel.DataAnnotations;
using Resources;

namespace ViewModels.Transactions;

public record TransactionCreateViewModel 
{
    public TransactionCreateViewModel()
    {
        TransactionDateTime = DateTime.Now;
    }

    public int AccountSideId { get; set; }
	public int Version { get; set; }
	public int Ordering { get; set; }
	public int InsertedBy { get; set; }
	public int UpdatedBy { get; set; }
	public int CategoryId { get; set; }
	public int BankAccountId { get; set; }
	public int CurrencyId { get; set; }
	public bool IsUpdatable { get; set; }
	public bool IsUndeletable { get; set; }
	public string? Description { get; set; }

	[Display(ResourceType = typeof(DataDictionary), 
	Name = nameof(DataDictionary.Amount))]
	public decimal Amount { get; set; }
	public decimal ExchangeRate { get; set; }
	public bool IsForeignCurrency { get; set; }

    [Display(ResourceType = typeof(DataDictionary),
		Name = nameof(DataDictionary.TransactionDateTime))]
    public DateTime TransactionDateTime { get; set; }
	public int ProjectId { get; set; }
	public int EventId { get; set; }

}