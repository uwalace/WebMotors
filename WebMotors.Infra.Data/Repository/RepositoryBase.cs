using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WebMotors.Infra.Data.Context;
using WebMotors.Domain.Interfaces.Repository;
using System.Linq.Expressions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebMotors.Infra.Data.Repository
{
	public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
			where TEntity : class
	{
		private readonly WebMotorsContext _context;
		private readonly DbSet<TEntity> DbSet;

		public RepositoryBase(WebMotorsContext context)
		{
			_context = context;
			DbSet = _context.Set<TEntity>();
		}

		public async Task<IEnumerable<ValidationResult>> CreateAsync(TEntity entity)
		{
			DbSet.Add(entity);
			return await this.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntity entity)
		{
			var entry = _context.ChangeTracker.Entries<TEntity>().FirstOrDefault();
			_context.Entry(entry.Entity).State = EntityState.Detached;

			DbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
				
		public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
		{
			if (@readonly)
				return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
			else
				return await DbSet.Where(predicate).ToListAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync( bool @readonly = false)
		{
			if (@readonly)
				return await DbSet.AsNoTracking().ToListAsync();
			else
				return await DbSet.ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await DbSet.FindAsync(id);
		}

		public virtual async Task<IEnumerable<ValidationResult>> UpdateAsync(TEntity entity)
		{
			var entry = _context.Entry(entity);
			DbSet.Attach(entity);
			entry.State = EntityState.Modified;

			return await this.SaveChangesAsync();
		}

		private async Task<IEnumerable<ValidationResult>> SaveChangesAsync()
		{
			var validationErrors = _context.ChangeTracker
			.Entries<IValidatableObject>()
			.SelectMany(e => e.Entity.Validate(null))
			.Where(r => r != ValidationResult.Success);

			if (!validationErrors.Any())
			await _context.SaveChangesAsync();

			return validationErrors;
		}

		public void Dispose()
		{
			if(_context != null) _context.Dispose();
		}
	}
}
