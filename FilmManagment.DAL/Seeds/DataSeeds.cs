using FilmManagment.DAL.Entities;
using System.Collections.Generic;
using FilmManagment.DAL.Enums;
using System;

namespace FilmManagment.DAL.Seeds
{
    public static class DataSeeds
    {
        // ACTOR SEEDS

        public static readonly ActorEntity Actor_JohnStone = new ActorEntity()
        {
            Id = Guid.Parse("63156915-53f4-4a7a-b099-1c57bace2307"),
            FirstName = "John",
            SecondName = "Stone",
            Age = 59,
            WikiUrl = "wikiurlJS",
            PhotoFilePath = @"c:/blabla/nic/bla/JohnStone",
            ActedMovies = new List<FilmActorEntity>()
        };

        public static readonly ActorEntity Actor_AxelBrown = new ActorEntity()
        {
            Id = Guid.Parse("562ed03a-dc26-41cf-8a01-ee78afd22541"),
            FirstName = "Axel",
            SecondName = "Brown",
            Age = 50,
            WikiUrl = "wikiurlAB",
            PhotoFilePath = @"c:/blabla/nic/bla/AxelBrown",
            ActedMovies = new List<FilmActorEntity>()
        };

        public static readonly ActorEntity Actor_MicalMorris = new ActorEntity()
        {
            Id = Guid.Parse("5aae9cc3-b880-441c-b88e-ca00242db99f"),
            FirstName = "Mical",
            SecondName = "Morris",
            Age = 21,
            WikiUrl = "wikiurlMM",
            PhotoFilePath = @"c:/blabla/nic/bla/MicalMorris",
            ActedMovies = new List<FilmActorEntity>()
        };

        public static readonly ActorEntity Actor_GarrethClark = new ActorEntity()
        {
            Id = Guid.Parse("7793e739-6940-4c51-9f37-340be6e613a9"),
            FirstName = "Garreth",
            SecondName = "Clark",
            Age = 23,
            WikiUrl = "wikiurlGC",
            PhotoFilePath = @"c:/blabla/nic/bla/GarrethClark",
            ActedMovies = new List<FilmActorEntity>()
        };

        // DIRECTOR SEEDS

        public static readonly DirectorEntity Director_AdamSilver = new DirectorEntity()
        {
            Id = Guid.Parse("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"),
            FirstName = "Adam",
            SecondName = "Silver",
            Age = 56,
            WikiUrl = "wikiurlAS",
            PhotoFilePath = @"c:/blabla/nic/bla/AdamSilver",
            DirectedMovies = new List<FilmDirectorEntity>()
        };

        public static readonly DirectorEntity Director_GeorgeBlack = new DirectorEntity()
        {
            Id = Guid.Parse("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"),
            FirstName = "George",
            SecondName = "Black",
            Age = 60,
            WikiUrl = "wikiurlGB",
            PhotoFilePath = @"c:/blabla/nic/bla/GeorgeBlack",
            DirectedMovies = new List<FilmDirectorEntity>()
        };

        public static readonly DirectorEntity Director_RorySabatini = new DirectorEntity()
        {
            Id = Guid.Parse("011a72e9-827c-48e4-ac61-da46ab5756e3"),
            FirstName = "Rory",
            SecondName = "Sabatini",
            Age = 35,
            WikiUrl = "wikiurlRS",
            PhotoFilePath = @"c:/blabla/nic/bla/RorySabatini",
            DirectedMovies = new List<FilmDirectorEntity>()
        };

        public static readonly DirectorEntity Director_PaulGasol = new DirectorEntity()
        {
            Id = Guid.Parse("9033b72b-6340-4667-8a14-b6aed51697b6"),
            FirstName = "Paul",
            SecondName = "Gasol",
            Age = 42,
            WikiUrl = "wikiurlPG",
            PhotoFilePath = @"c:/blabla/nic/bla/PaulGasol",
            DirectedMovies = new List<FilmDirectorEntity>()
        };

        // RATING SEEDS

        public static readonly RatingEntity Rating_1 = new RatingEntity()
        {
            Id = Guid.Parse("aa835099-587e-4dbb-b48e-f9c402f978a4"),
            RatingInPercents = 87,
            TextRating = "Best movie I have seen so far"
        };

        public static readonly RatingEntity Rating_2 = new RatingEntity()
        {
            Id = Guid.Parse("2ed269bc-2c39-457e-bf7c-96258b3d247a"),
            RatingInPercents = 50,
            TextRating = "Pretty average"
        };

