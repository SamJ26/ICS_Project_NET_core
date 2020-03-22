
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Factories
{
    // V tejto classe musime implementovat metodu CreateDbContext ktora je z IDesignTimeDbContextFactory interfacu
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer( @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    Initial Catalog = FilmManagmentDB;
                                    MultipleActiveResultSets = True;
                                    Integrated Security = True; ");

            return new AppDbContext(builder.Options);
        }
    }
}
