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
        // Auto properties
        public string UrlWiki { get; set; }
        public List<string> DirectedMovies { get; set; }
        public List<string> ActedMovies { get; set; }

        // TODO: Add photography


        // Default constructor
        // Changes defualt value in UrlWiki from null to string.Empty and creates new lists
        public Director()
        {
            UrlWiki = string.Empty;
            DirectedMovies = new List<string>();
            ActedMovies = new List<string>();
        }
    }
}
