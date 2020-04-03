using System;
using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains user's rating of one film.
    /// </summary>
    public class RatingEntity : EntityBase
    {
        public int RatingInPercents { get; set; } = 0;
        public string TextRating { get; set; } = string.Empty;

        public Guid FilmId { get; set; }
        public FilmEntity Film { get; set; }

        private sealed class RatingEntityEqualityComparer : IEqualityComparer<RatingEntity>
        {
            public bool Equals(RatingEntity x, RatingEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id 
                       && x.FilmId == y.FilmId
                       && x.RatingInPercents == y.RatingInPercents
                       && FilmEntity.FilmEntityWithoutRatingComparer.Equals(x.Film,y.Film)
                       && x.TextRating == y.TextRating;
            }

            public int GetHashCode(RatingEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FilmId, obj.Film, obj.RatingInPercents, obj.TextRating);
            }
        }

        public static IEqualityComparer<RatingEntity> RatingEntityComparer { get; } = new RatingEntityEqualityComparer();
    }
}

