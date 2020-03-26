using Microsoft.EntityFrameworkCore;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Seeds;

namespace FilmManagment.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<FilmEntity> Films { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FilmActorEntity> FilmsActorsEntity { get; set; }
        public DbSet<FilmDirectorEntity> FilmsDirectorsEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Connection between FilmEntity and RatingEntity
            modelBuilder.Entity<FilmEntity>()
                        .HasMany<RatingEntity>(i => i.Ratings)
                        .WithOne(i => i.Film)
                        .HasForeignKey(i => i.FilmId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Connection between FilmEntity and ActorEntity via table FilmActorEntity
            modelBuilder.Entity<FilmActorEntity>()
                        .HasKey(i => new { i.FilmId, i.ActorId });

            modelBuilder.Entity<FilmActorEntity>()
                        .HasOne<FilmEntity>(i => i.Film)
                        .WithMany(i => i.Actors)
                        .HasForeignKey(i => i.FilmId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmActorEntity>()
                        .HasOne<ActorEntity>(i => i.Actor)
                        .WithMany(i => i.ActedMovies)
                        .HasForeignKey(i => i.ActorId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Connection between FilmEntity and DirectorEntity via table FilmDirectorEntity
            modelBuilder.Entity<FilmDirectorEntity>()
                        .HasKey(i => new { i.FilmId, i.DirectorId });

            modelBuilder.Entity<FilmDirectorEntity>()
                        .HasOne<FilmEntity>(i => i.Film)
                        .WithMany(i => i.Directors)
                        .HasForeignKey(i => i.FilmId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmDirectorEntity>()
                        .HasOne<DirectorEntity>(i => i.Director)
                        .WithMany(i => i.DirectedMovies)
                        .HasForeignKey(i => i.DirectorId)
                        .OnDelete(DeleteBehavior.Cascade);

            DataSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
