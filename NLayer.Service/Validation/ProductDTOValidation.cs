using System;
using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validation
{
	public class ProductDTOValidation : AbstractValidator<ProductDTO>
    {
		public ProductDTOValidation()
		{
			RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
								.NotEmpty().WithMessage("{PropertyName} can not be null");

			RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");

			RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");

			RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}

