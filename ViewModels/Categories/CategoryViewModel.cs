namespace ViewModels.Category;

public record CategoryViewModel(int Id, int Parent, string Name, string Description);

public record CategoryCreateViewModel(int Parent, string Name, string Description);

public record CategoryUpdateViewModel(int Id, int Parent, string Name, string Description) : CategoryViewModel(Id, Parent, Name, Description);
