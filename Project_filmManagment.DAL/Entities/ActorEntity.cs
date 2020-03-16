
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added actor
    /// </summary>
    public class ActorEntity : Person
    {  
        // Auto properties
        public string UrlWiki { get; set; }  
        public string Photo_filePath { get; set; }

        public List<FilmEntity> ActedMovies { get; set; }

        // Default constructor
        // Changes default value null in urlWiki to string.Empty and creates new List
        public ActorEntity()
        {
            UrlWiki = string.Empty;
            Photo_filePath = string.Empty;
            ActedMovies = new List<FilmEntity>();
        }

        // Class which contains methods for testing of ActorEntity in database
        private sealed class ActorEqualityComparer : IEqualityComparer<ActorEntity>
        {
            public bool Equals(ActorEntity x, ActorEntity y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Id.Equals(y.Id) &&
                       string.Equals(x.FirstName, y.FirstName) &&
                       string.Equals(x.SecondName, y.SecondName) &&
                       x.Age.Equals(y.Age) &&
<<<<<<< Updated upstream:Project_filmManagment.DAL/Entities/ActorEntity.cs
                       string.Equals(x.UrlWiki, y.UrlWiki) &&
                       string.Equals(x.Photo_filePath, y.Photo_filePath) &&
                       x.ActedMovies.SequenceEqual(y.ActedMovies);
=======
                       string.Equals(x.WikiUrl, y.WikiUrl) &&
                       string.Equals(x.PhotoFilePath, y.PhotoFilePath) &&
                       x.ActedMovies.OrderBy(film => film.Id).SequenceEqual(y.ActedMovies.OrderBy(film => film.Id));            // TODO: consultation with teacher
>>>>>>> Stashed changes:FilmManagment.DAL/Entities/ActorEntity.cs
            }   

            public int GetHashCode(ActorEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.SecondName != null ? obj.SecondName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Age.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.UrlWiki != null ? obj.UrlWiki.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Photo_filePath != null ? obj.Photo_filePath.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ActedMovies != null ? obj.ActedMovies.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        // Property which is used to approach methods for testing in class ActorEqualityComparer
        public static IEqualityComparer<ActorEntity> Actor_EqualityComparer { get; } = new ActorEqualityComparer();
    }
}
