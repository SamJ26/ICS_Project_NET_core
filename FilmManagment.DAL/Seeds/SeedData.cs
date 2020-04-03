using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmManagment.DAL.Seeds
{
    public static class SeedData
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {
            // Seeding Film_WhiteHouse + Director_AdamSilver + Actor_JohnStone + Rating_1

            modelBuilder.Entity<FilmEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Film_WhiteHouse.Id,
                            OriginalName = DataSeeds.Film_WhiteHouse.OriginalName,
                            CzechName = DataSeeds.Film_WhiteHouse.CzechName,
                            CountryOfOrigin = DataSeeds.Film_WhiteHouse.CountryOfOrigin,
                            Description = DataSeeds.Film_WhiteHouse.Description,
                            ImageFilePath = DataSeeds.Film_WhiteHouse.ImageFilePath,
                            GenreOfFilm = DataSeeds.Film_WhiteHouse.GenreOfFilm,
                            LengthInMinutes = DataSeeds.Film_WhiteHouse.LengthInMinutes,
                        });

            modelBuilder.Entity<RatingEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Rating_1.Id,
                            RatingInPercents = DataSeeds.Rating_1.RatingInPercents,
                            TextRating = DataSeeds.Rating_1.TextRating,
                            FilmId = DataSeeds.Film_WhiteHouse.Id,
                        });

            modelBuilder.Entity<DirectorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Director_AdamSilver.Id,
                            FirstName = DataSeeds.Director_AdamSilver.FirstName,
                            SecondName = DataSeeds.Director_AdamSilver.SecondName,
                            Age = DataSeeds.Director_AdamSilver.Age,
                            WikiUrl = DataSeeds.Director_AdamSilver.WikiUrl,
                            PhotoFilePath = DataSeeds.Director_AdamSilver.PhotoFilePath,
                        });

            modelBuilder.Entity<ActorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Actor_JohnStone.Id,
                            FirstName = DataSeeds.Actor_JohnStone.FirstName,
                            SecondName = DataSeeds.Actor_JohnStone.SecondName,
                            Age = DataSeeds.Actor_JohnStone.Age,
                            WikiUrl = DataSeeds.Actor_JohnStone.WikiUrl,
                            PhotoFilePath = DataSeeds.Actor_JohnStone.PhotoFilePath,
                        });

            modelBuilder.Entity<FilmActorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.FilmActor_WhiteHouse.Id,
                            FilmId = DataSeeds.FilmActor_WhiteHouse.FilmId,
                            ActorId = DataSeeds.FilmActor_WhiteHouse.ActorId,
                        });

            modelBuilder.Entity<FilmDirectorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.FilmDirector_WhiteHouse.Id,
                            FilmId = DataSeeds.FilmDirector_WhiteHouse.FilmId,
                            DirectorId = DataSeeds.FilmDirector_WhiteHouse.DirectorId,
                        });

            // Seeding Film_DanishHero + Director_GeorgeBlack + Actor_AxelBrown + Rating_2

            modelBuilder.Entity<FilmEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Film_DanishHero.Id,
                            OriginalName = DataSeeds.Film_DanishHero.OriginalName,
                            CzechName = DataSeeds.Film_DanishHero.CzechName,
                            CountryOfOrigin = DataSeeds.Film_DanishHero.CountryOfOrigin,
                            Description = DataSeeds.Film_DanishHero.Description,
                            ImageFilePath = DataSeeds.Film_DanishHero.ImageFilePath,
                            GenreOfFilm = DataSeeds.Film_DanishHero.GenreOfFilm,
                            LengthInMinutes = DataSeeds.Film_DanishHero.LengthInMinutes,
                        });

            modelBuilder.Entity<RatingEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Rating_2.Id,
                            RatingInPercents = DataSeeds.Rating_2.RatingInPercents,
                            TextRating = DataSeeds.Rating_2.TextRating,
                            FilmId = DataSeeds.Film_DanishHero.Id,
                        });

            modelBuilder.Entity<DirectorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Director_GeorgeBlack.Id,
                            FirstName = DataSeeds.Director_GeorgeBlack.FirstName,
                            SecondName = DataSeeds.Director_GeorgeBlack.SecondName,
                            Age = DataSeeds.Director_GeorgeBlack.Age,
                            WikiUrl = DataSeeds.Director_GeorgeBlack.WikiUrl,
                            PhotoFilePath = DataSeeds.Director_GeorgeBlack.PhotoFilePath,
                        });

            modelBuilder.Entity<ActorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.Actor_AxelBrown.Id,
                            FirstName = DataSeeds.Actor_AxelBrown.FirstName,
                            SecondName = DataSeeds.Actor_AxelBrown.SecondName,
                            Age = DataSeeds.Actor_AxelBrown.Age,
                            WikiUrl = DataSeeds.Actor_AxelBrown.WikiUrl,
                            PhotoFilePath = DataSeeds.Actor_AxelBrown.PhotoFilePath,
                        });

            modelBuilder.Entity<FilmActorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.FilmActor_DanishHero.Id,
                            FilmId = DataSeeds.FilmActor_DanishHero.FilmId,
                            ActorId = DataSeeds.FilmActor_DanishHero.ActorId,
                        });

            modelBuilder.Entity<FilmDirectorEntity>()
                        .HasData(new
                        {
                            Id = DataSeeds.FilmDirector_DanishHero.Id,
                            FilmId = DataSeeds.FilmDirector_DanishHero.FilmId,
                            DirectorId = DataSeeds.FilmDirector_DanishHero.DirectorId,
                        });

            // Seeding Film_BigComeback without Actors, Directors and Ratings
        
            modelBuilder.Entity<FilmEntity>().HasData(DataSeeds.Film_BigComeback);

            // Seeding rest of Actors

            modelBuilder.Entity<ActorEntity>().HasData(DataSeeds.Actor_MicalMorris);
            modelBuilder.Entity<ActorEntity>().HasData(DataSeeds.Actor_GarrethClark);

            // Seeding rest of Directors

            modelBuilder.Entity<DirectorEntity>().HasData(DataSeeds.Director_RorySabatini);
            modelBuilder.Entity<DirectorEntity>().HasData(DataSeeds.Director_PaulGasol);
        }
    }
}
