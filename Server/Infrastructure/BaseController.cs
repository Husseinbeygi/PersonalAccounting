using Cyrus.Results;
using Domain.SeedWork;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Server.Infrastructure;

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

	[HttpGet("GetAll")]
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
	public async Task<IActionResult> Delete(TKey id)
	{

		var result = await Repository.RemoveByIdAsync(id);

		if (result)
		{
			return Ok();
		}

		return BadRequest();
	}

}
