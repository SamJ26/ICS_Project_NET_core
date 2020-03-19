
using FilmManagment.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Tests
{
    public class DbContextInMemoryFactory : IDbContextFactory<AppDbContext>
    {
        private readonly string dbName;
            
        public DbContextInMemoryFactory(string databaseName)
        {
            dbName = databaseName;
        }

        public AppDbContext CreateDbContext()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase(dbName);
            return new AppDbContext(contextOptionsBuilder.Options);
        }
    }
}
