using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebMotors.Application.Dto;
using WebMotors.Application.Interfaces;

namespace WebMotors.Services.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnunciosController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAnuncioAppService _service;

		public AnunciosController(IAnuncioAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{		
			return Ok(_mapper.Map<IEnumerable<AnuncioDto>>(await _service.GetAllAsync()));
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			return Ok(_mapper.Map<AnuncioDto>(await _service.GetByIdAsync(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] AnuncioDto model)
		{
			var validationResult = await _service.CreateAsync(model);
			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return Created("", model);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync([FromBody] AnuncioDto model)
		{
			var validationResult =  await _service.UpdateAsync(model);

			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> RemoveAsync(int id)
		{
			var entity = await _service.GetByIdAsync(id);
			if (entity != null)
			{
				await _service.DeleteAsync(entity);
				return NoContent();
			}
			else
				return NotFound(id);
		}
	}
}
