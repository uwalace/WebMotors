using WebMotors.App.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMotors.App.Services
{
	public interface IModelService
	{
        Task<List<Model>> GetAsync(int id);        
    }
}
