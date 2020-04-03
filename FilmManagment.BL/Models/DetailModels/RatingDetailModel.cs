using System;
using System.Collections.Generic;
using FilmManagment.BL.Models.ListModels;

namespace FilmManagment.BL.Models.DetailModels
{
    public class RatingDetailModel : ModelBase
    {
        public int RatingInPercents { get; set; }
        public string TextRating { get; set; } = string.Empty;

		public Guid FilmId { get; set; }

        private sealed class RatingDetailModelEqualityComparer : IEqualityComparer<RatingDetailModel>
        {
	        public bool Equals(RatingDetailModel x, RatingDetailModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.RatingInPercents == y.RatingInPercents
					   && x.TextRating == y.TextRating
					   && x.FilmId == y.FilmId;
	        }

	        public int GetHashCode(RatingDetailModel obj)
	        {
		        return HashCode.Combine(obj.RatingInPercents, obj.TextRating, obj.FilmId);
	        }
        }

        public static IEqualityComparer<RatingDetailModel> RatingDetailModelComparer { get; } = new RatingDetailModelEqualityComparer();
    }
}
