using System;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;

namespace NLayer.API.Middlewares
{
	public static class CustomExceptionHandler
	{
		public static void UserCustomException(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(config =>
			{
				config.Run(async context =>
				{
					context.Response.ContentType = "application/json";

					var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
					var statusCode = exceptionFeature.Error switch
					{
						ClientSideExceptions => 400,
						NotFoundException => 404,
						_ => 500
					};
					context.Response.StatusCode = statusCode;
					var response = CustomResponseDTO<NoContentDTO>.Fail(exceptionFeature.Error.Message, statusCode);
					await context.Response.WriteAsync(JsonSerializer.Serialize(response));
				});
			});
		}
	}
}

