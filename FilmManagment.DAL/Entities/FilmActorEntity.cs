using System;
using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class works as transition table for many-to-many relationship between FilmEntity and ActorEntity
    /// </summary>
    public class FilmActorEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public FilmEntity Film { get; set; }
        public ActorEntity Actor { get; set; }

        private sealed class FilmActorEntityEqualityComparer : IEqualityComparer<FilmActorEntity>
        {
            public bool Equals(FilmActorEntity x, FilmActorEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id
                       && ActorEntity.ActorEntityWithoutListComparer.Equals(x.Actor, y.Actor)
                       && FilmEntity.FilmEntityWithoutAllListsComparer.Equals(x.Film, y.Film);
            }

            public int GetHashCode(FilmActorEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.Film, obj.Actor);
            }
        }

        public static IEqualityComparer<FilmActorEntity> FilmActorEntityComparer { get; } = new FilmActorEntityEqualityComparer();
    }
}
