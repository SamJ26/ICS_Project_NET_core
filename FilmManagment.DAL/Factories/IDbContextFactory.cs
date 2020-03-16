
using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Factories
{
    // Metodu CreateDbContext() budeme nasledne pouzivat na vytvaranie novych AppDbContextov hlavne pri testoch
    // For generic type parameters, the out keyword specifies that the type parameter is covariant.
    // An interface that has a covariant type parameter enables its methods to return more derived types than those specified by the type parameter.
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateDbContext();
    }
}
