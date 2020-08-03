using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Application.Interfaces;
using WebMotors.Application.Services;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Infra.Data.Context;
using WebMotors.Infra.Data.Repository;

namespace WebMotors.Infra.CrossCutting.IoC
{
	public static class ConfigurationIoC
	{

		public static void AddServices(IServiceCollection services, IConfiguration configuration, string connectionStringName)
		{
			services.AddDbContext<WebMotorsContext>(option =>
				option.UseSqlServer(configuration.GetConnectionString(connectionStringName),
				x => x.MigrationsAssembly("WebMotors.Infra.Data")));

			//WebMotors.Infra.Data
			services.AddScoped<IAnuncioRepository, AnuncioRepository>();

			//WebMotors.Application
			services.AddScoped<IAnuncioAppService, AnuncioAppService>();

		}

	}
}
