using Domain.Categories;
using Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Server.Infrastructure;
using ViewModels.Category;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : BaseController
		<Category
		, int
		, CategoryViewModel
		, CategoryCreateViewModel
		, CategoryUpdateViewModel>
	{
		public CategoryController(ILogger<Category> logger, ICategoryRepository repository) : base(logger, repository)
		{
		}
	}
}
