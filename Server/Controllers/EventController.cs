using Domain.Events;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.Events;

namespace Server.Controllers;

public class EventController : BaseController
		<Event
		, int
		, EventViewModel
		, EventCreateViewModel
		, EventUpdateViewModel>

{
	public EventController
	(ILogger<EventController> logger,
	IEventRepository repository) : base(logger, repository)
	{
	}
}
