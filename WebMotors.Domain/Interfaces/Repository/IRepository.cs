using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebMotors.Domain.Interfaces.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(TEntity entity);

		Task DeleteAsync(TEntity entity);

		Task<IEnumerable<ValidationResult>> UpdateAsync(TEntity entity);

		Task<TEntity> GetByIdAsync(int id);

		Task<IEnumerable<TEntity>> GetAllAsync(bool @readonly = false);

		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
	}
}
