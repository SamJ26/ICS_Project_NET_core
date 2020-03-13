
using Microsoft.EntityFrameworkCore;
using Project_filmManagment.DAL.Entities;

namespace Project_filmManagment.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        // A DbSet<TEntity> can be used to query and save instances of TEntity to database
        // Via this properties we can access, insert and read values from database
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<FilmEntity> Films { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
