using System;
using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
	public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDTO<CategoryWithProductsDTO>> GetSingleCategoryWithProductAsync(int categoryId);
    }
}

