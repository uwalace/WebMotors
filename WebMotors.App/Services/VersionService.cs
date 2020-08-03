using WebMotors.App.Models.Domain;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public class VersionService : IVersionService
	{
		private readonly IConfiguration _configuration;
		public VersionService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<List<Version>> GetAsync(int id)
		{
			var result = await _configuration["AppSettings:BaseUriWebmotors"]
				.AppendPathSegments("Version")
				.SetQueryParam("ModelID", id)
				.GetJsonAsync<List<Version>>();

			return result;
		}
	}
}
