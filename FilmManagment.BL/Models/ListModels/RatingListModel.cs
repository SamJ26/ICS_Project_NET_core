using System;
using System.Collections.Generic;

namespace FilmManagment.BL.Models.ListModels
{
    public class RatingListModel : ModelBase
    {
        public int RatingInPercents { get; set; }

        private sealed class RatingListModelEqualityComparer : IEqualityComparer<RatingListModel>
        {
	        public bool Equals(RatingListModel x, RatingListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
				return x.RatingInPercents == y.RatingInPercents;
	        }

	        public int GetHashCode(RatingListModel obj)
	        {
		        return HashCode.Combine(obj.RatingInPercents);
	        }
        }

        public static IEqualityComparer<RatingListModel> RatingListModelComparer { get; } = new RatingListModelEqualityComparer();
    }
}
