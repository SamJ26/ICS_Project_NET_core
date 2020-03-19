
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class DirectorEntity : Person
    {
        public string WikiUrl { get; set; } = string.Empty;
        public string PhotoFilePath { get; set; } = string.Empty;

        public List<FilmDirectorEntity> DirectedMovies { get; set; } = new List<FilmDirectorEntity>();

        // TODO: resolve realtionship between director and actors in Film entity

        public List<FilmEntity> ActedMovies { get; set; } = new List<FilmEntity>();

        // TODO: add EC
    }
}
