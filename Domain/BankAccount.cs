using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain;

public class BankAccount : IEntity<int>
, IEntityHasIsActive
, IsEntityHasVersionControl
{
	public BankAccount(string name, string? accountNumber,
	string? sheba, string? cardNumber, int bankId, Bank bank,
	decimal firstAmount, int ordering, bool isActive)
	{
		Name = name;
		AccountNumber = accountNumber;
		Sheba = sheba;
		CardNumber = cardNumber;
		BankId = bankId;
		Bank = bank;
		FirstAmount = firstAmount;
		Ordering = ordering;
		IsActive = isActive;

		IncreaseVersion();
	}

	public int Id { get; private set; }
	public string Name { get; private set; }
	public string? AccountNumber { get; private set; }
	public string? Sheba { get; private set; }
	public string? CardNumber { get; private set; }
	public int BankId { get; private set; }
	public Bank Bank { get; private set; }
	public decimal FirstAmount { get; private set; }
	public int Ordering { get; private set; }
	public DateTime InsertDateTime { get; private set; }
	public bool IsActive { get; private set; }
	public int Version { get; private set; }

	public void Update(string name, string? accountNumber,
	string? sheba, string? cardNumber, int bankId, Bank bank,
	decimal firstAmount, int ordering, bool isActive, int version)
	{
		if (Version > version)
		{
			throw new InvalidEntityVersionException();
		}

		Name = name;
		AccountNumber = accountNumber;
		Sheba = sheba;
		CardNumber = cardNumber;
		BankId = bankId;
		Bank = bank;
		FirstAmount = firstAmount;
		Ordering = ordering;
		IsActive = isActive;

		IncreaseVersion();
	}

	public void IncreaseVersion()
	{
		Version++;
	}

}
