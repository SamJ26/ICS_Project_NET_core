
using System;
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

        private sealed class ActorEntityEqualityComparer : IEqualityComparer<ActorEntity>
        {
            public bool Equals(ActorEntity x, ActorEntity y)
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
                       && x.ActedMovies.OrderBy(i => i.Id).SequenceEqual(y.ActedMovies.OrderBy(i => i.Id), FilmActorEntity.FilmActorEntityComparer);
            }

            public int GetHashCode(ActorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.ActedMovies);
            }
        }

        public static IEqualityComparer<ActorEntity> ActorEntityComparer { get; } = new ActorEntityEqualityComparer();

        private sealed class ActorEntityWithoutListEqualityComparer : IEqualityComparer<ActorEntity>
        {
            public bool Equals(ActorEntity x, ActorEntity y)
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

            public int GetHashCode(ActorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath);
            }
        }

        public static IEqualityComparer<ActorEntity> ActorEntityWithoutListComparer { get; } = new ActorEntityWithoutListEqualityComparer();
    }
}
