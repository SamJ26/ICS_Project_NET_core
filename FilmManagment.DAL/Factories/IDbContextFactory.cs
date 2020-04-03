using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Factories
{
	public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
	{
		TDbContext CreateDbContext();
	}
}
