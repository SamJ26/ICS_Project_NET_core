
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

        public List<FilmEntity> DirectedMovies { get; set; } = new List<FilmEntity>();
        public List<FilmEntity> ActedMovies { get; set; } = new List<FilmEntity>();

        private sealed class DirectorsEqualityComparer : IEqualityComparer<DirectorEntity>
        {
            public bool Equals(DirectorEntity x, DirectorEntity y)
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
                       x.DirectedMovies.OrderBy(film => film.Id).SequenceEqual(y.DirectedMovies.OrderBy(film => film.Id)) &&        // TODO: consultation with teacher
                       x.ActedMovies.OrderBy(film => film.Id).SequenceEqual(y.ActedMovies.OrderBy(film => film.Id));                // TODO: consultation with teacher
            }

            public int GetHashCode(DirectorEntity obj)
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
                    hashCode = (hashCode * 397) ^ (obj.DirectedMovies != null ? obj.DirectedMovies.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<DirectorEntity> DirectorEqualityComparer { get; } = new DirectorsEqualityComparer();
    }
}
