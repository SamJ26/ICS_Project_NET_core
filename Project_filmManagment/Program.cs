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
            Film_1.DirectorsName = "Alfonz Hlina";

            // TODO: Adding actors to Film_1
            // TOOD: Add rating to Film_1

            Console.ReadKey();

        }
    }
}
