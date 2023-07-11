using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;

namespace NLayer.Repository
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature()
                {
                Id=1,
                Color="red",
                Height=200,
                ProductId=1,
                Width=10
                },
                new ProductFeature()
                {
                    Id = 2,
                    Color = "blue",
                    Height = 100,
                    ProductId = 2,
                    Width = 30
                }

            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

