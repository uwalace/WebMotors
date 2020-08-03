using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Application.Interfaces;
using WebMotors.Application.Services;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Infra.Data.Context;
using WebMotors.Infra.Data.Repository;

namespace WebMotors.Services.Api.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<WebMotorsContext>(option =>
				option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
				x => x.MigrationsAssembly("WebMotors.Infra.Data")));

			//WebMotors.Infra.Data
			services.AddScoped<IAnuncioRepository, AnuncioRepository>();

			//WebMotors.Application
			services.AddScoped<IAnuncioAppService, AnuncioAppService>();

		}
	}
}
