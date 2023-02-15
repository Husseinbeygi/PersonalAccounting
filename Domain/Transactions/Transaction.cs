using Domain.Exceptions;
using System;
using Domain.SeedWork;
using Domain.AccountSides;
using Domain.Categories;
using Domain.BankAccounts;
using Domain.Currencies;
using Domain.Projects;
using Domain.Events;

namespace Domain.Transactions;

public class Transaction :
IEntity<int>
, IEntityHasUpdateDateTime
, IEntityHasIsUnupdatable
, IEntityHasIsUndeletable
, IsEntityHasVersionControl
{
	private Transaction(int debtor, int creditor, int bankAccount,
	string? description, decimal creditAmount,
	decimal exchangeRate, bool isForeignCurrency, DateTime transactionDateTime, int currency, int insertedBy)
	{
		AccountSideId = debtor;
		CategoryId = creditor;
		BankAccountId = bankAccount;
		Description = description;
		Amount = creditAmount;
		ExchangeRate = exchangeRate;
		IsForeignCurrency = isForeignCurrency;
		TransactionDateTime = transactionDateTime;
		CurrencyId = currency;

		IncreaseVersion();

		SetUpdateDateTime();
		InsertedBy = insertedBy;
	}

	// FOR EF!
	public Transaction()
	{
	}

	public int Id { get; private set; }
	public int AccountSideId { get; private set; }
	public AccountSide AccountSide { get; private set; }
	public int Version { get; private set; }
	public int Ordering { get; private set; }
	public int InsertedBy { get; private set; }
	public int UpdatedBy { get; private set; }
	public int CategoryId { get; private set; }
	public Category Category { get; private set; }
	public int BankAccountId { get; private set; }
	public BankAccount BankAccount { get; private set; }
	public int CurrencyId { get; private set; }
	public Currency Currency { get; private set; }
	public bool IsUpdatable { get; private set; }
	public bool IsUndeletable { get; private set; }
	public string? Description { get; private set; }
	public decimal Amount { get; private set; }
	public decimal ExchangeRate { get; private set; }
	public bool IsForeignCurrency { get; private set; }
	public DateTime InsertDateTime { get; private set; }
	public DateTime UpdateDateTime { get; private set; }
	public DateTime TransactionDateTime { get; private set; }
	public int ProjectId { get; private set; }
	public Project Project { get; private set; }
	public int EventId { get; private set; }
	public Event Event { get; private set; }

	public void IncreaseVersion()
	{
		Version++;
	}

	public void SetUpdateDateTime()
	{
		UpdateDateTime = DateTime.UtcNow;
	}

	public static Transaction Insert(int debtor, int creditor,
	int bankAccount, string? description,
	decimal creditAmount, DateTime transactionDateTime, int currency,
	int insertedBy, decimal exchangeRate = 1m, bool isForeignCurrency = false)
	{
		var _transaction = new Transaction(debtor, creditor,
		bankAccount, description, creditAmount,
		exchangeRate, isForeignCurrency, transactionDateTime, currency, insertedBy);

		return _transaction;


	}

	public void Update(int debtor, int creditor, int bankAccount,
			string? description, decimal creditAmount,
			DateTime transactionDateTime, int currency, int updatedBy, int version,
			decimal exchangeRate = 1m, bool isForeignCurrency = false)
	{
		if (Version > version)
		{
			throw new InvalidEntityVersionException();
		}

		AccountSideId = debtor;
		CategoryId = creditor;
		BankAccountId = bankAccount;
		Description = description;
		Amount = creditAmount;
		ExchangeRate = exchangeRate;
		IsForeignCurrency = isForeignCurrency;
		TransactionDateTime = transactionDateTime;
		CurrencyId = currency;
		UpdatedBy = updatedBy;

		IncreaseVersion();
		SetUpdateDateTime();

	}


}
