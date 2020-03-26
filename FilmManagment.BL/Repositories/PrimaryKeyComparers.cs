using FilmManagment.DAL.Entities;
using System.Collections.Generic;
using System;

namespace FilmManagment.BL.Repositories
{
    public static class PrimaryKeyComparers
    {
        public static IEqualityComparer<IEntityBase> IdComparer { get; } = new IdEqualityComparer<Guid>();

        private sealed class IdEqualityComparer<TKey> : IEqualityComparer<IEntityBase>
        {
            public bool Equals(IEntityBase x, IEntityBase y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (ReferenceEquals(x, null)) return false;

                if (ReferenceEquals(y, null)) return false;

                if (x.GetType() != y.GetType()) return false;

                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(IEntityBase obj) => obj.Id.GetHashCode();
        }
    }
}
