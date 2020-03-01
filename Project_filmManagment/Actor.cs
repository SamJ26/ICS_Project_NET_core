using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains information about added actor
    /// </summary>
    public class Actor : Person
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
