using NLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.UnitOfWork;
using NLayer.Core.Repositories;
using NLayer.Repository.Repositories;
using NLayer.Core.Services;
using NLayer.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using NLayer.Service.Mapping;
using FluentValidation.AspNetCore;
using NLayer.Service.Validation;
using NLayer.API.Filters;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Middlewares;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers(option => option.Filters.Add(new ValidateFilterAttribute()))
				.AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDTOValidation>());

#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.Configure<ApiBehaviorOptions>(option =>
{
	option.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<AppDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), option =>
	{
		option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
	});
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();


app.Run();

