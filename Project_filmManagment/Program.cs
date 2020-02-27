using System;

namespace Project_filmManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a new film called Film_1
            Film Film_1 = new Film();

            // Adding specification of the film
            Film_1.CountryOfOrigin = "Hungary";
            Film_1.CzechName = "Dva Kone a Pes";
            Film_1.OriginalName = "Two Horses and Dog";
            Film_1.GenreOfFilm = Genre.ComedyFilm;
            Film_1.LengthInMinutes = 95;
            Film_1.Description = "Uzasny film plny konov a psov";

            // Creating a new film called Film_1
            Film Film_2 = new Film();

            // Adding specification of the film
            Film_2.CountryOfOrigin = "USA";
            Film_2.CzechName = "Zelezny muz";
            Film_2.OriginalName = "Iron Mane";
            Film_2.GenreOfFilm = Genre.ActionFilm;
            Film_2.LengthInMinutes = 123;
            Film_2.Description = "Genialni film o Marvel Superhrdinovi";

            // Creating a new film called Director
            Director director_1 = new Director();

            // Adding specification of the Director
            director_1.FirstName = "Jon";
            director_1.SecondName = "Mayer";
            director_1.Age = 43;
            director_1.ActedMovies.Add("Dva Kone a Pes");
            director_1.DirectedMovies.Add("Tri kone a pes");
            director_1.UrlWiki = "Wikipedia";

            // Creating a new film called Director
            Director director_2 = new Director();

            // Adding specification of the Director
            director_2.FirstName = "Jon";
            director_2.SecondName = "Favreau";
            director_2.Age = 53;
            director_2.ActedMovies.Add("Iron Man");
            director_2.ActedMovies.Add("Iron Man 2");
            director_2.DirectedMovies.Add("Iron Man");
            director_2.UrlWiki = "https://en.wikipedia.org/wiki/Jon_Favreau";

            Film_2.DirectorsName = (director_2.FirstName + " " + director_2.SecondName);

            Actor actor_2 = new Actor();

            // Adding specification of the Actor
            actor_2.FirstName = "Robert";
            actor_2.SecondName = "Downey Jr";
            actor_2.Age = 54;
            actor_2.ActedMovies.Add("Iron Man");
            actor_2.ActedMovies.Add("Iron Man 2");
            actor_2.ActedMovies.Add("Iron Man 3");
            actor_2.UrlWiki = "https://en.wikipedia.org/wiki/Robert_Downey_Jr.";

            Film_2.Actors.Add(actor_2);

            Actor actor_1 = new Actor();

            // Adding specification of the Actor
            actor_1.FirstName = "Jon";
            actor_1.SecondName = "Mayer";
            actor_1.Age = 43;
            actor_1.ActedMovies.Add("Dva Kone a Pes");
            actor_1.UrlWiki = "Wikipedia";

            Film_1.Actors.Add(actor_1);

            Rating rating_1 = new Rating();
            rating_1.RatingInPercents = 58;
            rating_1.TextRating = "Prumerny film";

            Film_1.Ratings.Add(rating_1);

            Rating rating_2 = new Rating();
            rating_2.RatingInPercents = 99;
            rating_2.TextRating = "Awesome introduction to Mavrel Cinematic Universe!!!!!!!!!!!!!!!!!!!!!!";
            Film_2.Ratings.Add(rating_2);

            Film_1.ReadInfo();
            Console.WriteLine(" ");
            director_1.ReadInfo();
            Console.WriteLine(" ");
            actor_1.ReadInfo();
            Console.WriteLine();
            Console.WriteLine("Dalsi film");
            Console.WriteLine();
            Film_2.ReadInfo();
            Console.WriteLine();
            director_2.ReadInfo();
            Console.WriteLine();
            actor_2.ReadInfo();

            Console.ReadKey();

        }
    }
}
