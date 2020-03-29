
using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using FilmManagment.DAL.Enums;
using FizzWare.NBuilder;

namespace FilmManagment.DAL.Seeds
{
    public class DataSeed
    {
        public static ActorEntity Actor_1 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("63156915-53f4-4a7a-b099-1c57bace2307"),
            FirstName = "John",
            SecondName = "Stone",
            Age = 59,
            WikiUrl = "wikiurlJS",
            PhotoFilePath = @"c:/blabla/nic/bla/JohnStone",
            ActedMovies = new List<FilmActorEntity>()
        };
        public static ActorEntity Actor_2 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("562ed03a-dc26-41cf-8a01-ee78afd22541"),
            FirstName = "Axel",
            SecondName = "Brown",
            Age = 50,
            WikiUrl = "wikiurlAB",
            PhotoFilePath = @"c:/blabla/nic/bla/AxelBrown",
            ActedMovies = new List<FilmActorEntity>()
        };
        public static ActorEntity Actor_3 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("5aae9cc3-b880-441c-b88e-ca00242db99f"),
            FirstName = "Micah",
            SecondName = "Morris",
            Age = 21,
            WikiUrl = "wikiurlMM",
            PhotoFilePath = @"c:/blabla/nic/bla/MicalMorris",
            ActedMovies = new List<FilmActorEntity>()
        };
        public static ActorEntity Actor_4 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("7793e739-6940-4c51-9f37-340be6e613a9"),
            FirstName = "Garreth",
            SecondName = "Clark",
            Age = 23,
            WikiUrl = "wikiurlGC",
            PhotoFilePath = @"c:/blabla/nic/bla/GarrethClark",
            ActedMovies = new List<FilmActorEntity>()
        };

        public static DirectorEntity Director_1 { get; } = new DirectorEntity()
        {
            Id = Guid.Parse("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"),
            FirstName = "Adam",
            SecondName = "Silver",
            Age = 56,
            WikiUrl = "wikiurlAS",
            PhotoFilePath = @"c:/blabla/nic/bla/AdamSilver",
            DirectedMovies = new List<FilmDirectorEntity>()
        };
        public static DirectorEntity Director_2 { get; } = new DirectorEntity()
        {
            Id = Guid.Parse("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"),
            FirstName = "George",
            SecondName = "Black",
            Age = 60,
            WikiUrl = "wikiurlGB",
            PhotoFilePath = @"c:/blabla/nic/bla/GeorgeBlack",
            DirectedMovies = new List<FilmDirectorEntity>()
        };
        public static DirectorEntity Director_3 { get; } = new DirectorEntity()
        {
            Id = Guid.Parse("011a72e9-827c-48e4-ac61-da46ab5756e3"),
            FirstName = "Rory",
            SecondName = "Sabatini",
            Age = 35,
            WikiUrl = "wikiurlRS",
            PhotoFilePath = @"c:/blabla/nic/bla/RorySabatini",
            DirectedMovies = new List<FilmDirectorEntity>()
        };
        public static DirectorEntity Director_4 { get; } = new DirectorEntity()
        {
            Id = Guid.Parse("9033b72b-6340-4667-8a14-b6aed51697b6"),
            FirstName = "Paul",
            SecondName = "Gasol",
            Age = 42,
            WikiUrl = "wikiurlPG",
            PhotoFilePath = @"c:/blabla/nic/bla/PaulGasol",
            DirectedMovies = new List<FilmDirectorEntity>()
        };
        public static RatingEntity Rating_1 { get; } = new RatingEntity()
        {
            Id = Guid.Parse("aa835099-587e-4dbb-b48e-f9c402f978a4"),
            RatingInPercents = 87,
            Film = Film_1,
            FilmId = Guid.Parse("07cab248-0bcf-4e36-a954-b4f8f619579e"),
            TextRating = "Best movie I have seen so far"
        };
        public static RatingEntity Rating_2 { get; } = new RatingEntity()
        {
            Id = Guid.Parse("2ed269bc-2c39-457e-bf7c-96258b3d247a"),
            RatingInPercents = 50,
            Film = Film_2,
            FilmId = Guid.Parse("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
            TextRating = "Pretty average"
        };

        public static FilmEntity Film_1 { get; } = new FilmEntity()
        {
            Id = Guid.Parse("07cab248-0bcf-4e36-a954-b4f8f619579e"),
            CountryOfOrigin = "USA",
            CzechName = "White house",
            Description = "Movie about white house",
            GenreOfFilm = Genre.ActionFilm,
            ImageFilePath = @"c:/blabla/nic/bla/WhiteHouse",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            OriginalName = "Bily dum",
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };
        public static FilmEntity Film_2 { get; } = new FilmEntity()
        {
            Id = Guid.Parse("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
            CountryOfOrigin = "Denmark",
            CzechName = "Danish Hero",
            Description = "Film about Danish Hero",
            GenreOfFilm = Genre.AdventureFilm,
            ImageFilePath = @"c:/blabla/nic/bla/DanishHero",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            OriginalName = "Dánský hrdina",
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };
        public static FilmEntity Film_3 { get; } = new FilmEntity()
        {
            Id = Guid.Parse("03b8ccb9-c1c2-4251-b86e-4a2a0baccfc7"),
            CountryOfOrigin = "England",
            CzechName = "Big Comeback",
            Description = "Movie about one of the best sports comeback",
            GenreOfFilm = Genre.DramaFilm,
            ImageFilePath = @"c:/blabla/nic/bla/BigComeback",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            OriginalName = "Velký návrat",
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmEntity>().HasData(Film_1);
            modelBuilder.Entity<FilmEntity>().HasData(Film_2);
            modelBuilder.Entity<FilmEntity>().HasData(Film_3);

            modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
            modelBuilder.Entity<ActorEntity>().HasData(Actor_2);
            modelBuilder.Entity<ActorEntity>().HasData(Actor_3);
            modelBuilder.Entity<ActorEntity>().HasData(Actor_4);

            modelBuilder.Entity<DirectorEntity>().HasData(Director_1);
            modelBuilder.Entity<DirectorEntity>().HasData(Director_2);
            modelBuilder.Entity<DirectorEntity>().HasData(Director_3);
            modelBuilder.Entity<DirectorEntity>().HasData(Director_4);

            modelBuilder.Entity<RatingEntity>().HasData(Rating_1);
            modelBuilder.Entity<RatingEntity>().HasData(Rating_2);

        }

    }
}
