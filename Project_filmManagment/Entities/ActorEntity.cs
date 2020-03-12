using System;
using System.Collections.Generic;

namespace Project_filmManagment.Entities
{
    /// <summary>
    /// This class contains information about added actor
    /// </summary>
    public class ActorEntity : Person
    {  
        // Auto properties
        public string UrlWiki { get; set; }  
        public string Photo_filePath { get; set; }

        // Type is string and not Film beacuse we don't want to create and specify new Film every time we add some to this list
        public List<string> ActedMovies { get; set; }

        // Default constructor
        // Changes default value null in urlWiki to string.Empty and creates new List
        public ActorEntity()
        {
            UrlWiki = string.Empty;
            Photo_filePath = string.Empty;
            ActedMovies = new List<string>();
        }
    }
}
