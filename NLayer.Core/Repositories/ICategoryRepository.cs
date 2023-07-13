using System;
namespace NLayer.Core.Repositories
{
	public interface ICategoryRepository : IGenericRepository<Category>
    {
		Task<Category> GetSingleCategoryWithProductAsync(int categoryId);
	}
}

