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
            Film_1.Director = "Alfonz Hlina";

            // Adding actors to Film_1
            Film_1.Actors = "Actor_1";
            Film_1.Actors = "Actor_2";
            Film_1.Actors = "Actor_3";

            // Adding rating of the film
            Ratings Film_1_rating = new Ratings();
            Film_1.Rating = Film_1_rating;
            Film_1_rating.RatingInPercents = 80;
            Film_1_rating.TextRating = "It was really amazing film";
            Film_1.NumberOfRatings++;
            Film_1.SumOfAllAddedRatings += Film_1_rating.RatingInPercents;
            Film_1.OverallRatingInPercents = Film_1.CalculateOverallRating();

            // Creating new object ( person ) for director "Alfonz Hlina"
            Person Director_AlfonzHlina = new Person();
            Director_AlfonzHlina.PersonsJob = TypeOfPerson.Director;
            Director_AlfonzHlina.FirstName = "Alfonz";
            Director_AlfonzHlina.SecondName = "Hlina";
            Director_AlfonzHlina.Age = 40;
            Director_AlfonzHlina.MoviesAsActor = "Nejaky nazov filmu";
            Director_AlfonzHlina.MoviesAsActor = "Nejaky druhy nazov filmu";
            Director_AlfonzHlina.MoviesAsDirector = Film_1.CzechName;
            Director_AlfonzHlina.MoviesAsDirector = "Nejaky dalsi film ktory reziroval";

            // Testing printout of actors, which played in Film_1:
            Film_1.ReadActersOfFilm();
            Console.ReadKey();

            // CONTINUE: write a class GraphicInterface ( maybe ?? ) which will contain two arrays and functions for working with them
            // TODO: need to be used array to store all films together or it will be managed via database

        }
    }
}
