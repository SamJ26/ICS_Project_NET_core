
using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class DirectorEntity : Person
    {
        public string WikiUrl { get; set; } = string.Empty;
        public string PhotoFilePath { get; set; } = string.Empty;

        public List<FilmEntity> DirectedMovies { get; set; } = new List<FilmEntity>();
        public List<FilmEntity> ActedMovies { get; set; } = new List<FilmEntity>();
    }
}
