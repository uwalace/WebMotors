using WebMotors.App.Models.Domain;
using System.Collections.Generic;

namespace WebMotors.App.Models.ViewModels
{
	public class AnuncioViewModel
	{
		public Anuncio Anuncio { get; set; }
		public IList<Make> Makes { get; set; }
		public IList<Model> Model { get; set; }
		public IList<Version> Version { get; set; }
	}
}
