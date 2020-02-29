using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class Director : Person
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
