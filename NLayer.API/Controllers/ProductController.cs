using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController:CustomBaseController
	{
		private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productsDTO = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var products = await _service.AddAsync(_mapper.Map<Product>(productDTO));
            var productsDTO = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDTO)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDTO));

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productEntity = await _service.GetByIdAsync(id);
            if(productEntity == null)
            {
                return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Fail("product not exist",404));
            }
            await _service.RemoveAsync(productEntity);
            
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }

    }
}

