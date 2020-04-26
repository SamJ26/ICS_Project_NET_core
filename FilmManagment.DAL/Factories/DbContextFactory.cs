using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Factories
{
    public class DbContextFactory : IDbContextFactory<AppDbContext>
    {
        private string connectionString;

        public DbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
