using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmManagment.DAL.Seeds
{
    public static class SeedData
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {
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
                            FilmId = DataSeeds.Film_WhiteHouse.Id
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

            // TODO: continue:

        }
    }
}
