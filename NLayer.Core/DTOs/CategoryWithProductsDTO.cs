using System;
namespace NLayer.Core.DTOs
{
	public class CategoryWithProductsDTO : CategoryDTO
	{
		public List<Product> Products { get; set; }
	}
}

