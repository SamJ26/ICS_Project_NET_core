
using Microsoft.EntityFrameworkCore;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Seeds;

namespace FilmManagment.DAL
{
    public class AppDbContext : DbContext
    {
        // Ked budeme vytvarat novy AppDbContext tak musime dat ctoru parameter contextOptions, ktory obsahuje info potrebne k vytvoreniu DBcontextu
        // DbContextOptions musime niekde inde nadefinovat ! ( v DesignTimeDbContextFactory )
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        // Podla tychto propert nam EF vytvori tabulky v DB a zaroven tieto property sluzia na pristup k nim
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<FilmEntity> Films { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: add all entities

            modelBuilder.Entity<ActorEntity>()
                        .HasMany<FilmEntity>();

            ActorSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
