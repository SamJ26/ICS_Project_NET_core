using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains informations about added director
    /// </summary>
    public class DirectorEntity : PersonBase
    {
        public string WikiUrl { get; set; } = string.Empty;
        public string PhotoFilePath { get; set; } = string.Empty;

        public ICollection<FilmDirectorEntity> DirectedMovies { get; set; } = new List<FilmDirectorEntity>();

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
	                   && x.DirectedMovies.OrderBy(i => i.Id).SequenceEqual(y.DirectedMovies.OrderBy(i => i.Id), FilmDirectorEntity.FilmDirectorEntityComparer);
            }

            public int GetHashCode(DirectorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.DirectedMovies);
            }
        }

        public static IEqualityComparer<DirectorEntity> DirectorEntityComparer { get; } = new DirectorEntityEqualityComparer();

        private sealed class DirectorEntityEqualityComparerWithoutList : IEqualityComparer<DirectorEntity>
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
                       && x.PhotoFilePath == y.PhotoFilePath;
            }

            public int GetHashCode(DirectorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath);
            }
        }

        public static IEqualityComparer<DirectorEntity> DirectorEntityWithoutListComparer { get; } = new DirectorEntityEqualityComparerWithoutList();
    }
}
