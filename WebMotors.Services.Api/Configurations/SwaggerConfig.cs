using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebMotors.Services.Api.Configurations
{
	public static class SwaggerConfig
	{
		public static void AddSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v1", new OpenApiInfo() { Description = "Documentação API", Version = "1.0" });
			});
		}

		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
			});

		}
	}
}
