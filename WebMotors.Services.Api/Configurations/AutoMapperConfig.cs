using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Application.AutoMapper;

namespace WebMotors.Services.Api.Configurations
{
	public static class AutoMapperConfig
	{
		public static void AddMapper(this IServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingAnuncio());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

	}
}
