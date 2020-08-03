using WebMotors.App.Configuration;
using WebMotors.App.Models.Domain;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public class AnuncioService : IAnuncioService
	{
        private const string URI_LOCAL = "AppSettings:BaseUriLocal";
        private readonly IOptions<AppSettings> _appSettings;


        public AnuncioService( IOptions<AppSettings> appSettings)
		{			
            _appSettings = appSettings;
        }

		public async Task<List<Anuncio>> GetAsync()
        {
            var result = await _appSettings.Value.BaseUriLocal             
                .GetJsonAsync<List<Anuncio>>();

            return result;
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            var result = await _appSettings.Value.BaseUriLocal
                  .AppendPathSegments( id)                
                  .GetJsonAsync<Anuncio>();
            
            return result;
        }

        public async Task<Anuncio> CreateAsync(Anuncio anuncio)
        {           
            var result = await _appSettings.Value.BaseUriLocal
                .PostJsonAsync(anuncio)
                .ReceiveJson<Anuncio>();

            return result;
        }

        public async Task<Anuncio> UpdateAsync(Anuncio anuncio)
        {
            var result = await _appSettings.Value.BaseUriLocal
                .PutJsonAsync(anuncio)
                .ReceiveJson<Anuncio>();

            return result;
        }

        public async Task<HttpResponseMessage> RemoveAsync(int id)
        {
            var result = await _appSettings.Value.BaseUriLocal
                .AppendPathSegments( id)
                .DeleteAsync();

            return result;
        }

		
	}
}
