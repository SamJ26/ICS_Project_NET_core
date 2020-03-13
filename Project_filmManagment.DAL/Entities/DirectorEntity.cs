
using System.Collections.Generic;

namespace Project_filmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class DirectorEntity : Person
    {
        // Auto properties
        public string UrlWiki { get; set; }
        public string Photo_filePath { get; set; }

        public List<FilmEntity> DirectedMovies { get; set; }
        public List<FilmEntity> ActedMovies { get; set; }

        // Default constructor
        // Changes defualt value in UrlWiki from null to string.Empty and creates new lists
        public DirectorEntity()
        {
            UrlWiki = string.Empty;
            Photo_filePath = string.Empty;
            DirectedMovies = new List<FilmEntity>();
            ActedMovies = new List<FilmEntity>();
        }
    }
}
