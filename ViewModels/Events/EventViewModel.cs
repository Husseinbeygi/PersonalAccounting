namespace ViewModels.Events;

public record EventViewModel(int Id, string Name);

public record EventCreateViewModel(string Name);

public record EventUpdateViewModel(string Name, int Id) : EventCreateViewModel(Name);

