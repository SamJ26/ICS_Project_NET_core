
using Project_filmManagment.DAL.Entities;
using Project_filmManagment.DAL.Enums;
using System;

namespace ProjectTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---- FILM_1 ----

            // Creating a new film called Film_1
            FilmEntity Film_1 = new FilmEntity();

            // Adding specification to Film_1
            Film_1.CountryOfOrigin = "Hungary";
            Film_1.CzechName = "Dva Kone a Pes";
            Film_1.OriginalName = "Two Horses and Dog";
            Film_1.GenreOfFilm = Genre.ComedyFilm;
            Film_1.LengthInMinutes = new TimeSpan(1, 20, 0);
            Film_1.Description = "Uzasny film plny konov a psov";

            // Creating a new Director to film Film_1
            DirectorEntity director_1 = new DirectorEntity();

            // Adding specification of Director to film Film_1
            director_1.FirstName = "Jon";
            director_1.SecondName = "Mayer";
            director_1.Age = 43;
            director_1.DirectedMovies.Add(Film_1);
            director_1.WikiUrl = "Wikipedia";

            Film_1.DirectorsName = (director_1.FirstName + " " + director_1.SecondName);

            // Creating new actor which played in film Film_1 
            ActorEntity actor_1 = new ActorEntity();

            // Adding specification of actor_1
            actor_1.FirstName = "John";
            actor_1.SecondName = "Stone";
            actor_1.Age = 43;
            actor_1.ActedMovies.Add(Film_1);
            actor_1.WikiUrl = "Wikipedia";

            Film_1.Actors.Add(actor_1);

            // Creating new rating of Film_1
            RatingEntity rating_1 = new RatingEntity();

            rating_1.RatingInPercents = 58;
            rating_1.TextRating = "Prumerny film";

            Film_1.Ratings.Add(rating_1);

            // TODO:

            //Film_1.SumOfAllAddedRatings += rating_1.RatingInPercents;
            //Film_1.SumOfAllAddedRatings = Film_1.CalculateOverallRating();

            // ---- FILM_2 ----

            // Creating a new film called Film_2
            FilmEntity Film_2 = new FilmEntity();

            // Adding specification of the film
            Film_2.CountryOfOrigin = "USA";
            Film_2.CzechName = "Zelezny muz";
            Film_2.OriginalName = "Iron Mans";
            Film_2.GenreOfFilm = Genre.ActionFilm;
            Film_2.LengthInMinutes = new TimeSpan(2, 5, 0);
            Film_2.Description = "Genialni film o Marvel Superhrdinovi";

            // Creating a new Director to film Film_2
            DirectorEntity director_2 = new DirectorEntity();

            // Adding specification of Director to film Film_2
            director_2.FirstName = "Jon";
            director_2.SecondName = "Favreau";
            director_2.Age = 53;
            director_2.ActedMovies.Add(Film_1);
            director_2.ActedMovies.Add(Film_2);
            director_2.DirectedMovies.Add(Film_2);
            director_2.WikiUrl = "https://en.wikipedia.org/wiki/Jon_Favreau";

            Film_2.DirectorsName = (director_2.FirstName + " " + director_2.SecondName);

            // Creating new actor which played in film Film_2
            ActorEntity actor_2 = new ActorEntity();

            // Adding specification of actor_2
            actor_2.FirstName = "Robert";
            actor_2.SecondName = "Downey Jr";
            actor_2.Age = 54;
            actor_2.ActedMovies.Add(Film_1);
            actor_2.ActedMovies.Add(Film_2);
            actor_2.WikiUrl = "https://en.wikipedia.org/wiki/Robert_Downey_Jr.";

            Film_2.Actors.Add(actor_2);

            // Creating new rating of Film_2
            RatingEntity rating_2 = new RatingEntity();

            rating_2.RatingInPercents = 99;
            rating_2.TextRating = "Awesome introduction to Mavrel Cinematic Universe!!!";

            Film_2.Ratings.Add(rating_2);

            // TODO:

            //Film_2.SumOfAllAddedRatings += rating_2.RatingInPercents;
            //Film_2.SumOfAllAddedRatings = Film_2.CalculateOverallRating();

            // ---- Print out ----

            Console.WriteLine("\n ----- Film_1 -----\n");

            TestingMethods.ReadInfo_Film(Film_1);
            TestingMethods.ReadInfo_Actor(actor_1);
            TestingMethods.ReadInfo_Director(director_1);

            Console.WriteLine("\n ----- Film_2 -----\n");

            TestingMethods.ReadInfo_Film(Film_2);
            TestingMethods.ReadInfo_Actor(actor_2);
            TestingMethods.ReadInfo_Director(director_2);

            Console.ReadKey();

        }
    }
}
