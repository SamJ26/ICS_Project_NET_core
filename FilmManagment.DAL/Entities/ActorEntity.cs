
using System.Collections.Generic;
using System.Linq;

namespace Project_filmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains information about added actor
    /// </summary>
    public class ActorEntity : Person
    {
        public string WikiUrl { get; set; } = string.Empty;
        public string PhotoFilePath { get; set; } = string.Empty;

        public List<FilmEntity> ActedMovies { get; set; } = new List<FilmEntity>();

        // Class which contains methods for testing of ActorEntity in database
        private sealed class ActorsEqualityComparer : IEqualityComparer<ActorEntity>
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
                       string.Equals(x.WikiUrl, y.WikiUrl) &&
                       string.Equals(x.PhotoFilePath, y.PhotoFilePath) &&
                       x.ActedMovies.SequenceEqual(y.ActedMovies);
            }   

            public int GetHashCode(ActorEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.SecondName != null ? obj.SecondName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Age.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.WikiUrl != null ? obj.WikiUrl.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.PhotoFilePath != null ? obj.PhotoFilePath.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ActedMovies != null ? obj.ActedMovies.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        // Property which is used to approach methods for testing in class ActorEqualityComparer
        public static IEqualityComparer<ActorEntity> ActorEqualityComparer { get; } = new ActorsEqualityComparer();
    }
}
