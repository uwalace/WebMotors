using WebMotors.App.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public interface IMakeService
	{
        Task<List<Make>> GetAsync();        
    }
}
