using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Infra.Data.Context;

namespace WebMotors.Infra.Data.Repository
{
	public class AnuncioRepository: RepositoryBase<Anuncio>, IAnuncioRepository
	{
		public AnuncioRepository(WebMotorsContext context) : base(context)
		{

		}
	}
}
