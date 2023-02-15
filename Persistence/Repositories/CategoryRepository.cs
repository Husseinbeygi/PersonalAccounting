using Domain.Categories;

namespace Persistence.Repositories;

public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
{
	public CategoryRepository(DatabaseContext context) : base(context)
	{
	}
}
