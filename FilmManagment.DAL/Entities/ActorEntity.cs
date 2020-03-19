
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added actor
    /// </summary>
    public class ActorEntity : Person
    {
        public string WikiUrl { get; set; } = string.Empty;
        public string PhotoFilePath { get; set; } = string.Empty;

        public List<FilmActorEntity> ActedMovies { get; set; } = new List<FilmActorEntity>();

        // TODO: add EC
    }
}
