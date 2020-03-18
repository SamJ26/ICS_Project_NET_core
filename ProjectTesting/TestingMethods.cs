
using System;
using FilmManagment.DAL.Entities;

namespace ProjectTesting
{
    /// <summary>
    /// This class contains methods for FilmManagment testing
    /// </summary>
    public class TestingMethods
    {
        /// <summary>
        /// Method for printing out informations about the film
        /// </summary>
        /// <param name="aFilm"> Name of the film which you want to know information about </param>
        public static void ReadInfo_Film(FilmEntity aFilm)
        {
            Console.WriteLine("Originalni nazev filmu: " + aFilm.OriginalName);
            Console.WriteLine("Cesky nazev:            " + aFilm.CzechName);
            Console.WriteLine("Zanr filmu:             " + aFilm.GenreOfFilm);
            Console.WriteLine("Delka filmu:            " + aFilm.LengthInMinutes);
            Console.WriteLine("Reziser filmu:          " + aFilm.Director.FirstName + " " + aFilm.Director.SecondName);
            Console.WriteLine("Popis Filmu:            " + aFilm.Description);
            Console.WriteLine("Pocet recenzi:          " + aFilm.Ratings.Count);
            Console.WriteLine("Prumerne hodnoceni:     " + aFilm.AvarageRatingInPercents);
            int NumA = aFilm.Actors.Count;
            for (int i = 0; i < NumA; i++)
            {
                Console.WriteLine("Herci ve filmu:         " + aFilm.Actors[i].FirstName + " " + aFilm.Actors[i].SecondName);
            }
            int NumR = aFilm.Ratings.Count;
            for (int i = 0; i < NumR; i++)
            {
                Console.WriteLine("Hodnoceni filmu:        " + aFilm.Ratings[i].RatingInPercents + "% - " + aFilm.Ratings[i].TextRating);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method for printing out informations about the director
        /// </summary>
        /// <param name="aDirector"> Name of the director which you want to know information about </param>
        public static void ReadInfo_Director(DirectorEntity aDirector)
        {
            Console.WriteLine("Jmeno rezisera:              " + aDirector.FirstName + " " + aDirector.SecondName);
            Console.WriteLine("Vek rezisera:                " + aDirector.Age);
            Console.WriteLine("Odkaz na zivotopis rezisera: " + aDirector.WikiUrl);
            int DMovies = aDirector.DirectedMovies.Count;
            for (int i = 0; i < DMovies; i++)
            {
                Console.WriteLine("Reziroval film:              " + aDirector.DirectedMovies[i].CzechName);
            }
            int AMovies = aDirector.ActedMovies.Count;
            for (int i = 0; i < AMovies; i++)
            {
                Console.WriteLine("Hral ve filmu:               " + aDirector.ActedMovies[i].CzechName);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method for printing out informations about the actor
        /// </summary>
        /// <param name="aActor">  Name of the actor which you want to know information about </param>
        public static void ReadInfo_Actor(ActorEntity aActor)
        {
            Console.WriteLine("Jmeno herce:                 " + aActor.FirstName + " " + aActor.SecondName);
            Console.WriteLine("Vek herce:                   " + aActor.Age);
            Console.WriteLine("Odkaz na zivotopis rezisera: " + aActor.WikiUrl);
            int AMovies = aActor.ActedMovies.Count;
            for (int i = 0; i < AMovies; i++)
            {
                Console.WriteLine("Hral ve filmu:               " + aActor.ActedMovies[i].CzechName);
            }
            Console.WriteLine();
        }
    }
}
