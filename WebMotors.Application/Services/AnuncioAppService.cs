using AutoMapper;
using WebMotors.Application.Dto;
using WebMotors.Application.Interfaces;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebMotors.Application.Services
{
	public class AnuncioAppService : IAnuncioAppService
	{
		private readonly IAnuncioRepository _repository;
		private readonly IMapper _mapper;
		public AnuncioAppService(IAnuncioRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<ValidationResult>> CreateAsync(AnuncioDto dto)
		{
			var entity = _mapper.Map<Anuncio>(dto);
			return await _repository.CreateAsync(entity);
		}

		public async Task DeleteAsync(AnuncioDto dto)
		{
			var entity = _mapper.Map<Anuncio>(dto);
			await _repository.DeleteAsync(entity);
		}

		public async Task<IEnumerable<AnuncioDto>> GetAllAsync(bool @readonly = false)
		{			
			return  _mapper.Map<IEnumerable<AnuncioDto>>(await _repository.GetAllAsync());
		}

		public async Task<AnuncioDto> GetByIdAsync(int id)
		{
			return _mapper.Map<AnuncioDto>(await _repository.GetByIdAsync(id));
		}

		public async Task<IEnumerable<ValidationResult>> UpdateAsync(AnuncioDto dto)
		{
			return await _repository.UpdateAsync(_mapper.Map<Anuncio>(dto));
		}

	}
}
