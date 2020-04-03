using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FilmManagment.DAL.Factories
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<AppDbContext>();
			builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                    Initial Catalog = FilmManagmentDB;
                                    MultipleActiveResultSets = True;
                                    Integrated Security = True; ");

			return new AppDbContext(builder.Options);
		}
	}
}
