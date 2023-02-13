namespace Domain.Exceptions;

public class InvalidEntityVersionException : Exception
{
	public InvalidEntityVersionException() : base("Optimistic Concurrency Error")
	{
	}
}
