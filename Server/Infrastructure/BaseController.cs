using Cyrus.Results;
using Domain.SeedWork;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Server.Infrastructure;

[Route("api/v1/[controller]")]
[ApiController]
public class BaseController<TEntity, TKey, TViewModel, TCreateModel, TUpdateModel> : ControllerBase where TEntity : class, IEntity<TKey>
{
	public BaseController(ILogger logger,
		IRepository<TEntity, TKey> repository)
	{
		Logger = logger;
		Repository = repository;
	}

	public ILogger Logger { get; }
	public IRepository<TEntity, TKey> Repository { get; }

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var entities = (await Repository.GetAllAsync()).ToList();

		var mappedEntities = entities.Adapt<List<TViewModel>>();

		var result = mappedEntities.ToResult();

		return Ok(result);
	}

	[HttpGet("Get/{id}")]
	public async Task<IActionResult> GetAll(TKey id)
	{
		var entities = await Repository.GetByIdAsync(id);

		if (entities == null)
		{
			return NotFound();
		}

		var mappedEntities = entities.Adapt<TViewModel>();

		var result = mappedEntities.ToResult();

		return Ok(result);
	}

	[HttpPost("Create")]
	public async Task<IActionResult> Create(TCreateModel model)
	{
		if (model is null)
		{
			return UnprocessableEntity();
		}

		var mappedEntities = model.Adapt<TEntity>();

		if (mappedEntities is null)
		{
			return UnprocessableEntity();
		}

		await Repository.AddAsync(mappedEntities);

		await Repository.SaveChangesAsync();

		var result = mappedEntities.ToResult();

		return Ok(result);
	}


	[HttpPatch("Update")]
	public async Task<IActionResult> Update(TUpdateModel model)
	{
		if (model is null)
		{
			return UnprocessableEntity();
		}

		var mappedEntities = model.Adapt<TEntity>();

		if (mappedEntities is null)
		{
			return UnprocessableEntity();
		}

		await Repository.UpdateAsync(mappedEntities);

		await Repository.SaveChangesAsync();

		var result = mappedEntities.ToResult();

		return Ok(result);
	}


	[HttpDelete("Delete")]
	public async Task<IActionResult> Delete(List<TKey> ids)
	{
		var Deleteresult = new List<bool>();
		var resultForResponse = new Result<bool>();
		foreach (var id in ids)
		{

			var res = await Repository.RemoveByIdAsync(id);
			Deleteresult.Add(res);
		}

		if (Deleteresult.Contains(false) == false)
		{
			resultForResponse.SetStatusSucceeded();
			return Ok(resultForResponse);
		}
		else if (Deleteresult.Contains(true) == false)
		{
			resultForResponse.SetStatusFailed();
			return Ok(resultForResponse);

		}
		else
		{
			resultForResponse.SetStatusPartiallySucceeded();
			return Ok(resultForResponse);

		}
	}

}
