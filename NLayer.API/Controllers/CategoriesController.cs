﻿using System;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	public class CategoriesController : CustomBaseController
	{
		private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]")]
		public async Task<IActionResult> GetSingleCategoryWithProductAsync(int categoryId)
		{
			return CreateActionResult(await _categoryService.GetSingleCategoryWithProductAsync(categoryId));
		}

    }
}

