using System;
using System.Collections.Generic;

namespace Project_filmManagment.Entities
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class DirectorEntity : Person
    {
        // Auto properties
        public string UrlWiki { get; set; }
        public string Photo_filePath { get; set; }

        // Type is string and not Film beacuse we don't want to create and specify new Film every time we add some to this list
        public List<string> DirectedMovies { get; set; }
        public List<string> ActedMovies { get; set; }

        // Default constructor
        // Changes defualt value in UrlWiki from null to string.Empty and creates new lists
        public DirectorEntity()
        {
            UrlWiki = string.Empty;
            Photo_filePath = string.Empty;
            DirectedMovies = new List<string>();
            ActedMovies = new List<string>();
        }
    }
}
