using WebMotors.App.Models.Domain;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public class ModelService :IModelService
	{
		private readonly IConfiguration _configuration;
		public ModelService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<List<Model>> GetAsync(int id)
		{
			var result = await _configuration["AppSettings:BaseUriWebmotors"]
				.AppendPathSegments("Model")
				.SetQueryParam("MakeID",id)
				.GetJsonAsync<List<Model>>();

			return result;
		}
	}
}
