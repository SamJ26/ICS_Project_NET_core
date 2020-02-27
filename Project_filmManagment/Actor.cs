using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains information about added actor
    /// </summary>
    internal class Actor : Person
    {
        // Private fields of the class
        string urlWiki;

        // TODO: Add photography

        // Auto property
        // Type is string and not Film beacuse we don't want to create new Film every time we add some to this list
        public List<string> ActedMovies { get; set; }

        // Default constructor
        // Changes default value null in urlWiki to string.Empty and creates new List
        public Actor()
        {
            urlWiki = string.Empty;
            ActedMovies = new List<string>();
        }

        public void ReadInfo()
        {
            Console.WriteLine("Jmeno herce :" + FirstName + " " + SecondName);
            Console.WriteLine("Vek herce: " + Age);
            Console.WriteLine("Odkaz na zivotopis rezisera: " + UrlWiki);
            int AMovies = ActedMovies.Count;
            if (AMovies > 0)
            {
                for (int i = 0; i < AMovies; i++)
                {
                    Console.WriteLine("Hral ve filmu: " + ActedMovies[i]);
                }
            }
            else
            {
                Console.WriteLine("Nehral v zadnom filme");
            }
        }

        #region Properties

        // Methods for getting and setting the value of variable urlWiki
        public string UrlWiki
        {
            get => urlWiki;
            set => urlWiki = value;
        }

        #endregion

    }
}
