using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
	public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1,
                    CategoryId = 1,
                    Price=100,
                    Stock=20,
                    CreatedDate=DateTime.Now,
                    Name = "Pencil 1" },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Price = 400,
                    Stock = 30,
                    CreatedDate = DateTime.Now,
                    Name = "Pen 2"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 3,
                    Price = 10,
                    Stock = 10,
                    CreatedDate = DateTime.Now,
                    Name = "Book 3"
                }
                );
        }
    }
}

