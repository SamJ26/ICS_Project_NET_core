using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    internal class Director : Person
    {
        // Private fields
        string urlWiki;

        // TODO: Add photography

        // Auto properties
        public List<string> DirectedMovies { get; set; }
        public List<string> ActedMovies { get; set; }

        // Default constructor
        // Changes defualt value in urlWiki from null to string.Empty and creates new lists
        public Director()
        {
            urlWiki = string.Empty;
            DirectedMovies = new List<string>();
            ActedMovies = new List<string>();
        }

        public void ReadInfo()
        {
            Console.WriteLine("Jmeno rezisera :"+FirstName+" "+SecondName);
            Console.WriteLine("Vek rezisera: "+Age);
            Console.WriteLine("Odkaz na zivotopis rezisera: " + UrlWiki);
            int DMovies = DirectedMovies.Count;
            for (int i = 0; i < DMovies; i++)
            {
                Console.WriteLine("Reziroval film: "+DirectedMovies[i]);
            }
            int AMovies = ActedMovies.Count;
            if (AMovies>0)
            {
                for (int i = 0; i < AMovies; i++)
                {
                    Console.WriteLine("Hral ve filmu: "+ActedMovies[i]);
                }
            } else { 
                Console.WriteLine("Nehral v zadnom filme");
            }
        }

        #region Properties

        public string UrlWiki
        {
            get => urlWiki;
            set => urlWiki = value;
        }

        #endregion

    }
}
