using Microsoft.EntityFrameworkCore;
using WebMotors.Domain.Entities;

namespace WebMotors.Infra.Data.Context
{
	public class WebMotorsContext : DbContext
	{
		public WebMotorsContext(DbContextOptions<WebMotorsContext> option) : base(option)
		{

		}

		public DbSet<Anuncio> Anuncio { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Anuncio>().HasKey(a => a.ID);			
		}

	}

	
}
