using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class works as transition table for many-to-many relationship between FilmEntity and DirectorEntity
    /// </summary>
    public class FilmDirectorEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }

        public FilmEntity Film { get; set; }
        public DirectorEntity Director { get; set; }

        private sealed class FilmDirectorEntityEqualityComparer : IEqualityComparer<FilmDirectorEntity>
        {
            public bool Equals(FilmDirectorEntity x, FilmDirectorEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id
                       && x.FilmId.Equals(y.FilmId) 
                       && x.DirectorId.Equals(y.DirectorId) 
                       && Equals(x.Film, y.Film) 
                       && Equals(x.Director, y.Director);
            }

            public int GetHashCode(FilmDirectorEntity obj)
            {
                return HashCode.Combine(obj.Id ,obj.FilmId, obj.DirectorId, obj.Film, obj.Director);
            }
        }

        public static IEqualityComparer<FilmDirectorEntity> FilmDirectorEntityComparer { get; } = new FilmDirectorEntityEqualityComparer();
    }
}
