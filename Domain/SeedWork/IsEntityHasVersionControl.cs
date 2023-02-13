namespace Domain.SeedWork;

public interface IsEntityHasVersionControl
{
	int Version { get; }

	void IncreaseVersion();

}