        // FILM SEEDS

        public static readonly FilmEntity Film_WhiteHouse = new FilmEntity()
        {
            Id = Guid.Parse("07cab248-0bcf-4e36-a954-b4f8f619579e"),
            OriginalName = "Bily dum",
            CzechName = "White house",
            CountryOfOrigin = "USA",
            Description = "Movie about white house",
            GenreOfFilm = Genre.ActionFilm,
            ImageFilePath = @"c:/blabla/nic/bla/WhiteHouse",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };

        public static readonly FilmEntity Film_DanishHero = new FilmEntity()
        {
            Id = Guid.Parse("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
            OriginalName = "Danish Hero",
            CountryOfOrigin = "Denmark",
            CzechName = "Dansky hrdina",
            Description = "Film about Danish Hero",
            GenreOfFilm = Genre.AdventureFilm,
            ImageFilePath = @"c:/blabla/nic/bla/DanishHero",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };

        public static readonly FilmEntity Film_BigComeback = new FilmEntity()
        {
            Id = Guid.Parse("03b8ccb9-c1c2-4251-b86e-4a2a0baccfc7"),
            OriginalName = "Big Comeback",
            CountryOfOrigin = "England",
            CzechName = "Velký návrat",
            Description = "Movie about one of the best sport comeback",
            GenreOfFilm = Genre.DramaFilm,
            ImageFilePath = @"c:/blabla/nic/bla/BigComeback",
            LengthInMinutes = new TimeSpan(2, 56, 30),
            Actors = new List<FilmActorEntity>(),
            Directors = new List<FilmDirectorEntity>(),
            Ratings = new List<RatingEntity>()
        };

        // FILM-ACTOR SEEDS

        public static readonly FilmActorEntity FilmActor_WhiteHouse = new FilmActorEntity()
        {
            Id = Guid.Parse("5c0154f3-6f6a-473c-8904-1a56dc39eb96"),
            FilmId = Film_WhiteHouse.Id,
            ActorId = Actor_JohnStone.Id,
            Film = Film_WhiteHouse,
            Actor = Actor_JohnStone
        };

        public static readonly FilmActorEntity FilmActor_DanishHero = new FilmActorEntity()
        {
            Id = Guid.Parse("4117bfcc-b81f-4e73-b8cc-af8a14135621"),
            FilmId = Film_DanishHero.Id,
            ActorId = Actor_AxelBrown.Id,
            Film = Film_DanishHero,
            Actor = Actor_AxelBrown
        };

        // FILM-DIRECTOR SEEDS

        public static readonly FilmDirectorEntity FilmDirector_WhiteHouse = new FilmDirectorEntity()
        {
            Id = Guid.Parse("8805e086-0206-4b9e-8fba-031a2f04092a"),
            FilmId = Film_WhiteHouse.Id,
            DirectorId = Director_AdamSilver.Id,
            Film = Film_WhiteHouse,
            Director = Director_AdamSilver
        };

        public static readonly FilmDirectorEntity FilmDirector_DanishHero = new FilmDirectorEntity()
        {
            Id = Guid.Parse("9e00af51-7eba-496a-9e72-254eaa9b674d"),
            FilmId = Film_DanishHero.Id,
            DirectorId = Director_GeorgeBlack.Id,
            Film = Film_DanishHero,
            Director = Director_GeorgeBlack
        };

        static DataSeeds()
        {
            // Seeding Film_WhiteHouse + Director_AdamSilver + Actor_JohnStone

            Film_WhiteHouse.Directors.Add(FilmDirector_WhiteHouse);
            Film_WhiteHouse.Actors.Add(FilmActor_WhiteHouse);
            Film_WhiteHouse.Ratings.Add(Rating_1);

            Director_AdamSilver.DirectedMovies.Add(FilmDirector_WhiteHouse);
            Actor_JohnStone.ActedMovies.Add(FilmActor_WhiteHouse);

            // Seeding Film_DanishHero + Director_GeorgeBlack + Actor_AxelBrown

            Film_DanishHero.Directors.Add(FilmDirector_DanishHero);
            Film_DanishHero.Actors.Add(FilmActor_DanishHero);
            Film_DanishHero.Ratings.Add(Rating_2);

            Director_GeorgeBlack.DirectedMovies.Add(FilmDirector_DanishHero);
            Actor_AxelBrown.ActedMovies.Add(FilmActor_DanishHero);
        }
    }
}
