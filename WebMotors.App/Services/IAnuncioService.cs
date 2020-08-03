using WebMotors.App.Models.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public interface IAnuncioService
	{
        Task<List<Anuncio>> GetAsync();

        Task<Anuncio> GetByIdAsync(int id);

        Task<Anuncio> CreateAsync(Anuncio entity);

        Task<Anuncio> UpdateAsync(Anuncio entity);

        Task<HttpResponseMessage> RemoveAsync(int id);
    }
}
