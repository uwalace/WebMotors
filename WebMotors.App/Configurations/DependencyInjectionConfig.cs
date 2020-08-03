
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.App.Services;
using WebMotors.App.Configuration;



namespace WebMotors.Services.Api.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

			services.AddScoped<IAnuncioService, AnuncioService>();
			services.AddScoped<IMakeService, MakeService>();
			services.AddScoped<IModelService, ModelService>();
			services.AddScoped<IVersionService, VersionService>();

		}
	}
}
