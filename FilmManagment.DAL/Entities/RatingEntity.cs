
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

        private sealed class RatingsEqualityComparer : IEqualityComparer<RatingEntity>
        {
            public bool Equals(RatingEntity x, RatingEntity y)
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
                       x.RatingInPercents.Equals(y.RatingInPercents) &&
                       string.Equals(x.TextRating, y.TextRating); 
                }

            public int GetHashCode(RatingEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.RatingInPercents.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.TextRating != null ? obj.TextRating.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<RatingEntity> RatingEqualityComparer { get; } = new RatingsEqualityComparer();
    }
}

