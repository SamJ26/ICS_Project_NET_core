
using System;
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

        // TODO: resolve relationship between director and actors in Film entity

        public List<FilmEntity> ActedMovies { get; set; } = new List<FilmEntity>();

        private sealed class DirectorEntityEqualityComparer : IEqualityComparer<DirectorEntity>
        {
            public bool Equals(DirectorEntity x, DirectorEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id 
                       && x.FirstName == y.FirstName
                       && x.SecondName == y.SecondName
                       && x.Age == y.Age 
                       && x.WikiUrl == y.WikiUrl
                       && x.PhotoFilePath == y.PhotoFilePath 
                       && Equals(x.DirectedMovies, y.DirectedMovies) 
                       && Equals(x.ActedMovies, y.ActedMovies);
            }

            public int GetHashCode(DirectorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.DirectedMovies, obj.ActedMovies);
            }
        }

        public static IEqualityComparer<DirectorEntity> DirectorEntityComparer { get; } = new DirectorEntityEqualityComparer();

        private sealed class DirectorEntityEqualityComparerWithoutActedMovies : IEqualityComparer<DirectorEntity>
        {
            public bool Equals(DirectorEntity x, DirectorEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id 
                       && x.FirstName == y.FirstName 
                       && x.SecondName == y.SecondName 
                       && x.Age == y.Age 
                       && x.WikiUrl == y.WikiUrl 
                       && x.PhotoFilePath == y.PhotoFilePath 
                       && Equals(x.DirectedMovies, y.DirectedMovies);
            }

            public int GetHashCode(DirectorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.DirectedMovies);
            }
        }

        public static IEqualityComparer<DirectorEntity> DirectorEntityEqualityComparerWithoutActedMoviesComparer { get; } = new DirectorEntityEqualityComparerWithoutActedMovies();
    }
}
