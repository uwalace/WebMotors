using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMotors.Domain.Interfaces.Entites;

namespace WebMotors.Domain.Entities
{
	[Table("tb_AnuncioWebmotors")]
	public class Anuncio : IEntity
	{
		public int ID { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string Versao { get; set; }
		public int Ano { get; set; }
		public int Quilometragem { get; set; }
		public string Observacao { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (string.IsNullOrEmpty(this.Marca)) yield return new ValidationResult("A marca deve ser preenchida");
			if (string.IsNullOrEmpty(this.Modelo)) yield return new ValidationResult("O modelo deve ser preenchido");
			if (string.IsNullOrEmpty(this.Versao)) yield return new ValidationResult("A versão deve ser preenchida");
			if (this.Ano == int.MinValue) yield return new ValidationResult("O ano deve ser preenchido");
			if (this.Quilometragem == int.MinValue) yield return new ValidationResult("A quilometragem deve ser preenchida");
			if (string.IsNullOrEmpty(this.Observacao)) yield return new ValidationResult("A observação deve ser preenchida");
		}
	}
}
