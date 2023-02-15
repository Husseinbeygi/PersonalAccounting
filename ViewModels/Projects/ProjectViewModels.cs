namespace ViewModels.Projects;

	public record ProjectViewModel(int Id, string Name);

	public record ProjectCreateViewModel(int Id, string Name) : ProjectViewModel(Id, Name);

	public record ProjectUpdateViewModel(string Name);
