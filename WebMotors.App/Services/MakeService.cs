using WebMotors.App.Models.Domain;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	
	public class MakeService : IMakeService
	{
		private readonly IConfiguration _configuration;

		public MakeService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<List<Make>> GetAsync()
		{
			var result = await _configuration["AppSettings:BaseUriWebmotors"]
				.AppendPathSegments("Make")
				.GetJsonAsync<List<Make>>();

			return result;
		}

	}
	
}
