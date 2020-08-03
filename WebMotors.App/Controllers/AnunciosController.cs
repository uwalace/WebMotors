using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMotors.App.Models;
using WebMotors.App.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using WebMotors.App.Services;
using WebMotors.App.Models.Domain;

namespace WebMotors.App.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioService _anuncioService;
		private readonly IMakeService _makeService;
		private readonly IModelService _modelService;
		private readonly IVersionService _versionService;

		public AnunciosController(IAnuncioService anuncioService,
								IMakeService makeService,
								IModelService modelService,
								IVersionService versionService)
		{
			_anuncioService = anuncioService;
			_makeService = makeService;
			_modelService = modelService;
			_versionService = versionService;
		}

		public async Task<IActionResult> Index()
        {          
            var anuncios = await _anuncioService.GetAsync();
            return View(anuncios);          
        }

		public async Task<IActionResult> Details(int id)
		{			
			var anuncios = await _anuncioService.GetByIdAsync(id);

			if (anuncios == null)
				return NotFound();
			else
				return View(anuncios);
		}

		public async Task<IActionResult> Create()
		{
			AnuncioViewModel model = new AnuncioViewModel() { Anuncio = new Anuncio(), 
															  Makes = await _makeService.GetAsync() };
			return View(model);
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Anuncio anuncio)
		{
			if (ModelState.IsValid)
			{
				var ret = await _anuncioService.CreateAsync(anuncio);
				
				return RedirectToAction(nameof(Index));
			}
			return View(anuncio);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var anuncio = await _anuncioService.GetByIdAsync(id);
		
			if (anuncio == null)
			{
				return NotFound();
			}
			var viewModel = new AnuncioViewModel() {
				Anuncio = anuncio,
				Makes = await _makeService.GetAsync()
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit( [Bind("ID,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Anuncio anuncio)
		{
			await _anuncioService.UpdateAsync(anuncio);

			return RedirectToAction(nameof(Index));
       
		}
		
		public async Task<IActionResult> Delete(int id)
		{
			var anuncio = await _anuncioService.GetByIdAsync(id);

			if (anuncio == null)
			{
				return NotFound();
			}
			
			return View(anuncio);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _anuncioService.RemoveAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<JsonResult> GetModel(int id)
		{
			return Json(await _modelService.GetAsync(id));
		}

		public async Task<JsonResult> GetVersion(int id)
		{
			return Json(await _versionService.GetAsync(id));
		}
	}
}
