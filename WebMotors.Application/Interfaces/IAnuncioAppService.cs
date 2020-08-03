using WebMotors.Application.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebMotors.Application.Interfaces
{
	public interface IAnuncioAppService
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(AnuncioDto dto);

		Task DeleteAsync(AnuncioDto dto);

		Task<IEnumerable<ValidationResult>> UpdateAsync(AnuncioDto dto);

		Task<AnuncioDto> GetByIdAsync(int id);

		Task<IEnumerable<AnuncioDto>> GetAllAsync(bool @readonly = false);
	}
}
