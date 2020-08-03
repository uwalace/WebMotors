using WebMotors.App.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public interface IVersionService
	{
        Task<List<Version>> GetAsync(int id);        
    }
}
